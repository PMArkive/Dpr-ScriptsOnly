namespace nn.fs
{
	public static class AddOnContent
	{
		public static extern Result QueryMountCacheSize(ref long pOutValue, int targetIndex);
		public static extern Result Mount(string name, int targetIndex, byte[] pFileSystemCacheBuffer, long fileSystemCacheBufferSize);
	}
}