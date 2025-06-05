using nn.account;
using nn.err;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using UnityEngine;

public class PiaPlugin
{
    public const ulong InvalidConstantId = 0;
    public const int InvalidStationIndex = 253;
    public const uint PlayerNameLengthMax = 20;
    public const int LocalCommunicationVersionMin = 0;
    public const int LocalCommunicationVersionMax = 32767;
    public const int PlayerInfoSizeMax = 4;

    private static List<PiaPluginSession.SessionEvent> s_SessionEventList = new List<PiaPluginSession.SessionEvent>();
    public static readonly Result SuccessResult = new Result(ResultValue.ResultSuccess, 0, ViewerType.Void, HandlingType.Void);
    public static readonly Result ProgrammingErrorResult = new Result(HandlingType.ProgrammingError);
    public static readonly Result InvalidArgumentResult = new Result(ResultValue.ResultInvalidArgument, 0, ViewerType.ShouldNotUse, HandlingType.ProgrammingError);
    public static readonly Result AllocationFailedResult = new Result(ResultValue.ResultAllocationFailed, 0, ViewerType.ShouldNotUse, HandlingType.ProgrammingError);

    // TODO
    private static void RegisterPiaLogNative() { }

    private static extern Result InitializeFrameworkNative([In] InitializeFrameworkSettingNative setting, [In] TraceFlagSettingNative traceFlags);

    // TODO
    public static Result InitializeFramework(InitializeFrameworkSetting setting) { return default; }

    // TODO
    private static void UnregisterPiaLogNative() { }

    private static extern void FinalizeAllNative();

    // TODO
    public static void FinalizeAll() { }

    private static extern Result RegisterInitializeInternetSettingNative([In] InitializeInternetSettingNative setting);

    // TODO
    public static Result RegisterInitializeInternetSetting(InitializeInternetSetting setting) { return default; }

    private static extern Result RegisterInitializeLanSettingNative([In] InitializeLanSetting setting);

    // TODO
    public static Result RegisterInitializeLanSetting(InitializeLanSetting setting) { return default; }

    private static extern Result RegisterInitializeLocalSettingNative([In] InitializeLocalSetting setting);

    // TODO
    public static Result RegisterInitializeLocalSetting(InitializeLocalSetting setting) { return default; }

    private static extern Result RegisterInitializeTransportSettingNative([In] InitializeTransportSetting setting);

    // TODO
    public static Result RegisterInitializeTransportSetting(InitializeTransportSetting setting) { return default; }

    private static extern Result RegisterInitializeCloneSettingNative([In] InitializeCloneSetting setting);

    // TODO
    public static Result RegisterInitializeCloneSetting(InitializeCloneSetting setting) { return default; }

    private static extern Result RegisterInitializeSyncSettingNative([In] InitializeSyncSetting setting);

    // TODO
    public static Result RegisterInitializeSyncSetting(InitializeSyncSetting setting) { return default; }

    private static extern Result RegisterInitializeReckoningSettingNative([In] InitializeReckoningSetting setting);

    // TODO
    public static Result RegisterInitializeReckoningSetting(InitializeReckoningSetting setting) { return default; }

    private static extern Result RegisterInitializeSessionSettingNative([In] InitializeSessionSetting setting);

    // TODO
    public static Result RegisterInitializeSessionSetting(InitializeSessionSetting setting) { return default; }

    private static extern Result RegisterStartupNetworkSettingNative([In] StartupNetworkSetting setting);

    // TODO
    public static Result RegisterStartupNetworkSetting(StartupNetworkSetting setting) { return default; }

    private static extern Result RegisterStartupSessionSettingNative([In] StartupSessionSettingNative settingNative, [In] PlayerInfoNative[] playerInfo, int infoNum);

    // TODO
    public static Result RegisterStartupSessionSetting(StartupSessionSetting setting, PlayerInfo[] playerInfo) { return default; }

    private static extern Result RegisterJoinRandomSessionSettingNative([In] PiaPluginSession.CreateSessionSettingNative createSessionSetting, [In] PiaPluginSession.SessionSearchCriteriaNative[] sessionSearchCriteriaList, int sessionSerachCriteriaListSize, [In] bool isMyBlockListUsed, [In] bool isOthersBlockListUsed, [In] bool isUniqueKeywordEnabled);

