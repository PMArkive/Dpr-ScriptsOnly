using nn.account;

namespace nn.ec
{
	public static class Shop
	{
		public static extern void ShowApplicationInformation(ulong applicationId);
		public static extern void ShowApplicationInformation(ulong applicationId, UserHandle selectedUser);
		public static extern void ShowAddOnContentList(ulong applicationId);
		public static extern void ShowAddOnContentList(ulong applicationId, UserHandle selectedUser);
		public static extern void ShowSubscriptionList(ulong applicationId);
		public static extern void ShowSubscriptionList(ulong applicationId, UserHandle selectedUser);
		public static extern void ShowSubscriptionList(ulong applicationId, CourseId courseId);
		public static extern void ShowSubscriptionList(ulong applicationId, CourseId courseId, UserHandle selectedUser);
		public static extern void ShowConsumableItemList(ulong applicationId);
		public static extern void ShowConsumableItemList(ulong applicationId, UserHandle selectedUser);
		public static extern void ShowConsumableItemDetail(ulong applicationId, ConsumableId consumableId, NsUid nsUid);
		public static extern void ShowConsumableItemDetail(ulong applicationId, ConsumableId consumableId, NsUid nsUid, UserHandle selectedUser);
		public static extern void ShowEnterCodeScene();
		public static extern void ShowEnterCodeScene(UserHandle selectedUser);
		public static extern void ShowShopProductDetails(NsUid nsuid);
		public static extern void ShowShopProductDetails(NsUid nsuid, UserHandle selectedUser);
		
		// TODO
		public static void ShowShopProductList(NsUid[] nsuidList, string listName) { }

		private static extern void ShowShopProductList(NsUid[] nsuidList, int nsuidCount, string listName);
		
		// TODO
		public static void ShowShopProductList(NsUid[] nsuidList, string listName, UserHandle selectedUser) { }

		private static extern void ShowShopProductList(NsUid[] nsuidList, int nsuidCount, string listName, UserHandle selectedUser);
		public static extern NsUid MakeNsUid(string str);
	}
}