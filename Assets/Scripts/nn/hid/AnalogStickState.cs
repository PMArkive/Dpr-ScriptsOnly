namespace nn.hid
{
	public struct AnalogStickState
	{
		public const int Max = 32767;

		public int x;
		public int y;
		
		public float fx { get => (float)x / Max; }
		public float fy { get => (float)y / Max; }
		
		public void Clear()
		{
			x = 0;
			y = 0;
		}
		
		// TODO
		public override string ToString() { return default; }
	}
}