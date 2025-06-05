using System;
using UnityEngine;

namespace NexAssets
{
	[Serializable]
	public class Ranking2ScoreData
	{
		[SerializeField]
		private uint category;
		[SerializeField]
		private string misc = "0";

		private ulong misc_;
		
		// TODO
		public void Validate() { }
		
		// TODO
		public NexPlugin.Ranking2ScoreData GetScoreData() { return default; }
	}
}