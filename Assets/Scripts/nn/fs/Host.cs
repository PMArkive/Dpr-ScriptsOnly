namespace nn.fs
{
	public static class Host
	{
		// TODO
		public static Result MountHost(string name, string rootPath) { return default; }
		
		// TODO
		public static Result MountHost(string name, string rootPath, MountHostOption option) { return default; }
		
		// TODO
		public static Result MountHostRoot() { return default; }
		
		// TODO
		public static Result MountHostRoot(MountHostOption option) { return default; }
		
		// TODO
		public static void UnMountHostRoot() { }
		
		// TODO
		public static ErrorRange ResultSaveDataHostFileSystemCorrupted { get; }
		
		// TODO
		public static ErrorRange ResultSaveDataHostEntryCorrupted { get; }
		
		// TODO
		public static ErrorRange ResultSaveDataHostFileDataCorrupted { get; }
		
		// TODO
		public static ErrorRange ResultSaveDataHostFileCorrupted { get; }
		
		// TODO
		public static ErrorRange ResultInvalidSaveDataHostHandle { get; }
		
		// TODO
		public static ErrorRange ResultHostFileSystemCorrupted { get; }
		
		// TODO
		public static ErrorRange ResultHostEntryCorrupted { get; }
		
		// TODO
		public static ErrorRange ResultHostFileDataCorrupted { get; }
		
		// TODO
		public static ErrorRange ResultHostFileCorrupted { get; }
		
		// TODO
		public static ErrorRange ResultInvalidHostHandle { get; }

		public enum MountHostOptionFlag : int
		{
			PseudoCaseSensitive = 1,
		}

		public struct MountHostOption
		{
			public int flags;
			
			// TODO
			public static MountHostOption MakeValue(int flags) { return default; }
		}
	}
}