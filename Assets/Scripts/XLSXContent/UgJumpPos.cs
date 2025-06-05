using System;
using UnityEngine;

namespace XLSXContent
{
	[Serializable]
	public class UgJumpPos : ScriptableObject
	{
		public SheetData[] Data;
		
		public SheetData this[int index] => Data[index];

		[Serializable]
		public class SheetData
		{
			public int ID;
			public int MapGroupID;
			public ZoneID ZoneID;
			public Vector2 Locators;
		}
	}
}