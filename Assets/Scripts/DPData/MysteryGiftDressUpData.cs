using System;

namespace DPData
{
	[Serializable]
	public struct MysteryGiftDressUpData
	{
		public const int InfoSize = 7;

		public uint[] maleDressIds;
		public uint[] femaleDressIds;
		public int reserved_int01;
		public int reserved_int02;
	}
}