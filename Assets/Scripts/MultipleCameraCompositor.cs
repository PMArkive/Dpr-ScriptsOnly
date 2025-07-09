using SmartPoint.AssetAssistant;
using System.Linq;
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
	
	public void OnViewportChange(int width, int height)
	{
        OnReset();
    }
	
	public RenderTexture colorBufferTexture { get => _colorBufferTexture; }
	public RenderTexture depthBufferTexture { get => _depthBufferTexture; }
	
	private void OnEnable()
	{
		OnReset();
    }
	
	private void OnReset()
	{
        OnDisable();

        if (_mainCamera == null)
            return;

        var screenWidth = Sequencer.screenWidth;
        var screenHeight = Sequencer.screenHeight;

        _camera = GetComponent<Camera>();

        _colorBufferTexture = new RenderTexture(screenWidth, screenHeight, 0, RenderTextureFormat.RGB111110Float);
        _colorBufferTexture.Create();

        _depthBufferTexture = new RenderTexture(screenWidth, screenHeight, 24, RenderTextureFormat.Depth);
        _depthBufferTexture.Create();

        _mainCamera.SetTargetBuffers(_colorBufferTexture.colorBuffer, _depthBufferTexture.depthBuffer);

        for (int i=0; i<_layerCameras.Length; i++)
        {
            var camera = _layerCameras[i];
            if (camera != null)
            {
                camera.clearFlags = CameraClearFlags.Nothing;
                camera.SetTargetBuffers(_colorBufferTexture.colorBuffer, _depthBufferTexture.depthBuffer);
            }
        }

        _resolveColorCB = new CommandBuffer();
        _resolveColorCB.name = "Resolve ColorBuffer";
        _resolveColorCB.SetGlobalTexture(GLOBAL_DEPTHTEX_ID, _depthBufferTexture);
        _resolveColorCB.Blit(_colorBufferTexture, BuiltinRenderTextureType.CameraTarget);
        _camera.AddCommandBuffer(CameraEvent.BeforeForwardOpaque, _resolveColorCB);

        _resolveDepthCB = new CommandBuffer();
        _resolveDepthCB.name = "Resolve DepthBuffer";
        _resolveDepthCB.SetGlobalTexture(OPAQUE_DEPTHTEX_ID, BuiltinRenderTextureType.Depth);
        _camera.AddCommandBuffer(CameraEvent.AfterForwardOpaque, _resolveDepthCB);

        Sequencer.update += OnUpdate;
    }
	
	private void OnDisable()
    {
        Sequencer.update -= OnUpdate;

        if (_colorBufferTexture != null)
        {
            Destroy(_colorBufferTexture);
            Destroy(_depthBufferTexture);
        }

        if (_mainCamera != null)
        {
            _mainCamera.SetTargetBuffers(Graphics.activeColorBuffer, Graphics.activeDepthBuffer);

            for (int i=0; i<_layerCameras.Length; i++)
            {
                var camera = _layerCameras[i];
                if (camera != null)
                    camera.SetTargetBuffers(Graphics.activeColorBuffer, Graphics.activeDepthBuffer);
            }

            if (_resolveColorCB != null)
            {
                _camera.RemoveCommandBuffer(CameraEvent.BeforeForwardOpaque, _resolveColorCB);
                _resolveColorCB.Clear();
                _resolveColorCB = null;
            }

            if (_resolveDepthCB != null)
            {
                _camera.RemoveCommandBuffer(CameraEvent.AfterForwardOpaque, _resolveDepthCB);
                _resolveDepthCB.Clear();
                _resolveDepthCB = null;
            }
        }
    }
	
	private void OnUpdate(float deltaTime)
    {
        var nearClipPlane = _mainCamera.nearClipPlane;
        var farClipPlane = _mainCamera.farClipPlane;
        var fieldOfView = _mainCamera.fieldOfView;

        _camera.nearClipPlane = nearClipPlane;
        _camera.farClipPlane = farClipPlane;
        _camera.fieldOfView = fieldOfView;

        for (int i=0; i<_layerCameras.Length; i++)
        {
            var camera = _layerCameras[i];
            if (camera != null)
            {
                camera.nearClipPlane = nearClipPlane;
                camera.farClipPlane = farClipPlane;
                camera.fieldOfView = fieldOfView;
            }
        }
    }
	
	public void AddLayerCamera(Camera layerCamera)
    {
        if (_layerCameras.FirstOrDefault(x => x == layerCamera) != null)
            return;

        var list = _layerCameras.ToList();
        list.Add(layerCamera);
        _layerCameras = list.ToArray();

        layerCamera.clearFlags = CameraClearFlags.Nothing;
        layerCamera.SetTargetBuffers(_colorBufferTexture.colorBuffer, _depthBufferTexture.depthBuffer);
    }
}