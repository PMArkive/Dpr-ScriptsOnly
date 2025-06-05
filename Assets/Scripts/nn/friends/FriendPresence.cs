using System.Runtime.InteropServices;
using System.Text;

namespace nn.friends
{
	public struct FriendPresence
	{
		// TODO
		public string GetDescription() { return default; }
		
		// TODO
		public ApplicationInfo GetLastPlayedApplication() { return default; }
		
		// TODO
		public long GetLastUpdatePosixTime() { return default; }
		
		// TODO
		public PresenceStatus GetStatus() { return default; }
		
		// TODO
		public bool IsSamePresenceGroupApplication() { return default; }

		private static extern void GetDescription(FriendPresence pFriendPresence, [In] [Out] StringBuilder description, long size);
		private static extern ApplicationInfo GetLastPlayedApplication(FriendPresence pFriendPresence);
		private static extern long GetLastUpdatePosixTime(FriendPresence pFriendPresence);
		private static extern PresenceStatus GetStatus(FriendPresence pFriendPresence);
		private static extern bool IsSamePresenceGroupApplication(FriendPresence pFriendPresence);
	}
}