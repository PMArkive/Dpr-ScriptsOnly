using System;
using UnityEngine;

namespace NexAssets
{
	[Serializable]
	public class Ranking2ChartInfoInput
	{
		[SerializeField]
		private uint chartIndex;
		[SerializeField]
		private byte numSeasonsToGoBack;
		
		// TODO
		public NexPlugin.Ranking2ChartInfoInput GetRanking2ChartInfoInput() { return default; }
	}
}