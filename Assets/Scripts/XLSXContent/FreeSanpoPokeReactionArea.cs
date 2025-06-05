using System;
using UnityEngine;

namespace XLSXContent
{
	[Serializable]
	public class FreeSanpoPokeReactionArea : ScriptableObject
	{
		public SheetSheet1[] Sheet1;
		
		public SheetSheet1 this[int index] => Sheet1[index];

		[Serializable]
		public class SheetSheet1
		{
			public int PokeID;
			public float[] RankArray;
			public int RankD;
			public int RankC;
			public int RankB;
			public float RankA;
			public float RankS;
		}
	}
}