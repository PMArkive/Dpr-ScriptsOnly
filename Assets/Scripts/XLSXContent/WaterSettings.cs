using System;
using UnityEngine;

namespace XLSXContent
{
    [Serializable]
    public class WaterSettings : ScriptableObject
    {
        public SheetSettings[] Settings;

        public SheetSettings this[int index] => Settings[index];

        [Serializable]
        public class SheetSettings
        {
            public ZoneID[] ZoneIDs;
            public float PlaneElevation;
            public Color Color;
            public float UpScale;
            public float Attenuation;
            public float MaxDensity;
            public float Reflectivity;
            public float FresnelPower;
            public float SpecularIntensity;
            public float SpecularCosinePower;
        }
    }
}