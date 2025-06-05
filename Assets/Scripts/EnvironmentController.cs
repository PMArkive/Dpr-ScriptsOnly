using SmartPoint.AssetAssistant;
using SmartPoint.Components;
using SmartPoint.Rendering;
using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
[ExecuteAlways]
public class EnvironmentController : MonoBehaviour
{
    public static EnvironmentController global { get; set; }
    public static float globalBumpScale { get; set; } = 1.0f;
    public static float globalLightPower { get; set; } = 1.0f;

    private AudioChannel _environmentSound;

    [SerializeField]
    private Texture2D _NoiseTex;
    [SerializeField]
    private Texture2D _SnowTex;
    [SerializeField]
    private Texture2D _SnowNormalTex;
    [SerializeField]
    private ShaderMode _ShaderMode;
    [SerializeField]
    public WeatherMode _WeatherMode;
    [SerializeField]
    private Texture2D _CloudShadowTex;
    [SerializeField]
    private Vector2 _CloudSpeed = new Vector2(1.0f, 1.0f);
    [SerializeField]
    private Vector2 _CloudTiling = new Vector2(0.01f, 0.01f);
    [SerializeField]
    private ParticleSystem _rainEffect;
    [SerializeField]
    private Texture2D _EnvironmentMap;
    [SerializeField]
    private Color _ShadowColor = new Color(0.625f, 0.625f, 0.625f);
    [SerializeField]
    private Color _SnowShadowColor = new Color(0.6f, 0.5f, 0.8f);
    [SerializeField]
    [Range(0.0f, 1.0f)]
    public float _Wetness;
    [SerializeField]
    [Range(0.0f, 1.0f)]
    public float _EmissionThreshold;
    [SerializeField]
    [Range(0.0f, 1.0f)]
    public float _EmissionScale = 1.0f;
    [SerializeField]
    [Range(0.0f, 10.0f)]
    public float _CloudShadowScale = 1.0f;
    [SerializeField]
    [Range(0.0f, 1.0f)]
    public float _CloudShadowBase;
    [SerializeField]
    [Range(0.0f, 1.0f)]
    public float _Blurry = 1.0f;
    [SerializeField]
    [Range(0.0f, 100.0f)]
    public float _ShadowDistance = 20.0f;
    [SerializeField]
    [Range(0.0f, 50.0f)]
    public float _ShadowNearPlaneOffset = 3.0f;
    [SerializeField]
    [Range(0.0f, 3.0f)]
    public float _ShadowNormalBias;
    [SerializeField]
    private GameObject _snowField;
    [SerializeField]
    private GameObject _waterField;
    [NonSerialized]
    public UpdateCallback callback;
    public Parameters parameters;
    private Light _light;

    private static readonly int _reflectionColorID = Shader.PropertyToID("_ReflectorColor");
    private static readonly int _characterLightColorID = Shader.PropertyToID("_CharacterLightColor");
    private static readonly int _characterReflectionColorID = Shader.PropertyToID("_CharacterReflectorColor");
    private static readonly int _pokeLightColorID = Shader.PropertyToID("_PokeLightColor");
    private static readonly int _pokeReflectionColorID = Shader.PropertyToID("_PokeReflectorColor");
    private static readonly int _vertexColorScaleID = Shader.PropertyToID("_VertexColorScale");
    private static readonly int _bloomThresholdID = Shader.PropertyToID("_BloomThreshold");
    private static readonly int _emissionScaleID = Shader.PropertyToID("_EmissionScale");
    private static readonly int _emissionThresholdID = Shader.PropertyToID("_EmissionThreshold");
    private static readonly int _cloudShadowID = Shader.PropertyToID("_CloudShadowTex");
    private static readonly int _cloudParamID = Shader.PropertyToID("_CloudParam");
    private static readonly int _cloudScaleID = Shader.PropertyToID("_CloudShadowScale");
    private static readonly int _cloudBaseID = Shader.PropertyToID("_CloudShadowBase");
    private static readonly int _shadowColorID = Shader.PropertyToID("_ShadowColor");
    private static readonly int _environmentMapID = Shader.PropertyToID("_EnvironmentMap");
    private static readonly int _snowTexID = Shader.PropertyToID("_SnowTex");
    private static readonly int _snowNormalTexID = Shader.PropertyToID("_SnowNormalTex");
    private static readonly int _noiseTexID = Shader.PropertyToID("_NoiseTex");
    private static readonly int _mipTexID = Shader.PropertyToID("_MipTex");
    private static readonly int _WetnessID = Shader.PropertyToID("_Wetness");
    private static readonly int _globalBumpScaleID = Shader.PropertyToID("_GlobalBumpScale");
    private static readonly int _globalLightPowerID = Shader.PropertyToID("_GlobalLightPower");
    private static readonly int _additionalBlurryID = Shader.PropertyToID("_AdditionalBlurry");

