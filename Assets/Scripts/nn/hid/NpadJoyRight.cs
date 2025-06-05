using System.Runtime.InteropServices;

namespace nn.hid
{
	public static class NpadJoyRight
	{
		public static extern void GetState(ref NpadJoyRightState pOutValue, NpadId npadId);
		public static extern void GetState(ref NpadState pOutValue, NpadId npadId);
		public static extern int GetStates([Out] NpadJoyRightState[] pOutValues, int count, NpadId npadId);
		public static extern int GetStates([Out] NpadStateArrayItem[] pOutValues, int count, NpadId npadId);
	}
}