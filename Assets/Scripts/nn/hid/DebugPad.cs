using System.Runtime.InteropServices;

namespace nn.hid
{
	public static class DebugPad
	{
		public const int StateCountMax = 16;
		
		// TODO
		public static void Initialize() { }
		
		// TODO
		public static void GetState(ref DebugPadState pOutValue) { }
		
		// TODO
		public static int GetStates([Out] DebugPadState[] pOutValues, int count) { return default; }
	}
}