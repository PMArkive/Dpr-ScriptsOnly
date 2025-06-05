using DPData;
using DPData.MysteryGift;

namespace Dpr.UI
{
	public class GiftListItemInfo
	{
		private MysteryGiftData giftData;
		
		public MysteryGiftData GiftData { get => giftData; }
		public RecvData RecvData { get; set; }
		public ConvertResult ConvertResult { get; set; }
		
		public GiftListItemInfo(byte[] data)
		{
			Create(data);
		}
		
		// TODO
		public CanReceiveResult CanReceive() { return default; }
		
		// TODO
		private void Create(byte[] data) { }
	}
}