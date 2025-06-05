using System;
using UnityEngine;

namespace Dpr.Contest
{
	[Serializable]
	public class LightSetting
	{
		public int userRank = (int)RankID.Normal;
		public Vector3 positon = Vector3.zero;
		public Vector3 rot = Vector3.zero;
        public Vector3 scale = Vector3.one;
	}
}