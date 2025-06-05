using System;
using UnityEngine;

namespace NexAssets
{
	[Serializable]
	public class RankingScoreData
	{
		[SerializeField]
		private uint category;
		[SerializeField]
		private NexPlugin.Ranking.OrderBy orderby = NexPlugin.Ranking.OrderBy.ORDER_BY_DESC;
		[SerializeField]
		private NexPlugin.Ranking.UpdateMode mode;
		[SerializeField]
		[Range(0.0f, 255.0f)]
		private byte group0;
		[SerializeField]
		[Range(0.0f, 255.0f)]
		private byte group1;
		[SerializeField]
		private string param = "0";

		private ulong param_;
		
		// TODO
		public void Validate() { }
		
		// TODO
		public NexPlugin.RankingScoreData GetRankingScoreData() { return default; }
	}
}