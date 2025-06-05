using nn.account;
using System;
using System.Runtime.InteropServices;

namespace nn.friends
{
	public static class Friends
	{
		public const int FriendCountMax = 300;
		public const int BlockedUserCountMax = 100;
		public const long PresenceAppFieldSize = 192;
		public const int InAppScreenNameLengthMax = 20;
		public const int GetProfileCountMax = 100;
		public const long ProfileImageSizeMax = 131072;
		public const int NotificationCountMax = 100;
		public const int FriendInvitationInviteeCountMax = 16;
		public const long FriendInvitationApplicationParameterSizeMax = 1024;

		public static extern void Initialize();
		
		// TODO
		public static Result GetFriendList(ref int outCount, NetworkServiceAccountId[] outAccountIds, Uid uid, int offset, FriendFilter filter) { return default; }

		private static extern Result GetFriendList(ref int outCount, [In] [Out] NetworkServiceAccountId[] outAccountIds, Uid uid, int offset, int count, FriendFilter filter);
		
		// TODO
		public static Result GetFriendList(ref int outCount, NetworkServiceAccountId[] outAccountIds, int offset, FriendFilter filter) { return default; }

		private static extern Result GetFriendList(ref int outCount, [In] [Out] NetworkServiceAccountId[] outAccountIds, int offset, int count, FriendFilter filter);
		
		// TODO
		public static Result GetFriendList(ref int outCount, Friend[] outFriends, Uid uid, int offset, FriendFilter filter) { return default; }

		private static extern Result GetFriendList(ref int outCount, [In] [Out] Friend[] outFriends, Uid uid, int offset, int count, FriendFilter filter);
		
		// TODO
		public static Result GetFriendList(ref int outCount, Friend[] outFriends, int offset, FriendFilter filter) { return default; }

		private static extern Result GetFriendList(ref int outCount, [In] [Out] Friend[] outFriends, int offset, int count, FriendFilter filter);
		
		// TODO
		public static Result UpdateFriendInfo(Friend[] outFriends, Uid uid, NetworkServiceAccountId[] accountIds) { return default; }

		private static extern Result UpdateFriendInfo([In] [Out] Friend[] outFriends, Uid uid, [In] NetworkServiceAccountId[] accountIds, int count);
		
		// TODO
		public static Result UpdateFriendInfo(Friend[] outFriends, NetworkServiceAccountId[] accountIds) { return default; }

		private static extern Result UpdateFriendInfo([In] [Out] Friend[] outFriends, NetworkServiceAccountId[] accountIds, int count);
		
		// TODO
		public static Result EnsureFriendListAvailable(AsyncContext outAsync, Uid uid) { return default; }

		public static extern Result CheckFriendListAvailability(ref bool outIsAvailable, Uid uid);
		public static extern Result CheckFriendListAvailability(ref bool outIsAvailable);
		private static extern Result EnsureFriendListAvailable(IntPtr outAsync, Uid uid);
		
		// TODO
		public static Result EnsureFriendListAvailable(AsyncContext outAsync) { return default; }

		private static extern Result EnsureFriendListAvailable(IntPtr outAsync);
		
		// TODO
		public static Result GetBlockedUserList(ref int outCount, NetworkServiceAccountId[] outAccountIds, Uid uid, int offset) { return default; }

		private static extern Result GetBlockedUserList(ref int outCount, [In] [Out] NetworkServiceAccountId[] outAccountIds, Uid uid, int offset, int count);
		
		// TODO
		public static Result GetBlockedUserList(ref int outCount, NetworkServiceAccountId[] outAccountIds, int offset) { return default; }

		private static extern Result GetBlockedUserList(ref int outCount, [In] [Out] NetworkServiceAccountId[] outAccountIds, int offset, int count);
		
		// TODO
		public static Result GetProfileList(AsyncContext outAsync, Profile[] outProfiles, Uid uid, NetworkServiceAccountId[] accountIds) { return default; }

		public static extern Result CheckBlockedUserListAvailability(ref bool outIsAvailable, Uid uid);
		public static extern Result CheckBlockedUserListAvailability(ref bool outIsAvailable);
		
		// TODO
		public static Result EnsureBlockedUserListAvailable(AsyncContext outAsync, Uid uid) { return default; }

		private static extern Result EnsureBlockedUserListAvailable(IntPtr outAsync, Uid uid);
		
		// TODO
		public static Result EnsureBlockedUserListAvailable(AsyncContext outAsync) { return default; }

		private static extern Result EnsureBlockedUserListAvailable(IntPtr outAsync);
		private static extern Result GetProfileList(IntPtr outAsync, [In] [Out] Profile[] outProfiles, Uid uid, [In] NetworkServiceAccountId[] accountIds, int count);
		
		// TODO
		public static Result GetProfileList(AsyncContext outAsync, Profile[] outProfiles, NetworkServiceAccountId[] accountIds) { return default; }

