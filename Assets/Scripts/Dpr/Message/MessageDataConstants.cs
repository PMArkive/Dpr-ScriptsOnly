using System.Collections.Generic;
using UnityEngine;

namespace Dpr.Message
{
    public static class MessageDataConstants
    {
        public const string COMMON_ASSETNAME = "common_msbt";
        public static readonly string JPN_KANJI_ASSET_FOLDER_NAME = "jpn_kanji";
        public static readonly Dictionary<int, string> ASSET_FOLDER_NAME_TABLE = new Dictionary<int, string>()
        {
            { 1, "jpn" },
            { 2, "english" },
            { 3, "french" },
            { 4, "italian" },
            { 5, "german" },
            { 7, "spanish" },
            { 8, "korean" },
            { 9, "simp_chinese" },
            { 10, "trad_chinese" },
        };
        public static readonly Dictionary<int, string> ROOT_FOLDER_NAME_TABLE = new Dictionary<int, string>()
        {
            { 1, "JP" },
            { 2, "En" },
            { 3, "Fr" },
            { 4, "It" },
            { 5, "Ge" },
            { 7, "Sp" },
            { 8, "Ko" },
            { 9, "Si" },
            { 10, "Tr" },
        };
        public const int TEXT_CAPACITY_SIZE = 64;
        public const char TAG_CHAR = '\x7c';
        public const string NEW_LINE_STR = "\n";
        public const char PAGE_SCROLL_CHAR = '\x25bd';
        public const char PAGE_CHANGE_CHAR = '\x25bc';
        public const int SPACE_CODE = 12288;
        public const int HALF_SPACE_CODE = 32;
        public const int QUATER_SPACE_CODE = 8239;
        public const int COMMA_CODE = 44;
        public const int PERIOD_CODE = 46;
        public const int ZERO_SPACE_CODE = 8203;
        public const int WAIT_FINISH_SOUND_VALUE = 1;
        public const int EXCEPTION_PATCHIM_CODE = 8;
        public static readonly int[] EXCLUDE_CODES = new int[3] { 10, 123, 125 };
        public static readonly char[] NEWLINE_CHAR_CODES = new char[3] { '\u000D', '\u25BD', '\u25BC' };
        public const int SINGLE_QUOTATION_CODE = 39;
        public const int DOUBLE_QUOTATION_CODE = 34;
        public const int AFTER_SINGLE_QUOTATION_CODE = 8217;
        public const int AFTER_DOUBLE_QUOTATION_CODE = 8221;
        public const int CLOSE_FONT_TAG_VALUE = 65535;
        public const int REF_USER_GENDER_VALUE = 255;
        public const int REF_TV_GENDER_VALUE = 254;
        public const int REF_USER_PARTY_VALUE = 253;
        public const int INVALID_LANG_ID = 6;
        public const float ONE_FRAME_TIME = 0.01f;
        public const int WORD_PARAM_ARRAY_SIZE = 19;
        public const float SPRITE_FONT_WIDTH = 32.0f;
        public const string EGG_LABEL_NAME = "MONSNAME_000";
        public const string RIVAL_MOTHER_LABEL_NAME = "DLP_SPEAKERS_NAME_007";
        public const string WOMAN_SUPPORTER_NAME_LABEL = "DP_CHARACTERS_205";
        public const string MAN_SUPPORTER_NAME_LABEL = "DP_CHARACTERS_204";
        public const float UNKNOWN_MSG_FONT_SIZE = 80.0f;
        public static readonly Vector2 DIGIT_UNICODE_RANGE = new Vector2Int(0x30, 0x39);
        public static int CHECK_FOUR_DIGIT_VALUE = 10000;
        public static int GENERATE_POOL_NUM = 300;
        public const string ITEM_FILE_NAME = "ss_itemname";
        public const string ITEM_PLURAL_FILE_NAME = "ss_itemname_plural";
        public const string ITEM_CLASSIFIED_FILE_NAME = "ss_itemname_classified";
        public const string ITEM_CLASSIFIED_PLURAL_FILE_NAME = "ss_itemname_plural_classified";
        public const string ITEM_ACC_FILE_NAME = "ss_itemname_acc";
        public const string ITEM_ACC_CLASSIFIED_FILE_NAME = "ss_itemname_acc_classified";
        public const string TRAINER_NAME_FILE_NAME = "dp_trainers_name";
        public const string TRAINER_TYPE_FILE_NAME = "dp_trainers_type";
        public const string WAZA_FILE_NAME = "ss_wazaname";
        public const string TOKUSEI_FILE_NAME = "ss_tokusei";
        public const string SEIKAKU_FILE_NAME = "ss_seikaku";
        public const string POKETYPE_FILE_NAME = "ss_typename";
        public const string MONSNAME_FILE_NAME = "ss_monsname";
        public const string BAG_POCKET_FILE_NAME = "ss_bag_pocket";
        public const string SPEAKER_NAME_FILE_NAME = "dlp_speakers_name";
        public const string AREANAME_FILE_NAME = "dp_fld_areaname";
        public const string AREANAME_INDIRECT_FILE_NAME = "dp_fld_areaname_indirect";
        public const string AREANAME_DISPLAY_FILE_NAME = "dp_fld_areaname_display";
        public const string AREANAME_TOWNMAP_FILE_NAME = "dp_fld_areaname_townmap";
        public const string POKETCH_FILE_NAME = "dp_poketch";
        public const string KINOMI_FILE_NAME = "ss_nuts_name";
        public const string UG_ITEM_FILE_NAME = "dp_underground_name";
        public const string UG_ITEM_PLURAL_FILE_NAME = "dp_underground_name_plural";
        public const string UG_ITEM_CLASSIFIED_FILE_NAME = "dp_underground_name_classified";
        public const string UG_ITEM_CLASSIFIED_PLURAL_FILE_NAME = "dp_underground_name_plural_classified";
        public const string UG_ITEM_ACC_FILE_NAME = "dp_underground_name_acc";
        public const string UG_ITEM_ACC_CLASSIFIED_FILE_NAME = "dp_underground_name_acc_classified";
        public const string STICKER_FILE_NAME = "dp_stickers_name";
        public const string STICKER_PLURAL_FILE_NAME = "dp_stickers_name_plural";
        public const string PARK_ITEM_FILE_NAME = "dlp_park_name";
        public const string PARK_ITEM_PLURAL_FILE_NAME = "dlp_park_name_plural";
        public const string RIBBON_NAME_FILE_NAME = "ss_ribbon";
        public const string CHARACTER_NAME_MSBT_FILE = "dp_characters";
        public const string POFFIN_NAME_MSBT_FILE = "dlp_poffin_name";
        public const string POFFIN_NAME_ACC_MSBT_FILE = "dlp_poffin_name_acc";
        public const string POFFIN_NAME_PLURAL_MSBT_FILE = "dlp_poffin_name_plural";
        public const string STYLE_NAME_MSBT_FILE = "ss_fld_dressup_item_name";
        public const string BAG_FILE_NAME = "ss_bag";
        public static readonly Dictionary<int, string> POKE_POWER_NAME_LABEL_ARRAY = new Dictionary<int, string>()
        {
            { 0, "SS_bag_160" },
            { 1, "SS_bag_153" },
            { 2, "SS_bag_154" },
            { 3, "SS_bag_155" },
            { 4, "SS_bag_156" },
            { 5, "SS_bag_157" },
        };
        public const string NG_TRAINER_NAME_DPR_B = "DP_CHARACTERS_206";
        public const string NG_TRAINER_NAME_DPR_S = "DP_CHARACTERS_247";
        public const int EXTERNAL_POKE_DOLLAR = 58112;
        public const int EXTERNAL_LEFT_DIRECTION = 57600;
        public const int EXTERNAL_UP_DIRECTION = 57601;
        public const int EXTERNAL_RIGHT_DIRECTION = 57602;
        public const int EXTERNAL_DOWN_DIRECTION = 57603;
        public const int EXTERNAL_SPARKLES = 57604;
        public static readonly Dictionary<int, int> CHARACTER1_CODE_TABLE = new Dictionary<int, int>()
        {
            { 0, 0x2665 },
            { 1, 0x266a },
            { 2, 0x2642 },
            { 3, 0x2640 },
            { 4, 0xe300 },
            { 5, 0x2190 },
            { 6, 0x2191 },
            { 7, 0x2192 },
            { 8, 0x2193 },
            { 19, 0xe100 },
            { 20, 0xe101 },
            { 21, 0xe102 },
            { 22, 0xe103 },
            { 23, 0xe104 },
        };
        public static readonly Dictionary<int, int> CHARACTER2_CODE_TABLE = new Dictionary<int, int>()
        {
            { 0, 0x2018 },
            { 1, 0x2019 },
            { 2, 0x201c },
            { 3, 0x201d },
            { 4, 0x201e },
            { 5, 0x201c },
            { 6, 0x0027 },
            { 7, 0x0022 },
            { 8, 0x0020 },
            { 9, 0x202f },
            { 12, 0x02b3 },
            { 13, 0x1d49 },
            { 14, 0x00aa },
            { 15, 0x2026 },
            { 16, 0xff65 },
            { 19, 0x1d3c },
            { 20, 0x2006 },
        };
        public static readonly char[] VOWEL_TABLE = new char[10]
        {
            'A', 'I', 'U', 'E', 'O', 'a', 'i', 'u', 'e', 'o'
        };
        public static readonly char[] VOWEL_FR_TABLE = new char[50]
        {
            'À', 'Á', 'Â', 'Ã', 'Ä', 'Å',
            'È', 'É', 'Ê', 'Ë',
            'Œ',
            'Ì', 'Í', 'Î', 'Ï',
            'Ò', 'Ó', 'Ô', 'Õ', 'Ö', 'Ø',
            'Ù', 'Ú', 'Û', 'Ü',
            'à', 'á', 'â', 'ã', 'ä', 'å',
            'è', 'é', 'ê', 'ë',
            'œ',
            'ì', 'í', 'î', 'ï',
            'ò', 'ó', 'ô', 'õ', 'ö', 'ø',
            'ù', 'ú', 'û', 'ü'            
        };
        public static readonly char[] VOWEL_E_IT_TABLE = new char[8]
        {
            'E', 'È', 'É', 'e', 'è', 'é', 'ê', 'ë'
        };
        public static readonly int[] NUM_PATCHIM_CODE_ARRAY = new int[10]
        {
            1, 8, 0, 1, 0, 0, 1, 8, 8, 0
        };
        public const int EXTERNAL_POCKET_HEAL = 57344;
        public const int EXTERNAL_POCKET_BALL = 57345;
        public const int EXTERNAL_POCKET_BATTLE = 57346;
        public const int EXTERNAL_POCKET_NUTS = 57347;
        public const int EXTERNAL_POCKET_TOOLS = 57348;
        public const int EXTERNAL_POCKET_WAZAMACHINE = 57349;
        public const int EXTERNAL_POCKET_TREASURE = 57350;
        public const int EXTERNAL_POCKET_IMPORTANTE = 57352;
        public static readonly Dictionary<int, int> POCKET_ICON_CODE_TABLE = new Dictionary<int, int>()
        {
            { 0, 0xe000 },
            { 1, 0xe001 },
            { 2, 0xe002 },
            { 3, 0xe003 },
            { 4, 0xe004 },
            { 5, 0xe005 },
            { 6, 0xe006 },
            { 8, 0xe008 },
        };
        public static readonly Dictionary<int, string> POCKET_NAME_LABEL_TABLE = new Dictionary<int, string>()
        {
            { 0, "SS_bag_pocket_001" },
            { 1, "SS_bag_pocket_002" },
            { 2, "SS_bag_pocket_003" },
            { 3, "SS_bag_pocket_004" },
            { 4, "SS_bag_pocket_005" },
            { 5, "SS_bag_pocket_006" },
            { 6, "SS_bag_pocket_007" },
            { 8, "SS_bag_pocket_008" },
        };
        public const float CONVERT_FEET_COEFFICIENT = 2.54f;
        public const int FEET_BASE_NUMBER = 12;
        public const int STD_BASE_NUMBER = 10;
        public const string START_FONT_TAG_STR = "<font=";
        public const string END_FONT_TAG_STR = "</font>";
        public static readonly Vector2 ASPECT_SCALE = new Vector2(0.6666667f, 0.6666667f);
        public const string SDCARD_MOUNT_NAME = "sd";
        public static readonly Dictionary<int, MessageEnumData.MsgLangId> CONVERT_LANG_ID_TABLE = new Dictionary<int, MessageEnumData.MsgLangId>()
        {
            { 1, MessageEnumData.MsgLangId.JPN },
            { 2, MessageEnumData.MsgLangId.USA },
            { 3, MessageEnumData.MsgLangId.FRA },
            { 4, MessageEnumData.MsgLangId.ITA },
            { 5, MessageEnumData.MsgLangId.DEU },
            { 7, MessageEnumData.MsgLangId.ESP },
            { 8, MessageEnumData.MsgLangId.KOR },
            { 9, MessageEnumData.MsgLangId.SCH },
            { 10, MessageEnumData.MsgLangId.TCH },
        };
    }
}