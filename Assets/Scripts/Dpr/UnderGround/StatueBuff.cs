using DPData;
using Dpr.SubContents;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using XLSXContent;

namespace Dpr.UnderGround
{
    public class StatueBuff : MonoBehaviour
    {
        public Transform IconsParent;
        public GameObject IconPrefab;
        public List<UIStatueBuffIcon> Icons;
        public SpriteAtlas IconAtlas;
        private int statueGridNum;
        public UgPokeLottery.PokeSlot[] DebugPokeSlots;
        public Dictionary<int, int> AddTypeKakurituDic = new Dictionary<int, int>();
        private List<UgSecretBase> secretBases = new List<UgSecretBase>();

        [Button("UpdateIcons", "UpdateIcons", new object[0] { })]
        public int Button01;
        [Button("ClearSecBase", "ClearSecBase", new object[0] { })]
        public int Button02;
        [Button("CalcStatueData", "CalcStatueData", new object[0] { })]
        public int Button03;

        private StatueEffectRawData statueData { get => UgFieldManager.Instance.ugStatueEffectData; }

        public int GetPlusSlotNum()
        {
            if (statueGridNum < 1)
                return 0;

            if (statueGridNum < 16)
                return 5;

            if (statueGridNum < 31)
                return 10;

            if (statueGridNum < 46)
                return 15;
            
            if (statueGridNum < 61)
                return 20;

            return 30;
        }
    }
}