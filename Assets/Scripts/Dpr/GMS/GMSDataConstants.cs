using UnityEngine;

namespace Dpr.GMS
{
	public class GMSDataConstants
	{
		public const string GMS_MSBT_NAME = "dlp_gmstation";
		public const string POINT_LABEL_NAME = "DLP_GMStation_018";

		public const int CREATE_POINT_DATA_SPAN = 60;
		public const int INIT_GENERATE_MARK_NUM = 355;
		public const int GENERATE_POINT_MARK_SPAN = 30;
		public const int MAX_POINT_NUM = 650;
		public const int POINT_HISTORY_DATA_NUM = 5;

		public static readonly Vector3 CONTEXT_MENU_POS = new Vector3(890.0f, 60.0f, 0.0f);

		public const int LIMIT_POINT_HISTORY_DATA_NUM = 6;
		public const float CONNECT_FX_FADE_TIME = 0.0f;
		public const int EXIT_GMS_WORK_VALUE = 1;
		public const int ILLEGAL_EXIT_GMS_WORK_VALUE = 0;

		public const string SPRITE_ATLAS_AB_PATH = "gms/textures/scenespriteatlas";
		public const string GRAPHIC_TEXT_SPRITE_ATLAS_AB_PATH = "gms/graphictext/gmsgraphictext";
		public const string MASTERDATA_AB_PATH = "md/gms_masterdatas";
	}
}