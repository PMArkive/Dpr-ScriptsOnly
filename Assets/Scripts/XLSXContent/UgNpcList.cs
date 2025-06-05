using Pml;
using System;
using UnityEngine;

namespace XLSXContent
{
	[Serializable]
	public class UgNpcList : ScriptableObject
	{
		public SheetSheet1[] Sheet1;
		
		public SheetSheet1 this[int index] => Sheet1[index];

		[Serializable]
		public class SheetSheet1
		{
			public ushort NpcId;
			public bool IsRandom;
			public ZoneID ZoneID;
			public Sex Sex;
			public string CharacterID;
			public byte ColorID;
			public string NameLabel;
		}
	}
}