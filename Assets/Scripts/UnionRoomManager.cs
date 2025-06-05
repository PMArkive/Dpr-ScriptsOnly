using Dpr.NetworkUtils;
using Dpr.SubContents;
using System;
using System.Collections;
using UnityEngine;
using XLSXContent;

public class UnionRoomManager : NetUseManager<UnionRoomManager>
{
    private const string UNION_MASTER_PATH = "unionroom/masterdata";
    private const string CHARACTER_DATATABLE_PATH = "UnionCharacterTable";
    private const string NPC_COLOR_DATATABLE = "UnionNpcColorTable";
    private const string UNION_BATTLE_DISPLAY_PATH = "unionroom/ui";
    private const string BATTLE_RULE_WINDOW_PATH = "UNION_BattleRuleWindow";
    private const int POSITION_DATA_MAX_SIZE = 12;
    private const float GURUGURU_HEIGHT_UP = 10;
    private const string UNION_FRONT_DESK_CONTROLLER = "FdController";
    private static readonly ZoneID[] enableZones = new ZoneID[4]
    {
        ZoneID.UNION, ZoneID.UNION01, ZoneID.UNION02, ZoneID.UNION03
    };
    private UnionCharacterTable.SheetSheet1[] _characterTable;
    private UnionNpcColorTable.SheetSheet1[] _npcColorTable;
    private NetJoinData netJoinData = new NetJoinData();
    private PosData[] posDataList = new PosData[POSITION_DATA_MAX_SIZE];
    private int posDataIndex;
    public UnionStateController stateController;
    private Coroutine waitInitCoroutine;
    public ZoneID returnZoneID;
    public int locatorIndex = 1;
    public Vector3 returnPosition;
    protected GameObject battleRuleDisplayUiObj;
    private GameObject batteStateDataWindow;
    public GameObject fdControllerObject;
    public UnionFrontDeskStateController unionFrontController;
    private GameObject startPointObject;
    private GameObject startLandObj;
    private UnionStartPointCollision pointCollision;
    private UnionTradeManager tradeManager;
    private BattleMatchingManager battleMatchingManager;
    private TranerData targetTrainerData;
    private UnionBaseMsgWindow msgWindow;
    private FieldCharacterEntity frontDeskEntity;
    private bool isError;
    private bool canLeave;
    private bool isLeaving;
    private bool isCancelStock;
    private const float STATE_UPDATE_INTERVAL = 2;
    private float stateUpdateTime;
    private OpcState.OnlineState nowTalkReserveState;
    private NetCharacterStateData stateData = new NetCharacterStateData();

    // TODO
    private FieldPlayerEntity player { get => EntityManager.activeFieldPlayer; }
    public bool isBattle { get; }
    private bool isTradeUIState { get; }
    private bool isBatteUIState { get; }
    private bool isRecordUIState { get; }
    private bool isBallDecoUIState { get; }

    // TODO
    protected override IEnumerator Start() { return null; }

    // TODO
    public override void SetMatchingParam(MatchingParam matchingParam) { }

    // TODO
    protected override void Init() { }

    // TODO
    protected override void MyUpdate(float deltaTime) { }

    // TODO
    protected override void OnDestroy() { }

    // TODO
    public void SetZoneData(ZoneID zoneId, int locIndex, Vector2Int gridPos) { }

    // TODO
    private void SetUp() { }

    // TODO
    private void Clear() { }

    // TODO
    private void CreateWarpCollision() { }

    // TODO
    private void SSGaminWaitMessage(bool isSSGaming) { }

    // TODO
    private void SetupLeave() { }

    // TODO
    private void LandStartPoint() { }

    // TODO
    private void CreateFrontDesk() { }

    // TODO
    public void LeaveUnion()
    {
        // TODO
        IEnumerator Leave() { return default; }
    }

    // TODO
    public void TransitionUnionInit() { }

    // TODO
    private void CreateTradeManager() { }

    // TODO
    public void ReturnBattle() { }

    // TODO
    private void ReturnBattleMatching() { }

    // TODO
    private void CreateBattleMatchingManager() { }

    // TODO
    protected override void OnSessionEvent(SessionEventData eventData) { }

    // TODO
    private void LeaveMine() { }

    // TODO
    private void LeaveOtherPlayer(int index) { }

    // TODO
    private void GamingError() { }

    // TODO
    private void BattleRuleCancel() { }

    // TODO
    private void Crush() { }

    // TODO
    private void Resume() { }

    // TODO
    private void NetworkError() { }

    // TODO
    private void TradeErrorDialog() { }

    // TODO
    private void OpenErrorDialog(ErrorCodeID errorId, Action<ErrorAppletResult> onClosedAct) { }

    // TODO
    private void OpenSystemErrorMessage(ErrorAppletResult errorAppletResult) { }

    // TODO
    private bool IsCheckCommunicationState() { return false; }

    // TODO
    private void LeaveCommunicationPlayer(int stationIndex)
    {
        // TODO
        void InputEnebled() { }
    }

    // TODO
    public void SessionStart() { }

    // TODO
    public void ClearSession() { }

    // TODO
    protected override void OnReceiveData(INetData netData) { }

    // TODO
    protected override void SetNetData(INetData netData) { }

    // TODO
    protected override IEnumerator LoadAsset() { return null; }

    // TODO
    private void SendJoinData(int stationIndex) { }

    // TODO
    private void SendPosData() { }

    // TODO
    private void SendOpcStateData(int stationIndex) { }

    // TODO
    private void SendOpcStateDataAll() { }

    // TODO
    public void SendRequestData(int stationIndex, byte id) { }

    // TODO
    private void SendIsTransitionAfter() { }

    // TODO
    private void SendStandbyPlayerData(int stationIndex) { }

    // TODO
    private void SendIsMatchWait(int stationIndex) { }

    // TODO
    private void SendPokeData(int stationIndex) { }

    // TODO
    private void SendBattleRuleData(int stationIndex) { }

    // TODO
    private void RecivePokeData(NetTradePokeData netTradePokeData) { }

    // TODO
    private void StartTalk(UnionOpcController controller, bool IsRecruitment, bool IsTargetCanTalk, OpcState.OnlineState onlineState = OpcState.OnlineState.NONE) { }

    // TODO
    private int GetAvaterId() { return 0; }

    // TODO
    private Vector3 GetStartPos() { return Vector3.zero; }

    // TODO
    private void CancelUIState(INetData talkCancel) { }

    // TODO
    private void OpenTargetTranerCard(TranerData tranerData, int stationIndex) { }

    // TODO
    private void CloseTargetTranerCard() { }

    // TODO
    private void SetNpcTalkBit() { }

    // TODO
    public UnionTradeManager.TargetTranerParam GetTargetTranerParam() { return default; }

    public enum UNION_ERRORSTATE : int
    {
        NONE = 0,
        NETWORK_ERROR = 1,
    }
}