using System;
using UnityEngine;

namespace XLSXContent
{
	[Serializable]
	public class ContestCommonData : ScriptableObject
	{
		public SheetContestCategory[] ContestCategory;
		public SheetContestRank[] ContestRank;

        public SheetContestCategory this[int index] => ContestCategory[index];

		[Serializable]
		public class SheetContestCategory
		{
			public bool valid_flag;
			public ushort id;
			public int category;
			public bool needDpClear;
			public string labelNameBrilliant;
			public string labelNameShining;
		}

		[Serializable]
		public class SheetContestRank
		{
			public bool valid_flag;
			public ushort id;
			public int rank;
			public string labelName;
		}
	}
}