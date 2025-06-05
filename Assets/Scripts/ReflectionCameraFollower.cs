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
	
	// TODO
	private void OnEnable() { }
	
	// TODO
	private void OnDisable() { }
	
	// TODO
	private void LateUpdate() { }
	
	// TODO
	public void SetCustomResolution(int width, int height) { }
}