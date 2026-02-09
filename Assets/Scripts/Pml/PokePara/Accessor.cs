using System;
using System.Runtime.InteropServices;
using Pml;

namespace Pml.PokePara
{
    public class Accessor
    {
        private const uint CORE_DATA_SIZE = 328;
        private const uint CALC_DATA_SIZE = 16;
        public const uint FULL_SERIALIZE_DATA_SIZE = 344;
        public const uint CORE_SERIALIZE_DATA_SIZE = 328;
        private const uint MAX_RIBBON_NUM_ON_RIBBON_FIELD_1 = 32;
        private const uint MAX_RIBBON_NUM_ON_RIBBON_FIELD_2 = 32;
        private const uint MAX_RIBBON_NUM_ON_RIBBON_FIELD_3 = 32;
        private const uint MAX_RIBBON_NUM_ON_RIBBON_FIELD_4 = 32;
        private const uint MIN_RIBBON_NO_ON_RIBBON_FIELD_1 = 0;
        private const uint MIN_RIBBON_NO_ON_RIBBON_FIELD_2 = 32;
        private const uint MIN_RIBBON_NO_ON_RIBBON_FIELD_3 = 64;
        private const uint MIN_RIBBON_NO_ON_RIBBON_FIELD_4 = 96;
        private const uint MAX_RIBBON_NO_ON_RIBBON_FIELD_1 = 31;
        private const uint MAX_RIBBON_NO_ON_RIBBON_FIELD_2 = 63;
        private const uint MAX_RIBBON_NO_ON_RIBBON_FIELD_3 = 95;
        private const uint MAX_RIBBON_NO_ON_RIBBON_FIELD_4 = 127;
        private static unsafe byte* IllegalCoreData;
        private static unsafe byte* DummyWriteCoreData;
        private static unsafe byte* IllegalCalcData;
        private static unsafe byte* DummyWriteCalcData;
        private byte[] m_pCalcData;
        private byte[] m_pCoreData;
        private AccessState m_accessState;
        private const byte POS1 = 0;
        private const byte POS2 = 1;
        private const byte POS3 = 2;
        private const byte POS4 = 3;
        private static readonly byte[][] BLOCK_POS_TABLE = GenerateBlockPosTable();

        private static byte[][] GenerateBlockPosTable()
        {
            byte[][] order = new byte[24][]
            {
                new byte[] { 0, 1, 2, 3 },
                new byte[] { 0, 1, 3, 2 },
                new byte[] { 0, 2, 1, 3 },
                new byte[] { 0, 2, 3, 1 },
                new byte[] { 0, 3, 1, 2 },
                new byte[] { 0, 3, 2, 1 },
                new byte[] { 1, 0, 2, 3 },
                new byte[] { 1, 0, 3, 2 },
                new byte[] { 1, 2, 0, 3 },
                new byte[] { 1, 2, 3, 0 },
                new byte[] { 1, 3, 0, 2 },
                new byte[] { 1, 3, 2, 0 },
                new byte[] { 2, 0, 1, 3 },
                new byte[] { 2, 0, 3, 1 },
                new byte[] { 2, 1, 0, 3 },
                new byte[] { 2, 1, 3, 0 },
                new byte[] { 2, 3, 0, 1 },
                new byte[] { 2, 3, 1, 0 },
                new byte[] { 3, 0, 1, 2 },
                new byte[] { 3, 0, 2, 1 },
                new byte[] { 3, 1, 0, 2 },
                new byte[] { 3, 1, 2, 0 },
                new byte[] { 3, 2, 0, 1 },
                new byte[] { 3, 2, 1, 0 },
            };

            byte[][] table = new byte[32][];
            for (int i = 0; i < 32; i++)
                table[i] = order[i % 24];

            return table;
        }

        public static void Initialize() { }

        public void AttachDecodedData(byte[] coreData, byte[] calcData)
        {
            m_pCoreData = coreData;
            m_pCalcData = calcData;
            m_accessState.isEncoded = false;
            m_accessState.isFastMode = false;
            UpdateChecksumAndEncode();
        }

        public void AttachEncodedData(byte[] coreData, byte[] calcData)
        {
            m_pCoreData = coreData;
            m_pCalcData = calcData;
            m_accessState.isEncoded = true;
            m_accessState.isFastMode = false;
        }

        public bool HaveCalcData()
        {
            return m_pCalcData != null;
        }

        public void ClearData()
        {
            if (m_pCoreData != null)
                Array.Clear(m_pCoreData, 0, m_pCoreData.Length);

            if (m_pCalcData != null)
                Array.Clear(m_pCalcData, 0, m_pCalcData.Length);

            m_accessState.isEncoded = false;
            m_accessState.isFastMode = false;
            UpdateChecksumAndEncode();
        }

        public void ClearCalcData()
        {
            if (m_pCalcData != null)
                Array.Clear(m_pCalcData, 0, m_pCalcData.Length);
        }

        public void StartFastMode()
        {
            DecodeAndCheckIllegalWrite();
            m_accessState.isFastMode = true;
        }

        public void EndFastMode()
        {
            m_accessState.isFastMode = false;
            UpdateChecksumAndEncode();
        }

        public bool IsFastMode()
        {
            return m_accessState.isFastMode;
        }

        public bool IsEncoded()
        {
            return m_accessState.isEncoded;
        }

        public void Serialize_FullData(byte[] buffer)
        {
            unsafe
            {
                fixed (byte* dst = buffer)
                {
                    Serialize(dst, dst + CORE_SERIALIZE_DATA_SIZE);
                }
            }
        }

        public void Serialize_CoreData(byte[] buffer)
        {
            unsafe
            {
                fixed (byte* dst = buffer)
                {
                    Serialize(dst, null);
                }
            }
        }

        public void Deserialize_FullData(byte[] serializedData)
        {
            unsafe
            {
                fixed (byte* src = serializedData)
                {
                    Deserialize(src, src + CORE_SERIALIZE_DATA_SIZE);
                }
            }
        }

        public void Deserialize_CoreData(byte[] serializedData)
        {
            unsafe
            {
                fixed (byte* src = serializedData)
                {
                    Deserialize(src, null);
                }
            }
        }

        public unsafe void Serialize_FullData(void* buffer)
        {
            Serialize(buffer, (void*)((long)buffer + CORE_SERIALIZE_DATA_SIZE));
        }

