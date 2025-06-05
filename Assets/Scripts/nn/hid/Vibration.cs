namespace nn.hid
{
	public static class Vibration
	{
		public static extern int GetDeviceHandles(VibrationDeviceHandle[] pOutValues, int count, NpadId npadId, NpadStyle npadStyle);
		public static extern void GetDeviceInfo(ref VibrationDeviceInfo pOutValue, VibrationDeviceHandle handle);
		public static extern void InitializeDevice(VibrationDeviceHandle handle);
		public static extern void SendValue(VibrationDeviceHandle handle, VibrationValue value);
		public static extern void GetActualValue(ref VibrationValue pOutValue, VibrationDeviceHandle handle);
		public static extern bool IsPermitted();
	}
}