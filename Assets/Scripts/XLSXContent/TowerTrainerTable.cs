using Dpr.Trainer;
using Pml.PokePara;
using Pml;
using System;
using UnityEngine;

namespace XLSXContent
{
    [Serializable]
    public class TowerTrainerTable : ScriptableObject
    {
        public SheetTrainerData[] TrainerData;
        public SheetTrainerPoke[] TrainerPoke;

        public SheetTrainerData this[int index] => TrainerData[index];

        [Serializable]
        public class SheetTrainerData
        {
            public TrainerType TrainerType;
            public string NameLabel;
            public string MsgFieldBefore;
            public string[] MsgBattle;
            public string[] SeqBattle;
            public byte ColorID;
            public int fldGraphic;
            public string singleEnc;
            public string doubleEnc;
        }

        [Serializable]
        public class SheetTrainerPoke
        {
            public uint ID;
            public MonsNo MonsNo;
            public ushort FormNo;
            public bool IsRare;
            public byte Level;
            public Sex Sex;
            public Seikaku Seikaku;
            public TokuseiNo Tokusei;
            public WazaNo Waza1;
            public WazaNo Waza2;
            public WazaNo Waza3;
            public WazaNo Waza4;
            public ItemNo Item;
            public BallId Ball;
            public SealTemplateID Seal;
            public byte TalentHp;
            public byte TalentAtk;
            public byte TalentDef;
            public byte TalentSpAtk;
            public byte TalentSpDef;
            public byte TalentAgi;
            public byte EffortHp;
            public byte EffortAtk;
            public byte EffortDef;
            public byte EffortSpAtk;
            public byte EffortSpDef;
            public byte EffortAgi;
        }
    }
}