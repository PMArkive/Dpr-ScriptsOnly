using System;

namespace DPData
{
	[Serializable]
	public struct MysteryGiftData
	{
		public const int DataSize = 732;
		public const int CrcIndex = 720;

		public MysteryGiftCommonData commonData;
		public MysteryGiftBufferData bufferData;
		public MysteryGiftPokemonData pokemonData;
		public MysteryGiftItemData itemData;
		public MysteryGiftDressUpData dressUpData;
		public uint moneyData;
		public MysteryGiftUnderGroundItemData underGroundItemData;
		public ushort crc;
		public short reserved_short01;
		public int reserved_int01;
		public int reserved_int02;
	}
}