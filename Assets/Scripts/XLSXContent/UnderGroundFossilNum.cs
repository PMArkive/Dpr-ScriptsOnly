using System;
using UnityEngine;

namespace XLSXContent
{
	[Serializable]
	public class UnderGroundFossilNum : ScriptableObject
	{
		public SheetData[] Data;
		
		public SheetData this[int index] => Data[index];

		[Serializable]
		public class SheetData
		{
			public ZoneID ZoneID;
			public int min;
			public int max;
		}
	}
}