        public unsafe void Serialize_CoreData(void* buffer)
        {
            Serialize(buffer, null);
        }

        public unsafe void Deserialize_FullData(void* serializedData)
        {
            Deserialize(serializedData, (void*)((long)serializedData + CORE_SERIALIZE_DATA_SIZE));
        }

        public unsafe void Deserialize_CoreData(void* serializedData)
        {
            Deserialize(serializedData, null);
        }

        // =============================================
        // Getters - Header
        // =============================================

        public uint GetPersonalRnd()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var header = GetCoreDataHeader(addr);
                    return header->personalRnd;
                }
            }
        }

        public uint GetCheckSum()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var header = GetCoreDataHeader(addr);
                    return header->checksum;
                }
            }
        }

        public bool IsFuseiTamago()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var header = GetCoreDataHeader(addr);
                    return header->fuseiTamagoFlag;
                }
            }
        }

        // =============================================
        // Getters - BlockA
        // =============================================

        public MonsNo GetMonsNo()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockA(addr, false);
                    return (MonsNo)block->monsno;
                }
            }
        }

        public uint GetItemNo()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockA(addr, false);
                    return block->itemno;
                }
            }
        }

        public uint GetID()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockA(addr, false);
                    return block->id;
                }
            }
        }

        public uint GetExp()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockA(addr, false);
                    return block->exp;
                }
            }
        }

        public TokuseiNo GetTokuseiNo()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockA(addr, false);
                    return (TokuseiNo)block->tokuseino;
                }
            }
        }

        public ushort GetBoxMark()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockA(addr, false);
                    return block->boxMark;
                }
            }
        }

        public uint GetColorRnd()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockA(addr, false);
                    return block->colorRnd;
                }
            }
        }

        public uint GetSeikaku()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockA(addr, false);
                    return block->seikaku;
                }
            }
        }

        public uint GetSeikakuHosei()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockA(addr, false);
                    return block->seikakuHosei;
                }
            }
        }

        public ushort GetFormNo()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockA(addr, false);
                    return block->formNo;
                }
            }
        }

        public uint GetEffortHp()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockA(addr, false);
                    return block->effortHp;
                }
            }
        }

        public uint GetEffortAtk()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockA(addr, false);
                    return block->effortAtk;
                }
            }
        }

        public uint GetEffortDef()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockA(addr, false);
                    return block->effortDef;
                }
            }
        }

        public uint GetEffortAgi()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockA(addr, false);
                    return block->effortAgi;
                }
            }
        }

        public uint GetEffortSpAtk()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockA(addr, false);
                    return block->effortSpatk;
                }
            }
        }

        public uint GetEffortSpDef()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockA(addr, false);
                    return block->effortSpdef;
                }
            }
        }

        public byte GetStyle()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockA(addr, false);
                    return block->style;
                }
            }
        }

        public byte GetBeautiful()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockA(addr, false);
                    return block->beautiful;
                }
            }
        }

        public byte GetCute()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockA(addr, false);
                    return block->cute;
                }
            }
        }

        public byte GetClever()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockA(addr, false);
                    return block->clever;
                }
            }
        }

        public byte GetStrong()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockA(addr, false);
                    return block->strong;
                }
            }
        }

        public byte GetFur()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockA(addr, false);
                    return block->fur;
                }
            }
        }

        public uint GetPokerus()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockA(addr, false);
                    return block->pokerus;
                }
            }
        }

        public bool IsTokusei1()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockA(addr, false);
                    return block->tokusei1Flag;
                }
            }
        }

        public bool IsTokusei2()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockA(addr, false);
                    return block->tokusei2Flag;
                }
            }
        }

        public bool IsTokusei3()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockA(addr, false);
                    return block->tokusei3Flag;
                }
            }
        }

        public bool IsFavorite()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockA(addr, false);
                    return block->favoriteFlag;
                }
            }
        }

        public bool IsSpecialGEnable()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockA(addr, false);
                    return block->special_g_flag;
                }
            }
        }

        public bool IsEventPokemon()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockA(addr, false);
                    return block->eventGetFlag;
                }
            }
        }

        public bool GetOfficialBattleEnableFlag()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockA(addr, false);
                    return block->officialBattleEnableFlag;
                }
            }
        }

        public Sex GetSex()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockA(addr, false);
                    return (Sex)block->sex;
                }
            }
        }

        public byte GetCampFriendship()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockA(addr, false);
                    return (byte)block->camp_friendship;
                }
            }
        }

        public bool GetDprIllegalFlag()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockA(addr, false);
                    return block->dpr_illegal_flag;
                }
            }
        }

        public byte GetTalentHeight()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockA(addr, false);
                    return block->talentHeight;
                }
            }
        }

        public byte GetTalentWeight()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockA(addr, false);
                    return block->talentWeight;
                }
            }
        }

        public bool HaveRibbon(uint ribbonNo)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockA(addr, false);
                    if (ribbonNo <= MAX_RIBBON_NO_ON_RIBBON_FIELD_1)
                        return (block->ribbonA & (1u << (int)(ribbonNo - MIN_RIBBON_NO_ON_RIBBON_FIELD_1))) != 0;
                    else if (ribbonNo <= MAX_RIBBON_NO_ON_RIBBON_FIELD_2)
                        return (block->ribbonB & (1u << (int)(ribbonNo - MIN_RIBBON_NO_ON_RIBBON_FIELD_2))) != 0;
                    else if (ribbonNo <= MAX_RIBBON_NO_ON_RIBBON_FIELD_3)
                        return (block->ribbonC & (1u << (int)(ribbonNo - MIN_RIBBON_NO_ON_RIBBON_FIELD_3))) != 0;
                    else if (ribbonNo <= MAX_RIBBON_NO_ON_RIBBON_FIELD_4)
                        return (block->ribbonD & (1u << (int)(ribbonNo - MIN_RIBBON_NO_ON_RIBBON_FIELD_4))) != 0;

                    return false;
                }
            }
        }

        public uint GetLumpingRibbon(LumpingRibbon ribbonId)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockA(addr, false);
                    switch (ribbonId)
                    {
                        case LumpingRibbon.A:
                            return block->lumpingRibbonA;
                        case LumpingRibbon.B:
                            return block->lumpingRibbonB;
                        default:
                            return 0;
                    }
                }
            }
        }

        // =============================================
        // Getters - BlockB
        // =============================================

        public uint GetSick()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockB(addr, false);
                    return block->sick;
                }
            }
        }

        public WazaNo GetWazaNo(byte wazaIndex)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockB(addr, false);
                    if (wazaIndex < PmlConstants.MAX_WAZA_NUM)
                        return (WazaNo)block->waza[wazaIndex];
                    return WazaNo.NULL;
                }
            }
        }

        public byte GetPP(byte wazaIndex)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockB(addr, false);
                    if (wazaIndex < PmlConstants.MAX_WAZA_NUM)
                        return block->pp[wazaIndex];
                    return 0;
                }
            }
        }

        public byte GetWazaPPUpCount(byte wazaIndex)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockB(addr, false);
                    if (wazaIndex < PmlConstants.MAX_WAZA_NUM)
                        return block->pointupUsedCount[wazaIndex];
                    return 0;
                }
            }
        }

        public WazaNo GetTamagoWazaNo(byte index)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockB(addr, false);
                    if (index < PmlConstants.MAX_WAZA_NUM)
                        return (WazaNo)block->tamagoWaza[index];
                    return WazaNo.NULL;
                }
            }
        }

        public uint GetHp()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockB(addr, false);
                    return block->hp;
                }
            }
        }

        public uint GetTalentHp()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockB(addr, false);
                    return block->talentHp;
                }
            }
        }

        public uint GetTalentAtk()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockB(addr, false);
                    return block->talentAtk;
                }
            }
        }

        public uint GetTalentDef()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockB(addr, false);
                    return block->talentDef;
                }
            }
        }

        public uint GetTalentSpAtk()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockB(addr, false);
                    return block->talentSpatk;
                }
            }
        }

        public uint GetTalentSpDef()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockB(addr, false);
                    return block->talentSpdef;
                }
            }
        }

        public uint GetTalentAgi()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockB(addr, false);
                    return block->talentAgi;
                }
            }
        }

        public uint GetEffortG()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockB(addr, false);
                    return block->effortG;
                }
            }
        }

        public bool IsTamago()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockB(addr, false);
                    return block->tamagoFlag;
                }
            }
        }

        public bool HaveNickName()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockB(addr, false);
                    return block->nicknameFlag;
                }
            }
        }

        public string GetNickName()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockB(addr, false);
                    return new string(block->nickname);
                }
            }
        }

        public uint GetPalma()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockB(addr, false);
                    return block->palma;
                }
            }
        }

        // =============================================
        // Getters - BlockC
        // =============================================

        public string GetPastParentsName()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockC(addr, false);
                    return new string(block->pastParentsName);
                }
            }
        }

        public Sex GetPastParentsSex()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockC(addr, false);
                    return (Sex)block->pastParentsSex;
                }
            }
        }

        public byte GetPastParentsLangID()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockC(addr, false);
                    return block->pastParentLangID;
                }
            }
        }

        public bool GetOwnedOthersFlag()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockC(addr, false);
                    return block->ownedByOthers != 0;
                }
            }
        }

        public ushort GetOthersFriendshipTrainerID()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockC(addr, false);
                    return block->othersFriendshipTrainerId;
                }
            }
        }

        public byte GetOthersFriendship()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockC(addr, false);
                    return block->othersFriendship;
                }
            }
        }

        public byte GetOthersMemoriesLevel()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockC(addr, false);
                    return block->othersMemoriesLevel;
                }
            }
        }

        public byte GetOthersMemoriesCode()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockC(addr, false);
                    return block->othersMemoriesCode;
                }
            }
        }

        public ushort GetOthersMemoriesData()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockC(addr, false);
                    return block->othersMemoriesData;
                }
            }
        }

        public byte GetOthersMemoriesFeel()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockC(addr, false);
                    return block->othersMemoriesFeel;
                }
            }
        }

        public bool GetPokeJobFlag(byte jobIndex)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockC(addr, false);
                    CalcPokeJobBitPos(out byte arrayIndex, out byte bitFlag, jobIndex);
                    if (arrayIndex < CoreDataBlockC.POKEJOB_LEN)
                        return (block->pokejob[arrayIndex] & bitFlag) != 0;
                    return false;
                }
            }
        }

        public byte GetEnjoy()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockC(addr, false);
                    return block->enjoy;
                }
            }
        }

        public byte GetNadenadeValue()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockC(addr, false);
                    return block->nadeNadeValue;
                }
            }
        }

        public uint GetCassetteVersion()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockC(addr, false);
                    return block->getCassette;
                }
            }
        }

        public byte GetBattleRomMark()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockC(addr, false);
                    return block->battleRomMark;
                }
            }
        }

        public uint GetLangId()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockC(addr, false);
                    return block->langId;
                }
            }
        }

        public uint GetMultiPurposeWork()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockC(addr, false);
                    return block->multiWork;
                }
            }
        }

        public byte GetEquipRibbonNo()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockC(addr, false);
                    return block->equipRibbon;
                }
            }
        }

        // =============================================
        // Getters - BlockD
        // =============================================

        public string GetOyaName()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockD(addr, false);
                    return new string(block->parentsName);
                }
            }
        }

        public uint GetFriendship()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var blockC = GetCoreDataBlockC(addr, false);
                    if (blockC->ownedByOthers != 0)
                        return blockC->othersFriendship;

                    var block = GetCoreDataBlockD(addr, false);
                    return block->friendship;
                }
            }
        }

        public byte GetOriginalFriendship()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockD(addr, false);
                    return block->friendship;
                }
            }
        }

        public byte GetMemoriesLevel()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockD(addr, false);
                    return block->memories_level;
                }
            }
        }

        public byte GetMemoriesCode()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockD(addr, false);
                    return block->memories_code;
                }
            }
        }

        public ushort GetMemoriesData()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockD(addr, false);
                    return block->memories_data;
                }
            }
        }

        public byte GetMemoriesFeel()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockD(addr, false);
                    return block->memories_feel;
                }
            }
        }

        public uint GetTamagoGetYear()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockD(addr, false);
                    return block->eggGetYear;
                }
            }
        }

        public uint GetTamagoGetMonth()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockD(addr, false);
                    return block->eggGetMonth;
                }
            }
        }

        public uint GetTamagoGetDay()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockD(addr, false);
                    return block->eggGetDay;
                }
            }
        }

        public uint GetBirthYear()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockD(addr, false);
                    return block->firstContactYear;
                }
            }
        }

        public uint GetBirthMonth()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockD(addr, false);
                    return block->firstContactMonth;
                }
            }
        }

        public uint GetBirthDay()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockD(addr, false);
                    return block->firstContactDay;
                }
            }
        }

        public uint GetGetPlace()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockD(addr, false);
                    return block->getPlace;
                }
            }
        }

        public uint GetBirthPlace()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockD(addr, false);
                    return block->birthPlace;
                }
            }
        }

        public uint GetGetBall()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockD(addr, false);
                    return block->getBall;
                }
            }
        }

        public uint GetGetLevel()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockD(addr, false);
                    return block->getLevel;
                }
            }
        }

        public Sex GetOyasex()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockD(addr, false);
                    return (Sex)block->parentsSex;
                }
            }
        }

        public byte GetTrainingFlag()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockD(addr, false);
                    return block->trainingFlag;
                }
            }
        }

        public bool GetWazaRecordFlag(byte recordIndex)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockD(addr, false);
                    CalcWazaRecordBitPos(out byte arrayIndex, out byte bitFlag, recordIndex);
                    if (arrayIndex < CoreDataBlockD.WAZA_RECORD_FLAG_LEN)
                        return (block->wazaRecordFlag[arrayIndex] & bitFlag) != 0;
                    return false;
                }
            }
        }

        public ulong GetBankUniqueID()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockD(addr, false);
                    ulong value = 0;
                    for (int i = 0; i < CoreDataBlockD.BANK_UNIQUE_ID_LEN; i++)
                        value |= (ulong)block->bankUniqueID[i] << (i * 8);
                    return value;
                }
            }
        }

        public bool CompareOyaName(string cmpName)
        {
            return GetOyaName() == cmpName;
        }

        // =============================================
        // Getters - CalcData
        // =============================================

        public uint GetLevel()
        {
            unsafe
            {
                fixed (byte* addr = m_pCalcData)
                {
                    var calc = GetCalcData(addr, false);
                    return calc->level;
                }
            }
        }

        public uint GetMaxHp()
        {
            unsafe
            {
                fixed (byte* addr = m_pCalcData)
                {
                    var calc = GetCalcData(addr, false);
                    return calc->maxHp;
                }
            }
        }

        public uint GetAtk()
        {
            unsafe
            {
                fixed (byte* addr = m_pCalcData)
                {
                    var calc = GetCalcData(addr, false);
                    return calc->atk;
                }
            }
        }

        public uint GetDef()
        {
            unsafe
            {
                fixed (byte* addr = m_pCalcData)
                {
                    var calc = GetCalcData(addr, false);
                    return calc->def;
                }
            }
        }

        public uint GetSpAtk()
        {
            unsafe
            {
                fixed (byte* addr = m_pCalcData)
                {
                    var calc = GetCalcData(addr, false);
                    return calc->spatk;
                }
            }
        }

        public uint GetSpDef()
        {
            unsafe
            {
                fixed (byte* addr = m_pCalcData)
                {
                    var calc = GetCalcData(addr, false);
                    return calc->spdef;
                }
            }
        }

        public uint GetAgi()
        {
            unsafe
            {
                fixed (byte* addr = m_pCalcData)
                {
                    var calc = GetCalcData(addr, false);
                    return calc->agi;
                }
            }
        }

        public GState GetGState()
        {
            unsafe
            {
                fixed (byte* addr = m_pCalcData)
                {
                    var calc = GetCalcData(addr, false);
                    return (GState)calc->gState;
                }
            }
        }

        // =============================================
        // Setters - Header
        // =============================================

        public void SetPersonalRnd(uint rnd)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var header = GetCoreDataHeader(addr);
                    header->personalRnd = rnd;
                }
            }
        }

        public void SetCheckSum(ushort checksum)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var header = GetCoreDataHeader(addr);
                    header->checksum = checksum;
                }
            }
        }

        public void SetFuseiTamagoFlag(bool flag)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var header = GetCoreDataHeader(addr);
                    header->fuseiTamagoFlag = flag;
                }
            }
        }

        // =============================================
        // Setters - BlockA
        // =============================================

        public void SetMonsNo(uint monsno)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockA(addr, true);
                    block->monsno = (ushort)monsno;
                }
            }
        }

        public void SetItemNo(ushort itemno)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockA(addr, true);
                    block->itemno = itemno;
                }
            }
        }

        public void SetID(uint id)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockA(addr, true);
                    block->id = id;
                }
            }
        }

        public void SetExp(uint exp)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockA(addr, true);
                    block->exp = exp;
                }
            }
        }

        public void SetTokuseiNo(uint tokusei)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockA(addr, true);
                    block->tokuseino = (ushort)tokusei;
                }
            }
        }

        public void SetBoxMark(ushort mark)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockA(addr, true);
                    block->boxMark = mark;
                }
            }
        }

        public void SetColorRnd(uint rnd)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockA(addr, true);
                    block->colorRnd = rnd;
                }
            }
        }

        public void SetSeikaku(uint seikaku)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockA(addr, true);
                    block->seikaku = (byte)seikaku;
                }
            }
        }

        public void SetSeikakuHosei(uint seikaku)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockA(addr, true);
                    block->seikakuHosei = (byte)seikaku;
                }
            }
        }

        public void SetFormNo(ushort formno)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockA(addr, true);
                    block->formNo = formno;
                }
            }
        }

        public void SetEffortHp(byte value)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockA(addr, true);
                    block->effortHp = value;
                }
            }
        }

        public void SetEffortAtk(byte value)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockA(addr, true);
                    block->effortAtk = value;
                }
            }
        }

        public void SetEffortDef(byte value)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockA(addr, true);
                    block->effortDef = value;
                }
            }
        }

        public void SetEffortAgi(byte value)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockA(addr, true);
                    block->effortAgi = value;
                }
            }
        }

        public void SetEffortSpAtk(byte value)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockA(addr, true);
                    block->effortSpatk = value;
                }
            }
        }

        public void SetEffortSpDef(byte value)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockA(addr, true);
                    block->effortSpdef = value;
                }
            }
        }

        public void SetStyle(byte style)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockA(addr, true);
                    block->style = style;
                }
            }
        }

        public void SetBeautiful(byte beautiful)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockA(addr, true);
                    block->beautiful = beautiful;
                }
            }
        }

        public void SetCute(byte cute)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockA(addr, true);
                    block->cute = cute;
                }
            }
        }

        public void SetClever(byte clever)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockA(addr, true);
                    block->clever = clever;
                }
            }
        }

        public void SetStrong(byte strong)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockA(addr, true);
                    block->strong = strong;
                }
            }
        }

        public void SetFur(byte fur)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockA(addr, true);
                    block->fur = fur;
                }
            }
        }

        public void SetPokerus(byte pokerus)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockA(addr, true);
                    block->pokerus = pokerus;
                }
            }
        }

        public void SetRibbon(uint ribbonNo)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockA(addr, true);
                    if (ribbonNo <= MAX_RIBBON_NO_ON_RIBBON_FIELD_1)
                        block->ribbonA |= (1u << (int)(ribbonNo - MIN_RIBBON_NO_ON_RIBBON_FIELD_1));
                    else if (ribbonNo <= MAX_RIBBON_NO_ON_RIBBON_FIELD_2)
                        block->ribbonB |= (1u << (int)(ribbonNo - MIN_RIBBON_NO_ON_RIBBON_FIELD_2));
                    else if (ribbonNo <= MAX_RIBBON_NO_ON_RIBBON_FIELD_3)
                        block->ribbonC |= (1u << (int)(ribbonNo - MIN_RIBBON_NO_ON_RIBBON_FIELD_3));
                    else if (ribbonNo <= MAX_RIBBON_NO_ON_RIBBON_FIELD_4)
                        block->ribbonD |= (1u << (int)(ribbonNo - MIN_RIBBON_NO_ON_RIBBON_FIELD_4));
                }
            }
        }

        public void RemoveRibbon(uint ribbonNo)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockA(addr, true);
                    if (ribbonNo <= MAX_RIBBON_NO_ON_RIBBON_FIELD_1)
                        block->ribbonA &= ~(1u << (int)(ribbonNo - MIN_RIBBON_NO_ON_RIBBON_FIELD_1));
                    else if (ribbonNo <= MAX_RIBBON_NO_ON_RIBBON_FIELD_2)
                        block->ribbonB &= ~(1u << (int)(ribbonNo - MIN_RIBBON_NO_ON_RIBBON_FIELD_2));
                    else if (ribbonNo <= MAX_RIBBON_NO_ON_RIBBON_FIELD_3)
                        block->ribbonC &= ~(1u << (int)(ribbonNo - MIN_RIBBON_NO_ON_RIBBON_FIELD_3));
                    else if (ribbonNo <= MAX_RIBBON_NO_ON_RIBBON_FIELD_4)
                        block->ribbonD &= ~(1u << (int)(ribbonNo - MIN_RIBBON_NO_ON_RIBBON_FIELD_4));
                }
            }
        }

        public void RemoveAllRibbon()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockA(addr, true);
                    block->ribbonA = 0;
                    block->ribbonB = 0;
                    block->ribbonC = 0;
                    block->ribbonD = 0;
                    block->lumpingRibbonA = 0;
                    block->lumpingRibbonB = 0;
                }
            }
        }

        public void SetLumpingRibbon(LumpingRibbon ribbonId, uint num)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockA(addr, true);
                    switch (ribbonId)
                    {
                        case LumpingRibbon.A:
                            block->lumpingRibbonA = (byte)num;
                            break;
                        case LumpingRibbon.B:
                            block->lumpingRibbonB = (byte)num;
                            break;
                    }
                }
            }
        }

        public void SetTokusei1Flag(bool flag)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockA(addr, true);
                    block->tokusei1Flag = flag;
                }
            }
        }

        public void SetTokusei2Flag(bool flag)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockA(addr, true);
                    block->tokusei2Flag = flag;
                }
            }
        }

        public void SetTokusei3Flag(bool flag)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockA(addr, true);
                    block->tokusei3Flag = flag;
                }
            }
        }

        public void SetFavoriteFlag(bool flag)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockA(addr, true);
                    block->favoriteFlag = flag;
                }
            }
        }

        public void SetSpecialGFlag(bool flag)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockA(addr, true);
                    block->special_g_flag = flag;
                }
            }
        }

        public void SetEventPokemonFlag(bool flag)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockA(addr, true);
                    block->eventGetFlag = flag;
                }
            }
        }

        public void SetOfficialBattleEnableFlag(bool flag)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockA(addr, true);
                    block->officialBattleEnableFlag = flag;
                }
            }
        }

        public void SetSex(Sex sex)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockA(addr, true);
                    block->sex = (byte)sex;
                }
            }
        }

        public void SetCampFriendship(byte value)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockA(addr, true);
                    block->camp_friendship = value;
                }
            }
        }

        public void SetDprIllegalFlag(bool flag)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockA(addr, true);
                    block->dpr_illegal_flag = flag;
                }
            }
        }

        public void SetTalentHeight(byte value)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockA(addr, true);
                    block->talentHeight = value;
                }
            }
        }

        public void SetTalentWeight(byte value)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockA(addr, true);
                    block->talentWeight = value;
                }
            }
        }

        // =============================================
        // Setters - BlockB
        // =============================================

        public void SetSick(uint sick)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockB(addr, true);
                    block->sick = sick;
                }
            }
        }

        public void SetWazaNo(byte wazaIndex, uint wazano)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockB(addr, true);
                    if (wazaIndex < PmlConstants.MAX_WAZA_NUM)
                        block->waza[wazaIndex] = (ushort)wazano;
                }
            }
        }

        public void SetPP(byte wazaIndex, byte pp)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockB(addr, true);
                    if (wazaIndex < PmlConstants.MAX_WAZA_NUM)
                        block->pp[wazaIndex] = pp;
                }
            }
        }

        public void SetWazaPPUpCount(byte wazaIndex, byte count)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockB(addr, true);
                    if (wazaIndex < PmlConstants.MAX_WAZA_NUM)
                        block->pointupUsedCount[wazaIndex] = count;
                }
            }
        }

        public void SetTamagoWazaNo(byte index, uint wazano)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockB(addr, true);
                    if (index < PmlConstants.MAX_WAZA_NUM)
                        block->tamagoWaza[index] = (ushort)wazano;
                }
            }
        }

        public void SetHp(ushort hp)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockB(addr, true);
                    block->hp = hp;
                }
            }
        }

        public void SetTalentHp(byte value)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockB(addr, true);
                    block->talentHp = value;
                }
            }
        }

        public void SetTalentAtk(byte value)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockB(addr, true);
                    block->talentAtk = value;
                }
            }
        }

        public void SetTalentDef(byte value)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockB(addr, true);
                    block->talentDef = value;
                }
            }
        }

        public void SetTalentSpAtk(byte value)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockB(addr, true);
                    block->talentSpatk = value;
                }
            }
        }

        public void SetTalentSpDef(byte value)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockB(addr, true);
                    block->talentSpdef = value;
                }
            }
        }

        public void SetTalentAgi(byte value)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockB(addr, true);
                    block->talentAgi = value;
                }
            }
        }

        public void SetEffortG(byte value)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockB(addr, true);
                    block->effortG = value;
                }
            }
        }

        public void SetTamagoFlag(bool flag)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockB(addr, true);
                    block->tamagoFlag = flag;
                }
            }
        }

        public void SetNickNameFlag(bool flag)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockB(addr, true);
                    block->nicknameFlag = flag;
                }
            }
        }

        public void SetNickName(string nickName)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockB(addr, true);
                    copyString(block->nickname, nickName, PmlConstants.MONS_NAME_BUFFER_SIZE);
                }
            }
        }

        public void SetPalma(uint value)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockB(addr, true);
                    block->palma = value;
                }
            }
        }

        // =============================================
        // Setters - BlockC
        // =============================================

        public void SetPastParentsName(string name)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockC(addr, true);
                    copyString(block->pastParentsName, name, PmlConstants.PERSON_NAME_BUFFER_SIZE);
                }
            }
        }

        public void SetPastParentsSex(Sex sex)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockC(addr, true);
                    block->pastParentsSex = (byte)sex;
                }
            }
        }

        public void SetPastParentsLangID(byte langID)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockC(addr, true);
                    block->pastParentLangID = langID;
                }
            }
        }

        public void SetOwnedOthersFlag(bool flag)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockC(addr, true);
                    block->ownedByOthers = (byte)(flag ? 1 : 0);
                }
            }
        }

        public void SetOthersFriendshipTrainerID(ushort trainerId)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockC(addr, true);
                    block->othersFriendshipTrainerId = trainerId;
                }
            }
        }

        public void SetOthersFriendship(byte friendship)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockC(addr, true);
                    block->othersFriendship = friendship;
                }
            }
        }

        public void SetOthersMemoriesLevel(byte level)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockC(addr, true);
                    block->othersMemoriesLevel = level;
                }
            }
        }

        public void SetOthersMemoriesCode(byte code)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockC(addr, true);
                    block->othersMemoriesCode = code;
                }
            }
        }

        public void SetOthersMemoriesData(ushort data)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockC(addr, true);
                    block->othersMemoriesData = data;
                }
            }
        }

        public void SetOthersMemoriesFeel(byte feel)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockC(addr, true);
                    block->othersMemoriesFeel = feel;
                }
            }
        }

        public void SetPokeJobFlag(byte jobIndex, bool set)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockC(addr, true);
                    CalcPokeJobBitPos(out byte arrayIndex, out byte bitFlag, jobIndex);
                    if (arrayIndex < CoreDataBlockC.POKEJOB_LEN)
                    {
                        if (set)
                            block->pokejob[arrayIndex] |= bitFlag;
                        else
                            block->pokejob[arrayIndex] &= (byte)~bitFlag;
                    }
                }
            }
        }

        public void ClearPokeJobFlag()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockC(addr, true);
                    for (int i = 0; i < CoreDataBlockC.POKEJOB_LEN; i++)
                        block->pokejob[i] = 0;
                }
            }
        }

        public void SetEnjoy(byte enjoy)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockC(addr, true);
                    block->enjoy = enjoy;
                }
            }
        }

        public void SetNadenadeValue(byte value)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockC(addr, true);
                    block->nadeNadeValue = value;
                }
            }
        }

        public void SetCassetteVersion(uint version)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockC(addr, true);
                    block->getCassette = (byte)version;
                }
            }
        }

        public void SetBattleRomMark(byte value)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockC(addr, true);
                    block->battleRomMark = value;
                }
            }
        }

        public void SetLangId(byte langId)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockC(addr, true);
                    block->langId = langId;
                }
            }
        }

        public void SetMultiPurposeWork(uint value)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockC(addr, true);
                    block->multiWork = value;
                }
            }
        }

        public void SetEquipRibbonNo(byte ribbonNo)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockC(addr, true);
                    block->equipRibbon = ribbonNo;
                }
            }
        }

        // =============================================
        // Setters - BlockD
        // =============================================

        public void SetOyaName(string oyaName)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockD(addr, true);
                    copyString(block->parentsName, oyaName, PmlConstants.PERSON_NAME_BUFFER_SIZE);
                }
            }
        }

        public void SetFriendship(byte friendship)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var blockC = GetCoreDataBlockC(addr, false);
                    if (blockC->ownedByOthers != 0)
                    {
                        var blockCW = GetCoreDataBlockC(addr, true);
                        blockCW->othersFriendship = friendship;
                    }
                    else
                    {
                        var block = GetCoreDataBlockD(addr, true);
                        block->friendship = friendship;
                    }
                }
            }
        }

        public void SetOriginalFriendship(byte friendship)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockD(addr, true);
                    block->friendship = friendship;
                }
            }
        }

        public void SetMemoriesLevel(byte level)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockD(addr, true);
                    block->memories_level = level;
                }
            }
        }

        public void SetMemoriesCode(byte code)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockD(addr, true);
                    block->memories_code = code;
                }
            }
        }

        public void SetMemoriesData(ushort data)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockD(addr, true);
                    block->memories_data = data;
                }
            }
        }

        public void SetMemoriesFeel(byte feel)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockD(addr, true);
                    block->memories_feel = feel;
                }
            }
        }

        public void SetTamagoGetYear(byte year)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockD(addr, true);
                    block->eggGetYear = year;
                }
            }
        }

        public void SetTamagoGetMonth(byte month)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockD(addr, true);
                    block->eggGetMonth = month;
                }
            }
        }

        public void SetTamagoGetDay(byte day)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockD(addr, true);
                    block->eggGetDay = day;
                }
            }
        }

        public void SetBirthYear(byte year)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockD(addr, true);
                    block->firstContactYear = year;
                }
            }
        }

        public void SetBirthMonth(byte month)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockD(addr, true);
                    block->firstContactMonth = month;
                }
            }
        }

        public void SetBirthDay(byte day)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockD(addr, true);
                    block->firstContactDay = day;
                }
            }
        }

        public void SetGetPlace(ushort place)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockD(addr, true);
                    block->getPlace = place;
                }
            }
        }

        public void SetBirthPlace(ushort place)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockD(addr, true);
                    block->birthPlace = place;
                }
            }
        }

        public void SetGetBall(byte ball)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockD(addr, true);
                    block->getBall = ball;
                }
            }
        }

        public void SetGetLevel(byte level)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockD(addr, true);
                    block->getLevel = level;
                }
            }
        }

        public void SetOyasex(Sex sex)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockD(addr, true);
                    block->parentsSex = (byte)sex;
                }
            }
        }

        public void SetTrainingFlag(byte value)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockD(addr, true);
                    block->trainingFlag = value;
                }
            }
        }

        public void SetWazaRecordFlag(byte recordIndex, bool set)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockD(addr, true);
                    CalcWazaRecordBitPos(out byte arrayIndex, out byte bitFlag, recordIndex);
                    if (arrayIndex < CoreDataBlockD.WAZA_RECORD_FLAG_LEN)
                    {
                        if (set)
                            block->wazaRecordFlag[arrayIndex] |= bitFlag;
                        else
                            block->wazaRecordFlag[arrayIndex] &= (byte)~bitFlag;
                    }
                }
            }
        }

        public void ClearWazaRecordFlag()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockD(addr, true);
                    for (int i = 0; i < CoreDataBlockD.WAZA_RECORD_FLAG_LEN; i++)
                        block->wazaRecordFlag[i] = 0;
                }
            }
        }

        public void SetBankUniqueID(ulong value)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockD(addr, true);
                    for (int i = 0; i < CoreDataBlockD.BANK_UNIQUE_ID_LEN; i++)
                        block->bankUniqueID[i] = (byte)(value >> (i * 8));
                }
            }
        }

        public void ClearBankUniqueID()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var block = GetCoreDataBlockD(addr, true);
                    for (int i = 0; i < CoreDataBlockD.BANK_UNIQUE_ID_LEN; i++)
                        block->bankUniqueID[i] = 0;
                }
            }
        }

        // =============================================
        // Setters - CalcData
        // =============================================

        public void SetLevel(byte level)
        {
            unsafe
            {
                fixed (byte* addr = m_pCalcData)
                {
                    var calc = GetCalcData(addr, true);
                    calc->level = level;
                }
            }
        }

        public void SetMaxHp(ushort maxHp)
        {
            unsafe
            {
                fixed (byte* addr = m_pCalcData)
                {
                    var calc = GetCalcData(addr, true);
                    calc->maxHp = maxHp;
                }
            }
        }

        public void SetAtk(ushort atk)
        {
            unsafe
            {
                fixed (byte* addr = m_pCalcData)
                {
                    var calc = GetCalcData(addr, true);
                    calc->atk = atk;
                }
            }
        }

        public void SetDef(ushort def)
        {
            unsafe
            {
                fixed (byte* addr = m_pCalcData)
                {
                    var calc = GetCalcData(addr, true);
                    calc->def = def;
                }
            }
        }

        public void SetSpAtk(ushort spatk)
        {
            unsafe
            {
                fixed (byte* addr = m_pCalcData)
                {
                    var calc = GetCalcData(addr, true);
                    calc->spatk = spatk;
                }
            }
        }

        public void SetSpDef(ushort spdef)
        {
            unsafe
            {
                fixed (byte* addr = m_pCalcData)
                {
                    var calc = GetCalcData(addr, true);
                    calc->spdef = spdef;
                }
            }
        }

        public void SetAgi(ushort agi)
        {
            unsafe
            {
                fixed (byte* addr = m_pCalcData)
                {
                    var calc = GetCalcData(addr, true);
                    calc->agi = agi;
                }
            }
        }

        public void SetGState(GState state)
        {
            unsafe
            {
                fixed (byte* addr = m_pCalcData)
                {
                    var calc = GetCalcData(addr, true);
                    calc->gState = (byte)state;
                }
            }
        }

        // =============================================
        // Infrastructure
        // =============================================

        private unsafe CalcData* GetCalcData(byte* _addr, bool forWrite)
        {
            return (CalcData*)_addr;
        }

        private unsafe CoreDataBlockA* GetCoreDataBlockA(byte* _addr, bool forWrite)
        {
            if (!m_accessState.isFastMode)
            {
                if (forWrite)
                    DecodeAndCheckIllegalWrite();
                else
                    DecodeAndCheckIllegalWrite();
            }

            var header = GetCoreDataHeader(_addr);
            byte pos = GetCoreDataBlockPos(header->personalRnd, CoreDataBlockId.A);
            byte* blockStart = _addr + CoreDataHeader.SIZE + pos * CoreData.CORE_DATA_BLOCK_SIZE;

            if (!m_accessState.isFastMode && !forWrite)
                UpdateChecksumAndEncode();

            return (CoreDataBlockA*)blockStart;
        }

        private unsafe CoreDataBlockB* GetCoreDataBlockB(byte* _addr, bool forWrite)
        {
            if (!m_accessState.isFastMode)
            {
                if (forWrite)
                    DecodeAndCheckIllegalWrite();
                else
                    DecodeAndCheckIllegalWrite();
            }

            var header = GetCoreDataHeader(_addr);
            byte pos = GetCoreDataBlockPos(header->personalRnd, CoreDataBlockId.B);
            byte* blockStart = _addr + CoreDataHeader.SIZE + pos * CoreData.CORE_DATA_BLOCK_SIZE;

            if (!m_accessState.isFastMode && !forWrite)
                UpdateChecksumAndEncode();

            return (CoreDataBlockB*)blockStart;
        }

        private unsafe CoreDataBlockC* GetCoreDataBlockC(byte* _addr, bool forWrite)
        {
            if (!m_accessState.isFastMode)
            {
                if (forWrite)
                    DecodeAndCheckIllegalWrite();
                else
                    DecodeAndCheckIllegalWrite();
            }

            var header = GetCoreDataHeader(_addr);
            byte pos = GetCoreDataBlockPos(header->personalRnd, CoreDataBlockId.C);
            byte* blockStart = _addr + CoreDataHeader.SIZE + pos * CoreData.CORE_DATA_BLOCK_SIZE;

            if (!m_accessState.isFastMode && !forWrite)
                UpdateChecksumAndEncode();

            return (CoreDataBlockC*)blockStart;
        }

        private unsafe CoreDataBlockD* GetCoreDataBlockD(byte* _addr, bool forWrite)
        {
            if (!m_accessState.isFastMode)
            {
                if (forWrite)
                    DecodeAndCheckIllegalWrite();
                else
                    DecodeAndCheckIllegalWrite();
            }

            var header = GetCoreDataHeader(_addr);
            byte pos = GetCoreDataBlockPos(header->personalRnd, CoreDataBlockId.D);
            byte* blockStart = _addr + CoreDataHeader.SIZE + pos * CoreData.CORE_DATA_BLOCK_SIZE;

            if (!m_accessState.isFastMode && !forWrite)
                UpdateChecksumAndEncode();

            return (CoreDataBlockD*)blockStart;
        }

        protected unsafe static CoreDataHeader* GetCoreDataHeader(byte* addr)
        {
            return (CoreDataHeader*)addr;
        }

        private unsafe static byte GetCoreDataBlockPos(uint key, CoreDataBlockId blockId)
        {
            uint index = (key >> 13) & 0x1F;
            return BLOCK_POS_TABLE[index][(int)blockId];
        }

        private void UpdateChecksumAndEncode()
        {
            if (m_accessState.isEncoded || m_accessState.isFastMode)
                return;

            updateChecksumAndEncode_Core(m_pCoreData);

            if (m_pCalcData != null)
                updateChecksumAndEncode_Calc(m_pCoreData, m_pCalcData);

            m_accessState.isEncoded = true;
        }

        public static void updateChecksumAndEncode_Core(byte[] pCoreData)
        {
            unsafe
            {
                fixed (byte* addr = pCoreData)
                {
                    var header = GetCoreDataHeader(addr);
                    uint personalRnd = header->personalRnd;

                    byte* blocksStart = addr + CoreDataHeader.SIZE;
                    uint blocksSize = CORE_DATA_SIZE - CoreDataHeader.SIZE;

                    header->checksum = Encoder.CalcChecksum(blocksStart, blocksSize);

                    Encoder.Encode(blocksStart, blocksSize, personalRnd);
                }
            }
        }

        private static void updateChecksumAndEncode_Calc(byte[] pCoreData, byte[] pCalcData)
        {
            unsafe
            {
                fixed (byte* coreAddr = pCoreData)
                fixed (byte* calcAddr = pCalcData)
                {
                    var header = GetCoreDataHeader(coreAddr);
                    uint personalRnd = header->personalRnd;

                    Encoder.Encode(calcAddr, CALC_DATA_SIZE, personalRnd);
                }
            }
        }

        private void DecodeAndCheckIllegalWrite()
        {
            if (!m_accessState.isEncoded)
                return;

            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var header = GetCoreDataHeader(addr);
                    uint personalRnd = header->personalRnd;

                    byte* blocksStart = addr + CoreDataHeader.SIZE;
                    uint blocksSize = CORE_DATA_SIZE - CoreDataHeader.SIZE;

                    Encoder.Decode(blocksStart, blocksSize, personalRnd);
                }

                if (m_pCalcData != null)
                {
                    fixed (byte* calcAddr = m_pCalcData)
                    {
                        fixed (byte* coreAddr = m_pCoreData)
                        {
                            var header = GetCoreDataHeader(coreAddr);
                            Encoder.Decode(calcAddr, CALC_DATA_SIZE, header->personalRnd);
                        }
                    }
                }
            }

            m_accessState.isEncoded = false;
        }

        private unsafe void Serialize(void* bufferForCore, void* bufferForCalc)
        {
            if (!m_accessState.isEncoded)
                UpdateChecksumAndEncode();

            fixed (byte* src = m_pCoreData)
            {
                Buffer.MemoryCopy(src, bufferForCore, CORE_DATA_SIZE, CORE_DATA_SIZE);
            }

            if (bufferForCalc != null && m_pCalcData != null)
            {
                fixed (byte* src = m_pCalcData)
                {
                    Buffer.MemoryCopy(src, bufferForCalc, CALC_DATA_SIZE, CALC_DATA_SIZE);
                }
            }
        }

        private unsafe void Deserialize(void* serializedCoreData, void* serializedCalcData)
        {
            fixed (byte* dst = m_pCoreData)
            {
                Buffer.MemoryCopy(serializedCoreData, dst, CORE_DATA_SIZE, CORE_DATA_SIZE);
            }

            if (serializedCalcData != null && m_pCalcData != null)
            {
                fixed (byte* dst = m_pCalcData)
                {
                    Buffer.MemoryCopy(serializedCalcData, dst, CALC_DATA_SIZE, CALC_DATA_SIZE);
                }
            }

            m_accessState.isEncoded = true;
            m_accessState.isFastMode = false;
            DecodeAndCheckIllegalWrite();
            UpdateChecksumAndEncode();
        }

        private unsafe void copyString(char* dst, string _src, int dst_len)
        {
            int len = Math.Min(_src.Length, dst_len - 1);
            for (int i = 0; i < len; i++)
                dst[i] = _src[i];
            for (int i = len; i < dst_len; i++)
                dst[i] = '\0';
        }

        private static void CalcWazaRecordBitPos(out byte arrayIndex, out byte bitFlag, byte recordIndex)
        {
            arrayIndex = (byte)(recordIndex / 8);
            bitFlag = (byte)(1 << (recordIndex % 8));
        }

        private static void CalcPokeJobBitPos(out byte arrayIndex, out byte bitFlag, byte jobIndex)
        {
            arrayIndex = (byte)(jobIndex / 8);
            bitFlag = (byte)(1 << (jobIndex % 8));
        }

        private struct AccessState
        {
            public bool isEncoded;
            public bool isFastMode;
        }
    }
}