    private Texture2D _mipTexture;
    private bool _cloudShadowEnable = true;
    private bool _throughGlobal;
    private float _savedShadowDistance;
    private float _savedShadowNearPlaneOffset;
    public EnvironmentSettings latestSettings;
    public EnvironmentSettings.Parameters latestParameters;
    public PeriodOfDay periodOfDay = PeriodOfDay.Daytime;
    [HideInInspector]
    public float AddLightIntensity;
    [HideInInspector]
    public float AddCharacterLightIntensity;
    [HideInInspector]
    public float AddPokeLightIntensity;

    private static List<EnvironmentController> _environmentControllers = new List<EnvironmentController>();

    public static bool globalSnowFieldEnable
    {
        get => global != null && global._snowField != null && global._snowField.activeSelf;
        set
        {
            if (global != null && global._snowField != null)
                global._snowField.SetActive(value);
        }
    }
    public static bool globalWaterFieldEnable
    {
        get => global != null && global._waterField != null && global._waterField.activeSelf;
        set
        {
            if (global != null && global._waterField != null)
                global._waterField.SetActive(value);
        }
    }
    public bool cloudShadowEnable { set => _cloudShadowEnable = value; }
    public Texture2D cloudShadowTex { set => _CloudShadowTex = value; }
    public float shadowDistance { get => _ShadowDistance; set => _ShadowDistance = value; }
    public float shadowNearPlaneOffset { get => _ShadowNearPlaneOffset; set => _ShadowNearPlaneOffset = value; }
    public ShaderMode shaderMode
    {
        get => _ShaderMode;
        set
        {
            _ShaderMode = value;
            OnValidate();
        }
    }
    public bool throughGlobal { set => _throughGlobal = value; }

    public bool IsActiveController()
    {
        if (_environmentControllers.Count < 1)
            return false;

        return _environmentControllers[_environmentControllers.Count-1] == this;
    }

    public void SetActiveController()
    {
        if (IsActiveController())
            return;

        _environmentControllers.Remove(this);
        _environmentControllers.Add(this);
    }

    private void OnEnable()
    {
        SetActiveController();
        _savedShadowDistance = QualitySettings.shadowDistance;
        _savedShadowNearPlaneOffset = QualitySettings.shadowNearPlaneOffset;
        Sequencer.update += OnUpdate;

        if (!_throughGlobal)
            global = this;

        if (_light != null)
            OnValidate();

        _light = GetComponent<Light>();
    }

    private void OnDisable()
    {
        _environmentControllers.Remove(this);
        ResetShadowSettings();
        Sequencer.update -= OnUpdate;
    }

