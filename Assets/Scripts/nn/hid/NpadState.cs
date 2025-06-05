namespace nn.hid
{
	public struct NpadState
	{
		public long samplingNumber;
		public NpadButton buttons;
		public AnalogStickState analogStickL;
		public AnalogStickState analogStickR;
		public NpadAttribute attributes;
		public NpadButton preButtons;
		
		// TODO
		public void Clear() { }
		
		// TODO
		public bool GetButton(NpadButton button) { return default; }
		
		// TODO
		public bool GetButtonDown(NpadButton button) { return default; }
		
		// TODO
		public bool GetButtonUp(NpadButton button) { return default; }
		
		// TODO
		public override string ToString() { return default; }
	}
}