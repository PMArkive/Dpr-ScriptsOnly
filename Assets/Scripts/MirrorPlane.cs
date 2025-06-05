using System.Collections;
using UnityEngine;

[ExecuteInEditMode]
public class MirrorPlane : MonoBehaviour
{
	[SerializeField]
	private string _texturePropertyName = "_MirrorMap";
	[SerializeField]
	private int _textureSize = 0x200;
	[SerializeField]
	private float _clipPlaneDistance = 0.001f;
	[SerializeField]
	private float _planeHeightOffset;
	[SerializeField]
	private LayerMask _targetLayers = -1;
	private Hashtable _cameraTable = new Hashtable();
	private RenderTexture _renderTexture;
	private static bool _renderingLock;
	private MaterialPropertyBlock _propertyBlock;
	private int _texturePropertyID;
	private Renderer _renderer;
	private Transform _transform;
	
	public LayerMask targetLayers { get => _targetLayers; set => _targetLayers = value; }
	
	// TODO
	private void OnEnable() { }
	
	// TODO
	private void OnDisable() { }
	
	// TODO
	public void OnWillRenderObject() { }
	
	// TODO
	private void UpdateCameraModes(Camera src, Camera dest) { }
	
	// TODO
	private void CreateMirrorObjects(Camera currentCamera, out Camera reflectionCamera)
	{
		reflectionCamera = null;
	}
	
	// TODO
	private Vector4 CalculateClipPlane(Camera reflectionCamera, Vector3 planePoint, Vector3 planeNormal) { return default; }
}