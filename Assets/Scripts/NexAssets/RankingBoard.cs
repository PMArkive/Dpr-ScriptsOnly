using NexPlugin;

namespace NexAssets
{
	public class RankingBoard : RankingBoardBase
	{
		public bool m_ParamFold;
		private RankingResult m_RankingInfo = new RankingResult();
		public GUIINDEX m_GuiIndex = GUIINDEX.SCORE | GUIINDEX.ORDER | GUIINDEX.PID;
		public COLUMN_ARG orderArg = new COLUMN_ARG((int)GUIINDEX_NUM.ORDER, "Order");
		public COLUMN_ARG pidArg = new COLUMN_ARG((int)GUIINDEX_NUM.PID, "PID");
        public COLUMN_ARG uidArg = new COLUMN_ARG((int)GUIINDEX_NUM.UID, "UID");
        public COLUMN_ARG categoryArg = new COLUMN_ARG((int)GUIINDEX_NUM.CATEGORY, "Category");
        public COLUMN_ARG scoreArg = new COLUMN_ARG((int)GUIINDEX_NUM.SCORE, "Score");
        public COLUMN_ARG group0Arg = new COLUMN_ARG((int)GUIINDEX_NUM.GROUP0, "Group0");
        public COLUMN_ARG group1Arg = new COLUMN_ARG((int)GUIINDEX_NUM.GROUP1, "Group1");
        public COLUMN_ARG paramArg = new COLUMN_ARG((int)GUIINDEX_NUM.PARAM, "Param");
        public COLUMN_ARG commonArg = new COLUMN_ARG((int)GUIINDEX_NUM.COMMON, "Common");
		
		// TODO
		public void ShowRankingBoard(RankingResult rankingInfo, bool enable = true) { }
		
		// TODO
		protected override void CreateColumnIndex() { }
		
		protected override string HeaderTextTag { get => "NexAssetsRankingHeaderText"; }
		protected override string ParamTextTag { get => "NexAssetsRankingParamText"; }
		
		// TODO
		protected override int GetDataCount() { return default; }
		
		// TODO
		protected override string GetContent(COLUMN_ARG columnArg) { return default; }

		public enum GUIINDEX : int
		{
			PID = 1,
			UID = 2,
			CATEGORY = 4,
			ORDER = 8,
			SCORE = 16,
			GROUP0 = 32,
			GROUP1 = 64,
			PARAM = 128,
			COMMON = 256,
		}

		private enum GUIINDEX_NUM : int
		{
			ORDER = 0,
			PID = 1,
			UID = 2,
			CATEGORY = 3,
			SCORE = 4,
			GROUP0 = 5,
			GROUP1 = 6,
			PARAM = 7,
			COMMON = 8,
			MAX = 9,
		}
	}
}