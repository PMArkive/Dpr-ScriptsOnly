using System;
using UnityEngine;

public sealed class EmissionColorChanger : MonoBehaviour
{
    private static readonly int _EmissionColorID = Shader.PropertyToID("_EmissionColor");
    private static readonly int _EmissionIntensityID = Shader.PropertyToID("_EmissionColorIntensity");

    [SerializeField]
    public int _materialIndex;
    private Renderer _renderer;
    private MaterialPropertyBlock propertyBlock;

    [SerializeField]
    private Property _morningProp;
    [SerializeField]
    private Property _daytimeProp;
    [SerializeField]
    private Property _eveningProp;
    [SerializeField]
    private Property _nightProp;
    [SerializeField]
    private Property _midnightProp;

    public Property this[PeriodOfDay periodOfDay]
    {
        get
        {
            switch (periodOfDay)
            {
                case PeriodOfDay.Morning: return _morningProp;
                case PeriodOfDay.Daytime: return _daytimeProp;
                case PeriodOfDay.Evening: return _eveningProp;
                case PeriodOfDay.Night: return _nightProp;
                case PeriodOfDay.Midnight: return _midnightProp;
                default: throw new IndexOutOfRangeException();
            }
        }
        set
        {
            switch (periodOfDay)
            {
                case PeriodOfDay.Morning:
                    _morningProp = value;
                    break;

                case PeriodOfDay.Daytime:
                    _daytimeProp = value;
                    break;

                case PeriodOfDay.Evening:
                    _eveningProp = value;
                    break;

                case PeriodOfDay.Night:
                    _nightProp = value;
                    break;

                case PeriodOfDay.Midnight:
                    _midnightProp = value;
                    break;
            }
        }
    }

    // TODO
    private void OnEnable() { }

    // TODO
    public void Update() { }

    // TODO
    private void OnDisable() { }

    [Serializable]
    public struct Property
    {
        [SerializeField]
        public Color color;
        [SerializeField]
        public float intensity;
    }
}