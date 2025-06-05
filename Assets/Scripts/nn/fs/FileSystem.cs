namespace nn.fs
{
	public static class FileSystem
	{
		public const int MountNameLengthMax = 15;

		public static extern Result GetEntryType(ref EntryType outValue, string path);
		public static extern Result GetFreeSpaceSize(ref long outValue, string path);
		public static extern void Unmount(string name);
		
		// TODO
		public static ErrorRange ResultPathNotFound { get; }
		
		// TODO
		public static ErrorRange ResultPathAlreadyExists { get; }
		
		// TODO
		public static ErrorRange ResultTargetLocked { get; }
		
		// TODO
		public static ErrorRange ResultDirectoryNotEmpty { get; }
		
		// TODO
		public static ErrorRange ResultDirectoryStatusChanged { get; }
		
		// TODO
		public static ErrorRange ResultUsableSpaceNotEnough { get; }
		
		// TODO
		public static ErrorRange ResultUnsupportedSdkVersion { get; }
		
		// TODO
		public static ErrorRange ResultMountNameAlreadyExists { get; }
		
		// TODO
		public static ErrorRange ResultTargetNotFound { get; }

		public static extern Result Commit(string name);
		private static extern Result Commit(string[] name, int nameCount);
		
		// TODO
		public static Result Commit(string[] name) { return default; }
	}
}