    // TODO
    public static Result RegisterJoinRandomSessionSetting(JoinRandomSessionSetting setting) { return default; }

    private static extern Result RegisterJoinRandomJointSessionSettingNative([In] PiaPluginSession.CreateSessionSettingNative createSessionSetting, [In] PiaPluginSession.SessionSearchCriteriaNative[] sessionSearchCriteriaList, int sessionSerachCriteriaListSize, [In] bool isMyBlockListUsed, [In] bool isOthersBlockListUsed, [In] bool isUniqueKeywordEnabled);

    // TODO
    public static Result RegisterJoinRandomJointSessionSetting(JoinRandomSessionSetting setting) { return default; }

    private static extern Result RegisterNatDebugSettingNative([In] NatDebugSetting setting);

    // TODO
    public static Result RegisterNatDebugSetting(NatDebugSetting setting) { return default; }

    private static extern Result UnregisterInitializeInternetSettingNative();

    // TODO
    public static Result UnregisterInitializeInternetSetting() { return default; }

    private static extern Result UnregisterInitializeLanSettingNative();

    // TODO
    public static Result UnregisterInitializeLanSetting() { return default; }

    private static extern Result UnregisterInitializeLocalSettingNative();

    // TODO
    public static Result UnregisterInitializeLocalSetting() { return default; }

    private static extern Result UnregisterInitializeTransportSettingNative();

    // TODO
    public static Result UnregisterInitializeTransportSetting() { return default; }

    private static extern Result UnregisterInitializeCloneSettingNative();

    // TODO
    public static Result UnregisterInitializeCloneSetting() { return default; }

    private static extern Result UnregisterInitializeSyncSettingNative();

    // TODO
    public static Result UnregisterInitializeSyncSetting() { return default; }

    private static extern Result UnregisterInitializeReckoningSettingNative();

    // TODO
    public static Result UnregisterInitializeReckoningSetting() { return default; }

    private static extern Result UnregisterInitializeSessionSettingNative();

    // TODO
    public static Result UnregisterInitializeSessionSetting() { return default; }

    private static extern Result UnregisterStartupNetworkSettingNative();

    // TODO
    public static Result UnregisterStartupNetworkSetting() { return default; }

    private static extern Result UnregisterStartupSessionSettingNative();

    // TODO
    public static Result UnregisterStartupSessionSetting() { return default; }

    private static extern Result UnregisterJoinRandomSessionSettingNative();

    // TODO
    public static Result UnregisterJoinRandomSessionSetting() { return default; }

    private static extern Result UnregisterJoinRandomJointSessionSettingNative();

    // TODO
    public static Result UnregisterJoinRandomJointSessionSetting() { return default; }

    private static extern Result UnregisterNatDebugSettingNative();

    // TODO
    public static Result UnregisterNatDebugSetting() { return default; }

    private static extern void DispatchNative();

    // TODO
    public static void Dispatch() { }

    private static extern Result CheckDispatchErrorNative();

    // TODO
    public static Result CheckDispatchError() { return default; }

    private static extern SessionEventListNative GetSessionEventListNative();

    // TODO
    public static List<PiaPluginSession.SessionEvent> GetSessionEventList() { return default; }

    private static extern void FinalizeNetworkNative();

    // TODO
    public static void FinalizeNetwork() { }

    private static extern Result ChangeStateAsyncNative(State state);

    // TODO
    public static Result ChangeStateAsync(State state) { return default; }

    private static extern Result GetCurrentHandlingResultNative();

    // TODO
    public static Result GetCurrentHandlingResult() { return default; }

    private static extern Result HandleErrorAsyncNative(Result result);

    // TODO
    public static Result HandleErrorAsync(Result result) { return default; }

    private static extern State ConvertHandlingTypeToStateNative(HandlingType handlingType);

    // TODO
    public static State ConvertHandlingTypeToState(HandlingType handlingType) { return default; }

    private static extern State GetJoinProcessStateNative();

    // TODO
    public static State GetJoinProcessState() { return default; }

    private static extern AsyncState GetAsyncProcessStateNative(AsyncProcessId id);

    // TODO
    public static AsyncState GetAsyncProcessState(AsyncProcessId id) { return default; }

    private static extern AsyncProcessId GetAsyncProcessIdNative();

    // TODO
    public static AsyncProcessId GetAsyncProcessId() { return default; }

