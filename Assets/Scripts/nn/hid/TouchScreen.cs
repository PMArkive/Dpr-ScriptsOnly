using System.Runtime.InteropServices;

namespace nn.hid
{
	public static class TouchScreen
	{
		public const int TouchCountMax = 16;
		public const int StateCountMax = 16;

		// TODO
		public static extern void Initialize();

		public static extern void GetState(ref TouchScreenState1 pOutValue);
		public static extern void GetState(ref TouchScreenState2 pOutValue);
		public static extern void GetState(ref TouchScreenState3 pOutValue);
		public static extern void GetState(ref TouchScreenState4 pOutValue);
		public static extern void GetState(ref TouchScreenState5 pOutValue);
		public static extern void GetState(ref TouchScreenState6 pOutValue);
		public static extern void GetState(ref TouchScreenState7 pOutValue);
		public static extern void GetState(ref TouchScreenState8 pOutValue);
		public static extern void GetState(ref TouchScreenState9 pOutValue);
		public static extern void GetState(ref TouchScreenState10 pOutValue);
		public static extern void GetState(ref TouchScreenState11 pOutValue);
		public static extern void GetState(ref TouchScreenState12 pOutValue);
		public static extern void GetState(ref TouchScreenState13 pOutValue);
		public static extern void GetState(ref TouchScreenState14 pOutValue);
		public static extern void GetState(ref TouchScreenState15 pOutValue);
		public static extern void GetState(ref TouchScreenState16 pOutValue);
		public static extern int GetStates([Out] TouchScreenState1[] pOutValues, int count);
		public static extern int GetStates([Out] TouchScreenState2[] pOutValues, int count);
		public static extern int GetStates([Out] TouchScreenState3[] pOutValues, int count);
		public static extern int GetStates([Out] TouchScreenState4[] pOutValues, int count);
		public static extern int GetStates([Out] TouchScreenState5[] pOutValues, int count);
		public static extern int GetStates([Out] TouchScreenState6[] pOutValues, int count);
		public static extern int GetStates([Out] TouchScreenState7[] pOutValues, int count);
		public static extern int GetStates([Out] TouchScreenState8[] pOutValues, int count);
		public static extern int GetStates([Out] TouchScreenState9[] pOutValues, int count);
		public static extern int GetStates([Out] TouchScreenState10[] pOutValues, int count);
		public static extern int GetStates([Out] TouchScreenState11[] pOutValues, int count);
		public static extern int GetStates([Out] TouchScreenState12[] pOutValues, int count);
		public static extern int GetStates([Out] TouchScreenState13[] pOutValues, int count);
		public static extern int GetStates([Out] TouchScreenState14[] pOutValues, int count);
		public static extern int GetStates([Out] TouchScreenState15[] pOutValues, int count);
		public static extern int GetStates([Out] TouchScreenState16[] pOutValues, int count);
	}
}