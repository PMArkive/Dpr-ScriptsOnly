namespace nn.ec
{
	public static class PurchasedEvent
	{
		public static extern void Initialize();
		public static extern bool PopPurchasedItemInfo(ref PurchasedItemInfo pOut);
	}
}