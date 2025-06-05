using System.Runtime.InteropServices;

namespace nn.hid
{
	public static class SixAxisSensor
	{
		public const int StateCountMax = 16;
		public const int HandleCountMax = 8;

		public static extern int GetHandles(SixAxisSensorHandle[] pOutValues, int count, NpadId npadId, NpadStyle npadStyle);
		public static extern void Start(SixAxisSensorHandle handle);
		public static extern void Stop(SixAxisSensorHandle handle);
		public static extern bool IsRest(SixAxisSensorHandle handle);
		public static extern void GetState(ref SixAxisSensorState pOutValue, SixAxisSensorHandle handle);
		public static extern int GetStates([Out] SixAxisSensorState[] pOutValues, int count, SixAxisSensorHandle handle);
		public static extern bool IsFusionEnabled(SixAxisSensorHandle handle);
		public static extern void EnableFusion(SixAxisSensorHandle handle, bool enable);
		public static extern void SetFusionParameters(SixAxisSensorHandle handle, float revisePower, float reviseRange);
		public static extern void GetFusionParameters(ref float pOutRevisePower, ref float pOutReviseRange, SixAxisSensorHandle handle);
		public static extern void ResetFusionParameters(SixAxisSensorHandle handle);
		public static extern void SetGyroscopeZeroDriftMode(SixAxisSensorHandle handle, GyroscopeZeroDriftMode mode);
		public static extern GyroscopeZeroDriftMode GetGyroscopeZeroDriftMode(SixAxisSensorHandle handle);
		public static extern bool IsFirmwareUpdateAvailableForSixAxisSensor(SixAxisSensorHandle handle);
	}
}