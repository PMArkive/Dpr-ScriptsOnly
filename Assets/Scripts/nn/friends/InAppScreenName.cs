namespace nn.friends
{
	public struct InAppScreenName
	{
		private byte[] name;
		private char[] language;
		
		public InAppScreenName(string name, string language = "")
		{
			this.name = new byte[64];
			this.language = new char[8];

			Name = name;
			Language = language;
		}
		
		// TODO
		public string Name { get; set; }
		
		// TODO
		public string Language { get; set; }
		
		// TODO
		public override string ToString() { return default; }
	}
}