    private static extern bool IsSessionMigratingNative();

    // TODO
    public static bool IsSessionMigrating() { return default; }

    private static extern uint GetMemoryUsageNative();

    // TODO
    public static uint GetMemoryUsage() { return default; }

    private static extern void StartWatermarkNative();

    // TODO
    public static void StartWatermark() { }

    private static extern void StopWatermarkNative();

    // TODO
    public static void StopWatermark() { }

    private static extern void GetWatermarkArrayNative(out IntPtr pWatermarkNativeArray, out int watermarkNativeArrayLength);

    // TODO
    public static List<Watermark> GetWatermarkList() { return default; }

    private static extern int GetRttNative(ulong constantId);

    // TODO
    public static int GetRtt(ulong constantId) { return default; }

    private static extern IntPtr GetNexNgsFacadeNative();

    // TODO
    public static IntPtr GetNexNgsFacade() { return default; }

    private static extern IntPtr GetNexCredentialsNative();

    // TODO
    public static IntPtr GetNexCredentials() { return default; }

    private static extern int GetCryptoKeySizeNative();

    // TODO
    public static int GetCryptoKeySize() { return default; }

    private static extern void AssertNative(bool flag);

    // TODO
    public static void Assert(bool flag) { }

    private static extern Result GetServerTimeNative(out DateTime dateTime);

    // TODO
    public static Result GetServerTime(out DateTime dateTime)
    {
        dateTime = default;
        return default;
    }

    private static extern Result GetLocalAddressNative([Out] LocalAdressInfoNative localAddressInfo);

    // TODO
    public static Result GetLocalAddress(ref LocalAdressInfo localAddressInfo) { return default; }

    private static extern void TraceNative(IntPtr mes);

    // TODO
    [Conditional("DEVELOPMENT_BUILD")]
    public static void Trace(string msg, string memberName = "", string sourceFilePath = "", int sourceLineNumber = 0) { }