    private void OnUpdate(float deltaTime)
    {
        callback?.Invoke(this, deltaTime);
        ResetShadowSettings();

        float lightMult = parameters.CharacterLightIntensity + AddCharacterLightIntensity;
        var lightMultVec = new Vector4(lightMult, lightMult, lightMult, 1.0f);
        Shader.SetGlobalColor(_characterLightColorID, parameters.CharacterLightColor * lightMultVec);
        Shader.SetGlobalColor(_characterReflectionColorID, parameters.CharacterReflectorColor);

        float pokeLightMult = parameters.PokeLightIntensity + AddPokeLightIntensity;
        var pokeLightMultVec = new Vector4(pokeLightMult, pokeLightMult, pokeLightMult, 1.0f);
        Shader.SetGlobalColor(_pokeLightColorID, parameters.PokeLightColor * pokeLightMultVec);
        Shader.SetGlobalColor(_pokeReflectionColorID, parameters.PokeReflectorColor);
        Shader.SetGlobalColor(_reflectionColorID, parameters.ReflectorColor);

        Shader.SetGlobalFloat(_vertexColorScaleID, parameters.VertexColorScale);
        Shader.SetGlobalFloat(_bloomThresholdID, parameters.BloomThreshold);
        Shader.SetGlobalFloat(_emissionScaleID, _EmissionScale);
        Shader.SetGlobalFloat(_emissionThresholdID, _EmissionThreshold);
        Shader.SetGlobalFloat(_WetnessID, _Wetness);
        Shader.SetGlobalFloat(_cloudScaleID, _CloudShadowScale);
        Shader.SetGlobalFloat(_cloudBaseID, 1.0f - _CloudShadowBase);
        Shader.SetGlobalFloat(_globalBumpScaleID, globalBumpScale);

        if (_throughGlobal)
            Shader.SetGlobalFloat(_globalLightPowerID, 0.0f);
        else
            Shader.SetGlobalFloat(_globalLightPowerID, globalLightPower - 1.0f);

        Shader.SetGlobalFloat(_additionalBlurryID, _Blurry);

        if (_WeatherMode == WeatherMode.Snow)
            Shader.SetGlobalColor(_shadowColorID, _SnowShadowColor * 0.5f);
        else
            Shader.SetGlobalColor(_shadowColorID, _ShadowColor * 0.5f);

        float x = GameManager.elapsedTimeOfDay * 60.0f * _CloudSpeed.x;
        if (!Mathf.Approximately(_CloudTiling.x, 0.0f))
            x = x % (1.0f / _CloudTiling.x);

        float y = GameManager.elapsedTimeOfDay * 60.0f * _CloudSpeed.y;
        if (!Mathf.Approximately(_CloudTiling.y, 0.0f))
            y = y % (1.0f / _CloudTiling.y);

        Shader.SetGlobalVector(_cloudParamID, new Vector4(x, y, _CloudTiling.x, _CloudTiling.y));

        if (_CloudShadowTex != null && _cloudShadowEnable)
            Shader.SetGlobalTexture(_cloudShadowID, _CloudShadowTex);
        else
            Shader.SetGlobalTexture(_cloudShadowID, Texture2D.blackTexture);

        if (_EnvironmentMap != null)
            Shader.SetGlobalTexture(_environmentMapID, _CloudShadowTex);
        else
            Shader.SetGlobalTexture(_environmentMapID, Texture2D.whiteTexture);

        Shader.SetGlobalTexture(_snowTexID, _SnowTex);

        if (_SnowNormalTex != null)
            Shader.SetGlobalTexture(_snowNormalTexID, _SnowNormalTex);
        else
            Shader.SetGlobalTexture(_snowNormalTexID, Texture2D.normalTexture);

        if (_NoiseTex != null)
            Shader.SetGlobalTexture(_noiseTexID, _NoiseTex);
        else
            Shader.SetGlobalTexture(_noiseTexID, Texture2D.grayTexture);

        if (_mipTexture != null)
            Shader.SetGlobalTexture(_mipTexID, _mipTexture);

        if (_light != null)
        {
            _light.intensity = parameters.LightIntensity + AddLightIntensity;
            _light.color = parameters.LightColor;
            _light.transform.eulerAngles = parameters.PitchYaw;
            _light.shadowNormalBias = _ShadowNormalBias;
        }

        DepthOfField.blurry = _Blurry;
    }

