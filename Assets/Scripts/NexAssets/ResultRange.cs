using System;
using UnityEngine;

namespace NexAssets
{
	[Serializable]
	public class ResultRange
	{
		[SerializeField]
		private uint offset;
		[SerializeField]
		private uint size = 20;
		[SerializeField]
		private bool useAnyOffset;
		
		// TODO
		public void Validate() { }
		
		// TODO
		public NexPlugin.ResultRange GetResultRange() { return default; }
	}
}