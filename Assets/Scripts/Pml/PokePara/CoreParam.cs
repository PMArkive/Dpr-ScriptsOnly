using Pml.Personal;
using Pml.WazaData;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Pml.PokePara
{
    public class CoreParam
    {
        public const int DATASIZE = 328;
        private static byte[] sCoreSerializeBuffer = new byte[DATASIZE];
        private const byte TOKUSEI_INDEX_ERROR = 255;
        public const byte BIRTH_FRIENDSHIP = 100;
        protected byte[] m_coreData;
        protected byte[] m_calcData;
        protected Accessor m_accessor;

        public byte[] GetCoreData()
        {
            return m_coreData;
        }

        public byte[] GetCalcData()
        {
            return m_calcData;
        }

        public Accessor GetAccessor()
        {
            return m_accessor;
        }

        public static sbyte GetPowerTransformBySeikaku(ushort seikaku, PowerID powerId)
        {
            return CalcTool.GetPowerTransformBySeikaku(seikaku, powerId);
        }

        public static void CheckPublicDataSize()
        {
            GFL.ASSERT(true);
        }

        public static bool IsRareFromValue(uint id, uint colorRnd)
        {
            return CalcTool.IsRareColor(id, colorRnd);
        }

        public uint GetPower(PowerID powerId)
        {
            switch (powerId)
            {
                case PowerID.HP:
                    return GetMaxHp();

                case PowerID.ATK:
                    return GetAtk();

                case PowerID.DEF:
                    return GetDef();

                case PowerID.SPATK:
                    return GetSpAtk();

                case PowerID.SPDEF:
                    return GetSpDef();

                case PowerID.AGI:
                    return GetAgi();

                default:
                    GFL.ASSERT(false);
                    return 0;
            }
        }

        public uint GetMaxHp()
        {
            if (HaveCalcParam())
                return m_accessor.GetMaxHp();

            return CalcMaxHp();
        }

        public uint GetHp()
        {
            if (HaveCalcParam())
                return m_accessor.GetHp();

            return CalcMaxHp();
        }

        public void SetHp(uint value)
        {
            var max = m_accessor.GetMaxHp();
            var newhp = (ushort)(value <= max ? value : max);
            m_accessor.SetHp(newhp);
        }

        public void ReduceHp(uint value)
        {
            var max = m_accessor.GetMaxHp();
            var newhp = (ushort)((value > max || max - value == 0) ? 0 : (max - value));
            m_accessor.SetHp(newhp);
        }

        public void ReduceNowHp(uint value)
        {
            var max = m_accessor.GetMaxHp();
            var curr = m_accessor.GetHp();

            var newhp = (ushort)((curr - value <= max) ? (curr - value) : max);
            newhp = (ushort)((curr <= value) ? 0 : newhp);

            m_accessor.SetHp(newhp);
        }

        public void RecoverHp(uint value)
        {
            var max = m_accessor.GetMaxHp();
            var curr = m_accessor.GetHp();

            var newhp = (ushort)((curr + value <= max) ? (curr + value) : max);

            m_accessor.SetHp(newhp);
        }

        public void RecoverHpFull()
        {
            m_accessor.SetHp((ushort)m_accessor.GetMaxHp());
        }

        public bool IsHpFull()
        {
            if (HaveCalcParam())
                return m_accessor.GetHp() == m_accessor.GetMaxHp();
            else
                return true;
        }

        public bool IsHpZero()
        {
            if (HaveCalcParam())
                return m_accessor.GetHp() == 0;

            return false;
        }

        public void RecoverAll()
        {
            RecoverHpFull();
            RecoverSick();
            RecoverWazaPPAll();
        }

        public void SetMaxHp(uint value)
        {
            m_accessor.SetMaxHp((ushort)value);
        }

        protected void SetAtk(ushort value)
        {
            m_accessor.SetAtk(value);
        }

        protected void SetDef(ushort value)
        {
            m_accessor.SetDef(value);
        }

        protected void SetSpAtk(ushort value)
        {
            m_accessor.SetSpAtk(value);
        }

        protected void SetSpDef(ushort value)
        {
            m_accessor.SetSpDef(value);
        }

        protected void SetAgi(ushort value)
        {
            m_accessor.SetAgi(value);
        }

        public bool HaveSick()
        {
            return GetSick() != Sick.NONE;
        }

        public Sick GetSick()
        {
            return (Sick)m_accessor.GetSick();
        }

        public void SetSick(Sick sick)
        {
            m_accessor.SetSick((uint)sick);
        }

        public void RecoverSick()
        {
            m_accessor.SetSick(0);
        }

        public uint GetLevel()
        {
            if (HaveCalcParam())
                return m_accessor.GetLevel();

            return CalcLevel();
        }

        public uint GetExp()
        {
            return m_accessor.GetExp();
        }

        // TODO
        public void SetExp(uint value) { }

        // TODO
        public void AddExp(uint value) { }

        // TODO
        public uint GetExpForCurrentLevel() { return 0; }

        // TODO
        public uint GetExpForNextLevel() { return 0; }

        // TODO
        public void LevelUp(byte upVal) { }

        // TODO
        public uint GetBasicPower(PowerID powerID) { return 0; }

        // TODO
        public uint GetNativeTalentPower(PowerID powerId) { return 0; }

        // TODO
        public uint GetTalentPower(PowerID powerId) { return 0; }

        // TODO
        public void ChangeTalentPower(PowerID powerId, uint value) { }

        // TODO
        public uint GetTalentPowerMaxNum() { return 0; }

        // TODO
        public bool IsTrainingDone(PowerID powerId) { return false; }

        // TODO
        public void SetTrainingDone(PowerID powerId) { }

        // TODO
        public uint GetEffortPower(PowerID powerId) { return 0; }

        public uint GetTotalEffortPower()
        {
            return m_accessor.GetEffortHp() +
                m_accessor.GetEffortAtk() +
                m_accessor.GetEffortDef() +
                m_accessor.GetEffortSpAtk() +
                m_accessor.GetEffortSpDef() +
                m_accessor.GetEffortAgi();
        }

        // TODO
        public void ChangeEffortPower(PowerID powerId, uint value) { }

        // TODO
        public void AddEffortPower(PowerID powerId, uint value) { }

        // TODO
        public void SubEffortPower(PowerID powerId, uint value) { }

        public GState GetGState()
        {
            if (HaveCalcParam())
                return m_accessor.GetGState();

            return GState.NONE;
        }

        public void SetGState(GState state)
        {
            if (HaveCalcParam())
            {
                m_accessor.SetGState(state);
                UpdateCalcDatas();
            }
        }

        public bool IsG()
        {
            if (HaveCalcParam())
            {
                var state = GetGState();
                return state == GState.G_GENERAL || state == GState.G_SPECIAL;
            }

            return false;
        }

        // TODO
        public void ChangeEffortG(byte value) { }

        // TODO
        public byte GetEffortG() { return 0; }

        // TODO
        public void AddEffortG(uint value) { }

        // TODO
        public void SubEffortG(uint value) { }

        // TODO
        public uint GetPower_G(PowerID powerID) { return 0; }

        // TODO
        public uint GetPower_NotG(PowerID powerID) { return 0; }

        // TODO
        public bool IsSpecialGEnable() { return false; }

        // TODO
        public void SetSpecialGEnable() { }

        // TODO
        public void SetSpecialGDisable() { }

        public MonsNo GetMonsNo()
        {
            return m_accessor.GetMonsNo();
        }

        public ushort GetFormNo()
        {
            return m_accessor.GetFormNo();
        }

        // TODO
        public void ChangeMonsNo(MonsNo newMonsno, ushort newFormno) { }

        public WazaNo GetWazaNo(byte index)
        {
            return m_accessor.GetWazaNo(index);
        }

        public byte GetWazaCount()
        {
            byte count = 0;

            if (GetWazaNo(0) != WazaNo.NULL)
                count++;
            if (GetWazaNo(1) != WazaNo.NULL)
                count++;
            if (GetWazaNo(2) != WazaNo.NULL)
                count++;
            if (GetWazaNo(3) != WazaNo.NULL)
                count++;

            return count;
        }

        public bool HaveWaza(WazaNo wazano)
        {
            return GetWazaIndex(wazano) != 4;
        }

        public byte GetWazaIndex(WazaNo wazano)
        {
            if (GetWazaNo(0) == wazano)
                return 0;
            else if (GetWazaNo(1) == wazano)
                return 1;
            else if (GetWazaNo(2) == wazano)
                return 2;
            else if (GetWazaNo(3) == wazano)
                return 3;
            else
                return 4;
        }

        // TODO
        public void SetDefaultWaza() { }

        public void PushWaza(WazaNo wazano)
        {
            if (HaveWaza(wazano))
                return;

            var count = GetWazaCount();
            if (count == PmlConstants.MAX_WAZA_NUM)
            {
                m_accessor.SetWazaNo(0, (uint)m_accessor.GetWazaNo(1));
                m_accessor.SetPP(0, m_accessor.GetPP(1));
                m_accessor.SetWazaPPUpCount(0, m_accessor.GetWazaPPUpCount(1));

                m_accessor.SetWazaNo(1, (uint)m_accessor.GetWazaNo(2));
                m_accessor.SetPP(1, m_accessor.GetPP(2));
                m_accessor.SetWazaPPUpCount(1, m_accessor.GetWazaPPUpCount(2));

                m_accessor.SetWazaNo(2, (uint)m_accessor.GetWazaNo(3));
                m_accessor.SetPP(2, m_accessor.GetPP(3));
                m_accessor.SetWazaPPUpCount(2, m_accessor.GetWazaPPUpCount(3));

                count = 3;
            }

            SetWaza(count, wazano);
        }

        public void SetWaza(byte wazaIndex, WazaNo wazano)
        {
            if (wazaIndex < PmlConstants.MAX_WAZA_NUM)
            {
                var pp = WazaDataSystem.s_wazaTable[(int)wazano].basePP;
                m_accessor.SetWazaNo(wazaIndex, (uint)wazano);
                m_accessor.SetWazaPPUpCount(wazaIndex, 0);
                m_accessor.SetPP(wazaIndex, pp);
            }
            else
            {
                GFL.ASSERT(false);
            }
        }

        // TODO
        public void RemoveWaza(byte wazaIndex) { }

        // TODO
        public void RemoveDuplicatedWaza() { }

        // TODO
        public void ExchangeWazaPos(byte pos1, byte pos2) { }

        // TODO
        public void CloseUpWazaPos() { }

        // TODO
        public bool CheckWazaMachine(uint machineNo) { return false; }

        // TODO
        public bool CheckWazaRecord(uint recordNo) { return false; }

        // TODO
        public bool CheckWazaOshie(uint oshieNo) { return false; }

        // TODO
        public bool CheckWazaOshie(WazaNo wazano) { return false; }

        // TODO
        public WazaNo GetTamagoWazaNo(byte index) { return WazaNo.NULL; }

        public void SetTamagoWazaNo(byte index, WazaNo wazano)
        {
            if (index < PmlConstants.MAX_WAZA_NUM)
                m_accessor.SetTamagoWazaNo(index, (uint)wazano);
            else
                GFL.ASSERT(false);
        }

        // TODO
        public void ClearTamagoWaza() { }

        // TODO
        public void InheriteTamagoWaza(CoreParam teacher) { }

        // TODO
        public WazaLearningResult AddWazaIfEmptyExist(WazaNo wazano) { return WazaLearningResult.SUCCEEDED; }

        // TODO
        public WazaLearningResult LearnNewWazaOnCurrentLevel(ref uint sameLevelIndex, ref WazaNo newWazano, [Optional] WazaLearnWork work) { return WazaLearningResult.SUCCEEDED; }

        // TODO
        public WazaLearningResult LearnNewWazaOnLevel(byte level, ref uint sameLevelIndex, ref WazaNo newWazano, [Optional] WazaLearnWork work) { return WazaLearningResult.SUCCEEDED; }

        // TODO
        public WazaLearningResult LearnNewWazaOnEvolution(ref uint learnIndex, ref WazaNo newWazano, [Optional] WazaLearnWork work) { return WazaLearningResult.SUCCEEDED; }

        // TODO
        public HashSet<WazaNo> CollectRemindableWaza()
        {
            // TODO
            void CheckAndAddWazaNo(HashSet<WazaNo> list, WazaNo wazaNo) { }

            return default;
        }

        public uint GetWazaPP(byte wazaIndex)
        {
            return m_accessor.GetPP(wazaIndex);
        }

        public uint GetWazaMaxPP(byte index)
        {
            return WazaDataSystem.GetMaxPP(GetWazaNo(index), GetWazaPPUpCount(index));
        }

        public void SetWazaPP(byte wazaIndex, byte value)
        {
            var max = GetWazaMaxPP(wazaIndex);
            m_accessor.SetPP(wazaIndex, (byte)((value <= max) ? value : max));
        }

        // TODO
        public void ReduceWazaPP(byte wazaIndex, byte value) { }

        public void RecoverWazaPP(byte wazaIndex)
        {
            RecoverWazaPP(wazaIndex, (byte)GetWazaMaxPP(wazaIndex));
        }

        public void RecoverWazaPP(byte wazaIndex, byte recvValue)
        {
            if (m_accessor.GetWazaNo(wazaIndex) == WazaNo.NULL)
                return;

            var val = Math.Min(GetWazaPP(wazaIndex) + recvValue, GetWazaMaxPP(wazaIndex));
            SetWazaPP(wazaIndex, (byte)val);
        }

        public void RecoverWazaPPAll()
        {
            RecoverWazaPP(0);
            RecoverWazaPP(1);
            RecoverWazaPP(2);
            RecoverWazaPP(3);
        }

        // TODO
        public bool CanUsePointUp(byte wazaIndex) { return false; }

        // TODO
        public void UsePointUp(byte wazaIndex) { }

        public uint GetWazaPPUpCount(byte wazaIndex)
        {
            return m_accessor.GetWazaPPUpCount(wazaIndex);
        }

        // TODO
        public void SetWazaPPUpCount(byte wazaIndex, byte value) { }

        // TODO
        public void IncWazaPPUpCount(byte wazaIndex) { }

        // TODO
        public bool GetWazaRecordFlag(byte recordIndex) { return false; }

        // TODO
        public void SetWazaRecordFlag(byte recordIndex) { }

        // TODO
        public void RemoveWazaRecordFlag(byte recordIndex) { }

        // TODO
        public void ClearWazaRecordFlag() { }

        public void ClearBankUniqueID()
        {
            m_accessor.ClearBankUniqueID();
        }

        // TODO
        public ulong GetBankUniqueID() { return 0; }

        // TODO
        public void SetBankUniqueID(ulong value) { }

        public Sex GetSex()
        {
            return m_accessor.GetSex();
        }

        // TODO
        public byte GetSexVector() { return 0; }

        // TODO
        public SexType GetSexType() { return SexType.RANDOM; }

        // TODO
        public void ChangeSex(Sex newSex) { }

        // TODO
        public Seikaku GetSeikaku() { return Seikaku.GANBARIYA; }

        // TODO
        public void ChangeSeikaku(Seikaku seikaku) { }

        // TODO
        public bool IsSeikakuHigh() { return false; }

        // TODO
        public bool IsSeikakuLow() { return false; }

        // TODO
        public Seikaku GetSeikakuHosei() { return Seikaku.GANBARIYA; }

        // TODO
        public void ChangeSeikakuHosei(Seikaku seikaku) { }

        // TODO
        public TokuseiNo GetTokuseiNo() { return TokuseiNo.NULL; }

        // TODO
        public byte GetTokuseiIndex() { return 0; }

        // TODO
        public byte GetTokuseiIndexStrict() { return 0; }

        // TODO
        public void FlipTokuseiIndex() { }

        // TODO
        public void SetTokusei3rd() { }

        // TODO
        public void SetTokuseiIndex(byte tokuseiIndex) { }

        // TODO
        public void SetFavoriteFlag(bool flag) { }

        // TODO
        public bool GetFavoriteFlag() { return false; }

        // TODO
        public bool CompareOwnerInfo(OwnerInfo ownerInfo) { return false; }

        // TODO
        public bool UpdateOwnerInfo(OwnerInfo ownerInfo) { return false; }

        public bool IsOwnedOriginalParent()
        {
            return !m_accessor.GetOwnedOthersFlag();
        }

        // TODO
        public bool HaveNickName() { return false; }

        public string GetNickName()
        {
            return m_accessor.GetNickName();
        }

        // TODO
        public void SetNickName(string nickName) { }

        // TODO
        public void SetDefaultNickName() { }

        // TODO
        public bool IsDefaultNickName() { return false; }

        // TODO
        public uint GetFriendship() { return 0; }

        // TODO
        public void SetFriendship(uint value) { }

        // TODO
        public void AddFriendship(uint value) { }

        // TODO
        public void SubFriendship(uint value) { }

        // TODO
        public uint GetOriginalFriendship() { return 0; }

        // TODO
        public void SetOriginalFriendship(uint value) { }

        // TODO
        public void AddOriginalFriendship(uint value) { }

        // TODO
        public void SubOriginalFriendship(uint value) { }

        // TODO
        public ushort GetOthersFriendshipTrainerID() { return 0; }

        // TODO
        public uint GetOthersFriendship() { return 0; }

        // TODO
        public void SetOthersFriendship(uint value) { }

        // TODO
        public void AddOthersFriendship(uint value) { }

        // TODO
        public void SubOthersFriendship(uint value) { }

        public bool IsEgg(EggCheckType type)
        {
            bool egg = m_accessor.IsTamago();
            bool badEgg = m_accessor.IsFuseiTamago();

            switch (type)
            {
                case EggCheckType.ONLY_LEGAL_EGG:
                    return egg && !badEgg;
                case EggCheckType.ONLY_ILLEGAL_EGG:
                    return badEgg;
                case EggCheckType.BOTH_EGG:
                    return egg || badEgg;
                default:
                    GFL.ASSERT(false);
                    return false;
            }
        }

        public void SetEggFlag()
        {
            bool egg = m_accessor.IsTamago();
            bool badEgg = m_accessor.IsFuseiTamago();

            if (!badEgg)
                m_accessor.SetTamagoFlag(true);
        }

        // TODO
        public void ChangeEgg() { }

        // TODO
        public void Birth() { }

        public ushort GetItem()
        {
            return (ushort)m_accessor.GetItemNo();
        }

        public void SetItem(ushort itemno)
        {
            m_accessor.SetItemNo(itemno);
        }

        // TODO
        public void RemoveItem() { }

        // TODO
        public void Evolve(MonsNo nextMonsno, uint routeIndex) { }

        // TODO
        public bool CanEvolve(EvolveSituation situation, PokeParty party, ref MonsNo nextMonsno, ref uint rootNum) { return false; }

        // TODO
        public bool CanEvolveByItem(EvolveSituation situation, ushort itemno, ref MonsNo nextMonsno, ref uint rootNum) { return false; }

        // TODO
        public bool CanEvolveByTrade(CoreParam pairPoke, ref MonsNo nextMonsno, ref uint rootNum) { return false; }

        // TODO
        public bool CanEvolveByEvent(EvolveSituation situation, PokeParty party, ref MonsNo nextMonsno, ref uint rootNum) { return false; }

        // TODO
        public bool HaveEvolutionRoot() { return false; }

        // TODO
        public void ChangeFormNo(ushort nextFormno, [Optional] FormChangeResult pResult) { }

        // TODO
        public ushort GetNextFormNoFromHoldItem(ushort holdItemno) { return 0; }

        // TODO
        public bool RegulateFormParams() { return false; }

        // TODO
        public bool IsRare() { return false; }

        // TODO
        public uint GetRareRnd() { return 0; }

        // TODO
        public RareType GetRareType() { return RareType.NOT_RARE; }

        // TODO
        public uint GetID() { return 0; }

        public uint GetPersonalRnd()
        {
            return m_accessor.GetPersonalRnd();
        }

        // TODO
        public uint GetCheckSum() { return 0; }

        // TODO
        public void SetID(uint id) { }

        // TODO
        public void SetRare() { }

        // TODO
        public void SetNotRare() { }

        // TODO
        public void SetRareType(RareType type) { }

        // TODO
        public PokeType GetType1() { return PokeType.NORMAL; }

        // TODO
        public PokeType GetType2() { return PokeType.NORMAL; }

        public string GetParentName()
        {
            return m_accessor.GetOyaName();
        }

        public void SetParentName(string name)
        {
            m_accessor.SetOyaName(name);
        }

        public Sex GetParentSex()
        {
            return m_accessor.GetOyasex();
        }

        public void SetParentSex(Sex sex)
        {
            m_accessor.SetOyasex(sex);
        }

        // TODO
        public uint GetMemories(Memories memoriesKind) { return default; }

        // TODO
        public void SetMemories(Memories memoriesKind, uint value) { }

        // TODO
        public string GetPastParentsName() { return ""; }

        // TODO
        public void SetPastParentsName(string name) { }

        // TODO
        public Sex GetPastParentsSex() { return Sex.NUM; }

        // TODO
        public void SetPastParentsSex(Sex sex) { }

        // TODO
        public byte GetPastParentsLangID() { return 0; }

        // TODO
        public void SetPastParentsLangID(byte langID) { }

        // TODO
        public byte GetCondition(Condition cond) { return 0; }

        // TODO
        public void SetCondition(Condition cond, byte value) { }

        // TODO
        public bool IsBoxMarkSet() { return false; }

        // TODO
        public bool IsBoxMarkSet(BoxMark mark) { return false; }

        // TODO
        public void SetBoxMark(BoxMark mark, BoxMarkColor color) { }

        // TODO
        public void RemoveBoxMark(BoxMark mark) { }

        // TODO
        public BoxMarkColor GetBoxMark(BoxMark mark) { return default; }

        // TODO
        public void RemoveAllBoxMark() { }

        // TODO
        public void SetAllBoxMark(BoxMarkContainer markContainer) { }

        // TODO
        public void GetAllBoxMark(BoxMarkContainer markContainer) { }

        public uint GetLangId()
        {
            return m_accessor.GetLangId();
        }

        public void SetLangId(uint langId)
        {
            m_accessor.SetLangId((byte)langId);
        }

        // TODO
        public uint GetCassetteVersion() { return 0; }

        // TODO
        public void SetCassetteVersion(uint version) { }

        public uint GetGetBall()
        {
            return m_accessor.GetGetBall();
        }

        public void SetGetBall(uint value)
        {
            m_accessor.SetGetBall((byte)value);
        }

        // TODO
        public byte GetBattleRomMark() { return 0; }

        // TODO
        public void SetBattleRomMark(byte battleRomMark) { }

        // TODO
        public byte GetNadenadeValue() { return 0; }

        // TODO
        public void SetNadenadeValue(byte value) { }

        // TODO
        public void AddNadenadeValue(byte value) { }

        // TODO
        public void SubNadenadeValue(byte value) { }

        // TODO
        public PokeType GetMezapaType() { return PokeType.NULL; }

        // TODO
        public uint GetMezapaPower() { return 0; }

        // TODO
        public TasteJudge JudgeTaste(Taste taste) { return TasteJudge.NORMAL; }

        // TODO
        public bool HaveRibbon(uint ribbonNo) { return false; }

        // TODO
        public void SetRibbon(uint ribbonNo) { }

        // TODO
        public void RemoveRibbon(uint ribbonNo) { }

        public void RemoveAllRibbon()
        {
            m_accessor.RemoveAllRibbon();
        }

        // TODO
        public void SetLumpingRibbon(LumpingRibbon ribbonId, uint num) { }

        // TODO
        public void SetLumpingRibbon(uint ribbonNo, uint num) { }

        // TODO
        public uint GetLumpingRibbon(LumpingRibbon ribbonId) { return default; }

        // TODO
        public uint GetLumpingRibbon(uint ribbonNo) { return default; }

        // TODO
        public bool IsEquipRibbonExist() { return false; }

        // TODO
        public byte GetEquipRibbonNo() { return 0; }

        // TODO
        public void SetEquipRibbonNo(byte ribbonNo) { }

        public bool HavePokerusJustNow()
        {
            return (m_accessor.GetPokerus() & 0xF) != 0;
        }

        public bool HavePokerusUntilNow()
        {
            return (m_accessor.GetPokerus() & 0xFF) != 0;
        }

        // TODO
        public bool HavePokerusPast() { return false; }

        // TODO
        public void CatchPokerus() { }

        public void InfectPokerusWith(CoreParam target)
        {
            target.SetPokerus(GetPokerus());
        }

        // TODO
        public void DecreasePokerusDayCount(int passedDayCount) { }

        public uint GetPokerus()
        {
            return m_accessor.GetPokerus();
        }

        public void SetPokerus(uint pokerus)
        {
            m_accessor.SetPokerus((byte)pokerus);
        }

        public bool GetEventPokeFlag()
        {
            return m_accessor.IsEventPokemon();
        }

        public void SetEventPokeFlag(bool flag)
        {
            m_accessor.SetEventPokemonFlag(flag);
        }

        public bool HaveOfficialBattleRights()
        {
            return m_accessor.GetOfficialBattleEnableFlag();
        }

        public void GrantOfficialBattleRights()
        {
            SetDefaultWaza();
            m_accessor.SetTamagoWazaNo(0, (uint)WazaNo.NULL);
            m_accessor.SetTamagoWazaNo(1, (uint)WazaNo.NULL);
            m_accessor.SetTamagoWazaNo(2, (uint)WazaNo.NULL);
            m_accessor.SetTamagoWazaNo(3, (uint)WazaNo.NULL);
            m_accessor.SetOfficialBattleEnableFlag(true);
        }

        // TODO
        public void RemoveAllRotomWaza() { }

        // TODO
        public void SetRotomWaza(byte wazaIndex)
        {
            var formno = GetFormNo();

        }

        // TODO
        public LoveLevel CheckLoveLevel(CoreParam partner) { return LoveLevel.GOOD; }

        public bool GetPokeJobFlag(byte jobIndex)
        {
            return m_accessor.GetPokeJobFlag(jobIndex);
        }

        public void SetPokeJobFlag(byte jobIndex)
        {
            m_accessor.SetPokeJobFlag(jobIndex, true);
        }

        public void RemovePokeJobFlag(byte jobIndex)
        {
            m_accessor.SetPokeJobFlag(jobIndex, false);
        }

        public void ClearPokeJobFlag()
        {
            m_accessor.ClearPokeJobFlag();
        }

        public byte GetCampFriendship()
        {
            return m_accessor.GetCampFriendship();
        }

        public void SetCampFriendship(uint value)
        {
            value = (value >= PmlConstants.MAX_CAMP_FRIENDSHIP) ? PmlConstants.MAX_CAMP_FRIENDSHIP : value;
            m_accessor.SetCampFriendship((byte)value);
        }

        public void AddCampFriendship(uint value)
        {
            SetCampFriendship(GetCampFriendship() + value);
        }

        public void SubCampFriendship(uint value)
        {
            var camp = GetCampFriendship();

            var newval = (camp < value) ? 0 : (camp - value);
            SetCampFriendship(newval);
        }

        public byte GetEnjoy()
        {
            return m_accessor.GetEnjoy();
        }

        public void SetEnjoy(uint value)
        {
            value = (value >= PmlConstants.MAX_ENJOY) ? PmlConstants.MAX_ENJOY : value;
            m_accessor.SetEnjoy((byte)value);
        }

        public void AddEnjoy(byte value)
        {
            SetEnjoy((byte)(GetEnjoy() + value));
        }

        public void SubEnjoy(byte value)
        {
            var enjoy = GetEnjoy();
            if (enjoy < value)
                m_accessor.SetEnjoy(0);
            else
                SetEnjoy((byte)(enjoy - value));
        }

        public uint GetPalma()
        {
            return m_accessor.GetPalma();
        }

        public void SetPalma(uint value)
        {
            m_accessor.SetPalma(value);
        }

        public bool GetDprIllegalFlag()
        {
            return m_accessor.GetDprIllegalFlag();
        }

        public void SetDprIllegalFlag(bool flag)
        {
            m_accessor.SetDprIllegalFlag(flag);
        }

        public bool StartFastMode()
        {
            if (IsFastMode())
                return false;

            m_accessor.StartFastMode();
            return true;
        }

        public bool EndFastMode(bool validFlag)
        {
            if (!IsFastMode() || !validFlag)
                return false;

            m_accessor.EndFastMode();
            return true;
        }

        public bool IsFastMode()
        {
            return m_accessor.IsFastMode();
        }

        public void Clear()
        {
            m_accessor.ClearData();
        }

        public bool IsNull()
        {
            return m_accessor.GetMonsNo() == MonsNo.NULL;
        }

        public bool HaveCalcParam()
        {
            return m_accessor.HaveCalcData();
        }

        public void CopyFrom(CoreParam pSrcParam)
        {
            pSrcParam.Serialize_Core(sCoreSerializeBuffer);
            Deserialize_Core(sCoreSerializeBuffer);
        }

        public void RecalculateCalcData()
        {
            UpdateCalcDatas();
        }

        public virtual unsafe void Serialize_Core(void* buffer)
        {
            m_accessor.Serialize_CoreData(buffer);
        }

        public virtual void Serialize_Core(byte[] buffer)
        {
            m_accessor.Serialize_CoreData(buffer);
        }

        public virtual unsafe void Deserialize_Core(void* serializedData)
        {
            m_accessor.Deserialize_FullData(serializedData);
        }

        public virtual void Deserialize_Core(byte[] serializedData)
        {
            m_accessor.Deserialize_FullData(serializedData);
        }

        public CoreParam()
        {
            m_coreData = Factory.CreateCoreData();
            m_accessor = new Accessor();
            m_accessor.AttachEncodedData(m_coreData, null);
        }

        public CoreParam(MonsNo monsno, ushort level, ulong id)
        {
            m_coreData = Factory.CreateCoreData(monsno, level, id);
            m_accessor = new Accessor();
            m_accessor.AttachEncodedData(m_coreData, null);
            InitCoreData();
            CheckIllegalParam();
        }

        public CoreParam(InitialSpec spec)
        {
            m_coreData = Factory.CreateCoreData(spec);
            m_accessor = new Accessor();
            m_accessor.AttachEncodedData(m_coreData, null);
            InitCoreData();
            CheckIllegalParam();
        }

        protected void InitCoreData()
        {
            SetLangId((uint)PmlUse.Instance.LangId);
            SetDefaultWaza();
            SetDefaultNickName();
            RecoverAll();
        }

        protected void SetIllegalParam()
        {
            m_accessor.SetFuseiTamagoFlag(true);
        }

        protected void CheckIllegalParam()
        {
            var monsno = GetMonsNo();
            var formno = GetFormNo();

            if (monsno == MonsNo.NULL)
                return;

            if (!PersonalSystem.CheckPokeExist(monsno, formno))
                SetIllegalParam();
        }

        protected void UpdateCalcDatas(bool keepDead = true)
        {
            bool validFlag = StartFastMode();

            UpdateLevel();
            UpdateMaxHpAndCorrectHp(keepDead);
            UpdateAtk();
            UpdateDef();
            UpdateSpAtk();
            UpdateSpDef();
            UpdateAgi();

            EndFastMode(validFlag);
        }

        protected void UpdateLevel()
        {
            m_accessor.SetLevel(CalcLevel());
        }

        protected void UpdateMaxHP()
        {
            SetMaxHp(CalcMaxHp());
        }

        protected void UpdateMaxHpAndCorrectHp(bool keepDead = true)
        {
            var max = GetMaxHp();
            var curr = GetHp();

            UpdateMaxHP();

            if (curr == 0 && keepDead)
                return;

            var newmax = GetMaxHp();
            var newhp = (ushort)((curr <= newmax) ? curr : newmax);
            newhp = (ushort)((max <= newmax) ? (curr - max + newmax) : newhp);

            m_accessor.SetHp(newhp);
        }

        protected void UpdateAtk()
        {
            SetAtk(CalcAtk());
        }

        protected void UpdateDef()
        {
            SetDef(CalcDef());
        }

        protected void UpdateSpAtk()
        {
            SetSpAtk(CalcSpAtk());
        }

        protected void UpdateSpDef()
        {
            SetSpDef(CalcSpDef());
        }

        protected void UpdateAgi()
        {
            SetAgi(CalcAgi());
        }

        protected uint GetAtk()
        {
            if (HaveCalcParam())
                return m_accessor.GetAtk();

            return CalcAtk();
        }

        protected uint GetDef()
        {
            if (HaveCalcParam())
                return m_accessor.GetDef();

            return CalcDef();
        }

        protected uint GetSpAtk()
        {
            if (HaveCalcParam())
                return m_accessor.GetSpAtk();

            return CalcSpAtk();
        }

        protected uint GetSpDef()
        {
            if (HaveCalcParam())
                return m_accessor.GetSpDef();

            return CalcSpDef();
        }

        protected uint GetAgi()
        {
            if (HaveCalcParam())
                return m_accessor.GetAgi();

            return CalcAgi();
        }

        // TODO
        protected byte CalcLevel()
        {
            return CalcTool.CalcLevel(GetMonsNo(), GetFormNo(), GetExp());
        }

        protected ushort CalcMaxHp()
        {
            if (HaveCalcParam())
            {
                _ = GetGState();
            }

            return CalcMaxHp_NotG();
        }

        protected ushort CalcAtk()
        {
            if (HaveCalcParam())
            {
                _ = GetGState();
            }

            return CalcAtk_NotG();
        }

        protected ushort CalcDef()
        {
            if (HaveCalcParam())
            {
                _ = GetGState();
            }

            return CalcDef_NotG();
        }

        protected ushort CalcSpAtk()
        {
            if (HaveCalcParam())
            {
                _ = GetGState();
            }

            return CalcSpAtk_NotG();
        }

        protected ushort CalcSpDef()
        {
            if (HaveCalcParam())
            {
                _ = GetGState();
            }

            return CalcSpDef_NotG();
        }

        protected ushort CalcAgi()
        {
            if (HaveCalcParam())
            {
                _ = GetGState();
            }

            return CalcAgi_NotG();
        }

        // TODO
        protected ushort CalcMaxHp_G() { return 0; }

        // TODO
        protected ushort CalcAtk_G() { return 0; }

        // TODO
        protected ushort CalcDef_G() { return 0; }

        // TODO
        protected ushort CalcSpAtk_G() { return 0; }

        // TODO
        protected ushort CalcSpDef_G() { return 0; }

        // TODO
        protected ushort CalcAgi_G() { return 0; }

        // TODO
        protected ushort CalcMaxHp_NotG() { return 0; }

        // TODO
        protected ushort CalcAtk_NotG() { return 0; }

        // TODO
        protected ushort CalcDef_NotG() { return 0; }

        // TODO
        protected ushort CalcSpAtk_NotG() { return 0; }

        // TODO
        protected ushort CalcSpDef_NotG() { return 0; }

        // TODO
        protected ushort CalcAgi_NotG() { return 0; }

        protected void changeWazaByFormChange(ushort nextFormno, [Optional] FormChangeResult pResult)
        {
            _ = GetMonsNo();

            RemoveDuplicatedWaza();
            CloseUpWazaPos();
        }

        protected void changeWazaByFormChange_Learn(WazaNo learnWaza, [Optional] FormChangeResult pResult)
        {
            var learnResult = AddWazaIfEmptyExist(learnWaza);

            if (pResult == null)
                return;

            switch (learnResult)
            {
                case WazaLearningResult.SUCCEEDED:
                    pResult.SetAddedWaza(learnWaza);
                    break;

                case WazaLearningResult.FAILED_FULL:
                    pResult.SetAddFailedWaza(learnWaza);
                    break;
            }
        }

        // TODO
        protected void changeWazaByFormChange_Forget(WazaNo forgetWaza, WazaNo supplyWaza, [Optional] FormChangeResult pResult)
        {

        }

        // TODO
        protected void changeWazaByFormChange_Replace(WazaNo forgetWaza, WazaNo learnWaza, [Optional] FormChangeResult pResult)
        {

        }

        protected uint AdjustEffortPower(uint beforeValue, uint afterValue)
        {
            if (afterValue >= PmlConstants.MAX_EFFORT_POWER)
                afterValue = PmlConstants.MAX_EFFORT_POWER;

            if (beforeValue <= afterValue && afterValue - beforeValue != 0)
            {
                var nextTotal = GetTotalEffortPower() + afterValue - beforeValue;
                if (nextTotal > PmlConstants.MAX_TOTAL_EFFORT_POWER)
                    afterValue = afterValue - nextTotal + PmlConstants.MAX_TOTAL_EFFORT_POWER;
            }

            return afterValue;
        }

        public class WazaLearnWork
        {
	        private WazaNo[] m_checkedWazaArray = new WazaNo[PersonalConstants.MAX_WAZAOBOE_CODE_NUM];
            private uint m_checkedWazaNum;

            public WazaLearnWork()
            {
                Clear();
            }

            public void Clear()
            {
                m_checkedWazaNum = 0;
                for (int i=0; i<m_checkedWazaArray.Length; i++)
                    m_checkedWazaArray[i] = WazaNo.NULL;
            }

            public void AddCheckedWaza(WazaNo waza)
            {
                if (IsCheckedWaza(waza))
                    return;

                if (m_checkedWazaNum < m_checkedWazaArray.Length)
                {
                    m_checkedWazaArray[m_checkedWazaNum] = waza;
                    m_checkedWazaNum++;
                }
                else
                {
                    GFL.ASSERT(false);
                }
            }

            public bool IsCheckedWaza(WazaNo waza)
            {
                for (int i=0; i<m_checkedWazaArray.Length; i++)
                {
                    if (m_checkedWazaArray[i] == waza)
                        return true;
                }

                return false;
            }
        }

        public class FormChangeResult
        {
	        private WazaNo[] m_addedWaza = new WazaNo[4];
            private WazaNo[] m_removedWaza = new WazaNo[4];
            private WazaNo[] m_addFailedWaza = new WazaNo[4];

            public FormChangeResult()
            {
                Clear();
            }

            public byte GetAddedWazaNum()
            {
                return getCount(m_addedWaza);
            }

            public WazaNo GetAddedWaza(byte idx)
            {
                return get(m_addedWaza, idx);
            }

            public byte GetRemovedWazaNum()
            {
                return getCount(m_removedWaza);
            }

            public WazaNo GetRemovedWaza(byte idx)
            {
                return get(m_removedWaza, idx);
            }

            public byte GetAddFailedWazaNum()
            {
                return getCount(m_addFailedWaza);
            }

            public WazaNo GetAddFaildedWaza(byte idx)
            {
                return get(m_addFailedWaza, idx);
            }

            public void Clear()
            {
                m_addedWaza[0] = WazaNo.NULL;
                m_removedWaza[0] = WazaNo.NULL;
                m_addFailedWaza[0] = WazaNo.NULL;

                m_addedWaza[1] = WazaNo.NULL;
                m_removedWaza[1] = WazaNo.NULL;
                m_addFailedWaza[1] = WazaNo.NULL;

                m_addedWaza[2] = WazaNo.NULL;
                m_removedWaza[2] = WazaNo.NULL;
                m_addFailedWaza[2] = WazaNo.NULL;

                m_addedWaza[3] = WazaNo.NULL;
                m_removedWaza[3] = WazaNo.NULL;
                m_addFailedWaza[3] = WazaNo.NULL;
            }

            public void SetAddedWaza(WazaNo wazano)
            {
                set(m_addedWaza, wazano);
            }

            public void SetRemovedWaza(WazaNo wazano)
            {
                set(m_removedWaza, wazano);
            }

            public void SetAddFailedWaza(WazaNo wazano)
            {
                set(m_addFailedWaza, wazano);
            }

            private void add(WazaNo[] pArray, WazaNo wazano)
            {
                for (int i=0; i<pArray.Length; i++)
                {
                    if (pArray[i] == WazaNo.NULL)
                        pArray[i] = wazano;
                }
            }

            private void set(WazaNo[] pArray, WazaNo wazano)
            {
                add(pArray, wazano);
            }

            private WazaNo get(WazaNo[] pArray, byte idx)
            {
                if (idx < pArray.Length)
                {
                    return pArray[idx];
                }
                else
                {
                    GFL.ASSERT(false);
                    return WazaNo.NULL;
                } 
            }

            private byte getCount(WazaNo[] pArray)
            {
                byte count = 0;
                for (; count<pArray.Length; count++)
                {
                    if (pArray[count] == WazaNo.NULL)
                        break;
                }

                return count;
            }
        }
    }
}