    private static void SetKeyword(string keyword, bool state)
    {
        if (state)
            Shader.EnableKeyword(keyword);
        else
            Shader.DisableKeyword(keyword);
    }

    private void OnDestroy()
    {
        if (_environmentSound != null)
        {
            _environmentSound.source.loop = false;
            _environmentSound.Stop();
            _environmentSound = null;
        }
    }

    public void SetLight(EnvironmentSettings light, PeriodOfDay periodOfDay, float progress, float weight = 0.0f)
    {
        if (!isActiveAndEnabled)
            return;

        if (light == null)
            return;

        if (_environmentControllers.Count > 0 &&
            _environmentControllers[_environmentControllers.Count-1] != this)
            return;

        latestSettings = light;
        this.periodOfDay = periodOfDay;
        _cloudShadowEnable = light.CloudShadowEnable;
        latestParameters = light.GetTransition(periodOfDay, weight);

        parameters.PitchYaw = new Vector2(latestParameters.LightPitch, latestParameters.LightYaw);
        parameters.LightColor = latestParameters.LightColor;
        parameters.LightIntensity = latestParameters.LightIntensity;
        parameters.ReflectorColor = latestParameters.ReflectorColor;
        parameters.VertexColorScale = latestParameters.VertexColorScale;
        parameters.BloomThreshold = latestParameters.BloomThreshold;
        parameters.CharacterLightColor = latestParameters.CharacterLightColor;
        parameters.CharacterLightIntensity = latestParameters.CharacterLightIntensity;
        parameters.CharacterReflectorColor = latestParameters.CharacterReflectorColor;
        parameters.PokeLightColor = latestParameters.PokeLightColor;
        parameters.PokeLightIntensity = latestParameters.PokeLightIntensity;
        parameters.PokeReflectorColor = latestParameters.PokeReflectorColor;

        _EmissionThreshold = ((float)periodOfDay + progress) * 0.2f;
        Fxaa.SetColorGrading(latestParameters.ColorGradingLookup, latestParameters.ColorGradingInfluence,
            latestParameters.NexColorGradingLookup, latestParameters.ColorGradingBlendWeight);

        if (latestParameters.FogEnable)
            Bloom.SetFogParameters(light.FogMode, latestParameters.FogStart, latestParameters.FogEnd,
                latestParameters.FogDensity, 100.0f, latestParameters.FogNearColor, latestParameters.FogFarColor);
        else
            Bloom.SetFogColorAlpha(0.0f, 0.0f);

        _ShadowColor = latestParameters.ShadowColor;
        _CloudShadowScale = latestParameters.CloudShadowScale;
        _Blurry = latestParameters.Blurry;
    }

    public void SetPokemonLight(EnvironmentSettings light, PeriodOfDay periodOfDay)
    {
        if (!isActiveAndEnabled)
            return;

        if (light == null)
            return;

        if (_environmentControllers.Count > 0 &&
            _environmentControllers[_environmentControllers.Count - 1] != this)
            return;

        var settings = light[periodOfDay];
        parameters.PokeLightColor = settings.PokeLightColor;
        parameters.PokeLightIntensity = settings.PokeLightIntensity;
        parameters.PokeReflectorColor = settings.PokeReflectorColor;

        float intensity = parameters.PokeLightIntensity;
        Shader.SetGlobalColor(_pokeLightColorID, parameters.PokeLightColor * new Vector4(intensity, intensity, intensity, 1.0f));
        Shader.SetGlobalColor(_pokeReflectionColorID, parameters.PokeReflectorColor);

        if (light == null)
            return;

        _light.intensity = parameters.LightIntensity;
        _light.color = parameters.LightColor;
        _light.transform.eulerAngles = parameters.PitchYaw;
        _light.shadowNormalBias = _ShadowNormalBias;
    }

