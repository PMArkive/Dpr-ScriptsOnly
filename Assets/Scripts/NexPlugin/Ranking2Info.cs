using System.Collections.Generic;

namespace NexPlugin
{
	public class Ranking2Info
	{
		internal uint numRankedIn;
		internal uint lowestRank;
		internal int season;
		internal List<Ranking2RankData> rankDataList;
		
		public Ranking2Info()
		{
			rankDataList = new List<Ranking2RankData>();
		}
		
		// TODO
		public List<Ranking2RankData> GetRankDataList() { return default; }
		
		// TODO
		public uint GetLowestRank() { return default; }
		
		// TODO
		public uint GetNumRankedIn() { return default; }
		
		// TODO
		public int GetSeason() { return default; }
		
		// TODO
		public void Trace() { }
		
		// TODO
		public override string ToString() { return default; }
	}
}