using DPData;
using Dpr.Message;
using Dpr.SubContents;
using Pml;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using XLSXContent;
using System;

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

        public void UpdateStatueParam()
        {
            GetStatues();
            CalcStatueData();
        }

        public void UpdateIcons()
        {
            ClearIcons();

            var maxValues = new List<(int, int)>();
            var dupeList = new List<(int, int)>(maxValues);

            for (int i=0; i<secretBases.Count; i++)
                maxValues.Add(GetMaxStatueEff(secretBases[i]));

            for (int i=0; i<maxValues.Count; i++)
            {
                var pokeType = maxValues[i].Item1;
                var value = maxValues[i].Item2;

                var go = Instantiate(IconPrefab, IconsParent);
                go.SetActive(true);

                var buffIcon = go.GetComponent<UIStatueBuffIcon>();
                buffIcon.SetData(pokeType, value, IconAtlas);
                Icons.Add(buffIcon);
            }
        }

        public void ClearIcons()
        {
            Icons.ForEach(x => Destroy(x.gameObject));
            Icons.Clear();
        }

        public void GetStatues()
        {
            secretBases.Clear();
            secretBases.Add(UgFieldManager.Instance.EffectiveBase);
        }

        public void ClearSecBase()
        {
            PlayerWork.UgRecord.myBase = default;
        }

        private void CalcStatueData()
        {
            statueGridNum = 0;
            AddTypeKakurituDic.Clear();

            for (int i=0; i<secretBases.Count; i++)
            {
                var secretBase = secretBases[i];

                if (secretBase.isNull)
                    continue;

                for (int j=0; j<secretBase.ugStoneStatue.Length; j++)
                {
                    var ugStoneStatue = secretBase.ugStoneStatue[j];
                    var id = ugStoneStatue.statueId;

                    if (id == 0)
                        continue;

                    var statue = Array.Find(UgFieldManager.Instance.ugStatueEffectData.table, x => id == x.statueId);

                    if (statue == null)
                        continue;

                    // Result ignored
                    _ = MessageManager.Instance.GetNameMessage(MessageDataConstants.MONSNAME_FILE_NAME, statue.monsId);

                    if (statue.type1Id != -1)
                    {
                        if (AddTypeKakurituDic.ContainsKey(statue.type1Id))
                            AddTypeKakurituDic[statue.type1Id] += statue.pokeTypeEffect[0];
                        else
                            AddTypeKakurituDic.Add(statue.type1Id, statue.pokeTypeEffect[0]);
                    }

                    if (statue.type2Id != -1)
                    {
                        if (AddTypeKakurituDic.ContainsKey(statue.type2Id))
                            AddTypeKakurituDic[statue.type2Id] += statue.pokeTypeEffect[1];
                        else
                            AddTypeKakurituDic.Add(statue.type2Id, statue.pokeTypeEffect[1]);
                    }

                    statueGridNum += statue.height * statue.width;
                }
            }
        }

        public (int, int) GetMaxStatueEff(UgSecretBase Base)
        {
            var typeScores = new int[(int)PokeType.MAX];

            for (int i=0; i<Base.ugStoneStatue.Length; i++)
            {
                var id = Base.ugStoneStatue[i].statueId;

                if (id == 0)
                    continue;

                var statue = Array.Find(UgFieldManager.Instance.ugStatueEffectData.table, x => id == x.statueId);
                if (statue != null)
                {
                    if (statue.type1Id != -1)
                        typeScores[statue.type1Id] += statue.pokeTypeEffect[0];
                    if (statue.type2Id != -1)
                        typeScores[statue.type2Id] += statue.pokeTypeEffect[1];
                }
            }

            var result = (0, 0);

            for (int i=0; i<typeScores.Length; i++)
            {
                if (result.Item2 < typeScores[i])
                {
                    result.Item1 = i;
                    result.Item2 = typeScores[i];
                }
            }

            return result;
        }

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

        public void OnDestroy()
        {
            IconsParent = null;
            IconPrefab = null;

            Icons.Clear();
            Icons = null;

            IconAtlas = null;

            Utils.ArrayDestroy(DebugPokeSlots);

            AddTypeKakurituDic.Clear();
            AddTypeKakurituDic = null;

            secretBases.Clear();
            secretBases = null;
        }
    }
}