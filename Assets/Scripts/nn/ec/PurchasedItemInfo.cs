using nn.account;

namespace nn.ec
{
	public struct PurchasedItemInfo
	{
		public Type type;
		public NetworkServiceAccountId nsaId;
		internal CourseId _courseId;
		
		// TODO
		public CourseId GetCourseId() { return default; }

		private static extern CourseId GetCourseId(PurchasedItemInfo info);

		public enum Type : int
		{
			Subscription = 0,
			Consumable = 1,
		}
	}
}