using DPData;
using UnityEngine;

namespace Dpr.NetworkUtils
{
	public struct DigPosData
	{
		public ZoneID zoneID;
		public Vector2Int MainPos;
		public DigPos digPos1;
		public DigPos digPos2;
		
		public bool isBothUsed { get => digPos1.IsNull && digPos2.IsNull; }
	}
}