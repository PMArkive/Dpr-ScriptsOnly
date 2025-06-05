using nn.account;
using System.Runtime.InteropServices;

namespace nn.friends
{
	public struct Friend
	{
		// TODO
		public NetworkServiceAccountId GetAccountId() { return default; }
		
		// TODO
		public Nickname GetNickname() { return default; }
		
		// TODO
		public FriendPresence GetPresence() { return default; }
		
		// TODO
		public Result GetProfileImage(ref long outSize, byte[] buffer) { return default; }
		
		// TODO
		public bool IsFavorite() { return default; }
		
		// TODO
		public bool IsNewly() { return default; }
		
		// TODO
		public bool IsValid() { return default; }
		
		// TODO
		public Result Update() { return default; }

		private static extern NetworkServiceAccountId GetAccountId(Friend friend);
		private static extern Nickname GetNickname(Friend friend);
		private static extern void GetPresence(Friend friend, ref FriendPresence outPresence);
		private static extern Result GetProfileImage(Friend friend, ref long outSize, [In] [Out] byte[] outBuffer, long size);
		private static extern bool IsFavorite(Friend friend);
		private static extern bool IsNewly(Friend friend);
		private static extern bool IsValid(Friend friend);
		private static extern Result Update(ref Friend pFriend);
	}
}