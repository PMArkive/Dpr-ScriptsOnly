using nn.account;
using System.Runtime.InteropServices;

namespace nn.friends
{
	public struct UserPresence
	{
		// TODO
		public Result Initialize(Uid uid) { return default; }
		
		// TODO
		public Result Initialize() { return default; }
		
		// TODO
		public void Clear() { }
		
		// TODO
		public Result Commit() { return default; }
		
		// TODO
		public void DeclareOpenOnlinePlaySession() { }
		
		// TODO
		public void DeclareCloseOnlinePlaySession() { }
		
		// TODO
		public Result SetDescription(string description) { return default; }

		private static extern Result Initialize(ref UserPresence pUserPresence, Uid uid);
		private static extern Result Initialize(ref UserPresence pUserPresence);
		private static extern void Clear(ref UserPresence pUserPresence);
		private static extern Result Commit(ref UserPresence pUserPresence);
		private static extern void DeclareOpenOnlinePlaySession(ref UserPresence pUserPresence);
		private static extern void DeclareCloseOnlinePlaySession(ref UserPresence pUserPresence);
		private static extern Result SetDescription(ref UserPresence pUserPresence, [In] string description);
	}
}