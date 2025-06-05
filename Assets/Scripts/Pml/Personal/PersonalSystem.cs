using Dpr.Message;
using XLSXContent;

namespace Pml.Personal
{
    public static class PersonalSystem
    {
        private static PersonalTable m_alldata;
        private static GrowTable m_allGrowData;
        private static EvolveTable m_allEvolveData;
        private static WazaOboeTable m_allWazaOboeData;
        private static PersonalTable.SheetPersonal s_PersonalData;
        private static GrowTable.SheetData s_GrowTable;
        private static EvolveTable.SheetEvolve s_EvolutionTable;
        private static WazaOboeTable.SheetWazaOboe s_WazaOboeData;
        private static readonly WazaNo[] OSHIE_WAZA = { WazaNo.HAADOPURANTO, WazaNo.BURASUTOBAAN, WazaNo.HAIDOROKANON, WazaNo.RYUUSEIGUN };

        public static void Initialize(PersonalTable personalTotal, WazaOboeTable wazaoboeTotal, GrowTable growTableTotal, EvolveTable evolveTableTotal)
        {
            m_alldata = personalTotal;
            m_allGrowData = growTableTotal;
            m_allEvolveData = evolveTableTotal;
            m_allWazaOboeData = wazaoboeTotal;
        }

        public static int GetMonsLabel(MonsNo monsno)
        {
            if (monsno == MonsNo.TAMAGO || monsno == MonsNo.DAMETAMAGO)
                return 0;

            if (monsno > MonsNo.END)
                return 0;

            return (int)monsno;
        }

        public static string GetMonsName(MonsNo monsNo)
        {
            return MessageManager.Instance.GetNameMessage(MessageDataConstants.MONSNAME_FILE_NAME, GetMonsLabel(monsNo));
        }

        public static string GetMonsName(MonsNo monsNo, MessageEnumData.MsgLangId langId)
        {
            if (langId == 0)
                langId = MessageManager.Instance.UserLanguageID;

            return MessageManager.Instance.GetNameMessage(MessageDataConstants.MONSNAME_FILE_NAME, GetMonsLabel(monsNo), langId);
        }

        public static bool CheckPokeExist(MonsNo monsno, ushort formno)
        {
            return GetPersonalData(monsno, formno).IsValidData();
        }

        public static void LoadPersonalData(MonsNo monsno, ushort formno)
        {
            s_PersonalData = GetPersonalData(monsno, formno);
        }

        public static PersonalTable.SheetPersonal GetPersonalData(MonsNo monsno, ushort formno)
        {
            return m_alldata.Personal[GetDataID(monsno, formno)];
        }

        private static uint GetDataID(MonsNo monsno, ushort formno)
        {
            if (monsno > MonsNo.END || monsno == MonsNo.NULL)
                return 0;

            if (formno != 0)
            {
                PersonalTable.SheetPersonal data = m_alldata.Personal[(int)monsno];
                if (data.valid_flag && data.form_index != 0)
                {
                    if (data.form_max <= formno)
                        return (uint)monsno;

                    return (uint)(formno + data.form_index - 1);
                }
            }

            return (uint)monsno;
        }

        public static uint GetPersonalParam(ParamID paramId)
        {
            return s_PersonalData.GetParam(paramId);
        }

        public static bool CheckPersonalWazaMachine(ushort machineNo)
        {
            return s_PersonalData.CheckWazaMachine(machineNo);
        }

        public static bool CheckPersonalWazaRecord(ushort recordNo)
        {
            return s_PersonalData.CheckWazaRecord(recordNo);
        }

        public static bool CheckPersonalWazaOshie(ushort oshieNo)
        {
            return s_PersonalData.CheckWazaOshie(oshieNo);
        }

        public static SexType GetPersonalSexType()
        {
            return s_PersonalData.GetSexType();
        }

        public static TokuseiPattern GetTokuseiPattern()
        {
            return s_PersonalData.GetTokuseiPattern();
        }

        public static void LoadGrowTable(MonsNo monsno, ushort formno)
        {
            s_GrowTable = GetGrowTable(monsno, formno);
        }

        public static void LoadGrowTable(uint grow_type)
        {
            s_GrowTable = GetGrowTable(grow_type);
        }

