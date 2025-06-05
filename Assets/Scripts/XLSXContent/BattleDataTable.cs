using System;
using Dpr.Battle.Logic;
using Dpr.Battle.View;
using Dpr.SequenceEditor;
using Dpr.Trainer;
using Pml;
using Pml.PokePara;
using UnityEngine;

namespace XLSXContent
{
    [Serializable]
    public class BattleDataTable : ScriptableObject
    {
        public SheetBattleSetupEffectData[] BattleSetupEffectData;
        public SheetSetupIntroPlaySequenceData[] SetupIntroPlaySequenceData;
        public SheetBattleStatusEffectObserverData[] BattleStatusEffectObserverData;
        public SheetBattleMiscEffectData[] BattleMiscEffectData;
        public SheetBattleWazaData[] BattleWazaData;
        public SheetBattleUniqueWazaData[] BattleUniqueWazaData;
        public SheetSafariCmdData[] SafariCmdData;
        public SheetBattleWazaMsgFrameData[] BattleWazaMsgFrameData;
        public SheetWeatherData[] WeatherData;
        public SheetBattleGroundData[] BattleGroundData;
        public SheetBallEffectData[] BallEffectData;
        public SheetMotionTimingData[] MotionTimingData;
        public SheetMotionReplaceData[] MotionReplaceData;
        public SheetPokemonEntryMotionData[] PokemonEntryMotionData;
        public SheetBattleConstant[] BattleConstant;
        public SheetAgeEyeBlink[] AgeEyeBlink;
        public SheetDisableBlinkPokemon[] DisableBlinkPokemon;
        public SheetPokemonMotionBlendTime[] PokemonMotionBlendTime;
        public SheetInterpolationSequence[] InterpolationSequence;

        public SheetBattleSetupEffectData this[int index] => BattleSetupEffectData[index];

        [Serializable]
        public class SheetBattleSetupEffectData
        {
            public string[] CmdSeqName;
            public byte[] Weight;
            public byte[] Cond;
            public string BattleBGM;
            public string WinBGM;
            public int FadeType;
        }

        [Serializable]
        public class SheetSetupIntroPlaySequenceData
        {
            public BattleSetupIntroID Key;
            public string SeqName;
        }

        [Serializable]
        public class SheetBattleStatusEffectObserverData
        {
            public Sick SickType;
            public EffectBattleID EffectID;
            public Vector3 Offset;
            public Vector3 Scale;
            public SEQ_DEF_NODE Node;
            public bool AdustScale;
        }

        [Serializable]
        public class SheetBattleMiscEffectData
        {
            public int Index;
            public BtlEff BtlEff;
            public string CmdSeqName;
        }

        [Serializable]
        public class SheetBattleWazaData
        {
            public WazaNo WazaNo;
            public string CmdSeqName;
            public string CmdSeqNameLegend;
            public string NotShortenTurnType0;
            public string NotShortenTurnType1;
            public string TurnType1;
            public string TurnType2;
            public string TurnType3;
            public string TurnType4;
        }

        [Serializable]
        public class SheetBattleUniqueWazaData
        {
            public WazaNo WazaNo;
            public MonsNo MonsNo;
            public byte FormNo;
            public int SrcTurnType;
            public int DestTurnType;
        }

        [Serializable]
        public class SheetSafariCmdData
        {
            public int SafariCmd;
            public string CmdSeqName;
            public string CmdCritialSeqName;
        }

        [Serializable]
        public class SheetBattleWazaMsgFrameData
        {
            public int Index;
            public string FileName;
            public int frame;
        }

        [Serializable]
        public class SheetWeatherData
        {
            public string MainFileName;
            public string CameraFileName;
            public string RangeFileName;
            public string RegisterName;
            public Vector3 CameraScale;
            public float LightPower;
            public int Time;
            public int ShortTime;
        }

        [Serializable]
        public class SheetBattleGroundData
        {
            public string MainFileName;
            public string CameraFileName;
            public Vector3 MainScale;
            public Vector3 CameraScale;
        }

        [Serializable]
        public class SheetBallEffectData
        {
            public BallId BallID;
            public string IntroEffectAssetbundleName;
            public string CaptureEffectAssetbundleName;
        }

        [Serializable]
        public class SheetMotionTimingData
        {
            public int MonsNo;
            public int FormNo;
            public int Sex;
            public int Buturi01;
            public int Buturi02;
            public int Buturi03;
            public int Tokusyu01;
            public int Tokusyu02;
            public int Tokusyu03;
            public int BodyBlow;
            public int Punch;
            public int Kick;
            public int Tail;
            public int Bite;
            public int Peck;
            public int Radial;
            public int Cry;
            public int Dust;
            public int Shot;
            public int Guard;
            public int LandingFall;
            public int LandingFallEase;
        }

        [Serializable]
        public class SheetMotionReplaceData
        {
            public int UniqueID;
            public int No;
            public MonsNo MonsNo;
            public int FormNo;
            public int BodyBlow;
            public int Punch;
            public int Kick;
            public int Tail;
            public int Bite;
            public int Peck;
            public int Radial;
            public int Cry;
            public int Dust;
            public int Shot;
            public int Guard;
            public int Buturi01;
            public int Tokusyu01;
            public WazaNo WazaNo;
            public int wazaMotion;
        }

        [Serializable]
        public class SheetPokemonEntryMotionData
        {
            public int Index;
            public int[] friendship;
            public int[] AnimationState;
            public int[] rate;
        }

        [Serializable]
        public class SheetBattleConstant
        {
            public BattleConstantKey Key;
            public int IntValue;
            public float FloatValue;
            public string StringValue;
        }

        [Serializable]
        public class SheetAgeEyeBlink
        {
            public TrainerAge age;
            public int min;
            public int max;
            public int twiceRate;
        }

        [Serializable]
        public class SheetDisableBlinkPokemon
        {
            public int id;
            public MonsNo MonsNo;
        }

        [Serializable]
        public class SheetPokemonMotionBlendTime
        {
            public int id;
            public MonsNo MonsNo;
            public float Damege;
        }

        [Serializable]
        public class SheetInterpolationSequence
        {
            public int id;
            public string SeqFile;
        }
    }
}