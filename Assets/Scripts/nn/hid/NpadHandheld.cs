using System.Runtime.InteropServices;

namespace nn.hid
{
	public static class NpadHandheld
	{
		public static extern void GetState(ref NpadHandheldState pOutValue, NpadId npadId);
		public static extern void GetState(ref NpadState pOutValue, NpadId npadId);
		public static extern int GetStates([Out] NpadHandheldState[] pOutValues, int count, NpadId npadId);
		public static extern int GetStates([Out] NpadStateArrayItem[] pOutValues, int count, NpadId npadId);
	}
}