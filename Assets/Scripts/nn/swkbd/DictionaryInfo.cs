namespace nn.swkbd
{
	public struct DictionaryInfo
	{
		public uint offset;
		public ushort size;
		public DictionaryLang lang;
		
		// TODO
		public static bool operator ==(DictionaryInfo lhs, DictionaryInfo rhs) { return default; }
		
		// TODO
		public static bool operator !=(DictionaryInfo lhs, DictionaryInfo rhs) { return default; }
		
		// TODO
		public override bool Equals(object right) { return default; }
		
		// TODO
		public bool Equals(DictionaryInfo other) { return default; }
		
		// TODO
		public override int GetHashCode() { return default; }
	}
}