    public enum ResultValue : uint
    {
        ResultAllocationFailed = 68609,
        ResultAlreadyInitialized = 68610,
        ResultBufferShortage = 68612,
        ResultBrokenData = 11267,
        ResultCancelled = 27653,
        ResultNetworkConnectionIsLost = 50182,
        ResultInvalidArgument = 68615,
        ResultInvalidState = 68616,
        ResultNoData = 11273,
        ResultNotFound = 11274,
        ResultNotImplemented = 3083,
        ResultNotInitialized = 68620,
        ResultBufferIsFull = 19469,
        ResultTimeout = 27662,
        ResultAlreadyExists = 68623,
        ResultContainerIsFull = 3088,
        ResultTemporaryUnavailable = 19473,
        ResultNotSet = 68627,
        ResultMemoryLeak = 68628,
        ResultInvalidNode = 3094,
        ResultNegligibleFault = 11288,
        ResultInvalidConnection = 27673,
        ResultLocalCommunicationInvalidState = 27675,
        ResultNetworkIsNotFound = 27676,
        ResultNetworkIsFull = 27677,
        ResultLocalCommunicationLowerVersion = 25630,
        ResultLocalCommunicationHigherVersion = 25631,
        ResultWifiOff = 50208,
        ResultSleep = 50209,
        ResultWirelessControllerCountLimitation = 25634,
        ResultConnectionFailed = 3108,
        ResultCreateStationFailed = 3109,
        ResultIncompatibleFormat = 68646,
        ResultNotInCommunication = 11303,
        ResultTableIsFull = 3112,
        ResultDataIsNotArrivedYet = 19500,
        ResultDataIsNotSet = 68658,
        ResultNatCheckFailed = 25652,
        ResultInUse = 3125,
        ResultDnsFailed = 25654,
        ResultNexInternalError = 58423,
        ResultJoinRequestDenied = 26680,
        ResultStationConnectionFailed = 25657,
        ResultMeshIsFull = 27709,
        ResultInvalidSystemMessage = 68670,
        ResultStationConnectionNatTraversalFailedUnknown = 25663,
        ResultNatTraversalFailedBothEim = 25666,
        ResultNatTraversalFailedLocalEimRemoteEdm = 25667,
        ResultNatTraversalFailedLocalEdmRemoteEim = 25668,
        ResultNatTraversalFailedBothEdm = 25669,
        ResultRelayFailedNoCandidate = 26694,
        ResultRelayFailedRttLimit = 26695,
        ResultRelayFailedRelayNumLimit = 26696,
        ResultRelayFailedUnknown = 26697,
        ResultNatTraversalRequestTimeout = 25674,
        ResultSessionIsNotFound = 27723,
        ResultMatchmakeSessionIsFull = 27724,
        ResultDeniedByParticipant = 27725,
        ResultParticipantInBlockList = 27726,
        ResultGameServerMaintenance = 42063,
        ResultSessionUserPasswordUnmatch = 27729,
        ResultSessionSystemPasswordUnmatch = 27730,
        ResultMeshConnectionIsLost = 27728,
        ResultSessionIsClosed = 27731,
        ResultCompanionStationIsOffline = 27732,
        ResultHostIsNotFriend = 27733,
        ResultSessionConnectionIsLost = 35926,
        ResultCompanionStationIsLeft = 27735,
        ResultSessionMigrationFailed = 27737,
        ResultGameServerProcessAborted = 44122,
        ResultSessionConnectionIsLostByHost = 35960,
        ResultSessionConnectionIsLostByHostMigrationFailure = 35958,
        ResultSessionConnectionIsLostByInconsistentInfo = 35959,
        ResultKickedOutFromSessionByInconsistentInfo = 35962,
        ResultKickedOutFromSessionByUser = 35961,
        ResultSessionWrongState = 27739,
        ResultCreateCommunityFailedUpperLimit = 27743,
        ResultJoinCommunityFailedUpperLimit = 27744,
        ResultCommunityIsFull = 27745,
        ResultCommunityIsNotFound = 27746,
        ResultCommunityIsClosed = 27747,
        ResultCommunityUserPasswordUnmatch = 27750,
        ResultAlreadyJoinedCommunity = 11364,
        ResultUserAccountNotExisted = 27749,
        ResultNatTraversalFailedBothEimSamePublicAddress = 25703,
        ResultNatTraversalFailedBothEdmSamePublicAddress = 25706,
        ResultNatTraversalFailedLocalEimRemoteEdmSamePublicAddress = 25704,
        ResultNatTraversalFailedLocalEdmRemoteEimSamePublicAddress = 25705,
        ResultSdkError = 60523,
        ResultSdkViewerResultError = 42094,
        ResultCancelledByUser = 44141,
        ResultSystemLowerVersion = 25711,
        ResultSystemHigherVersion = 25712,
        ResultNetworkConnectionIsLostByDuplicateLogin = 42097,
        ResultLicenseForNetworkServiceNotAvailable = 42098,
        ResultLicenseForNetworkServiceError = 42099,
        ResultLicenseForNetworkServiceSubscriptionError = 42100,
        ResultLicenseForNetworkServiceSubscriptionError2 = 42101,
        ResultOutOfMemory = 60539,
        ResultNetworkInterfaceIsNotFound = 27774,
        ResultInvalidClock = 27772,
        ResultIncreaseDataSize = 11389,
        ResultSuccess = 0,
    }

    public enum TraceFlag : short
    {
        Always = 0,
        Common = 1,
        CommonSocketDetail = 2,
        CommonDetail = 3,
        Local = 4,
        LocalMigration = 5,
        LocalDetail = 6,
        Net = 7,
        NetMigration = 8,
        Direct = 9,
        DirectConnect = 10,
        DirectDetail = 11,
        Nex = 12,
        NexMigration = 13,
        NexJoint = 14,
        NexTransport = 15,
        NexRelay = 16,
        NexRelayTransport = 17,
        NexNat = 18,
        NexNatProbe = 19,
        Nat = 20,
        NatProbe = 21,
        Cloud = 22,
        CloudConnectionDetail = 23,
        CloudTransport = 24,
        CloudHeapDetail = 25,
        CloudDetail = 26,
        Wan = 27,
        WanNat = 28,
        WanTransport = 29,
        WanDetail = 30,
        Lan = 31,
        LanMigration = 32,
        LanTransport = 33,
        Transport = 34,
        TransportInit = 35,
        TransportKeepAlive = 36,
        TransportRtt = 37,
        TransportBufferDetail = 38,
        TransportPacketDetail = 39,
        TransportProtocolDetail = 40,
        TransportRelay = 41,
        TransportRelayDetail = 42,
        TransportReliableDetail = 43,
        TransportDebug = 44,
        Mesh = 45,
        MeshMigration = 46,
        MeshUpdate = 47,
        MeshClock = 48,
        Session = 49,
        SessionMigration = 50,
        SessionJoint = 51,
        SessionReserved = 52,
        Lobby = 53,
        LobbyDetail = 54,
        Sync = 55,
        SyncFrameDrop = 56,
        SyncDetail = 57,
        Clone = 58,
        CloneUpdate = 59,
        CloneEvent = 60,
        CloneEventDetail = 61,
        CloneAtomic = 62,
        CloneClock = 63,
        Reckoning = 64,
        Chat = 65,
        ChatDetail = 66,
        Framework = 67,
        FrameworkDetail = 68,
        Emulation = 69,
        EmulationDetail = 70,
        Brain = 71,
        BrainDetail = 72,
        Plugin = 73,
        Report = 74,
        Terminate = 75,
        Default = 0,
        All = -1,
    }