        public static GrowTable.SheetData GetGrowTable(MonsNo monsno, ushort formno)
        {
            return m_allGrowData.Data[m_alldata.Personal[GetDataID(monsno, formno)].GetParam(ParamID.GROW)];
        }

        public static GrowTable.SheetData GetGrowTable(uint grow_type)
        {
            return m_allGrowData.Data[grow_type];
        }

        public static uint GetMinExp(byte level)
        {
            return s_GrowTable.GetMinExp(level);
        }

        public static void LoadWazaOboeData(MonsNo monsno, ushort formno)
        {
            s_WazaOboeData = GetWazaOboeData(monsno, formno);
        }

        public static WazaOboeTable.SheetWazaOboe GetWazaOboeData(MonsNo monsno, ushort formno)
        {
            return m_allWazaOboeData.WazaOboe[GetDataID(monsno, formno)];
        }

        public static byte GetWazaOboeNum()
        {
            return (byte)s_WazaOboeData.GetValidCodeNum();
        }

        public static ushort GetWazaOboeLevel(ushort index)
        {
            return s_WazaOboeData.GetLevel(index);
        }

        public static ushort GetWazaOboeWazaNo(ushort index)
        {
            return s_WazaOboeData.GetWazaNo(index);
        }

        public static OboeWazaKind GetWazaOboeKind(ushort index)
        {
            return s_WazaOboeData.GetOboeWazaKind(index);
        }

        public static int GetOshieWazaNum()
        {
            return OSHIE_WAZA.Length;
        }

        public static WazaNo GetOshieWazaNo(int idx)
        {
            if (idx < GetOshieWazaNum())
            {
                return OSHIE_WAZA[idx];
            }
            else
            {
                GFL.ASSERT(false);
                return WazaNo.NULL;
            }
        }

        public static void LoadEvolutionTable(MonsNo monsno, ushort formno)
        {
            s_EvolutionTable = GetEvolutionTable(monsno, formno);
        }

        public static EvolveTable.SheetEvolve GetEvolutionTable(MonsNo monsno, ushort formno)
        {
            return m_allEvolveData.Evolve[GetDataID(monsno, formno)];
        }

        public static byte GetEvolutionRouteNum()
        {
            return s_EvolutionTable.GetEvolutionRouteNum();
        }

        public static EvolveCond GetEvolutionCondition(byte route_index)
        {
            return s_EvolutionTable.GetEvolutionCondition(route_index);
        }

        public static EvolveCond GetEvolutionCondition(MonsNo next_monsno)
        {
            return s_EvolutionTable.GetEvolutionCondition(next_monsno);
        }

        public static ushort GetEvolutionParam(byte route_index)
        {
            return s_EvolutionTable.GetEvolutionParam(route_index);
        }

        public static MonsNo GetEvolvedMonsNo(byte route_index)
        {
            return s_EvolutionTable.GetEvolvedMonsNo(route_index);
        }

        public static ushort GetEvolvedFormNo(byte route_index)
        {
            return s_EvolutionTable.GetEvolvedFormNo(route_index);
        }

        public static bool IsEvolvedFormNoSpecified(byte route_index)
        {
            return s_EvolutionTable.IsEvolvedFormNoSpecified(route_index);
        }

        public static byte GetEvolveEnableLevel(byte route_index)
        {
            return s_EvolutionTable.GetEvolveEnableLevel(route_index);
        }

        public static AddPersonalTable.SheetAddPersonal GetAddPersonalData(MonsNo monsno, ushort formno)
        {
            return PmlUse.Instance.AddPersonalTable.AddPersonal[GetDataID_AddPersonal(monsno, formno)];
        }

        // TODO: What is going on in here?
        private static uint GetDataID_AddPersonal(MonsNo monsno, ushort formno)
        {
            if (monsno < MonsNo.END+1 && monsno != MonsNo.NULL)
            {
                var addPersonal = PmlUse.Instance.AddPersonalTable.AddPersonal;
                for (uint i=0; i<addPersonal.Length; i++)
                {
                    if (addPersonal[i].monsno == (ushort)monsno && addPersonal[i].formno == formno)
                        return i;
                }

            }

            return 0;
        }
    }
}
