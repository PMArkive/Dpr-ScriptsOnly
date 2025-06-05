using DPData;
using Dpr.EvScript;
using Dpr.Message;
using Pml.PokePara;
using Pml;
using System;
using XLSXContent;

public static class TvWork
{
    public static MessageEnumData.GenderID CurrentStrDataGenderId = MessageEnumData.GenderID.Neuter;
    private static ZoneID[] WeatherReportZone = new ZoneID[5]
    {
        ZoneID.R212B, ZoneID.R213, ZoneID.R216, ZoneID.L03, ZoneID.C09,
    };
    private static readonly int[] IgnoreDouguMotteruYasei = new int[58]
    {
        1,   2,   3,   4,   5,   6,   7,   8,
        9,   12,  19,  22,  27,  30,  33,  36,
        37,  38,  39,  42,  46,  47,  54,  59,
        64,  66,  68,  70,  71,  72,  73,  74,
        75,  76,  77,  91,  93,  98,  101, 105,
        107, 108, 110, 111, 112, 113, 115, 116,
        123, 126, 139, 141, 145, 146, 147, 148,
        149, 150,
    };

    // TODO
    public static int RandRange(int min, int max) { return 0; }

    // TODO
    public static void GetLinkRecord(TV_PROGRAM tvProgram, out TV_DATA_ID_INT[] recordInt, out TV_DATA_ID_STR[] recordStr)
    {
        recordInt = null;
        recordStr = null;
    }

    // TODO
    public static void Initialize() { }

    // TODO
    public static void RecordTvIntDataSet(TV_DATA_ID_INT index, int value) { }

    // TODO
    public static void RecordTvIntDataSet(TV_DATA_ID_INT_DEF index, int value) { }

    // TODO
    public static void RecordTvStrDataSet(TV_DATA_ID_STR index, string value) { }

    // TODO
    public static void RecordTvStrDataSet(TV_DATA_ID_STR index, string value, byte language) { }

    // TODO
    public static void RecordTvStrDataSet(TV_DATA_ID_STR index, string value, byte language, byte genderId) { }

    // TODO
    public static void RecordTvStrDataSet(TV_DATA_ID_STR_DEF index, string value) { }

    // TODO
    public static void RecordTvStrDataSet(TV_DATA_ID_STR_DEF index, string value, byte language) { }

    // TODO
    public static void RecordTvStrDataSet(TV_DATA_ID_STR_DEF index, string value, byte language, byte genderId) { }

    // TODO
    public static void TvBranchDataSet(TV_PROGRAM index, int value) { }

    // TODO
    public static void TVTpicEnable(TV_PROGRAM index) { }

    // TODO
    public static void TVTpicDisable(TV_PROGRAM index) { }

    // TODO
    public static int GetRecordTvIntData(TV_DATA_ID_INT index) { return 0; }

    // TODO
    public static int GetRecordTvIntData(TV_DATA_ID_INT_DEF index) { return 0; }

    // TODO
    public static string GetRecordTvStrData(TV_DATA_ID_STR index) { return ""; }

    // TODO
    public static string GetRecordTvStrData(TV_DATA_ID_STR_DEF index) { return ""; }

    // TODO
    public static void GetRecordTvStrData(TV_DATA_ID_STR index, out string str, out MessageEnumData.MsgLangId langId)
    {
        str = "";
        langId = MessageEnumData.MsgLangId.JPN;
    }

    // TODO
    public static void GetRecordTvStrData(TV_DATA_ID_STR_DEF index, out string str, out MessageEnumData.MsgLangId langId)
    {
        str = "";
        langId = MessageEnumData.MsgLangId.JPN;
    }

    // TODO
    public static void GetRecordTvStrData(TV_DATA_ID_STR index, out string str, out MessageEnumData.MsgLangId langId, out MessageEnumData.GenderID genderId)
    {
        str = "";
        langId = MessageEnumData.MsgLangId.JPN;
        genderId = MessageEnumData.GenderID.Masculine;
    }

    // TODO
    public static void GetRecordTvStrData(TV_DATA_ID_STR_DEF index, out string str, out MessageEnumData.MsgLangId langId, out MessageEnumData.GenderID genderId)
    {
        str = "";
        langId = MessageEnumData.MsgLangId.JPN;
        genderId = MessageEnumData.GenderID.Masculine;
    }

    // TODO
    public static int GetTvBranchData(TV_PROGRAM index) { return 0; }

    // TODO
    public static bool GetTVTpicCreate(TV_PROGRAM index) { return false; }

    // TODO
    public static void AddTvWatchCount() { }

    // TODO
    public static int GetTvWatchCount() { return 0; }

    // TODO
    public static EvWork.WORK_INDEX GetOverSaveDataIntMyWorkIndex(TV_DATA_ID_INT index) { return EvWork.WORK_INDEX.LOCALWORK0; }

    // TODO
    public static EvWork.WORK_INDEX GetOverSaveDataIntUseWorkIndex(TV_DATA_ID_INT index) { return EvWork.WORK_INDEX.LOCALWORK0; }

    // TODO
    public static RecordData CreateRecordData() { return null; }

