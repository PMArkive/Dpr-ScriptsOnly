namespace nn.err
{
	public static class Error
	{
		public static extern void Show(Result result);
		public static extern void Show(ErrorCode errorCode);
		
		// TODO
		public static void Show(Result result, bool suspendUnityThreads) { }
		
		// TODO
		public static void Show(ErrorCode errorCode, bool suspendUnityThreads) { }

		public static extern void ShowUnacceptableAddOnContentVersion();
		
		// TODO
		public static void ShowUnacceptableAddOnContentVersion(bool suspendUnityThreads) { }

		public static extern void ShowUnacceptableApplicationVersion();
		
		// TODO
		public static void ShowUnacceptableApplicationVersion(bool suspendUnityThreads) { }
	}
}