    public enum HandlingType : int
    {
        Void = 0,
        Ignorable = 1,
        Retry = 2,
        Cleanup = 3,
        CleanupWithLeave = 4,
        LogoutWithLeave = 5,
        ShutdownNetwork = 6,
        Finalize = 7,
        ProgrammingError = 8,
    }

    public enum ViewerType : int
    {
        Void = 0,
        ShouldUse = 1,
        MayUse = 2,
        ShouldNotUse = 3,
    }

    public enum NetworkType : int
    {
        Local = 0,
        Internet = 1,
        Lan = 2,
    }

    public enum State : int
    {
        NotInitialized = 0,
        NetworkStartedUp = 1,
        LoggedIn = 2,
        SessionInitialized = 3,
        SessionStartedUp = 4,
        SessionJoined = 5,
        SessionStartedBrowseMatchmake = 7,
        SessionLeft = 4,
        SessionCleanedUp = 3,
        SessionFinalized = 2,
        LoggedOut = 1,
        NetworkCleanedUp = 0,
        JointSessionJoined = 6,
        JointSessionLeft = 4,
    }

    public enum AsyncProcessId : int
    {
        Nothing = 0,
        ChangeState = 1,
        HandleError = 2,
        CreateSession = 3,
        BrowseSession = 4,
        JoinSession = 5,
        OpenSession = 6,
        UpdateAndOpenSession = 7,
        CloseSession = 8,
        UpdateSessionSetting = 9,
        RequestSessionProperty = 10,
        DestroyJointSession = 11,
        OpenJointSession = 12,
        UpdateAndOpenJointSession = 13,
        CloseJointSession = 14,
        UpdateJointSessionSetting = 15,
        RequestJointSessionProperty = 16,
    }

    public struct Result
    {
        public ResultValue resultValue { get; set; }
        private uint innerErrorCode { get; set; }
        public ViewerType viewerType { get; set; }
        public HandlingType handlingType { get; set; }
        private nn.Result sdkViewerResult { get; }

        public Result(HandlingType _handlingType) : this(ResultValue.ResultNotImplemented, 0, ViewerType.ShouldNotUse, _handlingType) { }

        public Result(ResultValue _resultValue, uint _innerErrorCode, ViewerType _viewerType, HandlingType _handlingType)
        {
            resultValue = _resultValue;
            innerErrorCode = _innerErrorCode;
            viewerType = _viewerType;
            handlingType = _handlingType;
            sdkViewerResult = new nn.Result(0, 0);
        }

        // TODO
        public bool IsSuccess() { return default; }

        // TODO
        public bool IsFailure() { return default; }

        // TODO
        public ErrorCode GetErrorCode() { return default; }

        // TODO
        public Result GetErrorResult() { return default; }

        // TODO
        public void Trace() { }
    }

    [Serializable]
    public class PlayerInfo
    {
        public byte nameStringLanguage;
        public string playerName;
        public Uid playerId;

        public PlayerInfo()
        {
            nameStringLanguage = 0;
            playerName = "";
        }

        internal PlayerInfo(PlayerInfoNative playerInfoNative)
        {
            nameStringLanguage = playerInfoNative.nameStringLanguage;
            playerName = UnmanagedMemoryManager.ReadUtf8(playerInfoNative.playerName, playerInfoNative.playerNameSize);
        }
    }

