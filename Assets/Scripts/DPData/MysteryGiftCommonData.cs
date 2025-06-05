using System;

namespace DPData
{
	[Serializable]
	public struct MysteryGiftCommonData
	{
		public long timestamp;
		public uint deliveryID;
		public ushort eventTextID;
		public ushort romVersion;
		public byte receiveFlag;
		public byte dataType;
		public byte cardMessageID;
		public byte[] padding;
		
		public bool IsReceiveOnce { get => (receiveFlag & 1) == 1; }
		
		public bool IsReceiveOneDay { get => ((receiveFlag >> 2) & 1) == 1; }
    }
}