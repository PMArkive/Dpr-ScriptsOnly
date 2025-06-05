using System.Runtime.InteropServices;

namespace nn.irsensor
{
	public static class ClusteringProcessor
	{
		public const int StateCountMax = 5;
		public const int ObjectCountMax = 16;
		public const int ObjectPixelCountMax = 76800;
		public const int OutObjectPixelCountMax = 65535;
		public const long ExposureTimeMinNanoSeconds = 7000;
		public const long ExposureTimeMaxNanoSeconds = 600000;

		public static extern void GetDefaultConfig(ref ClusteringProcessorConfig pOutValue);
		public static extern void Run(IrCameraHandle handle, ClusteringProcessorConfig config);
		public static extern Result GetState(ref ClusteringProcessorState pOutValue, IrCameraHandle handle);
		public static extern Result GetStates([Out] ClusteringProcessorState[] pOutStates, ref int pOutCount, int countMax, IrCameraHandle handle);
	}
}