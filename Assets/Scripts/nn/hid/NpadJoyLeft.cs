using System.Runtime.InteropServices;

namespace nn.hid
{
	public static class NpadJoyLeft
	{
		public static extern void GetState(ref NpadJoyLeftState pOutValue, NpadId npadId);
		public static extern void GetState(ref NpadState pOutValue, NpadId npadId);
		public static extern int GetStates([Out] NpadJoyLeftState[] pOutValues, int count, NpadId npadId);
		public static extern int GetStates([Out] NpadStateArrayItem[] pOutValues, int count, NpadId npadId);
	}
}