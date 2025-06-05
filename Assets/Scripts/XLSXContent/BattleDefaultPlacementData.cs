using System;
using Dpr.Battle.Logic;
using Dpr.SequenceEditor;
using UnityEngine;

namespace XLSXContent
{
    [Serializable]
    public class BattleDefaultPlacementData : ScriptableObject
    {
        public SheetDefaultCharaPlacementData[] DefaultCharaPlacementData;
        public SheetDefaultCameraPlacementData[] DefaultCameraPlacementData;

        public SheetDefaultCharaPlacementData this[int index] => DefaultCharaPlacementData[index];

        [Serializable]
        public class SheetDefaultCharaPlacementData
        {
            public BtlRule BtlRule;
            public BtlvPos BtlvPos;
            public Pml.PokePara.Size Size;
            public Vector3 PokePos;
            public Vector3 TrainerPos;
            public int RotY;
            public SEQ_DEF_DEFAULT_PLACEMENT UseSituation;
        }

        [Serializable]
        public class SheetDefaultCameraPlacementData
        {
            public BtlRule BtlRule;
            public Pml.PokePara.Size PokeSizeP;
            public Pml.PokePara.Size PokeSizeE;
            public Vector3 MainCamPos;
            public Vector3 MainCamRot;
            public float MainCamNear;
            public float MainCamFar;
            public float MainCamFov;
            public Vector3 SubCamPos;
            public Vector3 SubCamRot;
            public float SubCamNear;
            public float SubCamFar;
            public float SubCamFov;
        }
    }
}