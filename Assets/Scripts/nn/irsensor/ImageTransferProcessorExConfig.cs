namespace nn.irsensor
{
	public struct ImageTransferProcessorExConfig
	{
		public IrCameraConfig irCameraConfig;
		public ImageTransferProcessorFormat origFormat;
		public ImageTransferProcessorFormat trimmingFormat;
		public short trimmingStartX;
		public short trimmingStartY;
		public bool isExternalLightFilterEnabled;
	}
}