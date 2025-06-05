using Dpr.SequenceEditor;
using System;
using UnityEngine;

namespace Dpr.Battle.View.Playables
{
	[Serializable]
	public struct DofParam
	{
		public bool depthOfFieldEnable;
		[Header("フォーカス距離(DepthOfField=distance)")]
		public float focusDistance;
		[Header("F値(DepthOfField=focalLength)")]
		public float fStop;
		[Header("ぼかしスケール(DepthOfField=farDepth)")]
		public float focusRegionScale;
		
		public static DofParam Factory()
		{
			return new DofParam();
		}
		
		// TODO
		public static DofParam Factory(EffDepthOfFieldSet other) { return default; }
	}
}