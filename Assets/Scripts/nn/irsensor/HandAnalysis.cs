using nn.util;
using System.Runtime.InteropServices;

namespace nn.irsensor
{
	public static class HandAnalysis
	{
		public const int ProcessorStateCountMax = 5;
		public const int ShapePointCountMax = 512;
		public const int ShapeCountMax = 16;
		public const int ProtrusionCountMax = 8;
		public const int HandCountMax = 2;
		public const int ImageWidth = 40;
		public const int ImageHeight = 30;

		public static extern Result Run(IrCameraHandle handle, HandAnalysisConfig config);
		public static extern Result GetSilhouetteState(ref HandAnalysisSilhouetteState pOutValue, IrCameraHandle handle);
		
		// TODO
		public static Result GetSilhouetteState(HandAnalysisSilhouetteState[] pOutValueArray, ref int pReturnCount, long infSamplingNumber, IrCameraHandle handle) { return default; }

		private static extern Result GetSilhouetteState([In] [Out] HandAnalysisSilhouetteState[] pOutValueArray, ref int pReturnCount, int maxCount, long infSamplingNumber, IrCameraHandle handle);
		public static extern Result GetSilhouetteState(ref HandAnalysisSilhouetteState pOutState, [In] [Out] Float2[] pOutPointBuffer, IrCameraHandle handle);
		
		// TODO
		public static Result GetSilhouetteState(HandAnalysisSilhouetteState[] pOutStateArray, Float2[][] pOutPointArray, ref int pReturnCount, long infSamplingNumber, IrCameraHandle handle) { return default; }

		private static extern Result GetSilhouetteState([In] [Out] HandAnalysisSilhouetteState[] pOutStateArray, [In] [Out] Float2[][] pOutPointArray, ref int pReturnCount, int maxCount, long infSamplingNumber, IrCameraHandle handle);
		public static extern Result GetImageState(ref HandAnalysisImageState pOutState, [In] [Out] ushort[] pOutImageBuffer, IrCameraHandle handle);
		
		// TODO
		public static Result GetImageState(HandAnalysisImageState[] pOutStateArray, ushort[] pOutImageArray, ref int pReturnCount, long infSamplingNumber, IrCameraHandle handle) { return default; }

		private static extern Result GetImageState([In] [Out] HandAnalysisImageState[] pOutStateArray, [In] [Out] ushort[] pOutImageArray, ref int pReturnCount, int maxCount, long infSamplingNumber, IrCameraHandle handle);
	}
}