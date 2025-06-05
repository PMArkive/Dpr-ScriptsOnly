using Dpr.Message;
using System.Collections.Generic;
using UnityEngine;

namespace Dpr.NetworkUtils
{
	public static class NetworkConstants
	{
		public const int UPDATE_ORDER = -9999;
		public const ushort MIN_SESSION_PLAYER_NUM = 2;
		public const ushort MAX_SESSION_PLAYER_NUM = 16;
		public const int PASSWORD_NUM = 8;
		public const int VALIDATE_GAME_MODE = 1;
		public const int VALIDATE_PUBLICKEY_SIZE = 392;
		public const byte WAIT_STATION_FRAME = 254;

		public static readonly Vector2Int RAND_GAMEMODE_BIT = new Vector2Int(0, 4);

		public static int ADD_ERROR_DIALOG_SORT = 100;

		public static readonly Dictionary<int, string> LANG_CODE_TABLE = new Dictionary<int, string>()
		{
			{ (int)MessageEnumData.MsgLangId.JPN, "ja" },
			{ (int)MessageEnumData.MsgLangId.USA, "en-US" },
			{ (int)MessageEnumData.MsgLangId.ESP, "es" },
			{ (int)MessageEnumData.MsgLangId.FRA, "fr" },
			{ (int)MessageEnumData.MsgLangId.DEU, "de" },
			{ (int)MessageEnumData.MsgLangId.ITA, "it" },
			{ (int)MessageEnumData.MsgLangId.KOR, "ko" },
			{ (int)MessageEnumData.MsgLangId.TCH, "zh-Hant" },
			{ (int)MessageEnumData.MsgLangId.SCH, "zh-Hans" },
		};

		public const string NET_COMM_MSBT_NAME = "ss_net_mystery";
		public const string REPORT_MSBT_NAME = "ss_report";
		public const string CONFIRM_FIRST_CONNECT_MSG_LABEL = "SS_net_mystery_020";
		public const string CONNECTION_MSG_LABEL = "SS_net_mystery_027";
		public const string COMPLET_CONNECT_MSG_LABEL = "SS_net_mystery_022";
		public const string DO_REPORT_MSG_LABEL = "SS_net_mystery_023";
		public const string CHANGED_INTERNET_MSG_LABEL = "SS_net_mystery_040";
		public const string COMPLETE_REPORT_MSG_LABEL = "SS_report_18";
	}
}