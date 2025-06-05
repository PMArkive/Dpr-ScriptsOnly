using nn.account;
using System;

namespace INL1
{
	[Serializable]
	public class IlcaNetSessionSetting
	{
		public Uid playerId;
		public UserHandle userHandle;
		public string playerName = "ぷれいや～・3";
		public byte nameStringLanguage = 1;
		public IlcaNetSessionNetworkType networkType;
		public IlcaNetSessionInitMode matchingMode = IlcaNetSessionInitMode.Random;
		public ushort gameMode = 11451;
		public string matchmakeKeyword;
		public bool attributeValueEnable;

		public const int attributeMax = 6;

		public uint[] createSessionAttributeValue = new uint[attributeMax];
		public uint[] searchSessionAttributeValueMin = new uint[attributeMax];
        public uint[] searchSessionAttributeValueMax = new uint[attributeMax];

        public bool bSetOpenedOnly = true;
		public bool bSetVacantOnly = true;
        public ushort playerNumMax = 8;
		public bool bAutoSessionClose = true;
        public bool bAutoSessionOpen = true;
        public bool bOpenSession = true;
        public bool playerNumFreeSearchLocalOnly = true;
        public IlcaNetSessionCallbackLastEventLeave lastEventLeave = IlcaNetSessionCallbackLastEventLeave.NoLastCall;
		public IlcaNetSessionAutoRetryMode autoRetryMode;
		public int autoRetryRandomMatchmakeMaxNum = 1;
		public int autoRetryRandomMatchmakeMaxNumAddLocal = 50;
		public uint localRandomMatchmakeTimeUp = 270;
		public uint localRandomMatchmakeHostWaitTime = 25;
		public ushort localRandomMatchmakeHostWaitTimeMask = 0x7F;
		public uint searchSessionPropertyMax = 10;
		public IlcaNetSessionGamingStartMode gamingStartMode;
		public IlcaNetSessionPacketBundlingMode packetBundlingMode;

		public const int IlcaNetApplicationDataSystemBufferSizeMax = 360;

		public byte[] applicationData = new byte[1];
		public byte[] cryptoKeyDataSeed = new byte[] { 153, 24, 189, 15, 220, 250, 101, 119, 153, 24, 189, 15, 220, 250, 101, 119 };
		public string wirelessCryptoKey = "WirelessStrongCryptoKey2021";
		public ulong localCommunicationId = 0x100000011d90000;
		public ushort stationNumMax = 8;
		public bool isAnalysisResultPrintEnabled;
		public int measurementInterval;
		public ushort sendProtocolBufferNumPerStation = 0x40;
		public ushort receiveProtocolBufferNumPerStation = 0x40;
        public ushort sendThreadBufferNumPerStation = 0x60;
        public ushort receiveThreadBufferNumPerStation = 0x80;
        public ushort unreliableProtocolNum = 9;
		public ushort reliableProtocolNum = 9;
		public ushort broadcastReliableProtocolNum;
		public ushort streamBroadcastReliableProtocolNum;
		public int networkTopologyRelayMeshNum = 0x20;
		public ushort browsedSessionPropertyListNum = 10;
		public ushort relayRouteNumMax = 10;
		public ushort relayRouteRttMax = 400;
		public uint silenceTimeMax = 5500;
		public uint keepAliveSendingInterval = 1000;
		public int updateMeshSendingInterval = 1000;
		public bool isAutoInitializeLdn = true;
		public bool isLocalhostMatchmakeEnabled;
		public bool bSSCrashMode;
		public bool bNexUse = true;
		public bool bExcludeUserPassword;
		
		// TODO
		public IlcaNetSessionSetting DeepClone() { return default; }
	}
}