using AttributeData;
using System;
using UnityEngine;

namespace XLSXContent
{
    [Serializable]
    public class MapAttributeExTable : ScriptableObject
    {
        public SheetData[] Data;

        public SheetData this[int index] => Data[index];

        [Serializable]
        public class SheetData
        {
            public int Code;
            public MapAttributeEx AttributeEx;
            public string SoundLabelSunny;
            public string SoundLabelRain;
            public string SoundLabelRunSunny;
            public string SoundLabelRunRain;
            public string SoundLabelBicycleGear3Sunny;
            public string SoundLabelBicycleGear3Rain;
            public string SoundLabelBicycleGear4Sunny;
            public string SoundLabelBicycleGear4Rain;
            public EffectFieldID EffectWalkSunnyA;
            public EffectFieldID EffectWalkSunnyB;
            public EffectFieldID EffectWalkRainA;
            public EffectFieldID EffectWalkRainB;
            public EffectFieldID EffectRunSunnyA;
            public EffectFieldID EffectRunSunnyB;
            public EffectFieldID EffectRunRainA;
            public EffectFieldID EffectRunRainB;
            public EffectFieldID EffectBicycleSunnyA;
            public EffectFieldID EffectBicycleSunnyB;
            public EffectFieldID EffectBicycleRainA;
            public EffectFieldID EffectBicycleRainB;
            public EffectFieldID EffectJumpSunnyA;
            public EffectFieldID EffectJumpSunnyB;
            public EffectFieldID EffectJumpRainA;
            public EffectFieldID EffectJumpRainB;
        }
    }
}