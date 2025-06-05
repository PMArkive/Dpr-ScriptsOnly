using System;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/EnvironmentSettings", fileName = "EnvironmentSettings")]
[Serializable]
public class EnvironmentSettings : ScriptableObject
{
    [SerializeField]
    public bool CloudShadowEnable = true;
    [SerializeField]
    private Parameters Morning;
    [SerializeField]
    private Parameters Daytime;
    [SerializeField]
    private Parameters Evening;
    [SerializeField]
    private Parameters Night;
    [SerializeField]
    private Parameters Midnight;
    [SerializeField]
    private bool FixedTime;
    [SerializeField]
    public FogMode FogMode = FogMode.Linear;
    [NonSerialized]
    private Parameters Temporary = new Parameters();

    public Parameters this[PeriodOfDay periodOfDay]
    {
        get
        {
            switch (periodOfDay)
            {
                case PeriodOfDay.Morning: return Morning;
                case PeriodOfDay.Daytime: return Daytime;
                case PeriodOfDay.Evening: return Evening;
                case PeriodOfDay.Night: return Night;
                case PeriodOfDay.Midnight: return Midnight;
                default: return null;
            }
        }
    }

    public static PeriodOfDay GetPrevious(PeriodOfDay periodOfDay)
    {
        return (PeriodOfDay)(((int)periodOfDay + 1) % 5);
    }

    public static PeriodOfDay GetNext(PeriodOfDay periodOfDay)
    {
        return (PeriodOfDay)(((int)periodOfDay + 4) % 5);
    }

    public Parameters GetTransition(PeriodOfDay periodOfDay, float weight)
    {
        if (weight < 0.0001f)
            return this[periodOfDay];
        if (weight > 0.9999f)
            return this[GetNext(periodOfDay)];

        Parameters old = this[periodOfDay];
        Parameters next = this[GetNext(periodOfDay)];

        Temporary.LightColor = Color.Lerp(old.LightColor, next.LightColor, weight);
        Temporary.LightIntensity = Mathf.Lerp(old.LightIntensity, next.LightIntensity, weight);
        Temporary.ReflectorColor = Color.Lerp(old.ReflectorColor, next.ReflectorColor, weight);
        Temporary.CharacterLightColor = Color.Lerp(old.CharacterLightColor, next.CharacterLightColor, weight);
        Temporary.CharacterLightIntensity = Mathf.Lerp(old.CharacterLightIntensity, next.CharacterLightIntensity, weight);
        Temporary.CharacterReflectorColor = Color.Lerp(old.CharacterReflectorColor, next.CharacterReflectorColor, weight);
        Temporary.PokeLightColor = Color.Lerp(old.PokeLightColor, next.PokeLightColor, weight);
        Temporary.PokeLightIntensity = Mathf.Lerp(old.PokeLightIntensity, next.PokeLightIntensity, weight);
        Temporary.PokeReflectorColor = Color.Lerp(old.PokeReflectorColor, next.PokeReflectorColor, weight);
        Temporary.VertexColorScale = Mathf.Lerp(old.VertexColorScale, next.VertexColorScale, weight);
        Temporary.BloomThreshold = Mathf.Lerp(old.BloomThreshold, next.BloomThreshold, weight);
        Temporary.ShadowColor = Color.Lerp(old.ShadowColor, next.ShadowColor, weight);

        float oldLightYaw = old.LightYaw;
        float nextLightYaw = next.LightYaw - oldLightYaw;
        float signLightYaw = nextLightYaw >= 0.0f ? 0.5f : -0.5f;
        Temporary.LightYaw = oldLightYaw + (nextLightYaw - (nextLightYaw * 0.002777778f + signLightYaw) * 360.0f) * weight;

        float oldLightPitch = old.LightPitch;
        float nextLightPitch = next.LightPitch - oldLightPitch;
        float signLightPitch = nextLightPitch >= 0.0f ? 0.5f : -0.5f;
        Temporary.LightPitch = oldLightPitch + (nextLightPitch - (nextLightPitch * 0.002777778f + signLightPitch) * 360.0f) * weight;

        Temporary.CloudShadowScale = Mathf.Lerp(old.CloudShadowScale, next.CloudShadowScale, weight);
        Temporary.Blurry = Mathf.Lerp(old.Blurry, next.Blurry, weight);

        // TODO: Fuck this code, I hate these jumps
        return Temporary;
    }

    public EnvironmentSettings Clone()
    {
        var clone = MemberwiseClone() as EnvironmentSettings;

        clone.Morning = Morning.Clone();
        clone.Daytime = Morning.Clone();
        clone.Evening = Morning.Clone();
        clone.Night = Morning.Clone();
        clone.Midnight = Morning.Clone();
        clone.Temporary = Temporary.Clone();

        return clone;
    }

    [Serializable]
    public class Parameters
    {
	    [SerializeField]
        [Range(-180.0f, 180.0f)]
        public float LightYaw = -30.0f;
        [SerializeField]
        [Range(10.0f, 90.0f)]
        public float LightPitch = 70.0f;
        [SerializeField]
        public Color LightColor = Color.white;
        [SerializeField]
        [Range(0.1f, 5.0f)]
        public float LightIntensity = 1.2f;
        [SerializeField]
        public Color ReflectorColor = Color.gray;
        [SerializeField]
        public Color CharacterLightColor = Color.white;
        [SerializeField]
        [Range(0.1f, 5.0f)]
        public float CharacterLightIntensity = 1.2f;
        [SerializeField]
        public Color CharacterReflectorColor = Color.gray;
        [SerializeField]
        public Color PokeLightColor = Color.white;
        [SerializeField]
        [Range(0.1f, 5.0f)]
        public float PokeLightIntensity = 1.2f;
        [SerializeField]
        public Color PokeReflectorColor = Color.gray;
        [SerializeField]
        public bool ColorGradingEnable;
        [SerializeField]
        public Texture2D ColorGradingLookup;
        [SerializeField]
        [Range(0.0f, 1.0f)]
        public float ColorGradingInfluence = 1.0f;
        [NonSerialized]
        public Texture2D NexColorGradingLookup;
        [NonSerialized]
        public float ColorGradingBlendWeight = 1.0f;
        [SerializeField]
        [Range(0.0f, 1.0f)]
        public float VertexColorScale = 1.0f;
        [SerializeField]
        [Range(0.0f, 4.0f)]
        public float BloomThreshold = 1.0f;
        [SerializeField]
        public bool FogEnable;
        [SerializeField]
        public float FogStart = 1.0f;
        [SerializeField]
        public float FogEnd = 50.0f;
        [SerializeField]
        [Range(0.0f, 10.0f)]
        public float FogDensity = 0.66f;
        [SerializeField]
        public Color FogNearColor = Color.white;
        [SerializeField]
        public Color FogFarColor = Color.white;
        [SerializeField]
        public Color ShadowColor = Color.gray;
        [SerializeField]
        [Range(0.0f, 10.0f)]
        public float CloudShadowScale = 1.0f;
        [SerializeField]
        [Range(0.0f, 1.0f)]
        public float Blurry = 1.0f;

        public Parameters Clone()
        {
            return MemberwiseClone() as Parameters;
        }
    }
}