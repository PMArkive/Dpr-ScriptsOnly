using UnityEngine;
using UnityEngine.Rendering;

namespace Dpr.UI
{
    public class ModelViewBgCamera : MonoBehaviour
    {
        [SerializeField]
        private Camera _camera;
        private RenderTexture _renderTexture;

        public RenderTexture renderTexture { get => _renderTexture; }
        public Camera camera { get => _camera; }

        public void Setup()
        {
            _camera.RemoveAllCommandBuffers();

            if (_renderTexture == null ||
                _renderTexture.width != _camera.targetTexture.width ||
                _renderTexture.height != _camera.targetTexture.height)
            {
                if (_renderTexture != null)
                    _renderTexture.Release();

                _renderTexture = new RenderTexture(_camera.targetTexture.width, _camera.targetTexture.height, 0, _camera.targetTexture.format);
            }

            var buffer = new CommandBuffer();
            buffer.Blit(_camera.targetTexture, _renderTexture);
            _camera.AddCommandBuffer(CameraEvent.AfterImageEffects, buffer);
        }
    }
}