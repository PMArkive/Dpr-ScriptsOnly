using DPData;
using Dpr.Message;
using Pml.PokePara;
using Pml;
using System.Collections.Generic;
using XLSXContent;

public class InterviewWork
{
    private static Dictionary<int, int> TypeToProgramDict = new Dictionary<int, int>()
    {
        { (int)Type.BattleTower, (int)TV_PROGRAM.PRG_0_Chousen_BtlTower },  { (int)Type.YourPokemon,    (int)TV_PROGRAM.PRG_1_Anatano_Pokemon },
        { (int)Type.Poketch,     (int)TV_PROGRAM.PRG_2_Okiniiri_Poketch },  { (int)Type.Contest,        (int)TV_PROGRAM.PRG_3_Chousen_Contest },
        { (int)Type.Personality, (int)TV_PROGRAM.PRG_4_Seikakusindan },     { (int)Type.Poffin,         (int)TV_PROGRAM.PRG_5_Pofinryouri },
        { (int)Type.Tsurearuki,  (int)TV_PROGRAM.PRG_6_Turearuki_Mankitu }, { (int)Type.BallDecoration, (int)TV_PROGRAM.PRG_7_Sukina_Balldeco },
    };

    // TODO
    private static TV_PROGRAM TypeToProgram(Type type) { return TV_PROGRAM.PRG_0_Chousen_BtlTower; }

    // TODO
    private static Type ProgramToType(TV_PROGRAM tvProgram) { return Type.Poffin; }

    // TODO
    private static INTERVIEWER_PROGRAM TypeToInterviewBranchProgram(Type type) { return INTERVIEWER_PROGRAM.PRG_0_Chousen_BtlTower;  }

    // TODO
    private static TV_DATA_ID_INT_DEF InterviewToTvRecordInt(INTERVIEWER_DATA_ID_INT_DEF index) { return TV_DATA_ID_INT_DEF.BattleTowerWinCount; }

    // TODO
    private static INTERVIEWER_DATA_ID_INT_DEF TvToInterviewRecordInt(TV_DATA_ID_INT_DEF index) { return INTERVIEWER_DATA_ID_INT_DEF.Poffin; }

    // TODO
    private static TV_DATA_ID_STR_DEF InterviewToTvRecordStr(INTERVIEWER_DATA_ID_STR_DEF index) { return TV_DATA_ID_STR_DEF.BattleTowerPlayerName; }

    // TODO
    private static INTERVIEWER_DATA_ID_STR_DEF TvToInterviewRecordStr(TV_DATA_ID_STR_DEF index) { return INTERVIEWER_DATA_ID_STR_DEF.BattleTowerPlayerName; }

    // TODO
    public static TvDataTable.Sheetdata GetTableData(Type type) { return null; }

    // TODO
    public static void SetInterviewBranchData(INTERVIEWER_PROGRAM index, int value) { }

    // TODO
    public static void SetInterviewRecordStr(INTERVIEWER_DATA_ID_STR_DEF index, string value) { }

    // TODO
    public static void SetInterviewRecordStr(INTERVIEWER_DATA_ID_STR_DEF index, string value, byte language) { }

    // TODO
    public static void SetInterviewRecordStr(INTERVIEWER_DATA_ID_STR_DEF index, string value, byte language, byte genderId) { }

    // TODO
    public static void SetInterviewRecordInt(INTERVIEWER_DATA_ID_INT_DEF index, int value) { }

    // TODO
    public static void ApplyInterviewToTopic(Type type) { }

    // TODO
    public static void ApplyInterviewBranchData(INTERVIEWER_PROGRAM index) { }

    // TODO
    public static void ApplyInterviewRecordStr(INTERVIEWER_DATA_ID_STR_DEF index) { }

    // TODO
    public static void ApplyInterviewRecordInt(INTERVIEWER_DATA_ID_INT_DEF index) { }

    // TODO
    public static int GetInterviewBranchData(INTERVIEWER_PROGRAM index) { return 0; }

    // TODO
    public static void GetInterviewRecordStr(INTERVIEWER_DATA_ID_STR_DEF index, out string str, out MessageEnumData.MsgLangId langId)
    {
        str = "";
        langId = MessageEnumData.MsgLangId.JPN;
    }

    // TODO
    public static bool Check(Type type) { return false; }

    // TODO
    public static void SetTopicRecord(Type type) { }

    // TODO
    public static void SetAndEnableTopicPersonality(int pokeType) { }

    // TODO
    public static void SetAndEnableTopicBallDecoration(int ballDecorationTrainer) { }

    // TODO
    public static void SetTopicRecordBattleTower(int winCount, bool win) { }

    // TODO
    public static void SetTopicRecordContest(PokemonParam param, int contestName, int contestRank, int contestRankingNumber) { }

    // TODO
    public static void SetTopicRecordPoffin(PoffineTaste poffineTaste, int poffinType) { }

    // TODO
    public static void SetTopicRecordTsureArukiPokemon(PokemonParam param) { }

    // TODO
    public static void SetTopicRecordTsureArukiItemNo(ItemNo itemNo) { }

    public enum Type : int
    {
        None = 0,
        _Dummy_1 = 1,
        BattleTower = 2,
        _Dummy_3 = 3,
        YourPokemon = 4,
        _Dummy_5 = 5,
        Poketch = 6,
        Contest = 7,
        _Dummy_8 = 8,
        _Dummy_9 = 9,
        Personality = 10,
        Poffin = 11,
        _Dummy_12 = 12,
        Tsurearuki = 13,
        BallDecoration = 14,
    }

    public enum PoffineTaste : int
    {
        Kotteri = 1,
        Kudoi = 2,
        Mazui = 3,
        Maroyaka = 4,
        Etc = 5,
    }
}