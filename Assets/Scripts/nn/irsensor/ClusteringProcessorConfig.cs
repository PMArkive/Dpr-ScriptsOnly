namespace nn.irsensor
{
	public struct ClusteringProcessorConfig
	{
		public IrCameraConfig irCameraConfig;
		public Rect windowOfInterest;
		public int objectPixelCountMin;
		public int objectPixelCountMax;
		public int objectIntensityMin;
		public bool isExternalLightFilterEnabled;
		
		// TODO
		public override string ToString() { return default; }
	}
}