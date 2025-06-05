using System;

namespace DPData.MysteryGift
{
	[Serializable]
	public struct NameInfo
	{
		public string name;
		public byte languageId;
		public byte paddding;
		public int reserved_int01;
	}
}