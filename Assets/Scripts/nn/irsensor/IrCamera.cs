using nn.hid;

namespace nn.irsensor
{
	public static class IrCamera
	{
		public const int IntensityMax = 255;
		public const int ImageWidth = 320;
		public const int ImageHeight = 240;
		public const int GainMin = 1;
		public const int GainMax = 16;

		public static extern IrCameraHandle GetHandle(NpadId npadId);
		public static extern void Initialize(IrCameraHandle handle);
		public static extern void Finalize(IrCameraHandle handle);
		public static extern IrCameraStatus GetStatus(IrCameraHandle handle);
		public static extern Result CheckFirmwareUpdateNecessity(ref bool pOutIsUpdateNeeded, IrCameraHandle handle);
	}
}