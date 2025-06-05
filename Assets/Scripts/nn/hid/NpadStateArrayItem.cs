namespace nn.hid
{
	public struct NpadStateArrayItem
	{
		public long samplingNumber;
		public NpadButton buttons;
		public AnalogStickState analogStickL;
		public AnalogStickState analogStickR;
		public NpadAttribute attributes;
		
		// TODO
		public override string ToString() { return default; }
	}
}