    public void ResetShadowSettings()
    {
        if (_savedShadowDistance != QualitySettings.shadowDistance)
            QualitySettings.shadowDistance = _savedShadowDistance;

        if (_savedShadowNearPlaneOffset != QualitySettings.shadowNearPlaneOffset)
            QualitySettings.shadowNearPlaneOffset = _savedShadowNearPlaneOffset;
    }

    public void OnValidate()
    {
        if (global != this)
            return;

        if (_ShaderMode == ShaderMode.MipLevelsOnly || _ShaderMode == ShaderMode.MipLevelsMixed)
        {
            if (!Shader.IsKeywordEnabled("_MIPLEVEL_ONLY") && !Shader.IsKeywordEnabled("_MIPLEVEL_MIXED"))
            {
                if (_mipTexture == null)
                {
                    DestroyImmediate(_mipTexture);
                    _mipTexture = null;
                }

                var colors = new Color[6]
                {
                    new Color(0.0f, 0.0f, 1.0f, 0.8f),
                    new Color(0.0f, 0.5f, 1.0f, 0.4f),
                    new Color(1.0f, 1.0f, 1.0f, 0.0f),
                    new Color(1.0f, 0.7f, 0.0f, 0.2f),
                    new Color(1.0f, 0.3f, 0.0f, 0.6f),
                    new Color(1.0f, 0.0f, 0.0f, 0.8f),
                };

                _mipTexture = new Texture2D(32, 32, TextureFormat.ARGB32, true, true);
                _mipTexture.filterMode = FilterMode.Trilinear;

                var colorSet1 = new Color[1024];
                for (int i=0; i<colorSet1.Length; i++)
                    colorSet1[i] = colors[0];
                _mipTexture.SetPixels(colorSet1, 0);

                var colorSet2 = new Color[256];
                for (int i=0; i<colorSet2.Length; i++)
                    colorSet2[i] = colors[1];
                _mipTexture.SetPixels(colorSet2, 1);

                var colorSet3 = new Color[64];
                for (int i=0; i<colorSet3.Length; i++)
                    colorSet3[i] = colors[2];
                _mipTexture.SetPixels(colorSet3, 2);

                var colorSet4 = new Color[16];
                for (int i=0; i<colorSet4.Length; i++)
                    colorSet4[i] = colors[3];
                _mipTexture.SetPixels(colorSet4, 3);

                var colorSet5 = new Color[4];
                for (int i=0; i<colorSet5.Length; i++)
                    colorSet5[i] = colors[4];
                _mipTexture.SetPixels(colorSet5, 4);

                var colorSet6 = new Color[1];
                for (int i=0; i<colorSet6.Length; i++)
                    colorSet6[i] = colors[5];
                _mipTexture.SetPixels(colorSet6, 5);

                _mipTexture.Apply(false);
            }
        }
        else
        {
            if (_mipTexture == null)
            {
                DestroyImmediate(_mipTexture);
                _mipTexture = null;
            }
        }

        SetKeyword("_POSTPROCESS_DISABLE", _ShaderMode == ShaderMode.Default);
        SetKeyword("_NORMAL_ONLY", _ShaderMode == ShaderMode.Normal);
        SetKeyword("_TANGENT_ONLY", _ShaderMode == ShaderMode.VertexTangentOnly);
        SetKeyword("_COLOR_ONLY", _ShaderMode == ShaderMode.Color);
        SetKeyword("_VERTEXCOLOR_ONLY", _ShaderMode == ShaderMode.VertexColor);
        SetKeyword("_FRESNEL_ONLY", _ShaderMode == ShaderMode.Fresnel);
        SetKeyword("_GLOSSY_ONLY", _ShaderMode == ShaderMode.Glossy);
        SetKeyword("_REFLECTIVITY_ONLY", _ShaderMode == ShaderMode.Relfectivity);
        SetKeyword("_LIGHTINTENSITY_ONLY", _ShaderMode == ShaderMode.LightIntensity);
        SetKeyword("_LIGHTREFLECTION_ONLY", _ShaderMode == ShaderMode.LightReflection);
        SetKeyword("_LIGHTCOLOR_MIXED", _ShaderMode == ShaderMode.LightColorMixed);
        SetKeyword("_EYERAY_ONLY", _ShaderMode == ShaderMode.TangentSpaceEyeRay);
        SetKeyword("_MIPLEVEL_MIXED", _ShaderMode == ShaderMode.MipLevelsMixed);
        SetKeyword("_MIPLEVEL_ONLY", _ShaderMode == ShaderMode.MipLevelsOnly);
        SetKeyword("_ENVMAP_DISABLE", _ShaderMode == ShaderMode.EnvironmentMapDisable);
        SetKeyword("_UTILITYCHANNEL_R", _ShaderMode == ShaderMode.UtilityMapChannelR);
        SetKeyword("_UTILITYCHANNEL_G", _ShaderMode == ShaderMode.UtilityMapChannelG);
        SetKeyword("_UTILITYCHANNEL_B", _ShaderMode == ShaderMode.UtilityMapChannelB);
        SetKeyword("_UTILITYCHANNEL_A", _ShaderMode == ShaderMode.UtilityMapChannelA);
        SetKeyword("_SNOW", _WeatherMode == WeatherMode.Snow);
        SetKeyword("_RAIN", _WeatherMode == WeatherMode.Rain);

        if (_WeatherMode == WeatherMode.Rain)
        {
            if (_environmentSound == null)
            {
                if (_rainEffect != null)
                    _rainEffect.Play();

                _environmentSound = AudioPlayer.PlayEffect("rain");
                if (_environmentSound != null)
                    _environmentSound.source.loop = true;
            }
        }
        else
        {
            if (_environmentSound != null)
            {
                if (_rainEffect != null)
                    _rainEffect.Stop();

                _environmentSound.source.loop = false;
                _environmentSound.Stop();
                _environmentSound = null;
            }
        }
    }

