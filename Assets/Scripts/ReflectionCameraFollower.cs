using UnityEngine;

[RequireComponent(typeof(Camera))]
public class ReflectionCameraFollower : MonoBehaviour
{
	[SerializeField]
	private Camera _target;
	[SerializeField]
	private float _fovScale = 1.5f;

	private Camera _camera;
	private Transform _targetTransform;
	private Transform _cameraTransform;
	private int _ReflectionTexID;
	private int _ReflectionVP;
	private RenderTexture _targetTexture;
	private int customWidth;
	private int customHeight;
	
	private void OnEnable()
	{
		if (Screen.width == 0 || Screen.height == 0)
			return;

		if (_camera == null)
			_camera = GetComponent<Camera>();

		// Done twice
		_cameraTransform = _camera.transform;
		_cameraTransform = _camera.transform;

		if (_targetTexture == null)
		{
			_targetTexture = new RenderTexture(Screen.width, Screen.height, 24, RenderTextureFormat.ARGB32, 6);
			_targetTexture.useMipMap = true;
			_targetTexture.autoGenerateMips = true;
        }
		
		_camera.targetTexture = _targetTexture;

		_ReflectionTexID = Shader.PropertyToID("_ReflectionTex");
		_ReflectionVP = Shader.PropertyToID("_ReflectionVP");

		Shader.SetGlobalTexture(_ReflectionTexID, _camera.targetTexture);
	}
	
	private void OnDisable()
	{
		if (_camera != null)
			_camera.targetTexture = null;

		if (_targetTexture != null)
			DestroyImmediate(_targetTexture);
	}
	
	private void LateUpdate()
	{
		if (_target == null)
			return;

		if (_ReflectionTexID == 0)
			return;

		if (_targetTransform == null)
			_targetTransform = _target.transform;

		if (_camera == null)
		{
            _camera = GetComponent<Camera>();
            _cameraTransform = _camera.transform;
        }

		if (_camera.targetTexture != null)
		{
			var pos = _targetTransform.position;
			var euler = _targetTransform.rotation.eulerAngles;

			pos.y = -pos.y;
			_cameraTransform.position = pos;

			euler.x = -euler.x;
			euler.z = -euler.z;
			_cameraTransform.rotation = Quaternion.Euler(euler);

			_camera.fieldOfView = _target.fieldOfView * _fovScale;

			var worldMatrix = _camera.worldToCameraMatrix;
			var projMatrix = GL.GetGPUProjectionMatrix(_camera.projectionMatrix, false);
			Shader.SetGlobalMatrix(_ReflectionVP, projMatrix * worldMatrix);

			if (_targetTexture != null)
			{
				var width = customWidth < 1 ? Screen.width : customWidth;
				var height = customHeight < 1 ? Screen.height : customHeight;

				if (width != _targetTexture.width || height != _targetTexture.height)
				{
					_camera.targetTexture = null;
					DestroyImmediate(_targetTexture);

					_targetTexture = new RenderTexture(width, height, 24, RenderTextureFormat.ARGB32, 6);
                    _targetTexture.useMipMap = true;
                    _targetTexture.autoGenerateMips = true;

                    _camera.targetTexture = _targetTexture;
                }
			}

			Shader.SetGlobalTexture(_ReflectionTexID, _camera.targetTexture);
		}
	}
	
	public void SetCustomResolution(int width, int height)
	{
		customWidth = width;
		customHeight = height;
	}
}