using SmartPoint.AssetAssistant;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;

[RequireComponent(typeof(Camera))]
public class MultipleCameraCompositor : MonoBehaviour, IViewportChangeHandler, IEventSystemHandler
{
	public static readonly int OPAQUE_DEPTHTEX_ID = Shader.PropertyToID("_OpaqueDepthTexture");
	public static readonly int GLOBAL_DEPTHTEX_ID = Shader.PropertyToID("_GlobalDepthTexture");

    [SerializeField]
	private Camera _mainCamera;
	[SerializeField]
	private Camera[] _layerCameras;
	private Camera _camera;
	private RenderTexture _colorBufferTexture;
	private RenderTexture _depthBufferTexture;
	private CommandBuffer _resolveColorCB;
	private CommandBuffer _resolveDepthCB;
	
	// TODO
	public void OnViewportChange(int width, int height) { }
	
	// TODO
	public RenderTexture colorBufferTexture { get; }
	
	// TODO
	public RenderTexture depthBufferTexture { get; }
	
	// TODO
	private void OnEnable() { }
	
	// TODO
	private void OnReset() { }
	
	// TODO
	private void OnDisable() { }
	
	// TODO
	private void OnUpdate(float deltaTime) { }
	
	// TODO
	public void AddLayerCamera(Camera layerCamera) { }
}