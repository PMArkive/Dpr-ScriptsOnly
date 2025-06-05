using Pml.PokePara;
using System;
using UnityEngine;

namespace XLSXContent
{
    [Serializable]
    public class SealTable : ScriptableObject
    {
        public SheetSealData[] SealData;
        public SheetEffectPositionOffset[] EffectPositionOffset;
        public SheetFixedPositionEffect[] FixedPositionEffect;

        public SheetSealData this[int index] => SealData[index];

        [Serializable]
        public class SheetSealData
        {
            public SealID SealID;
            public int Category;
            public int SortNumber;
            public int EffectType;
            public string EffectAssetbundleName;
            public bool IsEffectYAxisToForward;
            public string IconAssetbundleName;
        }

        [Serializable]
        public class SheetEffectPositionOffset
        {
	        public Size Size;
            public float OffsetValue;
        }

        [Serializable]
        public class SheetFixedPositionEffect
        {
	        public SealID SealID;
            public Vector3 Position;
            public Vector3 Rotation;
            public Vector3 AdjustScaleRate;
        }
    }
}