using System.Runtime.InteropServices;

namespace nn.account
{
	public static class Account
	{
		public const int UserCountMax = 8;
		public const int ProfileImageBytesMax = 131072;
		public const int SaveDataThumbnailImageBytesMax = 147456;

		public static extern Result GetUserCount(ref int pOutCount);
		public static extern Result GetUserExistence(ref bool pOutExistence, Uid user);
		
		// TODO
		public static Result ListAllUsers(ref int pOutActualLength, Uid[] outUsers) { return default; }

		private static extern Result ListAllUsers(ref int pOutActualLength, [Out] Uid[] outUsers, int arrayLength);
		
		// TODO
		public static Result ListOpenUsers(ref int pOutActualLength, Uid[] outUsers) { return default; }

		private static extern Result ListOpenUsers(ref int pOutActualLength, [Out] Uid[] outUsers, int arrayLength);
		public static extern Result GetLastOpenedUser(ref Uid pOutUser);
		public static extern Result GetNickname(ref Nickname pOut, Uid user);
		
		// TODO
		public static Result LoadProfileImage(ref long pOutActualSize, byte[] outImage, Uid user) { return default; }

		private static extern Result LoadProfileImage(ref long pOutActualSize, byte[] outImage, long bufferSize, Uid user);
		public static extern void Initialize();
		public static extern Result OpenUser(ref UserHandle pOutHandle, Uid user);
		public static extern bool TryOpenPreselectedUser(ref UserHandle pOutHandle);
		public static extern Result ListQualifiedUsers(ref int pOutActualLength, Uid[] outUsers, int arrayLength);
		public static extern void CloseUser(UserHandle handle);
		public static extern Result GetUserId(ref Uid pOut, UserHandle handle);
		
		// TODO
		public static Result StoreSaveDataThumbnailImage(Uid user, byte[] imageBuffer) { return default; }

		private static extern Result StoreSaveDataThumbnailImage(Uid user, byte[] imageBuffer, long imageBufferSize);
		public static extern Result DeleteSaveDataThumbnailImage(Uid user);
		
		// TODO
		public static ErrorRange ResultCancelled { get; }
		
		// TODO
		public static ErrorRange ResultCancelledByUser { get; }
		
		// TODO
		public static ErrorRange ResultUserNotExist { get; }

		public static extern Result ShowUserSelector(ref Uid pOut, UserSelectionSettings arg);
		public static extern Result ShowUserSelector(ref Uid pOut);
		public static extern Result ShowUserCreator();
		
		// TODO
		public static Result ShowUserSelector(ref Uid pOut, UserSelectionSettings arg, bool suspendUnityThreads) { return default; }
		
		// TODO
		public static Result ShowUserSelector(ref Uid pOut, bool suspendUnityThreads) { return default; }
		
		// TODO
		public static Result ShowUserCreator(bool suspendUnityThreads) { return default; }
	}
}