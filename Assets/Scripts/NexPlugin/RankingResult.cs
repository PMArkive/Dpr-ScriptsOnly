using System.Collections.Generic;

namespace NexPlugin
{
	public class RankingResult
	{
		internal uint totalCount;
		internal List<RankingRankData> rankDataList;
		internal NpDateTime sinceTime;
		
		public RankingResult()
		{
			rankDataList = new List<RankingRankData>();
			totalCount = 0;
			sinceTime = NpDateTime.INVALID_DATE_TIME;
		}
		
		// TODO
		public uint GetTotalCount() { return default; }
		
		// TODO
		public List<RankingRankData> GetRankDataList() { return default; }
		
		// TODO
		public NpDateTime GetSinceTime() { return default; }
		
		// TODO
		public void Trace() { }
		
		// TODO
		public override string ToString() { return default; }
	}
}