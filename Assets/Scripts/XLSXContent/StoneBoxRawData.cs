using System;
using UnityEngine;

namespace XLSXContent
{
	[Serializable]
	public class StoneBoxRawData : ScriptableObject
	{
		public SheetBox[] Box;
		
		public SheetBox this[int index] => Box[index];

		[Serializable]
		public class SheetBox
		{
			public short type;
			public short boxId;
			public string shape;
			public int ratio1;
			public int ratio2;
		}
	}
}