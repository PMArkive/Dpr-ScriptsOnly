using System;
using UnityEngine;

namespace NexAssets
{
	[Serializable]
	public class Ranking2EstimateScoreRankInput
	{
		[SerializeField]
		private uint category;
		[SerializeField]
		private byte numSeasonsToGoBack;
		
		// TODO
		public NexPlugin.Ranking2EstimateScoreRankInput GetRanking2EstimateScoreRankInput() { return default; }
	}
}