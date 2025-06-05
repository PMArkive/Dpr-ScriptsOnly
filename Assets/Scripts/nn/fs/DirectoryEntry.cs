namespace nn.fs
{
	public struct DirectoryEntry
	{
		public string name;
		private byte _reserved0;
		private byte _reserved1;
		private byte _reserved2;
		private sbyte _entryType;
		private byte _reserved3;
		private byte _reserved4;
		private byte _reserved5;
		private long fileSize;
		
		public EntryType entryType { get => (EntryType)_entryType; set => _entryType = (sbyte)value; }
		
		// TODO
		public override string ToString() { return default; }
	}
}