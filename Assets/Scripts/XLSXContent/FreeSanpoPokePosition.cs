using System;
using UnityEngine;

namespace XLSXContent
{
	[Serializable]
	public class FreeSanpoPokePosition : ScriptableObject
	{
		public SheetSheet1[] Sheet1;
		
		public SheetSheet1 this[int index] => Sheet1[index];

		[Serializable]
		public class SheetSheet1
		{
			public int PokeID;
			public int[] RankArray;
			public int Pos1;
			public int Pos2;
			public int Pos3;
			public int Pos4;
			public int Pos5;
			public int Pos6;
			public int Pos7;
			public int Pos8;
			public int Pos9;
		}
	}
}