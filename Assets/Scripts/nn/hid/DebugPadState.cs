namespace nn.hid
{
	public struct DebugPadState
	{
		public long samplingNumber;
		public DebugPadAttribute attributes;
		public DebugPadButton buttons;
		public AnalogStickState analogStickR;
		public AnalogStickState analogStickL;
		
		// TODO
		public override string ToString() { return default; }
	}
}