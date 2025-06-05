using System;
using UnityEngine;

namespace XLSXContent
{
	[Serializable]
	public class LightStoneTable : ScriptableObject
	{
		public SheetData[] Data;
		
		public SheetData this[int index] => Data[index];

		[Serializable]
		public class SheetData
		{
			public ZoneID ZoneID;
			public int LightStone;
			public int BonusTime;
		}
	}
}