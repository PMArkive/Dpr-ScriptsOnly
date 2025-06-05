using System;
using UnityEngine;

namespace XLSXContent
{
	[Serializable]
	public class HardStoneRawData : ScriptableObject
	{
		public SheetHardStone[] HardStone;
		
		public SheetHardStone this[int index] => HardStone[index];

		[Serializable]
		public class SheetHardStone
		{
			public string textureName;
			public string shape;
			public int turn;
		}
	}
}