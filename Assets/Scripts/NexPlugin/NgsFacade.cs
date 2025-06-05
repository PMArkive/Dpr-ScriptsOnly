using nn;
using nn.account;
using System;
using System.Runtime.InteropServices;

namespace NexPlugin
{
	public static class NgsFacade
	{
		// TODO
		public static bool RegisterNotificationEventHandler(NotificationEventCB callback) { return default; }
		
		// TODO
		public static bool UnregisterNotificationEventHandler(NotificationEventCB callback) { return default; }

		public static extern Result IsConnected(IntPtr pNgsFacade);

		public static extern ulong GetPrincipalID(IntPtr pNgsFacade);
		
		// TODO
		public static bool LoginAsync(out uint asyncId, uint gameServerId, string accessKey, NetworkServiceAccountId nsaId, byte[] nsaIdToken, [Optional] [DefaultParameterValue(30000)] int timeOut, [Optional] LoginCB callback)
        {
            asyncId = default;
            return default;
        }

        // TODO
        public static bool LogoutAsync(out uint asyncId, IntPtr pNgsFacade, [Optional] AsyncResultCB callback)
        {
            asyncId = default;
            return default;
        }

        // TODO
        public static bool TestConnectivityAsync(out uint asyncId, IntPtr pNgsFacade, [Optional] TestConnectivityCB callback)
		{
			asyncId = default;
			return default;
		}

		public delegate void LoginCB(AsyncResult asyncResult, ulong principalId, IntPtr pNgsFacade);
		public delegate void TestConnectivityCB(AsyncResult asyncResult, bool result);
	}
}