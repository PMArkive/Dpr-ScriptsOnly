using DPData.MysteryGift;
using System;

namespace DPData
{
	[Serializable]
	public struct MysteryGiftItemData
	{
		public const int InfoSize = 7;

		public ItemInfo[] itemInfos;
	}
}