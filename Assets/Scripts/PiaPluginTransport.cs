using System;
using System.Runtime.InteropServices;

public class PiaPluginTransport
{
	public const int PacketAnalysisDataEntriesMax = 128;
	public const int PacketAnalysisDataNameLengthMax = 32;
	public const int ConnectionAnalysisDataEntriesMax = 32;
	public const uint ThroughputLimitMax = 268435455;

	// TODO
	private static extern PiaPlugin.Result SetEmulationSettingNative([In] EmulationSetting setting);
	
	// TODO
	public static PiaPlugin.Result SetEmulationSetting(EmulationSetting setting) { return default; }

	// TODO
	private static extern PiaPlugin.Result UpdateTransportAnalyzerNative();
	
	// TODO
	public static PiaPlugin.Result UpdateTransportAnalyzer() { return default; }

	// TODO
	private static extern TransportAnalysisData GetTransportAnalysisDataNative();
	
	// TODO
	public static TransportAnalysisData GetTransportAnalysisDataOld() { return default; }

	// TODO
	private static extern void GetTransportAnalysisDataNative2(IntPtr transportAnalysisData);
	
	// TODO
	public static TransportAnalysisData GetTransportAnalysisData() { return default; }

	public class EmulationSetting
	{
		public int sendThreadPacketLossRatio;
		public int receiveThreadPacketLossRatio;
		public int sendThreadLatencyEmulationMin;
		public int sendThreadLatencyEmulationMax;
		public int receiveThreadLatencyEmulationMin;
		public int receiveThreadLatencyEmulationMax;
		
		public EmulationSetting()
		{
			sendThreadLatencyEmulationMin = -1;
			sendThreadLatencyEmulationMax = -1;
			receiveThreadLatencyEmulationMin = -1;
			receiveThreadLatencyEmulationMax = -1;
			sendThreadPacketLossRatio = -1;
			receiveThreadPacketLossRatio = -1;
		}
	}

	public struct TransportAnalysisData
	{
		public PacketAnalysisData sendPacketAnalysisData;
		public PacketAnalysisData sendUnicastPacketAnalysisData;
		public PacketAnalysisData sendBroadcastPacketAnalysisData;
		public PacketAnalysisData recvPacketAnalysisData;
		public ConnectionAnalysisData connectionAnalysisData;
		public uint dispatchCount;

		// TODO
		private static extern void PrintNative([In] IntPtr data, bool isDetail, bool isTotalOnly);
		
		// TODO
		public void Print(bool isDetail, bool isTotalOnly) { }
	}

	public struct ConnectionAnalysisData
	{
		public Entry[] entry;
		public uint passedMilliSec;

		// TODO
		private static extern void PrintNative2([In] IntPtr connectionAnalysisData);
		
		// TODO
		public void Print() { }

        public struct Entry
		{
			public int rtt;
			public int rttMin;
			public int rttMax;
			public uint prevTotalUnicastPacketNum;
			public uint currTotalUnicastPacketNum;
			public uint prevUnicastPacketLossNum;
			public uint currUnicastPacketLossNum;
			public uint prevTotalBroadcastPacketNum;
			public uint currTotalBroadcastPacketNum;
			public uint prevBroadcastPacketLossNum;
			public uint currBroadcastPacketLossNum;
			public bool isValid;
		}
	}

	public struct ProtocolId
	{
		public uint value;
	}

	public struct PacketAnalysisData
	{
		public Entry[] entry;
		public int nowEntryNum;
		public int passedMilliSec;
		public string name;
		public int totalPacketNum;
		public int totalPacketSize;
		public int sumTotalPacketNum;
		public long sumTotalPacketSize;

		// TODO
		private static extern void PrintNative3([In] IntPtr packetAnalysisData, bool isDetail);
		
		// TODO
		public void Print(bool isDetail) { }

        public struct Entry
		{
			public ProtocolId protocolId;
			public uint totalNum;
			public uint totalDataSize;
			public uint sumTotalNum;
			public ulong sumTotalDataSize;
		}
	}

	public class Unreliable
	{
		// TODO
		private static extern uint GetSendUnreliableDataSizeMaxNative();
		
		// TODO
		public static uint GetSendUnreliableDataSizeMax() { return default; }

		// TODO
		private static extern PiaPlugin.Result SendToAllUnreliableNative(ushort port, IntPtr pData, uint dataSize);
		
		// TODO
		public static PiaPlugin.Result SendToAll(ushort port, byte[] data, uint dataSize) { return default; }

		// TODO
		private static extern PiaPlugin.Result SendUnreliableNative(ushort port, ulong destConstantId, IntPtr pData, uint dataSize);
		
		// TODO
		public static PiaPlugin.Result Send(ushort port, ulong destConstantId, byte[] data, uint dataSize) { return default; }

		// TODO
		private static extern PiaPlugin.Result ReceiveUnreliableNative(ushort port, out ulong srcConstantId, IntPtr pRecvBuf, out uint recvDataSize, uint recvBufSize);
		
		// TODO
		public static PiaPlugin.Result Receive(ushort port, out ulong srcConstantId, byte[] recvBuf, out uint recvDataSize)
		{
			srcConstantId = default;
			recvDataSize = default;
			return default;
		}
	}

	public class Reliable
	{
		// TODO
		private static extern PiaPlugin.Result SendReliableNative(ushort port, ulong destConstantId, IntPtr pData, uint dataSize);
		
		// TODO
		public static PiaPlugin.Result Send(ushort port, ulong destConstantId, byte[] data, uint dataSize) { return default; }

		// TODO
		private static extern PiaPlugin.Result ReceiveReliableNative(ushort port, out ulong srcConstantId, IntPtr pRecvBuf, out uint recvDataSize, uint recvBufSize);
		
