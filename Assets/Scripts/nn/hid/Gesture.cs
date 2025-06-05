using System.Runtime.InteropServices;

namespace nn.hid
{
	public static class Gesture
	{
		public const int PointCountMax = 4;
		public const int StateCountMax = 16;

		public static extern void Initialize();
		public static extern int GetStates([In] [Out] GestureState[] pOutValues, int count);
	}
}