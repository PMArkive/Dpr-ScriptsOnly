namespace nn.hid
{
	public struct ControllerSupportResultInfo
	{
		public byte playerCount;
		public NpadId selectedId;
		private byte _padding0;
		private byte _padding1;
		private byte _padding2;
		
		// TODO
		public override string ToString() { return default; }
	}
}