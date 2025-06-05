namespace nn.ec
{
	public struct ConsumableId
	{
		public const int MaxStringLength = 16;

		public string value;
		
		public ConsumableId(string _value)
		{
			value = _value;
		}
		
		// TODO
		public override string ToString() { return default; }
	}
}