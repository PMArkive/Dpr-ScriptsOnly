using UnityEngine;

public static class UnionTextData
{
	public const int TAG_INDEX_PLAYERNAME = 0;

	public const string UNION_UNIONROOM_MESSAGE_FILE_NAME = "dlp_net_union_room";
	public const string UNION_MENU_NET_COMMUNICATION_MESSAGE_FILE_NAME = "dp_net_communication";
	public const string UNION_MENU_BATTLE_FILE_NAME = "dp_options";
	public const string UNION_UNDERGROUND_MESSAGE_FILE_NAME = "dlp_underground";
	public const string UNION_SS_NET_NET_BTL_MESSGAE_FILE_NAME = "ss_net_net_btl";
	public const string UNION_SS_BOX_MESSGAE_FILE_NAME = "ss_box";
	public const string UNION_SS_NET_LIVE_COMM_MESSGAE_FILE_NAME = "ss_net_live_comm";
	public const string UNION_SS_NET_MESSAGE_ERROR_FILE_NAME = "ss_net_message_error";
	public const string UNION_GMSTATION_FILE_NAME = "dlp_gmstation";

	public static readonly string[] UNION_START_MENU_MASSEAGES = new string[]
	{
		"DLP_underground_615", "DLP_net_union_room_103", "DLP_underground_418",
	};
	public static readonly string UNION_EXIT_MESSAGE = "DLP_net_union_room_056";
	public static readonly string GLOBAL_EXIT_MESSAGE = "DLP_net_union_room_057";
	public static readonly string COLISEUM_EXIT_MESSAGE = "SS_net_net_btl_112";
	public static readonly string UNION_WAIT_SS_GAMING_MESSAGE = "SS_box_185";
	public static readonly string UNION_WAITOTHER_SS_GAMING_MESSAGE = "SS_box_176";
	public static readonly string[] UNION_START_MASSEAGES = new string[]
	{
		"dlp_net_union_room_044", "dlp_net_union_room_045",
		"dlp_net_union_room_046", "dlp_net_union_room_047",
	};
	public static readonly string[] UNION_MENU_DESCRIPTION = new string[]
	{
		"7-msg_union_info_03_15", "7-msg_union_info_03_04", "7-msg_union_info_03_05",
		"7-msg_union_info_03_06", "7-msg_union_info_03_12", "7-msg_union_info_03_13",
		"7-msg_union_info_03_03",
	};
	public static readonly string[] GLOBAL_MENU_DESCRIPTION = new string[]
	{
		"7-msg_union_info_03_15", "7-msg_union_info_03_04", "7-msg_union_info_03_05",
		"7-msg_union_info_03_12", "7-msg_union_info_03_13", "7-msg_union_info_03_03",
	};
	public static readonly string[] UNION_MENU_MASSEAGES = new string[]
	{
        "7-msg_union_info_03_12", "7-msg_union_info_03_04", "7-msg_union_info_03_05",
        "7-msg_union_info_03_06", "7-msg_union_info_03_13", "7-msg_union_info_03_03",
    };
	public static readonly string[] GLOBAL_MENU_MASSEAGES = new string[]
	{
        "7-msg_union_info_03_12", "7-msg_union_info_03_04", "7-msg_union_info_03_05",
        "7-msg_union_info_03_13", "7-msg_union_info_03_03",
    };
	public static readonly string[] UNION_BATTLE_TYPE = new string[]
	{
        "DP_options_006", "DP_options_007", "DP_options_009",
    };
	public static readonly string[] UNION_SYSTEM_BATTLE = new string[]
    {
        "SS_net_net_btl_098", "SS_net_net_btl_009",
    };
	public static readonly string[] UNION_NETWORK_ERROR = new string[]
	{
        "error_comm_26",
    };
	public static readonly string[] UNION_TARDE_ERROR = new string[]
	{
        "SS_net_live_comm_332", "DLP_net_union_room_112",
    };
	public static readonly string[] UNION_SYSTEM_GREETING = new string[]
    {
        "DLP_net_union_room_075", "SS_net_net_btl_009",
    };
    public static readonly string[] UNION_SYSTEM_BALLDECO = new string[]
    {
        "DLP_net_union_room_097", "DLP_net_union_room_098", "DLP_net_union_room_079",
    };
    public static readonly string[] UNION_SYSTEM_GREETIMG = new string[]
    {
        "7-msg_union_greeting_01", "7-msg_union_greeting_02",   "7-msg_union_greeting_03",
        "7-msg_union_greeting_04", "7-msg_union_greeting_05",   "7-msg_union_greeting_06",
        "7-msg_union_greeting_07", "7-msg_union_greeting_08",   "7-msg_union_greeting_09",
        "7-msg_union_greeting_10", "7-msg_union_talkboy_00_02", "7-msg_union_talkgirl_00_02",
    };
    public static readonly string[] UNION_SYSTEM_COMMUNICATE = new string[]
    {
        "7-msg_union_talkboy_00_03", "7-msg_union_talkgirl_00_03",
    };
    public static readonly string[] UNION_TALK_BATTLE = new string[]
    {
        "7-msg_union_talkboy_03_05",  "7-msg_union_talkboy_03_06",  "7-msg_union_talkboy_03_07",
        "7-msg_union_talkboy_03_08",  "7-msg_union_talkgirl_03_05", "7-msg_union_talkgirl_03_06",
        "7-msg_union_talkgirl_03_07", "7-msg_union_talkgirl_03_08",
    };
    public static readonly string[] UNION_TALK_TRADE = new string[]
    {
        "7-msg_union_talkboy_04_04",  "7-msg_union_talkboy_04_05", "7-msg_union_talkgirl_04_04",
        "7-msg_union_talkgirl_04_05",
    };
	public static readonly string[] UNION_TALK_RECODE = new string[]
	{
        "7-msg_union_talkboy_06_09",  "7-msg_union_talkboy_06_10",  "7-msg_union_talkboy_06_11",
        "7-msg_union_talkboy_06_12",  "7-msg_union_talkgirl_06_09", "7-msg_union_talkgirl_06_10",
        "7-msg_union_talkgirl_06_11", "7-msg_union_talkgirl_06_12",
    };
	public static readonly string[] UNION_TALK_GREETING = new string[]
	{
        "7-msg_union_talkboy_01_03",  "7-msg_union_talkboy_01_04", "7-msg_union_talkgirl_01_03",
        "7-msg_union_talkgirl_01_04",
    };
	public static readonly string[] UNION_TALK_BALLDECO = new string[]
	{
        "DLP_net_union_room_094", "DLP_net_union_room_095",
    };
	public static readonly string UNION_TEADE_PENALTY = "SS_net_live_comm_332";
    public static readonly string[] UNION_TALK_NPC = new string[]
	{
        "7-msg_union_info_01_01", "7-msg_union_info_01_02",
    };
	public static readonly string[] GLOBAL_TALK_NPC = new string[]
	{
		"7-msg_union_info_01_13", "7-msg_union_info_01_02",
    };
	public static readonly string[] UNION_TALK_NPC_START_CONTEXT = new string[]
	{
        "7-msg_union_info_03_01", "7-msg_union_info_03_02", "7-msg_union_info_03_03",
    };
	public static readonly string UNION_DESCRIPTION_START = "7-msg_union_info_01_03";
	public static readonly string[] UNION_TALK_NPC_STATE_DESCRIPTION = new string[]
	{
        "7-msg_union_info_01_14", "7-msg_union_info_01_04", "7-msg_union_info_01_05",
        "7-msg_union_info_01_06", "DLP_net_union_room_001", "DLP_net_union_room_061",
    };
	public static readonly string[] GLOBAL_TALK_NPC_STATE_DESCRIPTION = new string[]
	{
        "7-msg_union_info_01_14", "7-msg_union_info_01_04", "7-msg_union_info_01_05",
        "DLP_net_union_room_001", "DLP_net_union_room_061",
    };
	public static readonly string[] UNION_TALK_NPC_NO_PLAYER = new string[]
	{
        "7-msg_union_info_02_09", "7-msg_union_info_02_24",
    };
	public static readonly string[] UNION_TALK_NPC_OTHER_PLAYER = new string[]
	{
        "7-msg_union_info_02_01", "DLP_net_union_room_002", "DLP_net_union_room_003",
        "DLP_net_union_room_004",
    };
	public static readonly string[] UNION_TALK_NPC_SETTING_ROOM = new string[]
	{
        "DLP_net_union_room_044", "DLP_net_union_room_045", "DLP_net_union_room_046",
        "DLP_net_union_room_047",
    };
	public static readonly string[] UNION_TALK_NPC_CHANGE_GLOBAL_MODE = new string[]
	{
        "DLP_net_union_room_053", "DLP_net_union_room_054",
    };
	public static readonly string[] UNION_INTERNET_START = new string[]
	{
        "SS_net_live_comm_032", "3-msg_pcug_02_03",
    };
	public static readonly string UNION_INTERNET_CONNECT_WAIT = "SS_net_live_comm_035";
    public static readonly string[] UNION_CHECK_END = new string[]
	{
        "SS_net_live_comm_038", "3-msg_pcug_01_05", "DLP_net_union_room_032",
    };
	public static readonly string[] UNION_NPC_TRADE = new string[]
	{
        "7-msg_union_info_01_11", "DLP_GMStation_007", "DLP_GMStation_053",
        "DLP_GMStation_052",
    };
	public static readonly string[] COLISEUM_TALK_NPC = new string[]
	{
        "SS_net_net_btl_119", "7-msg_union_info_01_02",
	};
	public static readonly string[] COLISEUM_TALK_NPC_START_CONTEXT = new string[]
	{
        "7-msg_union_info_03_01", "7-msg_union_info_03_03",
    };
    public static readonly string[] COLISEUM_TALK_NPC_STATE_DESCRIPTION = new string[]
    {
        "SS_net_net_btl_121",
    };
    public static readonly string[] COLISEUM_TALK_NPC_END = new string[]
    {
        "8-msg_connect_rule_01",
    };
    public static readonly string[] COLISEUM_TALK_NOT_CHANGE_BATTLERULE = new string[]
    {
        "SS_net_net_btl_123",
    };
    public static readonly string[] COLISEUM_TALK_NPC_SETTING_BATTLE_RULE = new string[]
    {
        "DP_options_006", "DP_options_007", "DP_options_011",
    };
    public static readonly string[] COLISEUM_TALK_CHECK_BATTLERULE = new string[]
    {
        "SS_net_net_btl_122",
    };
    public static readonly string[] COLISEUM_BATTLE_RULE_SELECT = new string[]
    {
        "8-msg_connect_colosseum_02",
    };
    public static readonly string[] UNION_SYSTEM_MESSAGE = new string[]
    {
        "SS_box_185", "SS_box_179",
    };
    public static readonly string UNION_SECURITY_TRADE_ERROR = "error_fatal_save_00";
    public static readonly string UNION_CANCEL_TRADE_MATCH = "SS_box_177";
	public static readonly string[] UNION_SECURITY_TRADE_WAIT_CANCEL = new string[]
    {
        "SS_box_178",
    };
    public static readonly string[] BATTLE_DESCRIPTION = new string[]
    {
        "",
    };
    public static readonly string UNION_RECODE_TRADE_MATCH_HOST = "6-msg_union_record_01_01";
	public static readonly string UNION_RECODE_TRADE_CHECK = "6-msg_union_record_01_02";
	public static readonly string UNION_RECODE_TRADE_MATCH_GUEST = "6-msg_union_record_01_07";
	public static readonly string[] UNION_RECODE_TRADE_CHECK_JOIN = new string[]
    {
        "7-msg_union_talkboy_06_05", "7-msg_union_talkgirl_06_05",
    };
    public static readonly Vector2 BATTLE_RULE_ANCHOR_POS = new Vector2(15.0f, 110.0f);
	public static readonly string UNION_BATTLE_RULE = "SS_net_net_btl_019";
	public static readonly string COLISEUM_MATCH_WAITING = "SS_net_net_btl_114";
	public static readonly string COLISEUM_BATTLE_START = "SS_net_net_btl_118";

	public enum SpeakerID : int
	{
		MINE = 0,
		OPPONENT = 1,
		SYSTEM = 2,
	}

	public struct MsgStringParamData
	{
		public string msgFileName;
		public string labelName;
		
		public MsgStringParamData(string msgFile, string label)
		{
			msgFileName = msgFile;
			labelName = label;
		}
	}
}