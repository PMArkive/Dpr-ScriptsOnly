namespace nn.irsensor
{
	public static class ImageProcessor
	{
		public static extern void Stop(IrCameraHandle handle);
		public static extern void StopAsync(IrCameraHandle handle);
		public static extern ImageProcessorStatus GetStatus(IrCameraHandle handle);
	}
}