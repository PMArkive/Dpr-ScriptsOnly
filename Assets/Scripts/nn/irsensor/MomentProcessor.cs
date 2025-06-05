using System.Runtime.InteropServices;

namespace nn.irsensor
{
	public static class MomentProcessor
	{
		public const int StateCountMax = 5;
		public const int BlockColumnCount = 8;
		public const int BlockRowCount = 6;
		public const int BlockCount = 48;

		public static extern void GetDefaultConfig(ref MomentProcessorConfig pOutValue);
		public static extern void Run(IrCameraHandle handle, MomentProcessorConfig config);
		public static extern Result GetState(ref MomentProcessorState pOutValue, IrCameraHandle handle);
		
		// TODO
		public static Result GetStatus(MomentProcessorState[] pOutStates, ref int pOutCount, IrCameraHandle handle) { return default; }

		private static extern Result GetStates([In] [Out] MomentProcessorState[] pOutStates, ref int pOutCount, int countMax, IrCameraHandle handle);
		public static extern MomentStatistic CalculateMomentRegionStatistic(ref MomentProcessorState pState, Rect windowOfInterest, int startRow, int startColumn, int rowCount, int columnCount);
	}
}