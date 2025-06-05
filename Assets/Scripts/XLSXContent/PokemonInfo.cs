using Pml;
using Pml.PokePara;
using System;
using Ug;
using UnityEngine;

namespace XLSXContent
{
    [Serializable]
    public class PokemonInfo : ScriptableObject
    {
        public SheetCatalog[] Catalog;
        public SheetTrearuki[] Trearuki;

        public SheetCatalog this[int index] => Catalog[index];

        [Serializable]
        public class SheetCatalog
        {
            public int UniqueID;
            public int No;
            public int SinnohNo;
            public MonsNo MonsNo;
            public int FormNo;
            public Sex Sex;
            public bool Rare;
            public string AssetBundleName;
            public float BattleScale;
            public float ContestScale;
            public Size ContestSize;
            public float FieldScale;
            public float FieldChikaScale;
            public float StatueScale;
            public float FieldWalkingScale;
            public float FieldFureaiScale;
            public float MenuScale;
            public string ModelMotion;
            public Vector3 ModelOffset;
            public Vector3 ModelRotationAngle;
            public float DistributionScale;
            public string DistributionModelMotion;
            public Vector3 DistributionModelOffset;
            public Vector3 DistributionModelRotationAngle;
            public float VoiceScale;
            public string VoiceModelMotion;
            public Vector3 VoiceModelOffset;
            public Vector3 VoiceModelRotationAngle;
            public Vector3 CenterPointOffset;
            public Vector2 RotationLimitAngle;
            public float StatusScale;
            public string StatusModelMotion;
            public Vector3 StatusModelOffset;
            public Vector3 StatusModelRotationAngle;
            public float BoxScale;
            public string BoxModelMotion;
            public Vector3 BoxModelOffset;
            public Vector3 BoxModelRotationAngle;
            public float CompareScale;
            public string CompareModelMotion;
            public Vector3 CompareModelOffset;
            public Vector3 CompareModelRotationAngle;
            public float BrakeStart;
            public float BrakeEnd;
            public float WalkSpeed;
            public float RunSpeed;
            public float WalkStart;
            public float RunStart;
            public float BodySize;
            public float AppearLimit;
            public MoveType MoveType;
            public bool GroundEffect;
            public bool Waitmoving;
            public int BattleAjustHeight;
        }

        [Serializable]
        public class SheetTrearuki
        {
            public bool Enable;
            public int[] AnimeIndex;
            public float[] AnimeDuration;
        }
    }
}