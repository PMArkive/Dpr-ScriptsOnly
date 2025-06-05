using Pml;
using Pml.PokePara;
using System;
using UnityEngine;

namespace XLSXContent
{
	[Serializable]
	public class LocalKoukanData : ScriptableObject
	{
		public Sheetdata[] data;
		
		public Sheetdata this[int index] => data[index];

		[Serializable]
		public class Sheetdata
		{
			public MonsNo target;
			public string name_label;
			public int trainerid;
			public MonsNo monsno;
			public string nickname_label;
			public int level;
			public Seikaku seikaku;
			public int tokusei;
			public ItemNo itemno;
			public int rand;
			public Sex sex;
			public int language;
			public WazaNo[] waza;
		}
	}
}