		// TODO
		public static PiaPlugin.Result Receive(ushort port, out ulong srcConstantId, byte[] recvBuf, out uint recvDataSize)
		{
            srcConstantId = default;
            recvDataSize = default;
            return default;
        }

		// TODO
		private static extern void SetReliableThroughputLimitNative(ushort port, uint throughputLimit);
		
		// TODO
		public static void SetThroughputLimit(ushort port, uint throughputLimit) { }

		// TODO
		private static extern PiaPlugin.Result ReadySendReliableNative(ushort port, ulong destConstantId, uint dataSize);
		
		// TODO
		public static PiaPlugin.Result ReadySend(ushort port, ulong destConstantId, uint dataSize) { return default; }

		// TODO
		private static extern PiaPlugin.Result ReadyReceiveReliableNative(ushort port);
		
		// TODO
		public static PiaPlugin.Result ReadyReceive(ushort port) { return default; }
	}

	public class BroadcastReliable
	{
		// TODO
		private static extern PiaPlugin.Result SendBroadcastReliableNative(ushort port, ulong destConstantId, IntPtr pData, uint dataSize);
		
		// TODO
		public static PiaPlugin.Result Send(ushort port, ulong destConstantId, byte[] data, uint dataSize) { return default; }

		// TODO
		private static extern PiaPlugin.Result SendToAllBroadcastReliableNative(ushort port, IntPtr pData, uint dataSize);
		
		// TODO
		public static PiaPlugin.Result SendToAll(ushort port, byte[] data, uint dataSize) { return default; }

		// TODO
		private static extern PiaPlugin.Result ReceiveBroadcastReliableNative(ushort port, out ulong srcConstantId, IntPtr pRecvBuf, out uint recvDataSize, uint recvBufSize);
		
		// TODO
		public static PiaPlugin.Result Receive(ushort port, out ulong srcConstantId, byte[] recvBuf, out uint recvDataSize)
        {
            srcConstantId = default;
            recvDataSize = default;
            return default;
        }

        // TODO
        private static extern void SetBroadcastReliableThroughputLimitNative(ushort port, uint throughputLimit);
		
		// TODO
		public static void SetThroughputLimit(ushort port, uint throughputLimit) { }

		// TODO
		private static extern PiaPlugin.Result ReadySendBroadcastReliableNative(ushort port, ulong destConstantId, uint dataSize);
		
		// TODO
		public static PiaPlugin.Result ReadySend(ushort port, ulong destConstantId, uint dataSize) { return default; }

		// TODO
		private static extern PiaPlugin.Result ReadySendToAllBroadcastReliableNative(ushort port, uint dataSize);
		
		// TODO
		public static PiaPlugin.Result ReadySendToAll(ushort port, uint dataSize) { return default; }

		// TODO
		private static extern PiaPlugin.Result ReadyReceiveBroadcastReliableNative(ushort port);
		
		// TODO
		public static PiaPlugin.Result ReadyReceive(ushort port) { return default; }
	}

	public class StreamBroadcastReliable
	{
		// TODO
		private static extern PiaPlugin.Result Stream_RequestNative(ushort port, ulong destinationConstantId, IntPtr pBuffer, uint bufferSize, byte id);
		
		// TODO
		public static PiaPlugin.Result Request(ushort port, ulong destinationConstantId, byte[] pBuffer, byte id) { return default; }

		// TODO
		private static extern bool Stream_IsRequestedNative(ushort port, ulong constantId, byte id);
		
		// TODO
		public static bool IsRequested(ushort port, ulong constantId, byte id) { return default; }

		// TODO
		private static extern PiaPlugin.Result Stream_StartSendNative(ushort port, IntPtr cpData, uint dataSize, byte id);
		
		// TODO
		public static PiaPlugin.Result StartSend(ushort port, byte[] data, uint dataSize, byte id) { return default; }

		// TODO
		private static extern PiaPlugin.Result Stream_CancelNative(ushort port);
		
		// TODO
		public static PiaPlugin.Result Cancel(ushort port) { return default; }

		// TODO
		private static extern State Stream_GetStateNative(ushort port);
		
		// TODO
		public static State GetState(ushort port) { return default; }

		// TODO
		private static extern bool Stream_IsRunningNative(ushort port);
		
		// TODO
		public static bool IsRunning(ushort port) { return default; }

		// TODO
		private static extern byte Stream_GetProgressNative(ushort port);
		
		// TODO
		public static byte GetProgress(ushort port) { return default; }

		// TODO
		private static extern void Stream_SetThroughputLimitNative(ushort port, uint throughputLimit);
		
		// TODO
		public static void SetThroughputLimit(ushort port, uint throughputLimit) { }

		// TODO
		private static extern PiaPlugin.Result Stream_ReadyRequestNative(ushort port, ulong destinationConstantId);
		
		// TODO
		public static PiaPlugin.Result ReadyRequest(ushort port, ulong destinationConstantId) { return default; }

		// TODO
		private static extern PiaPlugin.Result Stream_ReadyStartSendNative(ushort port);
		
		// TODO
		public static PiaPlugin.Result ReadyStartSend(ushort port) { return default; }

        public enum State : int
		{
			None = 0,
			Sending = 1,
			WaitingSendAck = 2,
			SendSuccess = 3,
			WaitingReceive = 4,
			Receiving = 5,
			ReceiveSuccess = 6,
			RequestFailure = 7,
			CancelingSend = 8,
			CancelingRequest = 9,
			WaitingCancelAck = 10,
			CancelSuccess = 11,
			Failure = 12,
		}
	}
}