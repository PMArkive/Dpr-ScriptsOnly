using Dpr.SubContents;
using Pml;
using Pml.Personal;
using Pml.PokePara;
using System;
using System.Collections.Generic;
using System.Text;
using Ug;
using UnityEngine;
using XLSXContent;
using static Dpr.EvScript.EvWork;

namespace Dpr.UnderGround
{
    public class UgPokeLottery
    {
        private UgRandMark.Sheettable randMarkData;
        private UgEncount monsData;
        private List<KeyValuePair<TypeAndSize, int>> MonsDataIndexs = new List<KeyValuePair<TypeAndSize, int>>();
        private List<ushort> buf_wazaTable = new List<ushort>();

        public List<PokeSlot> DoLottery(int randMarkID)
        {
            randMarkData = Array.Find(UgResManager.UgRandMark.table, x => x.id == randMarkID);
            monsData = UgResManager.GetUgEncount(randMarkID);

            // Returns all the enabled mons from the relevant UgEncount file and adds them to MonsDataIndexs
            UgEncount.Sheettable[] origList = GetEnablePokes(GetVersionNo(), GetStoryNo());

            // Number from 0-30 based on amount of statues?
            int statueBoost = UgFieldManager.Instance.statueBuff.GetPlusSlotNum();

            // Roll for if we have the minimum amount of slots or maximum
            int slotCountRoll = UnityEngine.Random.Range(0, 100);
            int Num = randMarkData.min;
            if (slotCountRoll < 50 + statueBoost)
            {
                Num = randMarkData.max;
            }

            int rarePokeRoll = UnityEngine.Random.Range(0, 100);
            bool hideoutFlag = FlagWork.GetFlag(FLAG_INDEX.FE_DONE_KAKUREGA);

            MonsNo rareMonsno = MonsNo.NULL;
            if (rarePokeRoll < 50 || !hideoutFlag)
            {
                // Returns a monsno of the rare poke to spawn, or 0 if theres none
                rareMonsno = GetRarePoke(randMarkID, PlayerWork.playerData.mystatus.rom_code);
                Num--; // Will still remove a slot even if no eligible rare pokes exist
            }

            List<PokeSlot> slots = CreateSlots(Num);

            byte rareTryCount;
            if (UgFieldManager.Instance.KousekiBonusTime <= 0.0)
            {
                rareTryCount = 1;
            }
            else
            {
                rareTryCount = 2;
            }

            // Fill the slots
            LotteryPoke(origList, slots, rareTryCount);

            // Add the rare mon if there is one
            if (rareMonsno != 0)
            {
                PokeSlot item = new PokeSlot(PokeType.NULL, MonsSize.S);
                item.param = CreatePokemonParam_by_Tokusei(rareMonsno, rareTryCount);
                slots.Add(item);
            }

            return slots;
        }


        private MonsNo GetRarePoke(int randMarkID, int versionID)
        {
            UgSpecialPokemon.SheetSheet1[] allRares = Array.FindAll(UgResManager.UgSpecialPokemon.Sheet1, x => x.id == randMarkID);

            if (allRares.Length == 0)
                return MonsNo.NULL;

            List<PokeRate> rates = new List<PokeRate>();
            foreach (var rare in allRares)
            {
                if (versionID == 0)
                    rates.Add(new PokeRate(rare.monsno, rare.Dspecialrate));
                else
                    rates.Add(new PokeRate(rare.monsno, rare.Pspecialrate));
            }

            string log = "";
            rates.ForEach(poke =>
            {
                if (poke.rate != 0)
                    log += Enum.GetName(typeof(MonsNo), poke.monsNo) + " ";
            });

            // This line (or similar) is presumed to have been commented out.
            //Debug.Log(log);

            return RandomWithWeight.Lotto(rates).monsNo;
        }

