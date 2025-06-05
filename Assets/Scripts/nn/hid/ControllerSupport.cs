namespace nn.hid
{
	public static class ControllerSupport
	{
		public const int ExplainTextMaxLength = 32;
		public const int Utf8ByteSize = 4;
		public const int ExplainTextMaxBufferSize = 129;
		public const int ControllerSupportPlayerCountMax = 8;

		public static extern Result Show(ControllerSupportArg showControllerSupportArg);
		public static extern Result Show(ref ControllerSupportResultInfo pOutValue, ControllerSupportArg showControllerSupportArg);
		public static extern void SetExplainText(ref ControllerSupportArg pOutControllerSupportArg, string pStr, NpadId npadId);
		
		// TODO
		public static Result Show(ControllerSupportArg showControllerSupportArg, bool suspendUnityThreads) { return default; }
		
		// TODO
		public static Result Show(ref ControllerSupportResultInfo pOutValue, ControllerSupportArg showControllerSupportArg, bool suspendUnityThreads) { return default; }
		
		// TODO
		public static ErrorRange ResultCanceled { get; }
		
		// TODO
		public static ErrorRange ResultNotSupportedNpadStyle { get; }
	}
}