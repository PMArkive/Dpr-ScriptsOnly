namespace nn.fs
{
	public static class File
	{
		public static extern Result Read(FileHandle handle, long offset, byte[] buffer, long size, ReadOption option);
		public static extern Result Read(FileHandle handle, long offset, byte[] buffer, long size);
		public static extern Result Read(ref long outValue, FileHandle handle, long offset, byte[] buffer, long size, ReadOption option);
		public static extern Result Read(ref long outValue, FileHandle handle, long offset, byte[] buffer, long size);
		public static extern Result Write(FileHandle handle, long offset, byte[] buffer, long size, WriteOption option);
		public static extern Result Flush(FileHandle handle);
		public static extern Result SetSize(FileHandle handle, long size);
		public static extern Result GetSize(ref long outValue, FileHandle handle);
		public static extern OpenFileMode GetOpenMode(FileHandle handle);
		public static extern void Close(FileHandle handle);
		public static extern Result Create(string path, long size);
		public static extern Result Delete(string path);
		public static extern Result Rename(string currentPath, string newPath);
		public static extern Result Open(ref FileHandle outValue, string path, OpenFileMode mode);
	}
}