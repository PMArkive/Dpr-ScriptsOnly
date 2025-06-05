using System;
using UnityEngine;

namespace NexAssets
{
	[Serializable]
	public class RankingGetRankingParam
	{
		[SerializeField]
		private uint category;
		[SerializeField]
		private NexPlugin.Ranking.RankingMode mode;
		[SerializeField]
		private NexPlugin.Ranking.StatsFlag statsflag = NexPlugin.Ranking.StatsFlag.STATS_FLAG_TOTAL;
		[SerializeField]
		private RankingOrderParam rankingOrderParam = new RankingOrderParam();
		
		// TODO
		public uint GetCategory() { return default; }
		
		// TODO
		public NexPlugin.Ranking.RankingMode GetRankingMode() { return default; }
		
		// TODO
		public NexPlugin.Ranking.StatsFlag GetStatsFlag() { return default; }
		
		// TODO
		public NexPlugin.RankingOrderParam GetRankingOrderParam() { return default; }
	}
}