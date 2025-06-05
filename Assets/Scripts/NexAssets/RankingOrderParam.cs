using System;
using UnityEngine;

namespace NexAssets
{
	[Serializable]
	public class RankingOrderParam
	{
		[SerializeField]
		private NexPlugin.Ranking.OrderCalculation ordercalc;
		[SerializeField]
		private NexPlugin.Ranking.FilterGroupIndex groupindex = NexPlugin.Ranking.FilterGroupIndex.FILTER_GROUP_INDEX_NONE;
		[SerializeField]
		private byte groupnum;
		[SerializeField]
		private NexPlugin.Ranking.TimeScope timescope = NexPlugin.Ranking.TimeScope.TIME_SCOPE_ALL;
		[SerializeField]
		[Range(0.0f, 255.0f)]
		private byte length = 10;
		
		// TODO
		public NexPlugin.RankingOrderParam GetRankingOrderParam() { return default; }
	}
}