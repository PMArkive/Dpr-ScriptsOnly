using System.Collections;
using SmartPoint.AssetAssistant;
using UnityEngine;
using UnityEngine.UI;

namespace SmartPoint.Components
{
    [RequireComponent(typeof(Canvas), typeof(RawImage), typeof(GraphicRaycaster))]
    public class Fader : SingletonMonoBehaviour<Fader>
    {
        public const int SORTING_ORDER = 16384;
        private Canvas _canvas;
        private RawImage _filterImage;
        private float _fillPower;
        private Color _fillColor;
        private float _speed;
        private Texture2D _renderTexture;
        private bool _valid = true;
        [SerializeField]
        [Range(0.0f, 2.0f)]
        private float _duration = 0.5f;
        [SerializeField]
        private FadeMode _mode;
        private Material _defaultMaterial;
        private Material _cutoutMaterial;

        protected override bool Awake()
        {
            if (!base.Awake())
                return false;

            _canvas = GetComponent<Canvas>();
            _filterImage = GetComponent<RawImage>();
            _defaultMaterial = new Material(_filterImage.material);
            _cutoutMaterial = new Material(Shader.Find("Unlit/Transparent Cutout"));

            if (_filterImage.material == _filterImage.defaultMaterial)
            {
                if (_mode == FadeMode.Cutout)
                    _filterImage.material = _cutoutMaterial;
            }
            else
            {
                _filterImage.material = _defaultMaterial;
            }

            _canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            _canvas.sortingOrder = SORTING_ORDER;
            _canvas.enabled = true;
            _fillColor = _filterImage.color;
            _fillPower = 1.0f;

            return true;
        }

        public static bool valid { get => _instance._valid; set => _instance._valid = value; }
        public static Material material
        {
            get => _instance._filterImage.material;
            set
            {
                if (value == null)
                    _instance._filterImage.material = _instance._filterImage.defaultMaterial;
                else
                    _instance._filterImage.material = value;
            }
        }
        public static FadeMode fadeMode
        {
            get => _instance._mode;
            set
            {
                if (value == FadeMode.Cutout)
                {
                    _instance._filterImage.material = _instance._cutoutMaterial;
                    _instance._cutoutMaterial.SetFloat("_Cutoff", -1.0f);
                }
                else
                {
                    _instance._filterImage.material = _instance._defaultMaterial;
                }

                _instance._mode = value;
            }
        }
        public static float duration { get => _instance._duration; set => _instance._duration = value; }
        public static Color fillColor
        {
            get => Instance != null ? Instance._fillColor : new Color(0.0f, 0.0f, 0.0f, 0.0f);
            set
            {
                if (Instance != null)
                    _instance._fillColor = value;
            }
        }
        public static Texture filterTexture
        {
            get => Instance != null ? _instance._filterImage.texture : null;
            set
            {
                if (Instance != null)
                    _instance._filterImage.texture = value;
            }
        }
        public static bool isBusy { get => Instance != null ? _instance._speed != 0.0f : true; }
        public static float fadeInProgress { get => _instance._speed > 0.0f ? 0.0f : 1.0f - _instance._fillPower; }
        public static float fadeOutProgress { get => _instance._speed < 0.0f ? 0.0f : _instance._fillPower; }
        public static float fillPower { get => _instance._fillPower; }

        public void OnDisable()
        {
            if (_instance != null)
                Sequencer.update -= OnUpdate;
        }

        private void OnUpdate(float deltaTime)
        {
            _fillPower += _speed * 0.03333334f;
            if (_speed >= 0.0f) // Positive speed
            {
                if (_fillPower < 1.0f)
                {
                    if (_fillPower > 0.0f) // 0-1 (0 excluded)
                    {
                        // Enable canvas
                        _canvas.enabled = true;
                    }
                    else // Negative to 0 (0 included)
                    {
                        // Disable canvas
                        if (_renderTexture != null)
                        {
                            DestroyImmediate(_renderTexture);
                            _renderTexture = null;
                        }
                        _canvas.enabled = false;
                    }
                }
                else // 1+
                {
                    // Cap to 1
                    _fillPower = 1.0f;
                    _speed = 0.0f;
                    _canvas.enabled = true;
                }
            }
            else // Negative speed
            {
                if (_fillPower > 0.0f) // 0-1 (0 excluded)
                {
                    _canvas.enabled = true;
                }
                else // Negative to 0 (0 included)
                {
                    // Cap to 0
                    _fillPower = 0.0f;
                    _speed = 0.0f;

                    if (_renderTexture != null)
                    {
                        DestroyImmediate(_renderTexture);
                        _renderTexture = null;
                    }
                    _canvas.enabled = false;
                }
            }

            if (_speed == 0.0f)
                Sequencer.update -= OnUpdate;

            UpdateMaterial();
        }

        private void UpdateMaterial()
        {
            switch (_mode)
            {
                case FadeMode.Color:
                    _filterImage.color = new Color(_fillColor.r, _fillColor.g, _fillColor.b, _fillColor.a * _fillPower);
                    break;

                case FadeMode.Cutout:
                    _filterImage.color = fillColor;
                    _filterImage.material.SetFloat("_Cutoff", 1.0f - _fillPower);
                    break;

                case FadeMode.Cross:
                    _filterImage.color = new Color(1.0f, 1.0f, 1.0f, _fillPower);
                    break;
            }
        }

        public static void FadeIn()
        {
            if (Instance == null)
                return;

            FadeIn(_instance._duration);
        }

        public static void FadeIn(float duration)
        {
            if (Instance == null)
                return;

            if (!_instance._valid)
                return;

            if (duration <= 0.0f || _instance._fillPower == 0.0f)
            {
                _instance._canvas.enabled = false;
                _instance._speed = 0.0f;
                _instance._fillPower = 0.0f;
                _instance.UpdateMaterial();
                return;
            }

            Sequencer.update += _instance.OnUpdate;
            _instance._speed = -1.0f / duration;
        }

        public static void FadeOut()
        {
            if (Instance == null)
                return;

            FadeOut(_instance._duration);
        }

        public static void FadeOut(float duration)
        {
            if (Instance == null)
                return;

            if (!_instance._valid)
                return;

            if (_instance._mode == FadeMode.Cross)
            {
                _instance._canvas.enabled = true;
                _instance._fillPower = 0.0f;
                Sequencer.Start(_instance.CaptureScreen());
                return;
            }

            if (duration <= 0.0f || _instance._fillPower == 1.0f)
            {
                _instance._canvas.enabled = true;
                _instance._speed = 0.0f;
                _instance._fillPower = 1.0f;
                _instance.UpdateMaterial();
                return;
            }

            Sequencer.update += _instance.OnUpdate;
            _instance._speed = 1.0f / duration;
        }

        private IEnumerator CaptureScreen()
        {
            _renderTexture = new Texture2D(Screen.width, Screen.height, TextureFormat.ARGB32, false, true);
            _speed = 1.0f;

            yield return new WaitForEndOfFrame();

            _renderTexture.ReadPixels(new Rect(0.0f, 0.0f, Screen.width, Screen.height), 0, 0);
            _renderTexture.Apply();
            _filterImage.texture = _renderTexture;
            _speed = 0.0f;
            _fillPower = 1.0f;
            _canvas.enabled = true;
            UpdateMaterial();
        }

        public enum FadeMode : int
        {
            Color = 0,
            Cutout = 1,
            Cross = 2,
        }
    }
}