        private void LotteryPoke(UgEncount.Sheettable[] origList, List<PokeSlot> slots, byte rareTryCount)
        {
            string log = "";
            foreach (var encount in origList)
            {
                log += Enum.GetName(typeof(MonsNo), encount.monsno) + ", ";
            }

            // This line (or similar) is presumed to have been commented out.
            //Debug.Log(log);

            if (slots.Count < 1)
                return;

            foreach (var slot in slots)
            {
                UgEncount.Sheettable[] filteredSlots = GetFilteredListWithTypeAndSize(origList, slot);
                log = "";
                foreach (var filteredSlot in filteredSlots)
                {
                    log += Enum.GetName(typeof(MonsNo), filteredSlot.monsno) + ", ";
                }

                // This line (or similar) is presumed to have been commented out.
                //Debug.Log(log);

                List<PokeRate> rates = new List<PokeRate>();
                foreach (var filteredSlot in filteredSlots)
                {
                    UgPokemonData.Sheettable monData = UgResManager.GetUgPokeData(filteredSlot.monsno);
                    if (UgFieldManager.Instance.KousekiBonusTime <= 0.0f)
                        rates.Add(new PokeRate(filteredSlot.monsno, monData.flagrate[GetStoryNo() - 1]));
                    else
                        rates.Add(new PokeRate(filteredSlot.monsno, monData.rateup * monData.flagrate[GetStoryNo() - 1]));
                }

                PokeRate rolledRate = RandomWithWeight.Lotto(rates);
                slot.param = CreatePokemonParam_by_Tokusei(rolledRate.monsNo, rareTryCount);
            }
        }

        private PokemonParam CreatePokemonParam_by_Tokusei(MonsNo monsNo, byte rareTryCount)
        {
            ushort level = GetPokeLevel(false);

            if (PlayerWork.playerParty.GetMemberCount() == 0)
                return new PokemonParam(monsNo, level, 0);

            CoreParam lead = PlayerWork.playerParty.GetMemberPointer(0);
            TokuseiNo ability = lead.GetTokuseiNo();
            InitialSpec spec = new InitialSpec();

            int heldItemOdds = 50;

            switch (ability)
            {
                case TokuseiNo.HUKUGAN:
                case TokuseiNo.KYOUUN:
                    heldItemOdds = 60;
                    break;

                case TokuseiNo.SINKURO:
                    spec.seikaku = (ushort)lead.GetSeikaku();
                    break;

                case TokuseiNo.PURESSYAA:
                case TokuseiNo.HARIKIRI:
                case TokuseiNo.YARUKI:
                    level = GetPokeLevel(true);
                    break;

                case TokuseiNo.MEROMEROBODHI:
                    if (UnityEngine.Random.Range(0, 100) < 67)
                    {
                        if (lead.GetSex() == Sex.MALE)
                            spec.sex = (ushort)Sex.FEMALE;
                        else
                            spec.sex = (ushort)Sex.MALE;
                    }
                    break;
            }

            spec.monsno = monsNo;
            spec.level = level;
            spec.rareTryCount = rareTryCount;

            if (UgFieldManager.isForceRareColor)
                spec.rareRnd = InitialSpec.INIT_SPEC_RARE_TRUE;

            if (monsNo == MonsNo.KARANAKUSI || monsNo == MonsNo.TORITODON)
            {
                if (Array.Find(UgResManager.UgMiniMap.Icon, x => x.zoneid == PlayerWork.transitionZoneID).IsEast)
                    spec.formno = 1;
                else
                    spec.formno = 0;
            }

            PokemonParam param = new PokemonParam(spec);
            int heldItemRoll = UnityEngine.Random.Range(0, 100);

            EncountTools.SetWildPokemonItem(param, heldItemRoll, heldItemOdds, 20);
            short wazaNo = GetTamagoWazaNo(param);
            if (wazaNo > -1)
                SetTamagoWaza(param, (ushort)wazaNo);

            return param;
        }

        public short GetTamagoWazaNo(PokemonParam param)
        {
            string log = "";
            for (byte i=0; i<param.GetWazaCount(); i++)
            {
                WazaNo wazaNo = param.GetWazaNo(i);
                log += Enum.GetName(typeof(WazaNo), wazaNo) + "\n";
            }

            // This line (or similar) is presumed to have been commented out.
            //Debug.Log(log);

            TamagoWazaTable eggMoveTable = PmlUse.Instance.TamagoWazaTable;
            PersonalTable.SheetPersonal personalData = PersonalSystem.GetPersonalData(param.GetMonsNo(), param.GetFormNo());
            TamagoWazaTable.SheetData monEggMoveData = Array.Find(eggMoveTable.Data, x => x.no == personalData.egg_monsno);

            buf_wazaTable.Clear();
            buf_wazaTable.AddRange(monEggMoveData.wazaNo);

            UgTamagoWazaIgnoreTable.SheetSheet1 ugEggMoveData = Array.Find(UgResManager.UgTamagoWazaIgnoreTable.Sheet1, x => x.MonsNo == personalData.egg_monsno);
            if (ugEggMoveData != null)
            {
                foreach (ushort waza in ugEggMoveData.Waza)
                {
                    if (waza != 0)
                        buf_wazaTable.Remove(waza);
                }
            }

            if (buf_wazaTable.Count == 0)
                return -1;
            else
                return (short)buf_wazaTable[UnityEngine.Random.Range(0, buf_wazaTable.Count)];
        }

