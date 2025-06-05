using SmartPoint.AssetAssistant;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;

namespace Dpr.Battle.View
{
	[RequireComponent(typeof(Camera))]
	public sealed class BattleMultipleCameraCompositor : MonoBehaviour, IViewportChangeHandler, IEventSystemHandler
	{
		private const CameraEvent FIELD_DEPTH_COMMAND_BUFFER_EVENT = CameraEvent.BeforeForwardAlpha;
		private const CameraEvent RESOLVE_COLOR_COMMAND_BUFFER_EVENT = CameraEvent.BeforeForwardOpaque;
		private const CameraEvent RESOLVE_DEPTH_COMMAND_BUFFER_EVENT = CameraEvent.BeforeForwardAlpha;

        [SerializeField]
		private Camera _camera;
		[SerializeField]
		private Camera _mainCamera;
		[SerializeField]
		private Camera[] _layerCameras;

		private RenderTexture _colorBufferTexture;
		private RenderTexture _depthBufferTexture;
		private RenderTexture _copyDepthBufferTexture;
		private CommandBuffer _fieldDepthBuffer;
		private CommandBuffer _resolveColorCB;
		private CommandBuffer _resolveDepthCB;
		
		public RenderTexture ColorBufferRT { get => _colorBufferTexture; }
		public RenderTexture DepthBufferRT { get => _depthBufferTexture; }
		public RenderTexture CopyDepthBufferRT { get => _copyDepthBufferTexture; }
		
		// TODO
		public Camera GetLayerCamera(CameraIndex index) { return default; }
		
		// TODO
		public void OnViewportChange(int screenWidth, int screenHeight) { }
		
		// TODO
		private void OnEnable() { }
		
		// TODO
		private void OnDisable() { }
		
		// TODO
		private void OnReset() { }
		
		// TODO
		public void OnLateUpdate(float deltaTime) { }
		
		// TODO
		public void AddLayerCamera(Camera layerCamera) { }

		public enum CameraIndex : int
		{
			ScreenEffect = 0,
			CharaEffect = 1,
			Depth = 2,
		}
	}
}