    public struct PlayerInfoNative : IDisposable
    {
        public byte nameStringLanguage;
        public IntPtr playerName;
        public int playerNameSize;
        public Uid playerId;

        internal PlayerInfoNative(PlayerInfo playerInfo)
        {
            nameStringLanguage = playerInfo.nameStringLanguage;

            int size = 0;
            playerName = UnmanagedMemoryManager.WriteUtf8(playerInfo.playerName, ref size);
            playerNameSize = playerInfo.playerName.Length;
            playerId = playerInfo.playerId;
        }

        // TODO
        public void Dispose() { }
    }

    internal struct DispatchResultNative : IDisposable
    {
        public Result result { get; set; }
        public IntPtr pSessionEventArray { get; set; }
        public int sessionEventNum { get; set; }

        // TODO
        public void Dispose() { }
    }

    public struct SessionEventListNative : IDisposable
    {
        public IntPtr pSessionEventArray { get; set; }
        public int sessionEventNum { get; set; }

        // TODO
        public void Dispose() { }
    }

    public struct AsyncState
    {
        public bool isCompleted;

        public Result result { get; set; }
    }

    public struct CryptoSetting
    {
        public Mode mode;
        public IntPtr pKeyData;

        public enum Mode : int
        {
            Nothing = 0,
            Aes128 = 1,
        }
    }

    public class TraceFlagSetting
    {
        public const uint ArraySize = 75;
        public uint count;
        public TraceFlag[] flags = new TraceFlag[ArraySize];

        public TraceFlagSetting()
        {
            count = 0;
        }

        // TODO
        public TraceFlagSetting add(TraceFlag value) { return default; }
    }

    [Serializable]
    public class TraceFlagSettingNative : IDisposable
    {
        private const uint ArraySize = 75;

        public uint count { get; set; }

        private TraceFlag[] flags;

        // TODO
        internal TraceFlagSettingNative(TraceFlagSetting setting) { }

        // TODO
        public void Dispose() { }
    }

    public class InitializeFrameworkSetting
    {
        public uint piaBufferSize;
        public NetworkType networkType;
        public int backgroundThreadPriority = -1;
        public TraceFlagSetting traceFlags = new TraceFlagSetting();
        public CoreId threadCoreId;

        public enum CoreId : int
        {
            CoreId_Default = 0,
            CoreId_0 = 1,
            CoreId_1 = 2,
            CoreId_2 = 3,
        }
    }

    public class InitializeFrameworkSettingNative : IDisposable
    {
        public uint piaBufferSize;
        public int networkType;
        public int backgroundThreadPriority;
        public IntPtr unityVersion;
        public int threadCoreId;

        internal InitializeFrameworkSettingNative(InitializeFrameworkSetting setting)
        {
            piaBufferSize = setting.piaBufferSize;
            networkType = (int)setting.networkType;
            backgroundThreadPriority = setting.backgroundThreadPriority;

            int size = 0;
            unityVersion = UnmanagedMemoryManager.WriteUtf8(Application.unityVersion, ref size);
            threadCoreId = (int)setting.threadCoreId;
        }

        // TODO
        public void Dispose() { }
    }

    public class InitializeInternetSetting
    {
        public uint totalMemorySize;
        public uint emergencyMemorySize;
        public uint gameId;
        public string accessKey = "";
        public UserHandle userHandle;
        public byte nexVersionMajor;
        public byte nexVersionMinor;
        public byte nexVersionMicro;
    }

    public class InitializeInternetSettingNative : IDisposable
    {
        public uint totalMemorySize;
        public uint emergencyMemorySize;
        public uint gameId;
        public IntPtr accessKey = IntPtr.Zero;
        public UserHandle userHandle;
        public byte nexVersionMajor;
        public byte nexVersionMinor;
        public byte nexVersionMicro;

        internal InitializeInternetSettingNative(InitializeInternetSetting setting)
        {
            totalMemorySize = setting.totalMemorySize;
            emergencyMemorySize = setting.emergencyMemorySize;
            gameId = setting.gameId;

            int size = 0;
            accessKey = UnmanagedMemoryManager.WriteUtf8(setting.accessKey, ref size);
            userHandle = setting.userHandle;
            nexVersionMajor = setting.nexVersionMajor;
            nexVersionMinor = setting.nexVersionMinor;
            nexVersionMicro = setting.nexVersionMicro;
        }

