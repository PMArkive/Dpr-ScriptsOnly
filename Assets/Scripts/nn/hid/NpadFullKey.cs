using System.Runtime.InteropServices;

namespace nn.hid
{
	public static class NpadFullKey
	{
		public static extern void GetState(ref NpadFullKeyState pOutValue, NpadId npadId);
		public static extern void GetState(ref NpadState pOutValue, NpadId npadId);
		public static extern int GetStates([Out] NpadFullKeyState[] pOutValues, int count, NpadId npadId);
		public static extern int GetStates([Out] NpadStateArrayItem[] pOutValues, int count, NpadId npadId);
	}
}