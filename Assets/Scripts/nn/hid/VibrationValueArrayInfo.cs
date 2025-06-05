namespace nn.hid
{
	public struct VibrationValueArrayInfo
	{
		public int sampleLength;
		public bool isLoop;
		public uint loopStartPosition;
		public uint loopEndPosition;
		public uint loopInterval;
		
		// TODO
		public override string ToString() { return default; }
	}
}