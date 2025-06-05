using System;
using UnityEngine;

namespace NexAssets
{
	[Serializable]
	public class Ranking2GetParam
	{
		[SerializeField]
		private uint category;
		[SerializeField]
		[Range(0.0f, 100.0f)]
		private uint length = 10;
		[SerializeField]
		private NexPlugin.Ranking2.Ranking2GetOptionFlags optionFlag;
		[SerializeField]
		private NexPlugin.Ranking2.Ranking2SortFlags sortFlag;
		[SerializeField]
		private Ranking2Mode mode = Ranking2Mode.RANGE_RANKING;
		[SerializeField]
		[Range(0.0f, 255.0f)]
		private byte period;
		
		// TODO
		public NexPlugin.Ranking2GetParam GetRanking2GetParam() { return default; }
	}
}