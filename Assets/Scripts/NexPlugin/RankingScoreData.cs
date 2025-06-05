namespace NexPlugin
{
	public class RankingScoreData
	{
		internal ulong param;
		internal uint category;
		internal uint score;
		internal Ranking.OrderBy orderBy;
		internal Ranking.UpdateMode updateMode;
		internal byte group0;
		internal byte group1;
		
		public RankingScoreData()
		{
			param = 0;
			category = 0;
			score = 0;
			orderBy = Ranking.OrderBy.ORDER_BY_DESC;
			updateMode = Ranking.UpdateMode.UPDATE_MODE_NORMAL;
			group0 = 0;
			group1 = 0;
		}
		
		// TODO
		public uint GetCategory() { return default; }
		
		// TODO
		public void SetCategory(uint category_) { }
		
		// TODO
		public void SetScore(uint score_) { }
		
		// TODO
		public uint GetScore() { return default; }
		
		// TODO
		public void SetOrderBy(Ranking.OrderBy orderBy_) { }
		
		// TODO
		public Ranking.OrderBy GetOrderBy() { return default; }
		
		// TODO
		public void SetUpdateMode(Ranking.UpdateMode updateMode_) { }
		
		// TODO
		public Ranking.UpdateMode GetUpdateMode() { return default; }
		
		// TODO
		public void SetGroup0(byte group0_) { }
		
		// TODO
		public byte GetGroup0() { return default; }
		
		// TODO
		public void SetGroup1(byte group1_) { }
		
		// TODO
		public byte GetGroup1() { return default; }
		
		// TODO
		public void SetParam(ulong param_) { }
		
		// TODO
		public ulong GetParam() { return default; }
		
		// TODO
		public void Trace() { }
		
		// TODO
		public override string ToString() { return default; }
	}
}