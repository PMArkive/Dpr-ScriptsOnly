namespace nn.aoc
{
	public static class Aoc
	{
		public static extern int CountAddOnContent();
		public static extern int ListAddOnContent(int[] outIndices, int offset, int count);
		public static extern void GetAddOnContentListChangedEvent();
		public static extern bool IsAddOnContentListChanged();
		public static extern void DestroyAddOnContentListChangedEvent();
		
		// TODO
		public static void ShowAddOnContentLostError(int[] indices) { }

		private static extern void ShowAddOnContentLostError(int[] indices, int count);
	}
}