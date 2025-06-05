public class PlayReportManager
{
    private static readonly string[] REPORT_LOG_EVENT_STR = new string[32]
    {
        "tower_single",               "tower_double",               "union_battle_single_p2p",    "union_battle_double_p2p",
        "union_battle_multi_p2p",     "coliseum_battle_single_p2p", "coliseum_battle_double_p2p", "coliseum_battle_multi_p2p",
        "union_battle_single_net",    "union_battle_double_net",    "union_battle_multi_net",     "coliseum_battle_single_net",
        "coliseum_battle_double_net", "coliseum_battle_multi_net",  "union_trade_p2p",            "union_trade_net",
        "gms_trade_net",              "puffin",                     "fushigi_net",                "fushigi_serial",
        "statue",                     "landmark",                   "fossil_digging",             "brilliantstone_collect",
        "fureai",                     "contest_p2p",                "contest_net",                "ball_decoration",
        "costume",                    "tsurearuki",                 "pokemon_id",                 "lithography",
    };
    private static readonly string CHECK_POINT_EVENT_STR = "check_point";
    private static readonly string RECORD_DATA_EVENT_STR = "record_data";
    public static PlayReportEvent[] Events = new PlayReportEvent[77];
    public static eCaptureType CaptureType = eCaptureType.None;

    // TODO
    public static void Init() { }

    // TODO
    public static void AddPokemonInfo(PlayReportEvent prepo, uint[] monsno, uint[] form, uint addNum, uint addMax) { }

    // TODO
    public static void SaveCheckPointEvent(int eventId) { }

    // TODO
    public static void SaveRecordDataEvent() { }

    // TODO
    public static void SaveReportLog_TowerSingle(uint rank, uint ruleId, uint[] monsno, uint[] monsForm, uint monsNum) { }

    // TODO
    public static void SaveReportLog_TowerDouble(uint rank, uint ruleId, uint[] monsNo, uint[] monsForm, uint monsNum) { }

    // TODO
    public static void SaveReportLog_UnionBattleSingleP2P(uint result, uint ruleId, uint[] monsNo, uint[] monsForm, uint monsNum) { }

    // TODO
    public static void SaveReportLog_UnionBattleDoubleP2P(uint result, uint ruleId, uint[] monsNo, uint[] monsForm, uint monsNum) { }

    // TODO
    public static void SaveReportLog_UnionBattleMultiP2P(uint result, uint ruleId, uint[] monsNo, uint[] monsForm, uint monsNum) { }

    // TODO
    public static void SaveReportLog_ColiseumBattleSingleP2P(uint result, uint ruleId, uint[] monsNo, uint[] monsForm, uint monsNum) { }

    // TODO
    public static void SaveReportLog_ColiseumBattleDoubleP2P(uint result, uint ruleId, uint[] monsNo, uint[] monsForm, uint monsNum) { }

    // TODO
    public static void SaveReportLog_ColiseumBattleMultiP2P(uint result, uint ruleId, uint[] monsNo, uint[] monsForm, uint monsNum) { }

    // TODO
    public static void SaveReportLog_UnionBattleSingleNet(uint result, uint ruleId, uint[] monsNo, uint[] monsForm, uint monsNum) { }

    // TODO
    public static void SaveReportLog_UnionBattleDoubleNet(uint result, uint ruleId, uint[] monsNo, uint[] monsForm, uint monsNum) { }

    // TODO
    public static void SaveReportLog_UnionBattleMultiNet(uint result, uint ruleId, uint[] monsNo, uint[] monsForm, uint monsNum) { }

    // TODO
    public static void SaveReportLog_ColiseumBattleSingleNet(uint result, uint ruleId, uint[] monsNo, uint[] monsForm, uint monsNum) { }

    // TODO
    public static void SaveReportLog_ColiseumBattleDoubleNet(uint result, uint ruleId, uint[] monsNo, uint[] monsForm, uint monsNum) { }

    // TODO
    public static void SaveReportLog_ColiseumBattleMultiNet(uint result, uint ruleId, uint[] monsNo, uint[] monsForm, uint monsNum) { }

    // TODO
    public static void SaveReportLog_UnionTradeP2P(uint myMonsNo, uint myMonsForm, uint oppRomId, uint oppMonsNo, uint oppMonsForm) { }

    // TODO
    public static void SaveReportLog_UnionTradeNet(uint myMonsNo, uint myMonsForm, uint oppRomId, uint oppMonsNo, uint oppMonsForm) { }

    // TODO
    public static void SaveReportLog_GMSTradeNet(uint myMonsNo, uint myMonsForm, uint oppMonsNo, uint oppMonsForm) { }

    // TODO
    public static void SaveReportLog_Puffin(uint puffinLv, uint puffinNo, uint materialNo1, uint materialNo2, uint materialNo3, uint materialNo4, uint puffinPlace) { }

    // TODO
    public static void SaveReportLog_FushigiNet(uint giftId, uint getMonsNo, uint getMonsForm, uint getItemNo, uint getItemCnt, uint getWearNo, uint getUgItemNo, uint getOtherNo, uint getMoney, uint getPoint) { }

    // TODO
    public static void SaveReportLog_FushigiSerial(uint giftId, uint getMonsNo, uint getMonsForm, uint getItemNo, uint getItemCnt, uint getWearNo, uint getUgItemNo, uint getOtherNo, uint getMoney, uint getPoint) { }

    // TODO
    public static void SaveReportLog_Statue(uint[] statueId, uint statueIdNum) { }

    // TODO
    public static void SaveReportLog_Landmark(uint landmarkId, uint connection, uint landmarkNumExplored, uint landmarkNumUnexplored) { }

    // TODO
    public static void SaveReportLog_FossilDigging(uint connection, bool tonariDigging, uint[] diggingItemNo, uint diggingItemNum) { }

    // TODO
    public static void SaveReportLog_BrilliantStoneCollect(uint connection, uint othersNum, uint brilliantStoneNumPc, uint brilliantStoneNumOthres) { }

    // TODO
    public static void SaveReportLog_Fureai(uint turearukiMonsNo, uint otherMonsNo1, uint otherMonsNo2, uint otherMonsNo3, uint otherMonsNo4, uint otherMonsNo5) { }

    // TODO
    public static void SaveReportLog_ContestP2P(uint result, uint category, uint level, uint monsNo, uint costume, uint wazaId, uint score, uint bestPerformer) { }

    // TODO
    public static void SaveReportLog_ContestNet(uint result, uint category, uint level, uint monsNo, uint costume, uint wazaId, uint score, uint bestPerformer) { }

    // TODO
    public static void SaveReportLog_BallDecoration(uint[] sealId, uint sealIdNum) { }

    // TODO
    public static void SaveReportLog_Custome() { }

    // TODO
    public static void SaveReportLog_Tsurearuki() { }

    // TODO
    public static void SaveReportLog_PokemonId(uint monsNo, uint monsForm, uint captureMethod, uint shiny) { }

    // TODO
    public static void SaveReportLog_Lithography(uint lithographyId) { }

    // TODO
    public static void StartWildBattle(eCaptureType type) { }

    // TODO
    public static void AddCapture() { }

    // TODO
    public static void AddBattle() { }

    // TODO
    public static void AddZenmetu() { }

    // TODO
    public static void AddMoney(int add) { }

    // TODO
    public static void PoketoreCount() { }

    // TODO
    public static void GoUnderGround() { }

    // TODO
    public static void NpcKoukan() { }

    // TODO
    public static void AddWalkCnt(int walk) { }

    public enum EventID : int
    {
        CHECK_POINT_RIVAL_1 = 0,
        CHECK_POINT_GYM_1 = 1,
        CHECK_POINT_BOSS_1 = 2,
        CHECK_POINT_GYM_2 = 3,
        CHECK_POINT_BOSS_2 = 4,
        CHECK_POINT_RIVAL_2 = 5,
        CHECK_POINT_GYM_3 = 6,
        CHECK_POINT_GYM_4 = 7,
        CHECK_POINT_RIVAL_3 = 8,
        CHECK_POINT_GYM_5 = 9,
        CHECK_POINT_RIVAL_4 = 10,
        CHECK_POINT_GYM_6 = 11,
        CHECK_POINT_BOSS_3 = 12,
        CHECK_POINT_BOSS_4 = 13,
        CHECK_POINT_GYM_7 = 14,
        CHECK_POINT_BOSS_5 = 15,
        CHECK_POINT_BOSS_6 = 16,
        CHECK_POINT_BOSS_7 = 17,
        CHECK_POINT_BOSS_8 = 18,
        CHECK_POINT_GYM_8 = 19,
        CHECK_POINT_RIVAL_5 = 20,
        CHECK_POINT_ELITE_1 = 21,
        CHECK_POINT_ELITE_2 = 22,
        CHECK_POINT_ELITE_3 = 23,
        CHECK_POINT_ELITE_4 = 24,
        CHECK_POINT_CHAMPION = 25,
        CHECK_POINT_GYM_1_ENHANCED = 26,
        CHECK_POINT_GYM_2_ENHANCED = 27,
        CHECK_POINT_GYM_3_ENHANCED = 28,
        CHECK_POINT_GYM_4_ENHANCED = 29,
        CHECK_POINT_GYM_5_ENHANCED = 30,
        CHECK_POINT_GYM_6_ENHANCED = 31,
        CHECK_POINT_GYM_7_ENHANCED = 32,
        CHECK_POINT_GYM_8_ENHANCED = 33,
        CHECK_POINT_ELITE_1_ENHANCED = 34,
        CHECK_POINT_ELITE_2_ENHANCED = 35,
        CHECK_POINT_ELITE_3_ENHANCED = 36,
        CHECK_POINT_ELITE_4_ENHANCED = 37,
        CHECK_POINT_CHAMPION_ENHANCED = 38,
        CHECK_POINT_ELITE_1_ENHANCED_2ND = 39,
        CHECK_POINT_ELITE_2_ENHANCED_2ND = 40,
        CHECK_POINT_ELITE_3_ENHANCED_2ND = 41,
        CHECK_POINT_ELITE_4_ENHANCED_2ND = 42,
        CHECK_POINT_CHAMPION_ENHANCED_2ND = 43,
        CHECK_POINT_END = 44,
        TOWER_SINGLE = 44,
        TOWER_DOUBLE = 45,
        UNION_BATTLE_SINGLE_P2P = 46,
        UNION_BATTLE_DOUBLE_P2P = 47,
        UNION_BATTLE_MULTI_P2P = 48,
        COLISEUM_BATTLE_SINGLE_P2P = 49,
        COLISEUM_BATTLE_DOUBLE_P2P = 50,
        COLISEUM_BATTLE_MULTI_P2P = 51,
        UNION_BATTLE_SINGLE_NET = 52,
        UNION_BATTLE_DOUBLE_NET = 53,
        UNION_BATTLE_MULTI_NET = 54,
        COLISEUM_BATTLE_SINGLE_NET = 55,
        COLISEUM_BATTLE_DOUBLE_NET = 56,
        COLISEUM_BATTLE_MULTI_NET = 57,
        UNION_TRADE_P2P = 58,
        UNION_TRADE_NET = 59,
        GMS_TRADE_NET = 60,
        PUFFIN = 61,
        FUSHIGI_NET = 62,
        FUSHIGI_SERIAL = 63,
        STATUE = 64,
        LANDMARK = 65,
        FOSSIL_DIGGING = 66,
        BRILLIANTSTONE_COLLECT = 67,
        FUREAI = 68,
        CONTEST_P2P = 69,
        CONTEST_NET = 70,
        BALL_DECORATION = 71,
        COSTUME = 72,
        TSUREARUKI = 73,
        POKEMON_ID = 74,
        LITHOGRAPHY = 75,
        REPORT_LOG_END = 76,
        REPORT_LOG_EVENT_NUM = 32,
        RECORD_DATA = 76,
        EVENT_NUM = 77,
    }

    public enum eCaptureType : int
    {
        None = 0,
        Wild = 1,
        Symbol = 2,
        Fishing = 3,
    }
}