        // TODO
        public void Dispose() { }
    }

    [Serializable]
    public class InitializeLanSetting { }

    [Serializable]
    public class InitializeLocalSetting
    {
        public int localCommunicationVersion;
    }

    [Serializable]
    public class InitializeTransportSetting
    {
        public ushort stationNumMax;
        public int measurementInterval;
        public ushort sendProtocolBufferNumPerStation = 8;
        public ushort receiveProtocolBufferNumPerStation = 8;
        public ushort sendThreadBufferNumPerStation;
        public ushort receiveThreadBufferNumPerStation;
        public ushort unreliableProtocolNum;
        public ushort reliableProtocolNum;
        public ushort broadcastReliableProtocolNum;
        public ushort streamBroadcastReliableProtocolNum;
        public bool isAnalysisResultPrintEnabled;
    }

    [Serializable]
    public class InitializeCloneSetting
    {
        public bool isEnable;
        public ushort broadcastEventProtocolNum;
        public ushort broadcastEventProtocolBufferNum;
        public uint atomicProtocolIdMax = 32;
    }

    [Serializable]
    public class InitializeSyncSetting
    {
        public bool isEnable;
        public bool isChangeDelayEnabled;
        public uint[] dataUnitSize = new uint[16];
    }

    [Serializable]
    public class InitializeReckoningSetting
    {
        public bool isEnable;
        public ushort reckoning1dProtocolNum;
        public ushort reckoning3dProtocolNum;
        public ushort reckoningProtocolBufferNum;
    }

    [Serializable]
    public class InitializeSessionSetting
    {
        public PiaPluginSession.NetworkTopology networkTopology;
        public ushort browsedSessionPropertyListNum;
    }

    [Serializable]
    public class StartupNetworkSetting
    {
        public bool isAutoInitializeNetworkInterface;
    }

    [Serializable]
    public class StartupSessionSetting
    {
        public ushort relayRouteNumMax;
        public ushort relayRouteRttMax;
        public bool isEachPlayerCountedAsParticipant = true;
        public bool isAutoInitializeLdn;
        public uint silenceTimeMax = 10000;
        public uint keepAliveSendingInterval = 1000;
        public int updateMeshSendingInterval = 1000;
        public CryptoSetting cryptoSetting;
        public string localAddress = "";
        public uint v4Subnetmask;
        public int v6InterfaceIndex;
        public bool useBroadcastOnSendingToAllStation;
    }

    private class StartupSessionSettingNative : IDisposable
    {
        public ushort relayRouteNumMax;
        public ushort relayRouteRttMax;
        public bool isAutoInitializeLdn;
        public uint silenceTimeMax;
        public uint keepAliveSendingInterval;
        public int updateMeshSendingInterval;
        public bool isEachPlayerCountedAsParticipant;
        public CryptoSetting cryptoSetting;
        public IntPtr pLocalAddress;
        public uint v4Subnetmask;
        public int v6InterfaceIndex;
        public bool useBroadcastOnSendingToAllStation;

        internal StartupSessionSettingNative(StartupSessionSetting setting)
        {
            relayRouteNumMax = setting.relayRouteNumMax;
            relayRouteRttMax = setting.relayRouteRttMax;
            isEachPlayerCountedAsParticipant = setting.isEachPlayerCountedAsParticipant;
            isAutoInitializeLdn = setting.isAutoInitializeLdn;
            silenceTimeMax = setting.silenceTimeMax;
            keepAliveSendingInterval = setting.keepAliveSendingInterval;
            updateMeshSendingInterval = setting.updateMeshSendingInterval;
            cryptoSetting = setting.cryptoSetting;

            int size = 0;
            pLocalAddress = UnmanagedMemoryManager.WriteUtf8(setting.localAddress, ref size);
            v4Subnetmask = setting.v4Subnetmask;
            v6InterfaceIndex = setting.v6InterfaceIndex;
            useBroadcastOnSendingToAllStation = setting.useBroadcastOnSendingToAllStation;
        }

        // TODO
        public void Dispose() { }
    }

