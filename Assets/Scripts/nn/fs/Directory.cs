using System.Runtime.InteropServices;

namespace nn.fs
{
	public static class Directory
	{
		public const int EntryNameLengthMax = 768;

		public static extern Result Read(ref long outValue, [Out] DirectoryEntry[] entryBuffer, DirectoryHandle handle, long entryBufferCount);
		public static extern Result GetEntryCount(ref long outValue, DirectoryHandle handle);
		public static extern void Close(DirectoryHandle handle);
		public static extern Result Create(string path);
		public static extern Result Delete(string path);
		public static extern Result DeleteRecursively(string path);
		public static extern Result CleanRecursively(string path);
		public static extern Result Rename(string currentPath, string newPath);
		public static extern Result Open(ref DirectoryHandle outValue, string path, OpenDirectoryMode mode);
	}
}