        public void SetTamagoWaza(PokemonParam param, ushort wazaNo)
        {
            param.SetTamagoWazaNo(0, (WazaNo)wazaNo);
            if (param.AddWazaIfEmptyExist((WazaNo)wazaNo) == WazaLearningResult.FAILED_FULL)
            {
                param.SetWaza(0, (WazaNo)wazaNo);
            }

            string log = "";
            for (byte i=0; i<param.GetWazaCount(); i++)
            {
                WazaNo finalWazaNo = param.GetWazaNo(i);
                log += Enum.GetName(typeof(WazaNo), finalWazaNo) + "\n";
            }

            // This line (or similar) is presumed to have been commented out.
            //Debug.Log(log);
        }

        private UgEncount.Sheettable[] GetEnablePokes(int versionNo, int storyNo)
        {
            UgEncount.Sheettable[] enabledPokes = Array.FindAll(
                Array.FindAll(monsData.table, x => x.version == 1 || x.version == versionNo),
                x => x.zukanflag <= storyNo
            );

            for (int i=0; i<enabledPokes.Length; i++)
            {
                UgEncount.Sheettable poke = enabledPokes[i];
                UgPokemonData.Sheettable mondata = UgResManager.GetUgPokeData(poke.monsno);
                MonsDataIndexs.Add(new KeyValuePair<TypeAndSize, int>(new TypeAndSize((PokeType)mondata.type1ID, mondata.size), i));

                if (mondata.type2ID != -1)
                {
                    MonsDataIndexs.Add(new KeyValuePair<TypeAndSize, int>(new TypeAndSize((PokeType)mondata.type2ID, mondata.size), i));
                }
            }

            return enabledPokes;
        }

        private UgEncount.Sheettable[] GetFilteredListWithTypeAndSize(UgEncount.Sheettable[] list, PokeSlot slot)
        {
            List<KeyValuePair<TypeAndSize, int>> foundSlots = MonsDataIndexs.FindAll(x => x.Equals(slot.ts));
            List<UgEncount.Sheettable> typeSizeList = new List<UgEncount.Sheettable>();
            foundSlots.ForEach(x => typeSizeList.Add(list[x.Value]));
            return typeSizeList.ToArray();
        }

        private List<PokeSlot> CreateSlots(int Num)
        {
            List<PokeSlot> finalList = new List<PokeSlot>();
            int[] array = new int[18];
            this.randMarkData.typerate.CopyTo(array, 0);

            StringBuilder sb = new StringBuilder();
            sb.Append("タイプ抽選加算値\n");

            // Add extra weight to types that have statues
            for (int i = 0; i < array.Length; i++)
            {
                if (UgFieldManager.Instance.statueBuff.AddTypeKakurituDic.ContainsKey(i))
                {
                    int arrayItem = array[i];
                    int dictItem = UgFieldManager.Instance.statueBuff.AddTypeKakurituDic[i];
                    array[i] = arrayItem + dictItem;
                    sb.Append(Enum.GetName(typeof(PokeType), i) + ":");
                    sb.Append(dictItem);
                    sb.Append("\n");
                }
            }

            // This line (or similar) is presumed to have been commented out.
            var log = sb.ToString();
            //Debug.Log(log);
            sb.Clear();

            // Only consider types that actually have available mons
            List<TypeRate> typeWeights = new List<TypeRate>();
            for (int i = 0; i < array.Length; i++)
            {
                if (this.MonsDataIndexs.Exists(x => x.Key.type == (PokeType)i))
                {
                    TypeRate typeRate = new TypeRate((PokeType)i, array[i]);
                    typeWeights.Add(typeRate);
                    sb.Append(Enum.GetName(typeof(PokeType), i) + ":");
                    sb.Append(array[i]);
                    sb.Append("\n");
                }
            }

            // This line (or similar) is presumed to have been commented out.
            log = sb.ToString();
            Debug.Log(log);

            List<MonsSize> sizes = new List<MonsSize>();
            for (int i = 0; i < randMarkData.smax; i++)
            {
                sizes.Add(MonsSize.S);
            }
            for (int i = 0; i < randMarkData.mmax; i++)
            {
                sizes.Add(MonsSize.M);
            }
            for (int i = 0; i < randMarkData.lmax; i++)
            {
                sizes.Add(MonsSize.L);
            }
            for (int i = 0; i < randMarkData.llmax; i++)
            {
                sizes.Add(MonsSize.LL);
            }

            for (int i = 0; i < Num; i++)
            {
                TypeRate rolledTypeRate = RandomWithWeight.Lotto(typeWeights);
                List<KeyValuePair<TypeAndSize, int>> foundAll = MonsDataIndexs.FindAll(x => x.Key.type == rolledTypeRate.type);

                List<MonsSize> existSizeList = new List<MonsSize>();

                foundAll.ForEach(x => {
                    if (!existSizeList.Exists(s => x.Key.size == s))
                    {
                        existSizeList.Add(x.Key.size);
                    }
                });

                sizes.RemoveAll(s => existSizeList.Exists(x => s != x));

                MonsSize randomSize = GetRandomSize(sizes, existSizeList);
                finalList.Add(new PokeSlot(rolledTypeRate.type, randomSize));
            }

            return finalList;
        }

