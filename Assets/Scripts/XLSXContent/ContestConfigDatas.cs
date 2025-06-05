using Dpr.Contest;
using Pml.PokePara;
using System;
using UnityEngine;

namespace XLSXContent
{
	[Serializable]
	public class ContestConfigDatas : ScriptableObject
	{
		public SheetTapScoreData[] TapScoreData;
		public SheetTapTimingData[] TapTimingData;
		public SheetComboBonusData[] ComboBonusData;
		public SheetMatchingSkill[] MatchingSkill;
		public SheetLotteryEntryRank[] LotteryEntryRank;
		public SheetResultCameraTween[] ResultCameraTween;
		public SheetResultMotion[] ResultMotion;
		public SheetValueData[] ValueData;
		public SheetStringData[] StringData;

        public SheetTapScoreData this[int index] => TapScoreData[index];

		[Serializable]
		public class SheetTapScoreData
		{
			public bool valid_flag;
			public ushort id;
			public int tension;
			public int best;
			public int great;
			public int nice;
			public int fast;
			public int slow;
			public int upCount;
			public int downCount;
		}

		[Serializable]
		public class SheetTapTimingData
		{
			public bool valid_flag;
			public ushort id;
			public int pattern;
			public float bestRange;
			public float greatRange;
			public float niceRange;
			public float fastRange;
		}

		[Serializable]
		public class SheetComboBonusData
		{
			public bool valid_flag;
			public ushort id;
			public int chainCount;
			public int basePoint;
			public int bonusPoint;
		}

		[Serializable]
		public class SheetMatchingSkill
		{
			public bool valid_flag;
			public ushort id;
			public int skillPoint;
		}

		[Serializable]
		public class SheetLotteryEntryRank
		{
			public bool valid_flag;
			public ushort id;
			public float aveSkillPoint;
			public RankID contestRank;
		}

		[Serializable]
		public class SheetResultCameraTween
		{
			public bool valid_flag;
			public ushort id;
			public int entryNumber;
			public float duration;
			public Size size;
			public float posX;
			public float posY;
			public float posZ;
			public float angleX;
			public float angleY;
			public float angleZ;
		}

		[Serializable]
		public class SheetResultMotion
		{
			public bool valid_flag;
			public ushort id;
			public int monsNo;
			public uint winAnim;
			public uint loseAnim;
			public uint waitAnim;
			public float duration;
		}

		[Serializable]
		public class SheetValueData
		{
			public bool valid_flag;
			public ushort id;
			public int value;
		}

		[Serializable]
		public class SheetStringData
		{
			public bool valid_flag;
			public ushort id;
			public string value;
		}
	}
}