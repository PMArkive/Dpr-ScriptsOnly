using System;

public class PiaPluginClone
{
	public class BroadcastEvent
	{
		// TODO
		private static extern uint GetPayloadSizeMaxNative(ushort port);
		
		// TODO
		public static uint GetPayloadSizeMax(ushort port) { return default; }

		// TODO
		private static extern State GetEventStateStationNative(ushort port, ulong constantId);
		
		// TODO
		public static State GetEventState(ushort port, ulong constantId) { return default; }

		// TODO
		private static extern bool IsInCommunicationNative(ushort port, ulong constantId);
		
		// TODO
		public static bool IsInCommunication(ushort port, ulong constantId) { return default; }

		// TODO
		private static extern bool IsSynchronizingNative(ushort port);
		
		// TODO
		public static bool IsSynchronizing(ushort port) { return default; }

		// TODO
		private static extern PiaPlugin.Result ReceiveNative(ushort port, out ulong srcConstantId, IntPtr pRecvBuf, out uint recvDataSize, uint recvBufSize);
		
		// TODO
		public static PiaPlugin.Result Receive(ushort port, out ulong srcConstantId, byte[] recvBuf, out uint recvDataSize)
		{
			srcConstantId = default;
			recvDataSize = default;
			return default;
		}

		// TODO
		private static extern PiaPlugin.Result SendNative(ushort port, IntPtr pData, uint dataSize);
		
		// TODO
		public static PiaPlugin.Result Send(ushort port, byte[] data, uint dataSize) { return default; }

		// TODO
		private static extern PiaPlugin.Result ReadySendNative(ushort port, uint dataSize);
		
		// TODO
		public static PiaPlugin.Result ReadySend(ushort port, uint dataSize) { return default; }

		// TODO
		private static extern PiaPlugin.Result ReadyReceiveNative(ushort port, uint dataSize);
		
		// TODO
		public static PiaPlugin.Result ReadyReceive(ushort port, uint dataSize) { return default; }

		// TODO
		private static extern void SetThroughputLimitNative(ushort port, uint throughputLimit);
		
		// TODO
		public static void SetThroughputLimit(ushort port, uint throughputLimit) { }

        public enum State : int
		{
			NotSynchronized = 0,
			Synchronizing = 1,
		}
	}

	public class Atomic
	{
		// TODO
		private static extern void TryLockNative(uint id, uint priority);
		
		// TODO
		public static void TryLock(uint id, uint priority) { }

		// TODO
		private static extern void UnlockNative(uint id);
		
		// TODO
		public static void Unlock(uint id) { }

		// TODO
		private static extern LockStatus GetLockStatusNative(uint id);
		
		// TODO
		public static LockStatus GetLockStatus(uint id) { return default; }

        public enum LockStatus : int
		{
			LockStatus_Unlocked = 0,
			LockStatus_TryLock = 1,
			LockStatus_Locked = 2,
		}
	}

	public class Clock
	{
		public const ulong InvalidClock = 18446744073709551615;

		// TODO
		private static extern PiaPlugin.Result GetClockNative(ref ulong pClock);
		
		// TODO
		public static PiaPlugin.Result GetClock(ref ulong pClock) { return default; }

		// TODO
		private static extern bool IsSynchronizingClockNative();
		
		// TODO
		public static bool IsSynchronizingClock() { return default; }

		// TODO
		private static extern PiaPlugin.Result SynchronizeClockNative();
		
		// TODO
		public static PiaPlugin.Result SynchronizeClock() { return default; }

		// TODO
		private static extern void UpdateClockNative(ulong elapsedTime, ulong increaseTimeMin, ulong increaseTimeMax);
		
		// TODO
		public static void UpdateClock(ulong elapsedTime, ulong increaseTimeMin, ulong increaseTimeMax) { }
	}
}