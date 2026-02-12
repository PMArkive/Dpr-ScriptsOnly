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

        public void AddExp(uint value)
        {
        	SetExp(Accessor.GetExp(this[0]) + value);
        }

        // TODO
        public uint GetExpForCurrentLevel() { return 0; }

        // TODO
        public uint GetExpForNextLevel() { return 0; }

        // TODO
        public void LevelUp(byte upVal) { }

        // TODO
        public uint GetBasicPower(PowerID powerID) { return 0; }

        public uint GetNativeTalentPower(PowerID powerId)
        {
        	switch(powerId) {
        	case 0:
        	  return Accessor.GetTalentHp(this[0]);
        	case 1:
        	  return Accessor.GetTalentAtk(this[0]);
        	case 2:
        	  return Accessor.GetTalentDef(this[0]);
        	case 3:
        	  return Accessor.GetTalentSpAtk(this[0]);
        	case 4:
        	  return Accessor.GetTalentSpDef(this[0]);
        	case 5:
        	  return Accessor.GetTalentAgi(this[0]);
        	default:
        	  GFL.ASSERT(0);
        	  return 0;
        	}
        }

        // TODO
        public uint GetTalentPower(PowerID powerId) { return 0; }

        public void ChangeTalentPower(PowerID powerId, uint value)
        {
        	var uVar2 = 0x1f;
        	if (value < 0x1f) {
        	  uVar2 = value;
        	}
        	switch(powerId) {
        	case 0:
        	  break;
        	case 1:
        	  Accessor.SetTalentAtk(this[0],uVar2);
        	  UpdateAtk();
        	case 2:
        	  Accessor.SetTalentDef(this[0],uVar2);
        	  UpdateDef();
        	case 3:
        	  Accessor.SetTalentSpAtk(this[0],uVar2);
        	  UpdateSpAtk();
        	case 4:
        	  Accessor.SetTalentSpDef(this[0],uVar2);
        	  UpdateSpDef();
        	case 5:
        	  Accessor.SetTalentAgi(this[0],uVar2);
        	  UpdateAgi();
        	default:
        	  GFL.ASSERT(0);
        	}
        	Accessor.SetTalentHp(this[0],uVar2);
        	uVar2 = GetMaxHp();
        	var uVar3 = GetHp();
        	UpdateMaxHP();
        	if (uVar3 == 0) {
        	}
        	var uVar4 = GetMaxHp();
        	var uVar1 = uVar4;
        	if (uVar3 <= uVar4) {
        	  uVar1 = uVar3;
        	}
        	if (uVar2 <= uVar4) {
        	  uVar1 = (uVar3 - uVar2) + uVar4;
        	}
        	Accessor.SetHp(this[0],uVar1);
        }

        // TODO
        public uint GetTalentPowerMaxNum() { return 0; }

        public bool IsTrainingDone(PowerID powerId)
        {
        	if ((int)(int)powerId < 6) {
        	  return (Accessor.GetTrainingFlag(this[0]) & 1 << (ulong)(powerId & 0x1f) & 0xff) != 0;
        	}
        	GFL.ASSERT(0);
        	return false;
        }

        // TODO
        public void SetTrainingDone(PowerID powerId) { }

        public uint GetEffortPower(PowerID powerId)
        {
        	switch(powerId) {
        	case 0:
        	  return Accessor.GetEffortHp(this[0]);
        	case 1:
        	  return Accessor.GetEffortAtk(this[0]);
        	case 2:
        	  return Accessor.GetEffortDef(this[0]);
        	case 3:
        	  return Accessor.GetEffortSpAtk(this[0]);
        	case 4:
        	  return Accessor.GetEffortSpDef(this[0]);
        	case 5:
        	  return Accessor.GetEffortAgi(this[0]);
        	default:
        	  GFL.ASSERT(0);
        	  return 0;
        	}
        }

        public uint GetTotalEffortPower()
        {
            return m_accessor.GetEffortHp() +
                m_accessor.GetEffortAtk() +
                m_accessor.GetEffortDef() +
                m_accessor.GetEffortSpAtk() +
                m_accessor.GetEffortSpDef() +
                m_accessor.GetEffortAgi();
        }

        public void ChangeEffortPower(PowerID powerId, uint value)
        {
        	var uVar2 = GetEffortPower();
        	uVar2 = AdjustEffortPower(uVar2,value);
        	switch(powerId) {
        	case 0:
        	  break;
        	case 1:
        	  Accessor.SetEffortAtk(this[0],uVar2);
        	  UpdateAtk();
        	case 2:
        	  Accessor.SetEffortDef(this[0],uVar2);
        	  UpdateDef();
        	case 3:
        	  Accessor.SetEffortSpAtk(this[0],uVar2);
        	  UpdateSpAtk();
        	case 4:
        	  Accessor.SetEffortSpDef(this[0],uVar2);
        	  UpdateSpDef();
        	case 5:
        	  Accessor.SetEffortAgi(this[0],uVar2);
        	  UpdateAgi();
        	default:
        	  GFL.ASSERT(0);
        	}
        	Accessor.SetEffortHp(this[0],uVar2);
        	var uVar3 = GetMaxHp();
        	var uVar4 = GetHp();
        	UpdateMaxHP();
        	if (uVar4 == 0) {
        	}
        	var uVar5 = GetMaxHp();
        	var uVar1 = uVar5;
        	if (uVar4 <= uVar5) {
        	  uVar1 = uVar4;
        	}
        	if (uVar3 <= uVar5) {
        	  uVar1 = (uVar4 - uVar3) + uVar5;
        	}
        	Accessor.SetHp(this[0],uVar1);
        }

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

        public void ChangeEffortG(byte value)
        {
        	if (9 < (value & 0xff)) {
        	  value = 10;
        	}
        	Accessor.SetEffortG(this[0],value);
        }

        public byte GetEffortG()
        {
        	Accessor.GetEffortG(this[0]);
        }

        public void AddEffortG(uint value)
        {
        	var uVar2 = Accessor.GetEffortG(this[0]) + value;
        	if (9 < (uVar2 & 0xff)) {
        	  uVar2 = 10;
        	}
        	Accessor.SetEffortG(this[0],uVar2);
        }

        public void SubEffortG(uint value)
        {
        	if (value < (Accessor.GetEffortG(this[0]) & 0xff)) {
        	  Accessor.GetEffortG(this[0]) = Accessor.GetEffortG(this[0]) - value;
        	  if (9 < (Accessor.GetEffortG(this[0]) & 0xff)) {
        	    Accessor.GetEffortG(this[0]) = 10;
        	  }
        	}
        	else {
        	  Accessor.GetEffortG(this[0]) = 0;
        	}
        	Accessor.SetEffortG(this[0],Accessor.GetEffortG(this[0]),0);
        }

        // TODO
        public uint GetPower_G(PowerID powerID) { return 0; }

        // TODO
        public uint GetPower_NotG(PowerID powerID) { return 0; }

        public bool IsSpecialGEnable()
        {
        	Accessor.IsSpecialGEnable(this[0]);
        }

        public void SetSpecialGEnable()
        {
        	Accessor.SetSpecialGFlag(this[0],1);
        }

        public void SetSpecialGDisable()
        {
        	Accessor.SetSpecialGFlag(this[0],0);
        }

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

        public void RemoveWaza(byte wazaIndex)
        {
        	if (3 < ((uint)wazaIndex & 0xff)) {
        	  GFL.ASSERT(0);
        	}
        	Accessor.SetWazaNo(this[0],wazaIndex,0);
        	Accessor.SetWazaPPUpCount(this[0],wazaIndex & 0xffffffff,0);
        	Accessor.SetPP(this[0],wazaIndex & 0xffffffff,0);
        }

        // TODO
        public void RemoveDuplicatedWaza() { }

        public void ExchangeWazaPos(byte pos1, byte pos2)
        {
        	if (3 < ((pos2 | pos1) & 0xff)) {
        	  GFL.ASSERT(0);
        	}
        	if ((pos1 & 0xff) == (pos2 & 0xff)) {
        	}
        	var uVar4 = Accessor.GetWazaNo(this[0],pos2);
        	Accessor.SetWazaNo(this[0],pos1,uVar4);
        	uVar4 = Accessor.GetPP(this[0],pos2);
        	Accessor.SetPP(this[0],pos1,uVar4);
        	uVar4 = Accessor.GetWazaPPUpCount(this[0],pos2);
        	Accessor.SetWazaPPUpCount(this[0],pos1,uVar4);
        	Accessor.SetWazaNo(this[0],pos2,Accessor.GetWazaNo(this[0],pos1),0);
        	Accessor.SetWazaPPUpCount(this[0],pos2,Accessor.GetWazaPPUpCount(this[0],pos1),0);
        	Accessor.SetPP(this[0],pos2,Accessor.GetPP(this[0],pos1),0);
        }

        public void CloseUpWazaPos()
        {
        	if (Accessor.GetWazaNo(this[0],0) == 0) {
        	  ExchangeWazaPos(0,1);
        	  ExchangeWazaPos(1,2);
        	  ExchangeWazaPos(2,3);
        	}
        	if (Accessor.GetWazaNo(this[0],1) == 0) {
        	  ExchangeWazaPos(1,2);
        	  ExchangeWazaPos(2,3);
        	}
        	if (Accessor.GetWazaNo(this[0],2) != 0) {
        	}
        	ExchangeWazaPos(2,3);
        }

        // TODO
        public bool CheckWazaMachine(uint machineNo) { return false; }

        // TODO
        public bool CheckWazaRecord(uint recordNo) { return false; }

        // TODO
        public bool CheckWazaOshie(uint oshieNo) { return false; }

        // TODO
        public bool CheckWazaOshie(WazaNo wazano) { return false; }

        public WazaNo GetTamagoWazaNo(byte index)
        {
        	Accessor.GetTamagoWazaNo(this[0],index);
        }

        public void SetTamagoWazaNo(byte index, WazaNo wazano)
        {
            if (index < PmlConstants.MAX_WAZA_NUM)
                m_accessor.SetTamagoWazaNo(index, (uint)wazano);
            else
                GFL.ASSERT(false);
        }

        public void ClearTamagoWaza()
        {
        	Accessor.SetTamagoWazaNo(this[0],0,0);
        	Accessor.SetTamagoWazaNo(this[0],1,0);
        	Accessor.SetTamagoWazaNo(this[0],2,0);
        	Accessor.SetTamagoWazaNo(this[0],3,0);
        }

        // TODO
        public void InheriteTamagoWaza(CoreParam teacher) { }

        public WazaLearningResult AddWazaIfEmptyExist(WazaNo wazano)
        {
        	uint uVar2;
        	if ((Accessor.GetWazaNo(this[0],0) != wazano) &&
        	   (Accessor.GetWazaNo(this[0],0) = Accessor.GetWazaNo(this[0],1),
        	   Accessor.GetWazaNo(this[0],0) != wazano)) {
        	  if (Accessor.GetWazaNo(this[0],2) == wazano) {
        	    return (WazaLearningResult)2;
        	  }
        	  if (Accessor.GetWazaNo(this[0],3) != wazano) {
        	    if (Accessor.GetWazaNo(this[0],0) == 0) {
        	      uVar2 = 0;
        	    }
        	    else {
        	      uVar2 = 1;
        	      if (Accessor.GetWazaNo(this[0],1) != 0) {
        	        uVar2 = 2;
        	        if (Accessor.GetWazaNo(this[0],2) != 0) {
        	          uVar2 = 3;
        	          if (Accessor.GetWazaNo(this[0],3) != 0) {
        	            return (WazaLearningResult)1;
        	          }
        	        }
        	      }
        	    }
        	    SetWaza(uVar2,wazano);
        	    return (WazaLearningResult)0;
        	  }
        	}
        	return (WazaLearningResult)2;
        }

        public WazaLearningResult LearnNewWazaOnCurrentLevel(ref uint sameLevelIndex, ref WazaNo newWazano, [Optional] WazaLearnWork work)
        {
        	if ((Accessor.HaveCalcData(this[0]) & 1) == 0) {
        	  var uVar1 = CalcLevel();
        	  uVar1 = uVar1 & 0xff;
        	}
        	else {
        	}
        	LearnNewWazaOnLevel(Accessor.GetLevel(this[0]),sameLevelIndex,newWazano,work);
        	return (WazaLearningResult)0;
        }

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

        public void ReduceWazaPP(byte wazaIndex, byte value)
        {
        	var uVar1 = 0;
        	if ((uint)(value * 0x1000000) <= (uint)(Accessor.GetPP(this[0],wazaIndex) * 0x1000000)) {
        	  uVar1 = Accessor.GetPP(this[0],wazaIndex) * 0x1000000 + value * -0x1000000;
        	}
        	var uVar3 = GetWazaMaxPP(wazaIndex & 0xffffffff);
        	if (uVar1 >> 0x18 <= uVar3) {
        	  uVar3 = uVar1 >> 0x18;
        	}
        	Accessor.SetPP(this[0],wazaIndex & 0xffffffff,uVar3);
        }

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

        public bool CanUsePointUp(byte wazaIndex)
        {
        	return Accessor.GetWazaPPUpCount(this[0],wazaIndex) < 3;
        }

        public void UsePointUp(byte wazaIndex)
        {
        	var uVar4 = wazaIndex & 0xffffffff;
        	var iVar3 = 3;
        	if ((Accessor.GetWazaPPUpCount(this[0],uVar4) + 1U & 0xff) < 3) {
        	  iVar3 = Accessor.GetWazaPPUpCount(this[0],uVar4) + 1;
        	}
        	Accessor.SetWazaPPUpCount(this[0],uVar4,iVar3);
        	RecoverWazaPP(uVar4,Accessor.GetPP(this[0],uVar4) - Accessor.GetPP(this[0],wazaIndex));
        }

        public uint GetWazaPPUpCount(byte wazaIndex)
        {
            return m_accessor.GetWazaPPUpCount(wazaIndex);
        }

        public void SetWazaPPUpCount(byte wazaIndex, byte value)
        {
        	if (2 < (value & 0xff)) {
        	  value = 3;
        	}
        	Accessor.SetWazaPPUpCount(this[0],wazaIndex,value);
        }

        // TODO
        public void IncWazaPPUpCount(byte wazaIndex) { }

        public bool GetWazaRecordFlag(byte recordIndex)
        {
        	Accessor.GetWazaRecordFlag(this[0],recordIndex);
        }

        public void SetWazaRecordFlag(byte recordIndex)
        {
        	Accessor.SetWazaRecordFlag(this[0],recordIndex,1);
        }

        public void RemoveWazaRecordFlag(byte recordIndex)
        {
        	Accessor.SetWazaRecordFlag(this[0],recordIndex,0);
        }

        public void ClearWazaRecordFlag()
        {
        	Accessor.ClearWazaRecordFlag(this[0]);
        }

        public void ClearBankUniqueID()
        {
            m_accessor.ClearBankUniqueID();
        }

        public ulong GetBankUniqueID()
        {
        	Accessor.GetBankUniqueID(this[0]);
        }

        public void SetBankUniqueID(ulong value)
        {
        	Accessor.SetBankUniqueID(this[0],value);
        }

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

        public Seikaku GetSeikaku()
        {
        	Accessor.GetSeikaku(this[0]);
        }

        public void ChangeSeikaku(Seikaku seikaku)
        {
        	Accessor.SetSeikaku(this[0],seikaku);
        }

        // TODO
        public bool IsSeikakuHigh() { return false; }

        // TODO
        public bool IsSeikakuLow() { return false; }

        public Seikaku GetSeikakuHosei()
        {
        	Accessor.GetSeikakuHosei(this[0]);
        }

        public void ChangeSeikakuHosei(Seikaku seikaku)
        {
        	Accessor.SetSeikakuHosei(this[0],seikaku);
        	UpdateCalcDatas(1);
        }

        public TokuseiNo GetTokuseiNo()
        {
        	Accessor.GetTokuseiNo(this[0]);
        }

        public byte GetTokuseiIndex()
        {
        	if ((Accessor.IsTokusei3(this[0]) & 1) != 0) {
        	  return 2;
        	}
        	return Accessor.IsTokusei2(this[0]) & 1;
        }

        // TODO
        public byte GetTokuseiIndexStrict() { return 0; }

        public void FlipTokuseiIndex()
        {
        	if ((Accessor.IsTokusei3(this[0]) & 1) != 0) {
        	  GFL.ASSERT(0);
        	}
        	if ((Accessor.IsTokusei2(this[0]) & 1) != 0) {
        	  SetTokuseiIndex();
        	}
        	SetTokuseiIndex(1);
        }

        // TODO
        public void SetTokusei3rd() { }

        // TODO
        public void SetTokuseiIndex(byte tokuseiIndex) { }

        public void SetFavoriteFlag(bool flag)
        {
        	Accessor.SetFavoriteFlag(this[0],flag & 1);
        }

        public bool GetFavoriteFlag()
        {
        	Accessor.IsFavorite(this[0]);
        }

        // TODO
        public bool CompareOwnerInfo(OwnerInfo ownerInfo) { return false; }

        // TODO
        public bool UpdateOwnerInfo(OwnerInfo ownerInfo) { return false; }

        public bool IsOwnedOriginalParent()
        {
            return !m_accessor.GetOwnedOthersFlag();
        }

        public bool HaveNickName()
        {
        	Accessor.HaveNickName(this[0]);
        }

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

        public uint GetFriendship()
        {
        	Accessor.GetFriendship(this[0]);
        }

        public void SetFriendship(uint value)
        {
        	if (0xfe < value) {
        	  value = 0xff;
        	}
        	Accessor.SetFriendship(this[0],value);
        	UpdateCalcDatas(1);
        }

        public void AddFriendship(uint value)
        {
        	var uVar2 = Accessor.GetFriendship(this[0]) + value;
        	if (0xfe < uVar2) {
        	  uVar2 = 0xff;
        	}
        	Accessor.SetFriendship(this[0],uVar2);
        	UpdateCalcDatas(1);
        }

        public void SubFriendship(uint value)
        {
        	var uVar3 = Accessor.GetFriendship(this[0]) - value;
        	if (Accessor.GetFriendship(this[0]) < value) {
        	  uVar3 = 0;
        	}
        	else {
        	  if (0xff < uVar3) {
        	    uVar3 = 0xff;
        	  }
        	}
        	Accessor.SetFriendship(this[0],uVar3);
        	UpdateCalcDatas(1);
        }

        public uint GetOriginalFriendship()
        {
        	return Accessor.GetOriginalFriendship(this[0]);
        }

        public void SetOriginalFriendship(uint value)
        {
        	if (0xfe < value) {
        	  value = 0xff;
        	}
        	Accessor.SetOriginalFriendship(this[0],value);
        }

        public void AddOriginalFriendship(uint value)
        {
        	var uVar2 = value + (uint)Accessor.GetOriginalFriendship(this[0]);
        	if (0xfe < uVar2) {
        	  uVar2 = 0xff;
        	}
        	Accessor.SetOriginalFriendship(this[0],uVar2);
        }

        public void SubOriginalFriendship(uint value)
        {
        	var uVar2 = (Accessor.GetOriginalFriendship(this[0]) & 0xff) - value;
        	if ((Accessor.GetOriginalFriendship(this[0]) & 0xff) < value) {
        	  Accessor.SetOriginalFriendship(this[0],0);
        	}
        	if (0xff < uVar2) {
        	  uVar2 = 0xff;
        	}
        	Accessor.SetOriginalFriendship(this[0],uVar2);
        }

        public ushort GetOthersFriendshipTrainerID()
        {
        	Accessor.GetOthersFriendshipTrainerID(this[0]);
        }

        public uint GetOthersFriendship()
        {
        	return Accessor.GetOthersFriendship(this[0]);
        }

        public void SetOthersFriendship(uint value)
        {
        	if (0xfe < value) {
        	  value = 0xff;
        	}
        	Accessor.SetOthersFriendship(this[0],value);
        }

        public void AddOthersFriendship(uint value)
        {
        	var uVar2 = value + (uint)Accessor.GetOthersFriendship(this[0]);
        	if (0xfe < uVar2) {
        	  uVar2 = 0xff;
        	}
        	Accessor.SetOthersFriendship(this[0],uVar2);
        }

        public void SubOthersFriendship(uint value)
        {
        	var uVar2 = (Accessor.GetOthersFriendship(this[0]) & 0xff) - value;
        	if ((Accessor.GetOthersFriendship(this[0]) & 0xff) < value) {
        	  Accessor.SetOthersFriendship(this[0],0);
        	}
        	if (0xff < uVar2) {
        	  uVar2 = 0xff;
        	}
        	Accessor.SetOthersFriendship(this[0],uVar2);
        }

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

        public void RemoveItem()
        {
        	Accessor.SetItemNo(this[0],0);
        }

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

        public bool RegulateFormParams()
        {
        	Accessor.GetMonsNo(this[0]);
        	Accessor.GetFormNo(this[0]);
        	return false;
        }

        // TODO
        public bool IsRare() { return false; }

        public uint GetRareRnd()
        {
        	Accessor.GetColorRnd(this[0]);
        }

        // TODO
        public RareType GetRareType() { return RareType.NOT_RARE; }

        public uint GetID()
        {
        	Accessor.GetID(this[0]);
        }

        public uint GetPersonalRnd()
        {
            return m_accessor.GetPersonalRnd();
        }

        public uint GetCheckSum()
        {
        	Accessor.GetCheckSum(this[0]);
        }

        public void SetID(uint id)
        {
        	Accessor.SetID(this[0],id);
        }

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

        public uint GetMemories(Memories memoriesKind)
        {
        	switch(memoriesKind) {
        	case 0:
        	  return Accessor.GetTamagoGetYear(this[0]);
        	case 1:
        	  return Accessor.GetTamagoGetMonth(this[0]);
        	case 2:
        	  return Accessor.GetTamagoGetDay(this[0]);
        	case 3:
        	  return Accessor.GetGetPlace(this[0]);
        	case 4:
        	  return Accessor.GetBirthYear(this[0]);
        	case 5:
        	  return Accessor.GetBirthMonth(this[0]);
        	case 6:
        	  return Accessor.GetBirthDay(this[0]);
        	case 7:
        	  return Accessor.GetBirthPlace(this[0]);
        	case 8:
        	  return Accessor.GetGetBall(this[0]);
        	case 9:
        	  return Accessor.GetGetLevel(this[0]);
        	case 10:
        	  return (ulong)(Accessor.GetMemoriesLevel(this[0]) & 0xff);
        	case 0xb:
        	  return (ulong)(Accessor.GetMemoriesCode(this[0]) & 0xff);
        	case 0xc:
        	  return (ulong)(Accessor.GetMemoriesData(this[0]) & 0xffff);
        	case 0xd:
        	  return (ulong)(Accessor.GetMemoriesFeel(this[0]) & 0xff);
        	case 0xe:
        	  return (ulong)(Accessor.GetOthersMemoriesLevel(this[0]) & 0xff);
        	case 0xf:
        	  return (ulong)(Accessor.GetOthersMemoriesCode(this[0]) & 0xff);
        	case 0x10:
        	  return (ulong)(Accessor.GetOthersMemoriesData(this[0]) & 0xffff);
        	case 0x11:
        	  return (ulong)(Accessor.GetOthersMemoriesFeel(this[0]) & 0xff);
        	default:
        	  GFL.ASSERT(0);
        	  return 0;
        	}
        }

        public void SetMemories(Memories memoriesKind, uint value)
        {
        	switch(memoriesKind) {
        	case 0:
        	  Accessor.SetTamagoGetYear(this[0],value);
        	case 1:
        	  Accessor.SetTamagoGetMonth(this[0],value);
        	case 2:
        	  Accessor.SetTamagoGetDay(this[0],value);
        	case 3:
        	  Accessor.SetGetPlace(this[0],value);
        	case 4:
        	  Accessor.SetBirthYear(this[0],value);
        	case 5:
        	  Accessor.SetBirthMonth(this[0],value);
        	case 6:
        	  Accessor.SetBirthDay(this[0],value);
        	case 7:
        	  Accessor.SetBirthPlace(this[0],value);
        	case 8:
        	  Accessor.SetGetBall(this[0],value);
        	case 9:
        	  Accessor.SetGetLevel(this[0],value);
        	case 10:
        	  Accessor.SetMemoriesLevel(this[0],value);
        	case 0xb:
        	  Accessor.SetMemoriesCode(this[0],value);
        	case 0xc:
        	  Accessor.SetMemoriesData(this[0],value);
        	case 0xd:
        	  Accessor.SetMemoriesFeel(this[0],value);
        	case 0xe:
        	  Accessor.SetOthersMemoriesLevel(this[0],value);
        	case 0xf:
        	  Accessor.SetOthersMemoriesCode(this[0],value);
        	case 0x10:
        	  Accessor.SetOthersMemoriesData(this[0],value);
        	case 0x11:
        	  Accessor.SetOthersMemoriesFeel(this[0],value);
        	default:
        	  GFL.ASSERT(0);
        	}
        }

        public string GetPastParentsName()
        {
        	Accessor.GetPastParentsName(this[0]);
        }

        public void SetPastParentsName(string name)
        {
        	Accessor.SetPastParentsName(this[0],name);
        }

        public Sex GetPastParentsSex()
        {
        	Accessor.GetPastParentsSex(this[0]);
        }

        public void SetPastParentsSex(Sex sex)
        {
        	Accessor.SetPastParentsSex(this[0],sex);
        }

        public byte GetPastParentsLangID()
        {
        	Accessor.GetPastParentsLangID(this[0]);
        }

        public void SetPastParentsLangID(byte langID)
        {
        	Accessor.SetPastParentsLangID(this[0],langID);
        }

        public byte GetCondition(Condition cond)
        {
        	switch(cond) {
        	case 0:
        	  return Accessor.GetStyle(this[0]);
        	case 1:
        	  return Accessor.GetBeautiful(this[0]);
        	case 2:
        	  return Accessor.GetCute(this[0]);
        	case 3:
        	  return Accessor.GetClever(this[0]);
        	case 4:
        	  return Accessor.GetStrong(this[0]);
        	case 5:
        	  return Accessor.GetFur(this[0]);
        	default:
        	  GFL.ASSERT(0);
        	  return 0;
        	}
        }

        public void SetCondition(Condition cond, byte value)
        {
        	switch(cond) {
        	case 0:
        	  Accessor.SetStyle(this[0],value);
        	case 1:
        	  Accessor.SetBeautiful(this[0],value);
        	case 2:
        	  Accessor.SetCute(this[0],value);
        	case 3:
        	  Accessor.SetClever(this[0],value);
        	case 4:
        	  Accessor.SetStrong(this[0],value);
        	case 5:
        	  Accessor.SetFur(this[0],value);
        	default:
        	}
        }

        // TODO
        public bool IsBoxMarkSet() { return false; }

        // TODO
        public bool IsBoxMarkSet(BoxMark mark) { return false; }

        public void SetBoxMark(BoxMark mark, BoxMarkColor color)
        {
        	if (((int)mark < 6) && ((int)color < 3)) {
        	  var uVar1 = BoxMarkController.SetBoxMarkColor(Accessor.GetBoxMark(this[0]),mark,color,0);
        	  Accessor.SetBoxMark(this[0],uVar1);
        	}
        	GFL.ASSERT(0);
        }

        public void RemoveBoxMark(BoxMark mark)
        {
        	if ((int)mark < 6) {
        	  var uVar1 = BoxMarkController.SetBoxMarkColor(Accessor.GetBoxMark(this[0]),mark,0,0);
        	  Accessor.SetBoxMark(this[0],uVar1);
        	}
        	GFL.ASSERT(0);
        }

        public BoxMarkColor GetBoxMark(BoxMark mark)
        {
        	BoxMarkController.GetBoxMarkColor(Accessor.GetBoxMark(this[0]),mark,0);
        }

        public void RemoveAllBoxMark()
        {
        	var uVar1 = BoxMarkController.SetBoxMarkColor(Accessor.GetBoxMark(this[0]),0,0,0);
        	Accessor.SetBoxMark(this[0],uVar1);
        	uVar1 = BoxMarkController.SetBoxMarkColor(Accessor.GetBoxMark(this[0]),1,0,0);
        	Accessor.SetBoxMark(this[0],uVar1);
        	uVar1 = BoxMarkController.SetBoxMarkColor(Accessor.GetBoxMark(this[0]),2,0,0);
        	Accessor.SetBoxMark(this[0],uVar1);
        	uVar1 = BoxMarkController.SetBoxMarkColor(Accessor.GetBoxMark(this[0]),3,0,0);
        	Accessor.SetBoxMark(this[0],uVar1);
        	uVar1 = BoxMarkController.SetBoxMarkColor(Accessor.GetBoxMark(this[0]),4,0,0);
        	Accessor.SetBoxMark(this[0],uVar1);
        	uVar1 = BoxMarkController.SetBoxMarkColor(Accessor.GetBoxMark(this[0]),5,0,0);
        	Accessor.SetBoxMark(this[0],uVar1);
        }

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

        public uint GetCassetteVersion()
        {
        	Accessor.GetCassetteVersion(this[0]);
        }

        public void SetCassetteVersion(uint version)
        {
        	Accessor.SetCassetteVersion(this[0],version);
        }

        public uint GetGetBall()
        {
            return m_accessor.GetGetBall();
        }

        public void SetGetBall(uint value)
        {
            m_accessor.SetGetBall((byte)value);
        }

        public byte GetBattleRomMark()
        {
        	Accessor.GetBattleRomMark(this[0]);
        }

        public void SetBattleRomMark(byte battleRomMark)
        {
        	Accessor.SetBattleRomMark(this[0],battleRomMark);
        }

        public byte GetNadenadeValue()
        {
        	Accessor.GetNadenadeValue(this[0]);
        }

        public void SetNadenadeValue(byte value)
        {
        	Accessor.SetNadenadeValue(this[0],value);
        }

        public void AddNadenadeValue(byte value)
        {
        	Accessor.SetNadenadeValue(this[0],Accessor.GetNadenadeValue(this[0]) + value,0);
        }

        public void SubNadenadeValue(byte value)
        {
        	if ((Accessor.GetNadenadeValue(this[0]) & 0xff) < (value & 0xff)) {
        	  Accessor.SetNadenadeValue(this[0],0);
        	}
        	if ((~(Accessor.GetNadenadeValue(this[0]) - value) & 0xff) != 0) {
        	  Accessor.SetNadenadeValue(this[0],Accessor.GetNadenadeValue(this[0]) - value,0);
        	}
        	Accessor.SetNadenadeValue(this[0],0xff);
        }

        // TODO
        public PokeType GetMezapaType() { return PokeType.NULL; }

        // TODO
        public uint GetMezapaPower() { return 0; }

        // TODO
        public TasteJudge JudgeTaste(Taste taste) { return TasteJudge.NORMAL; }

        public bool HaveRibbon(uint ribbonNo)
        {
        	Accessor.HaveRibbon(this[0],ribbonNo);
        }

        public void SetRibbon(uint ribbonNo)
        {
        	Accessor.SetRibbon(this[0],ribbonNo);
        }

        public void RemoveRibbon(uint ribbonNo)
        {
        	Accessor.RemoveRibbon(this[0],ribbonNo);
        }

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

        public bool IsEquipRibbonExist()
        {
        	return Accessor.GetEquipRibbonNo(this[0]) != -1;
        }

        public byte GetEquipRibbonNo()
        {
        	Accessor.GetEquipRibbonNo(this[0]);
        }

        public void SetEquipRibbonNo(byte ribbonNo)
        {
        	Accessor.SetEquipRibbonNo(this[0],ribbonNo);
        }

        public bool HavePokerusJustNow()
        {
            return (m_accessor.GetPokerus() & 0xF) != 0;
        }

        public bool HavePokerusUntilNow()
        {
            return (m_accessor.GetPokerus() & 0xFF) != 0;
        }

        public bool HavePokerusPast()
        {
        	if (Accessor.GetPokerus(this[0]) != 0) {
        	  return (Accessor.GetPokerus(this[0]) & 0xf) == 0;
        	}
        	return false;
        }

        // TODO
        public void CatchPokerus() { }

        public void InfectPokerusWith(CoreParam target)
        {
            target.SetPokerus(GetPokerus());
        }

        public void DecreasePokerusDayCount(int passedDayCount)
        {
        	if ((Accessor.GetPokerus(this[0]) & 0xff) != 0) {
        	  var uVar1 = 0x10;
        	  if ((Accessor.GetPokerus(this[0]) & 0xf0) != 0) {
        	    uVar1 = Accessor.GetPokerus(this[0]) & 0xfffffff0;
        	  }
        	  var uVar2 = (Accessor.GetPokerus(this[0]) & 0xf) - passedDayCount;
        	  if ((int)(Accessor.GetPokerus(this[0]) & 0xf) < passedDayCount || 4 < passedDayCount) {
        	    uVar2 = 0;
        	  }
        	  GFL.ASSERT(((uVar1 | uVar2) & 0xff) != 0,0);
        	  Accessor.SetPokerus(this[0],uVar1 | uVar2);
        	}
        }

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