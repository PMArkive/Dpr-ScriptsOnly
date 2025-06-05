namespace nn
{
	public struct ErrorRange
	{
		private int _module;
		private int _descriptionBegin;
		private int _descriptionEnd;
		
		internal ErrorRange(int Module, int DescriptionBegin, int DescriptionEnd)
		{
			_module = Module;
			_descriptionBegin = DescriptionBegin;
			_descriptionEnd = DescriptionEnd;
		}
		
		public int Module { get => _module; }
		public int DescriptionBegin { get => _descriptionBegin; }
		public int DescriptionEnd { get => _descriptionEnd; }
		
		// TODO
		public bool Includes(Result result) { return default; }
	}
}