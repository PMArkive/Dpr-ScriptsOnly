using nn.account;

namespace nn.fs
{
	public static class SaveData
	{
		// TODO
		public static ErrorRange ResultUsableSpaceNotEnoughForSaveData { get; }

		public static extern Result Ensure(Uid user);
		public static extern Result Mount(string name, Uid user);
		public static extern Result MountSaveDataReadOnly(string name, ulong applicationId, Uid user);
		public static extern bool IsExisting(Uid user);
		public static extern bool IsExisting(ulong applicationId, Uid user);
		
		// TODO
		public static void SetRootPath(string rootPath) { }
		
		// TODO
		public static Result MountForDebug(string name) { return default; }
	}
}