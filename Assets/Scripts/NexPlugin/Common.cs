using System;
using System.Runtime.InteropServices;

namespace NexPlugin
{
	public static class Common
	{
		public const ulong INVALID_PRINCIPALID = 0;
		public const ulong INVALID_UNIQUEID = 0;
		public const int DEFAULT_CORE_NO = 1;
		public const uint INFINITE_TIME_INTERVAL = int.MaxValue;

		// TODO
		public static extern bool IsInitializedNex();

		// TODO
		public static extern bool IsNetworkConnected();

		// TODO
		public static extern bool InitializeNexPlugin(uint pluginMemSize);

		// TODO
		public static extern bool FinalizeNexPlugin();
		
		// TODO
		public static bool InitializeNexAsync(out uint asyncId, ThreadMode threadMode, [Optional] AsyncResultCB callback)
		{
			asyncId = default;
			return default;
		}

		// TODO
		public static extern bool InitializeNex(ThreadMode threadMode);
		
		// TODO
		public static bool FinalizeNexAsync(out uint asyncId, [Optional] AsyncResultCB callback)
        {
            asyncId = default;
            return default;
        }

        // TODO
        public static extern bool FinalizeNex();
		
		// TODO
		public static void SetTerminateImmediately(bool bTerminate) { }

		// TODO
		public static extern bool GetTerminateImmediately();

		// TODO
		public static extern bool SetThreadCoreNo(int coreNo);
		
		// TODO
		public static uint Dispatch(uint dispatchTimeout, [Optional] DispachFlag? dispatchFlags) { return default; }
		
		// TODO
		public static void DispatchAll() { }
		
		// TODO
		public static uint GetReadyJobsSize() { return default; }
		
		// TODO
		public static bool UpdateAsyncResult() { return default; }
		
		// TODO
		public static void Wait([Optional] [DefaultParameterValue(0u)] uint dispatchTimeout, [Optional] DispachFlag? dispatchFlags) { }

		// TODO
		public static extern void DumpMemory();
		
		// TODO
		public static int GetNexAsyncCallCount() { return default; }
		
		// TODO
		public static void DumpNexAsyncCallList() { }
		
		// TODO
		public static int GetAllocedCount() { return default; }
		
		// TODO
		public static int GetUsedAllocsize() { return default; }

		[Flags]
		public enum ThreadMode : int
		{
			ThreadModeSafeTransportBuffer = 1,
			ThreadModeUnsafeTransportBuffer = 2,
		}

		[Flags]
		public enum DispachFlag : int
		{
			ContinueWhenEmpty = 1,
			DispatchKeepAliveOnly = 2,
		}

		public enum NotificationEvents : int
		{
			ParticipationEvent = 3,
			OwnershipChangeEvent = 4,
			GatheringUnregistered = 109,
			HostChangeEvent = 110,
			GameNotificationLogout = 111,
			SubscriptionEvent = 112,
			GameServerMaintenance = 113,
			MaintenanceAnnouncement = 114,
			RoundStarted = 116,
			FirstRoundReportReceived = 117,
			RoundSummarized = 118,
			MatchmakeSystemConfigurationNotification = 119,
			MatchmakeSessionSystemPasswordSet = 120,
			MatchmakeSessionSystemPasswordClear = 121,
			AddedToGathering = 122,
			UserStatusUpdatedEvent = 128,
		}

		public enum ParticipationEvents : int
		{
			Participate = 1,
			Disconnect = 7,
			EndParticipation = 8,
		}
	}
}