    // TODO
    public static void ApplyRecordData(RecordData recordData) { }

    // TODO
    private static bool CheckEnableRecordProgram(TV_PROGRAM tvProgram) { return false; }

    // TODO
    private static int GetMyBranchData(TV_PROGRAM tvProgram) { return 0; }

    // TODO
    private static TV_STR_DATA GetMyStrData(TV_DATA_ID_STR_DEF index) { return default; }

    // TODO
    private static int GetMyIntData(TV_DATA_ID_INT_DEF index) { return 0; }

    // TODO
    private static void SetUseBranchData(TV_PROGRAM tvProgram, int value) { }

    // TODO
    private static void SetUseStrData(TV_DATA_ID_STR_DEF index, TV_STR_DATA value) { }

    // TODO
    private static void SetUseIntData(TV_DATA_ID_INT_DEF index, int value) { }

    // TODO
    public static TvDataTable.Sheetdata GetTableData(TV_PROGRAM tvProgram) { return null; }

    // TODO
    public static TvDataTable.Sheetdata GetTableData(int tvProgram) { return null; }

    // TODO
    public static int GetChannel() { return 0; }

    // TODO
    public static int GetChannel(int hour, int minute, DayOfWeek dayOfWeek) { return 0; }

    // TODO
    public static TV_PROGRAM FindEnableProgram() { return TV_PROGRAM.PRG_0_Chousen_BtlTower; }

    // TODO
    public static bool CheckEnableProgram(TV_PROGRAM id) { return false; }

    // TODO
    public static int[] GetCommercialIndexArray() { return null; }

    // TODO
    private static bool FlagCheck(EvWork.SYSFLAG_INDEX flagIndex) { return false; }

    // TODO
    public static void CapturePokemon(PokemonParam param, int ballcnt) { }

    // TODO
    public static void CaptureFailed(int ballcnt, bool isWin) { }

    // TODO
    public static void SetFishing(FishingRod rod, MonsNo monsno) { }

    // TODO
    public static void ChangeGroupName() { }

    // TODO
    public static void HiddenItem(ItemNo itemNo) { }

    // TODO
    public static void EggHatch(PokemonParam param, int placeNo) { }

    // TODO
    public static void Seimeihandan(PokemonParam param) { }

    // TODO
    public static void Kasekihori(int itemNo) { }

    // TODO
    public static void Safari(MonsNo monsNo, int safariCount) { }

    // TODO
    public static void Ryouyaku(PokemonParam param, ItemNo itemNo) { }

    // TODO
    public static void KinomiHousaku(ItemNo itemNo, int itemCount) { }

    // TODO
    public static void NewGroup() { }

    // TODO
    public static void CustumBallSakusei(int sealName, MonsNo monsNo) { }

    // TODO
    public static void RareMonohiroi(ItemNo itemNo, PokemonParam param) { }

    // TODO
    public static void HimitsukichiReceiveNice(int niceCount) { }

    // TODO
    public static void HimitsukichiSendNice(int niceCount) { }

    // TODO
    public static void BtlTowerRensyouKousin(MonsNo monsNo, int winCount, bool isDouble) { }

    // TODO
    public static void OokisasokuteiKousin(MonsNo monsNo, int sizeValue) { }

    // TODO
    public static void KinomiMeijin(ItemNo itemNo) { }

    // TODO
    public static void SafariMeijin(int pokemonCount) { }

    // TODO
    public static void SekizouHakkutunin(int statueCount) { }

    // TODO
    public static void Hikariishi(int hikariishiCount) { }

    // TODO
    public static void GroupSyoukai(int groupPokemonType, string groupName, string memberName) { }

    // TODO
    public static void WeatherReport(int weatherNo, int placeNo) { }

    // TODO
    public static void TairyouHassei(int placeNo, MonsNo monsNo) { }

    // TODO
    public static void PokemonAisyou(int aisyou, int pokemonType, int effectivePokemonType) { }

    // TODO
    public static void KinomiJouhou(int state, int placeNo) { }

    // TODO
    public static void DouguMotteruYasei(MonsNo monsNo, ItemNo itemNo) { }

    // TODO
    public static void FashionChange(int style, int placeNo) { }

    // TODO
    public static void MakeDailyTopic() { }

    // TODO
    public static void MakeTairyouhasseiTopic() { }

    public class RecordData
    {
        public PersonalityData Personality;
        public BallDecorationData BallDecoration;
        public KasekihoriData Kasekihori;
        public StatueData Statue;
        public FashionData Fashion;

        public class PersonalityData
        {
            public int BranchData;
            public TV_STR_DATA PlayerName;
        }

        public class BallDecorationData
        {
            public int BranchData;
            public int Trainer;
        }

        public class KasekihoriData
        {
            public int BranchData;
            public int ItemNo;
            public TV_STR_DATA PlayerName;
        }

        public class StatueData
        {
            public int BranchData;
            public int StatueCount;
            public TV_STR_DATA PlayerName;
        }

        public class FashionData
        {
            public int BranchData;
            public int Style;
            public int PlaceNo;
            public TV_STR_DATA PlayerName;
        }
    }
}