		private static extern Result GetProfileList(IntPtr outAsync, [In] [Out] Profile[] outProfiles, [In] NetworkServiceAccountId[] accountIds, int count);
		public static extern Result DeclareOpenOnlinePlaySession(Uid uid);
		public static extern Result DeclareOpenOnlinePlaySession();
		public static extern Result DeclareCloseOnlinePlaySession(Uid uid);
		public static extern Result DeclareCloseOnlinePlaySession();
		public static extern Result GetPlayHistoryRegistrationKey(ref PlayHistoryRegistrationKey outKey, Uid uid, bool isLocalPlay);
		public static extern Result GetPlayHistoryRegistrationKey(ref PlayHistoryRegistrationKey outKey, bool isLocalPlay);
		public static extern Result AddPlayHistory(Uid uid, PlayHistoryRegistrationKey key, InAppScreenName inAppScreenName, InAppScreenName myInAppScreenName);
		public static extern Result AddPlayHistory(PlayHistoryRegistrationKey key, InAppScreenName inAppScreenName, InAppScreenName myInAppScreenName);
		
		// TODO
		public static bool TryPopFriendInvitationNotificationInfo(ref Uid pOutUid, ref long pOutSize, byte[] pOutBuffer) { return default; }

		private static extern bool TryPopFriendInvitationNotificationInfo(ref Uid pOutUid, ref long pOutSize, [In] [Out] byte[] pOutBuffer, long bufferSize);
		public static extern Result ShowFriendList(Uid uid);
		public static extern Result ShowUserDetailInfo(Uid uid, NetworkServiceAccountId accountId, InAppScreenName myInAppScreenName, InAppScreenName inAppScreenName);
		public static extern Result StartSendingFriendRequest(Uid uid, NetworkServiceAccountId accountId, InAppScreenName myInAppScreenName, InAppScreenName inAppScreenName);
		public static extern Result ShowMethodsOfSendingFriendRequest(Uid uid);
		public static extern Result StartFacedFriendRequest(Uid uid);
		public static extern Result ShowReceivedFriendRequestList(Uid uid);
		public static extern Result ShowBlockedUserList(Uid uid);
		
		// TODO
		public static Result StartFriendInvitation(Uid uid, int maxInviteeCount, FriendInvitationGameModeDescription description, byte[] pAppParameter) { return default; }

		private static extern Result StartFriendInvitation(Uid uid, int maxInviteeCount, FriendInvitationGameModeDescription description, [In] byte[] pAppParameter, long appParameterSize);
		
		// TODO
		public static Result StartSendingFriendInvitation(Uid uid, NetworkServiceAccountId[] pInvitees, FriendInvitationGameModeDescription description, byte[] pAppParameter) { return default; }

		private static extern Result StartSendingFriendInvitation(Uid uid, [In] NetworkServiceAccountId[] pInvitees, int inviteeCount, FriendInvitationGameModeDescription description, [In] byte[] pAppParameter, long appParameterSize);
		
		// TODO
		public static ErrorRange ResultNotInitialized { get; }
		
		// TODO
		public static ErrorRange ResultInvalidArgument { get; }
		
		// TODO
		public static ErrorRange ResultUserNotOpened { get; }
		
		// TODO
		public static ErrorRange ResultNetworkServiceAccountNotLinked { get; }
		
		// TODO
		public static ErrorRange ResultOwnNetworkServiceAccountSpecified { get; }
		
		// TODO
		public static ErrorRange ResultInternetRequestNotAccepted { get; }
		
		// TODO
		public static ErrorRange ResultNotCalled { get; }
		
		// TODO
		public static ErrorRange ResultCallInProgress { get; }
		
		// TODO
		public static ErrorRange ResultCanceled { get; }
		
		// TODO
		public static ErrorRange ResultProfileImageCacheNotFound { get; }
		
		// TODO
		public static ErrorRange ResultOutOfMemory { get; }
		
		// TODO
		public static ErrorRange ResultOutOfResource { get; }
		
		// TODO
		public static ErrorRange ResultReservedKey { get; }
		
		// TODO
		public static ErrorRange ResultDuplicatedKey { get; }
		
		// TODO
		public static ErrorRange ResultNotificationNotFound { get; }
		
		// TODO
		public static ErrorRange ResultPlayHistoryRegistrationKeyBroken { get; }
		
		// TODO
		public static ErrorRange ResultOwnPlayHistoryRegistrationKey { get; }
		
		// TODO
		public static ErrorRange ResultAppletCanceled { get; }
		
		// TODO
		public static ErrorRange ResultApplicationInfoNotRegistered { get; }
		
		// TODO
		public static ErrorRange ResultNotPermitted { get; }
		
		// TODO
		public static ErrorRange ResultInvalidOperation { get; }
		
		// TODO
		public static ErrorRange ResultNotImplemented { get; }
		
		// TODO
		public static ErrorRange ResultResponseFormatError { get; }
		
		// TODO
		public static ErrorRange ResultHttpError { get; }
		
		// TODO
		public static ErrorRange ResultServerError { get; }
	}
}