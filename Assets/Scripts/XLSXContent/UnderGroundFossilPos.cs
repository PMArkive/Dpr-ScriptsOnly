using System;
using UnityEngine;

namespace XLSXContent
{
	[Serializable]
	public class UnderGroundFossilPos : ScriptableObject
	{
		public SheetData[] Data;
		
		public SheetData this[int index] => Data[index];

		[Serializable]
		public class SheetData
		{
			public ZoneID ZoneID;
			public Vector2Int start;
			public Vector2Int end;
		}
	}
}