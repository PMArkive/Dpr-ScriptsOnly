namespace nn.hid
{
	public struct ControllerFirmwareUpdateArg
	{
		public bool enableForceUpdate;
		private byte _padding0;
		private byte _padding1;
		private byte _padding2;
		
		// TODO
		public void SetDefault() { }
	}
}