using SmartPoint.AssetAssistant;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;

namespace SmartPoint.Rendering
{
    [ExecuteAlways]
    [RequireComponent(typeof(Camera))]
    public class PostProcessFilter : MonoBehaviour, IViewportChangeHandler, IEventSystemHandler
    {
        [SerializeField]
        private ImageEffectObject[] _effects;
        [SerializeField]
        private Camera _camera;
        private RenderTexture _renderTexture;
        private CommandBuffer[] _commandBuffers;

        public void OnViewportChange(int width, int height)
        {
            Reset();
        }

        public T GetEffect<T>() where T : ImageEffectObject
        {
            if (_effects == null)
                return null;

            for (int i=0; i<_effects.Length; i++)
            {
                if (_effects[i] is T effect)
                    return effect;
            }

            return null;
        }

        public void OnEnable()
        {
            if (Application.isPlaying)
                Reset();
        }

        public void Reset()
        {
            OnDisable();

            if (_effects == null)
                return;

            if (_camera == null)
                _camera = GetComponent<Camera>();

            int width;
            int height;
            var targetTexture = _camera == null ? null : _camera.targetTexture;
            if (targetTexture == null)
            {
                width = Sequencer.screenWidth;
                height = Sequencer.screenHeight;
            }
            else
            {
                width = _camera.targetTexture.width;
                height = _camera.targetTexture.height;
            }

            if (_renderTexture == null)
            {
                _renderTexture = new RenderTexture(width, height, 24, UnityEngine.Experimental.Rendering.DefaultFormat.LDR);
                _renderTexture.autoGenerateMips = false;
            }

            _commandBuffers = new CommandBuffer[_effects.Length];

            for (int i=0; i<_effects.Length; i++)
            {
                var effect = _effects[i];
                if (effect != null)
                {
                    effect.temporaryRT = _renderTexture;
                    effect.camera = _camera;
                    _commandBuffers[i] = effect.Build(BuiltinRenderTextureType.CameraTarget, out RenderTargetIdentifier rt, i == _effects.Length - 1);
                    _camera.AddCommandBuffer(CameraEvent.BeforeImageEffects, _commandBuffers[i]);
                }
            }
        }

        public void OnPreCull()
        {
            if (_effects != null)
            {
                for (int i=0; i<_effects.Length; i++)
                {
                    var effect = _effects[i];
                    if (effect != null)
                        effect.Update();
                }
            }
        }

        private void OnDisable()
        {
            if (_camera == null)
                return;

            if (_renderTexture != null)
            {
                DestroyImmediate(_renderTexture);
                _renderTexture = null;
            }

            if (_commandBuffers != null)
            {
                for (int i=0; i<_commandBuffers.Length; i++)
                {
                    var buffer = _commandBuffers[i];
                    if (buffer != null)
                    {
                        _camera.RemoveCommandBuffer(CameraEvent.BeforeImageEffects, buffer);
                        buffer.Clear();
                        _commandBuffers[i] = null;
                    }
                }

                _commandBuffers = null;
            }

            if (_effects != null)
            {
                for (int i=0; i<_effects.Length; i++)
                {
                    var effect = _effects[i];
                    if (effect != null)
                        effect.Destroy();
                }
            }
        }
    }
}