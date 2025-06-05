namespace nn.fs
{
	public static class Rom
	{
		// TODO
		public static ErrorRange ResultRomHostFileSystemCorrupted { get; }
		
		// TODO
		public static ErrorRange ResultRomHostEntryCorrupted { get; }
		
		// TODO
		public static ErrorRange ResultRomHostFileDataCorrupted { get; }
		
		// TODO
		public static ErrorRange ResultRomHostFileCorrupted { get; }
		
		// TODO
		public static ErrorRange ResultInvalidRomHostHandle { get; }

		public static extern Result QueryMountRomCacheSize(ref long pOutValue);
		public static extern Result MountRom(string name, byte[] pFileSystemCacheBuffer, long fileSystemCacheBufferSize);
		
		// TODO
		public static bool CanMountRomForDebug() { return default; }
	}
}