    [Serializable]
    public class JoinRandomSessionSetting
    {
        public PiaPluginSession.CreateSessionSetting createSessionSetting;
        public PiaPluginSession.SessionSearchCriteria[] sessionSearchCriteriaList;
        public bool isMyBlockListUsed = true;
        public bool isOthersBlockListUsed = true;
        public bool isUniqueKeywordEnabled;
    }

    [Serializable]
    public class NatDebugSetting
    {
        public byte natTraversalFailureRatioForHost;
        public byte natTraversalFailureRatioForClient;
        public bool isNatTypeCheckFailure;
        public bool isDnsResolutionFailure;
    }

    public class Watermark
    {
		public string name { get; set; }
        public long valueMax { get; set; }
        public long valueMin { get; set; }
        public long latestValue { get; set; }
        public long updateCount { get; set; }

        public Watermark()
        {
            name = "";
            latestValue = 0;
            updateCount = 0;
            valueMax = 0;
            valueMin = 0;
        }

        internal Watermark(WatermarkNative watermarkNative)
        {
            name = UnmanagedMemoryManager.ReadUtf8(watermarkNative.pName, watermarkNative.nameSize);
            valueMax = watermarkNative.valueMax;
            valueMin = watermarkNative.valueMin;
            latestValue = watermarkNative.valueMax;
            updateCount = watermarkNative.updateCount;
        }
    }

    internal class WatermarkNative : IDisposable
    {
		public IntPtr pName { get; set; }
        public int nameSize { get; set; }
        public long valueMax { get; set; }
        public long valueMin { get; set; }
        public long latestValue { get; set; }
        public long updateCount { get; set; }

        // TODO
        public void Dispose() { }
    }

    public struct DateTime
    {
        public ushort year;
        public byte month;
        public byte day;
        public byte hour;
        public byte minute;
        public byte second;
        private bool isRegistered;

        public DateTime(ushort year_, byte month_, byte day_, byte hour_, byte minute_, byte second_)
        {
            year = year_;
            month = month_;
            day = day_;
            hour = hour_;
            minute = minute_;
            second = second_;
            isRegistered = true;
        }

        public bool IsRegistered()
        {
            return isRegistered;
        }
    }

    [Serializable]
    public class LocalAdressInfo
    {
        public string address6 = "";
        public uint interfaceIndex;
        public string address4 = "";
        public uint subnetMask;

        public LocalAdressInfo()
        {
            address6 = "";
            interfaceIndex = 0;
            address4 = "";
            subnetMask = 0;
        }

        internal LocalAdressInfo(LocalAdressInfoNative localAdressInfoNative)
        {
            address6 = UnmanagedMemoryManager.ReadUtf8(localAdressInfoNative.address6, localAdressInfoNative.address6Length);
            interfaceIndex = localAdressInfoNative.interfaceIndex;
            address4 = UnmanagedMemoryManager.ReadUtf8(localAdressInfoNative.address4, localAdressInfoNative.address4Length);
            subnetMask = localAdressInfoNative.subnetMask;
        }
    }

    internal class LocalAdressInfoNative : IDisposable
    {
		public IntPtr address6 { get; set; }
        public ushort address6Length { get; set; }
        public uint interfaceIndex { get; set; }
        public IntPtr address4 { get; set; }
        public ushort address4Length { get; set; }
        public uint subnetMask { get; set; }

        internal LocalAdressInfoNative()
        {
            address6 = IntPtr.Zero;
            address6Length = 0;
            interfaceIndex = 0;
            address4 = IntPtr.Zero;
            address4Length = 0;
            subnetMask = 0;
        }

        internal LocalAdressInfoNative(LocalAdressInfo localAddressInfo)
        {
            address6 = IntPtr.Zero;
            address6Length = 0;
            interfaceIndex = 0;
            address4 = IntPtr.Zero;
            address4Length = 0;
            subnetMask = 0;

            int size = 0;
            address6 = UnmanagedMemoryManager.WriteUtf8(localAddressInfo.address6, ref size);
            address4 = UnmanagedMemoryManager.WriteUtf8(localAddressInfo.address4, ref size);
        }

        // TODO
        public void Reset() { }

        // TODO
        public void Dispose() { }
    }

    public class Debug
    {
        private static extern Result EnableBroadcastOnSendingToAllStationForDebugNative();

        // TODO
        public static Result EnableBroadcastOnSendingToAllStationForDebug() { return default; }
    }
}