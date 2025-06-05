namespace nn.hid
{
	public static class ControllerFirmwareUpdate
	{
		public static extern Result Show(ControllerFirmwareUpdateArg showControllerFirmwareUpdateArg);
		
		// TODO
		public static Result Show(ControllerFirmwareUpdateArg showControllerFirmwareUpdateArg, bool suspendUnityThreads) { return default; }
		
		// TODO
		public static ErrorRange ResultControllerFirmwareUpdateError { get; }
		
		// TODO
		public static ErrorRange ResultControllerFirmwareUpdateFailed { get; }
	}
}