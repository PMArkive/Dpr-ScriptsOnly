namespace nn.ec
{
	public struct CourseId
	{
		public const int MaxStringLength = 16;

		public string value;
		
		public CourseId(string _value)
		{
			value = _value;
		}
		
		// TODO
		public override string ToString() { return default; }
	}
}