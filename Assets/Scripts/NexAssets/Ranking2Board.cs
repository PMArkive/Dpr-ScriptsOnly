using NexPlugin;

namespace NexAssets
{
	public class Ranking2Board : RankingBoardBase
	{
		public bool m_ParamFold;
		private Ranking2Info m_RankingInfo = new Ranking2Info();
		public GUIINDEX m_GuiIndex = GUIINDEX.SCORE | GUIINDEX.RANK | GUIINDEX.PID;
		public COLUMN_ARG rankArg = new COLUMN_ARG((int)GUIINDEX_NUM.RANK, "Rank");
		public COLUMN_ARG pidArg = new COLUMN_ARG((int)GUIINDEX_NUM.PID, "PID");
        public COLUMN_ARG uidArg = new COLUMN_ARG((int)GUIINDEX_NUM.UID, "UID");
        public COLUMN_ARG scoreArg = new COLUMN_ARG((int)GUIINDEX_NUM.SCORE, "Score");
        public COLUMN_ARG miscArg = new COLUMN_ARG((int)GUIINDEX_NUM.MISC, "Misc");
        public COLUMN_ARG commonArg = new COLUMN_ARG((int)GUIINDEX_NUM.COMMON, "Common");

        // TODO
        public void ShowRankingBoard(Ranking2Info rankingInfo, bool enable = true) { }
		
		// TODO
		protected override void CreateColumnIndex() { }
		
		protected override string HeaderTextTag { get => "NexAssetsRanking2HeaderText"; }
		protected override string ParamTextTag { get => "NexAssetsRanking2ParamText"; }
		
		// TODO
		protected override int GetDataCount() { return default; }
		
		// TODO
		protected override string GetContent(COLUMN_ARG columnArg) { return default; }

		public enum GUIINDEX : int
		{
			PID = 1,
			UID = 2,
			RANK = 4,
			SCORE = 8,
			MISC = 16,
			COMMON = 32,
		}

		private enum GUIINDEX_NUM : int
		{
			RANK = 0,
			PID = 1,
			UID = 2,
			SCORE = 3,
			MISC = 4,
			COMMON = 5,
			MAX = 6,
		}
	}
}