using System.Runtime.InteropServices;

namespace nn.hid
{
	public static class NpadJoyDual
	{
		public static extern void GetState(ref NpadJoyDualState pOutValue, NpadId npadId);
		public static extern void GetState(ref NpadState pOutValue, NpadId npadId);
		public static extern int GetStates([Out] NpadJoyDualState[] pOutValues, int count, NpadId npadId);
		public static extern int GetStates([Out] NpadStateArrayItem[] pOutValues, int count, NpadId npadId);
	}
}