namespace nn.err
{
	public struct ErrorCode
	{
		public uint category;
		public uint number;
		
		// TODO
		public override string ToString() { return default; }
		
		// TODO
		public bool IsValid() { return default; }

		private static extern bool IsValid(ErrorCode errorCode);
		public static extern ErrorCode GetInvalidErrorCode();
	}
}