    public enum ShaderMode : int
    {
        Default = 0,
        Color = 1,
        VertexColor = 2,
        Normal = 3,
        VertexTangentOnly = 4,
        LightIntensity = 5,
        LightReflection = 6,
        LightColorMixed = 7,
        Fresnel = 8,
        Glossy = 9,
        Relfectivity = 10,
        TangentSpaceEyeRay = 11,
        MipLevelsOnly = 12,
        MipLevelsMixed = 13,
        EnvironmentMapDisable = 14,
        UtilityMapChannelR = 15,
        UtilityMapChannelG = 16,
        UtilityMapChannelB = 17,
        UtilityMapChannelA = 18,
    }

    public enum WeatherMode : int
    {
        Sunny = 0,
        Rain = 1,
        Snow = 2,
    }

    [Serializable]
    public class Parameters
    {
	    [SerializeField]
        public Color LightColor = Color.white;
        [SerializeField]
        [Range(0.0f, 5.0f)]
        public float LightIntensity = 1.2f;
        [SerializeField]
        public Color ReflectorColor = Color.gray;
        [SerializeField]
        public Color CharacterLightColor = Color.white;
        [SerializeField]
        [Range(0.0f, 5.0f)]
        public float CharacterLightIntensity = 1.2f;
        [SerializeField]
        public Color CharacterReflectorColor = Color.gray;
        [SerializeField]
        public Color PokeLightColor = Color.white;
        [SerializeField]
        public Color PokeReflectorColor = Color.gray;
        [SerializeField]
        [Range(0.0f, 5.0f)]
        public float PokeLightIntensity = 1.0f;
        [SerializeField]
        public Vector2 PitchYaw = new Vector2(70.0f, -30.0f);
        [SerializeField]
        [Range(0.0f, 1.0f)]
        public float VertexColorScale;
        [SerializeField]
        [Range(0.0f, 4.0f)]
        public float BloomThreshold = 1.0f;
    }

    public delegate void UpdateCallback(EnvironmentController controller, float deltaTime);
}