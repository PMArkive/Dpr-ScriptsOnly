namespace nn.hid
{
	public struct VibrationValue
	{
		public const int FrequencyLowDefault = 160;
		public const int FrequencyHighDefault = 320;

		public float amplitudeLow;
		public float frequencyLow;
		public float amplitudeHigh;
		public float frequencyHigh;
		
		// TODO
		public static VibrationValue Make() { return default; }
		
		// TODO
		public static VibrationValue Make(float amplitudeLow, float frequencyLow, float amplitudeHigh, float frequencyHigh) { return default; }
		
		public VibrationValue(float amplitudeLow, float frequencyLow, float amplitudeHigh, float frequencyHigh)
		{
			this.amplitudeLow = amplitudeLow;
			this.frequencyLow = frequencyLow;
			this.amplitudeHigh = amplitudeHigh;
			this.frequencyHigh = frequencyHigh;
		}
		
		// TODO
		public void Set(float amplitudeLow, float frequencyLow, float amplitudeHigh, float frequencyHigh) { }
		
		// TODO
		public void Clear() { }
		
		// TODO
		public override string ToString() { return default; }
	}
}