        private MonsSize GetRandomSize(List<MonsSize> list, List<MonsSize> existSizeList)
        {
            if (list.Count == 0)
            {
                return existSizeList[UnityEngine.Random.Range(0, existSizeList.Count)];
            }
            else
            {
                int roll = UnityEngine.Random.Range(0, list.Count);
                MonsSize result = list[roll];
                list.RemoveAt(roll);
                return result;
            }

        }

        private int GetStoryNo()
        {
            int result = 1;

            if (FlagWork.GetFlag(FLAG_INDEX.FE_HIDEN_04_GET))
                result = 2;

            if (FlagWork.GetFlag(FLAG_INDEX.FE_HIDEN_05_GET))
                result = 3;

            if (FlagWork.GetSysFlag(SYSFLAG_INDEX.BADGE_ID_C09))
                result = 4;

            if (FlagWork.GetFlag(FLAG_INDEX.FE_HIDEN_07_GET))
                result = 5;
            
            if (PlayerWork.zukan.zenkoku_flag)
                result = 6;

            return result;
        }

        private int GetVersionNo()
        {
            return PlayerWork.playerData.mystatus.rom_code + 2;
        }

        private ushort GetPokeLevel(bool SelectForceMax = false)
        {
            int badges = FlagWork.BadgeCount();
            int hallOfFameWork = FlagWork.GetWork(WORK_INDEX.WK_SCENE_DENDOU);

            int index = 0;
            if (badges > 0)
                index = badges - 1;
            if (hallOfFameWork > 0)
                index = 8;

            UgEncountLevel.SheetData levelData = UgResManager.UgEncountLevel.Data[index];

            if (SelectForceMax)
                return (ushort)levelData.MaxLv;

            return (ushort)UnityEngine.Random.Range(levelData.MinLv, levelData.MaxLv + 1);
        }

        public class PokeSlot
        {
	        public PokemonParam param;
            public TypeAndSize ts;

            public PokeType type { get => ts.type; }
            public MonsSize size { get => ts.size; }

            public PokeSlot(PokeType type, MonsSize size)
            {
                this.ts.type = type;
                this.ts.size = size;
                this.ts.value = (int)Mathf.Pow(10.0f, (float)size);
            }
        }

        // Not sure why Equals was overriden
        public struct TypeAndSize
        {
            public MonsSize size;
            public PokeType type;
            public int value;

            public TypeAndSize(PokeType type, MonsSize size)
            {
                this.type = type;
                this.size = size;
                this.value = (int)Mathf.Pow(10.0f, (float)size) + (int)type;
            }

            public override bool Equals(object obj)
            {
                if (GetType().Equals(obj.GetType()))
                {
                    TypeAndSize other = (TypeAndSize)obj;
                    return this.value == other.value;
                }

                return false;
            }

            public override int GetHashCode()
            {
                return value;
            }
        }

        public struct TypeRate : IHaveWeight
        {
            public PokeType type;
            public int rate;

            float IHaveWeight.lotteryWeight { get => rate; }

            public TypeRate(PokeType type, int rate)
            {
                this.type = type;
                this.rate = rate;
            }
        }

        public struct PokeRate : IHaveWeight
        {
            public MonsNo monsNo;
            public int rate;

            float IHaveWeight.lotteryWeight { get => rate; }

            public PokeRate(MonsNo monsNo, int rate)
            {
                this.monsNo = monsNo;
                this.rate = rate;
            }
        }
    }
}
