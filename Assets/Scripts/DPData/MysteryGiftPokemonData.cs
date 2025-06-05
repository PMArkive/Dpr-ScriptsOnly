using DPData.MysteryGift;
using System;

namespace DPData
{
	[Serializable]
	public struct MysteryGiftPokemonData
	{
		public const int NameInfoSize = 9;
		public const int RibbonSize = 16;

		public uint parentId;
		public uint romVersion;
		public uint randomValue;
		public uint colorRandomValue;
		public NameInfo[] nickNames;
		public NameInfo[] parentNames;
		public ushort getArea;
		public ushort captureArea;
		public ushort captureBallId;
		public ushort itemId;
		public ushort[] skillIDs;
		public ushort[] eggSkillIDs;
		public ushort monsNo;
		public byte formNo;
		public byte sex;
		public byte level;
		public byte isEgg;
		public byte seikaku;
		public byte tokusei;
		public byte isRare;
		public byte captureLevel;
		public byte[] ribbonIds;
		public byte[] twoRibbonIds;
		public byte hpRandom;
		public byte attackRandom;
		public byte defenseRandom;
		public byte agilityRandom;
		public byte spAttackRandom;
		public byte spDefenseRandom;
		public byte parentSex;
		public byte hpEffort;
		public byte attackEffort;
		public byte defenseEffort;
		public byte agilityEffort;
		public byte spAttackEffort;
		public byte spDefenseEffort;
		public byte style;
		public byte beautiful;
		public byte cute;
		public byte clever;
		public byte strong;
		public byte fur;
		public byte padding;
		public short reserved_short01;
		public int reserved_int01;
		public int reserved_int02;
	}
}