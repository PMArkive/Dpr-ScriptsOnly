using Dpr.NetworkUtils;
using Dpr.SubContents;
using Effect;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColiseumRoomManager : NetUseManager<ColiseumRoomManager>
{
    private const int POSITION_DATA_MAX_SIZE = 12;
    private PosData[] posDataArray;
    private PosData posDataPrev;
    private bool[] sendedPlayerFlagArray;
    private AnswerID[] receivedAnswerArray;
    private bool[] playerReadyFlagArray;
    private int[] playerReadyPointIndexArray;
    private NetworkManager networkManager;
    private Queue<INetData> receivedNetDataQueue;
    private int posDataIndex;
    private NetJoinData netJoinData;
    private NetDataColiseumConfirmEntryData confirmEntryData;
    private NetDataColiseumReplyEntryData replyEntryData;
    private NetPosData netPosData;
    private NetRequestData requestData;
    private NetDataColiseumReadyPointJoinData readyPointJoinData;
    private readonly string FRONT_DESK_CONTROLLER = "FdController";
    private readonly string WARP_OBJ_NAME = "StartPoint";
    private readonly string NPC_OBJ_NAME = "UNION_UNION";
    private const float FADE_OUT_DURATION = 0.3f;
    private const int NPC_TALK_BIT = 15;
    private const int LEAVED_COLISEUM_WORK_VAL = 2;
    private static readonly ZoneID[] enableZones = new ZoneID[1] { ZoneID.UNION03 };
    private ColiseumState coliseumState;
    private ZoneID returnZoneID;
    private GameObject fdControllerObject;
    private ColiseumFrontDeskStateController coliseumFrontController;
    private FieldCharacterEntity frontDeskEntity;
    private GameObject startPointObject;
    private UnionStartPointCollision pointCollision;
    private ShowMessageWindow showMsgWindow;
    private List<BattleReadyPoint> battleReadyPoints = new List<BattleReadyPoint>();
    private int reserveReadyPointIndex;
    private int fixedReadyPointIndex;
    private ColiseumPlayerMove playerMove;
    private Coroutine waitInitCoroutine;
    private BattleModeID battleModeID;
    private bool isEnableInput;
    private bool isCalledFadeOut;
    private readonly EffectFieldID[] LOAD_EFFECT_IDS = new EffectFieldID[4]
    {
        EffectFieldID.EF_F_MARK_SQUARE_BLUE_01, EffectFieldID.EF_F_MARK_SQUARE_BLUE_02,
        EffectFieldID.EF_F_MARK_SQUARE_RED_01,  EffectFieldID.EF_F_MARK_SQUARE_RED_02,
    };
    private Dictionary<int, EffectData> effectDataTable = new Dictionary<int, EffectData>();
    private BattleMatchingManager battleMatchingManager;
    private bool isNetworkError;

    // TODO
    private void InitNetData() { }

    // TODO
    private void ResetNetworkData() { }

    // TODO
    private void ResetCheckEnterReadyPointData() { }

    // TODO
    private void ResetReadyData() { }

    // TODO
    private void ResetNetworkDataByStationIndex(int stationIndex) { }

    // TODO
    private void ReleaseNetData() { }

    // TODO
    private void UpdateNetwork() { }

    // TODO
    private bool EnabledNetwork() { return false; }

    // TODO
    private bool IsPlayingBattle() { return false; }

    // TODO
    private void SendPosData() { }

    // TODO
    private void SendConfirmEntryTeam(int entryNumber) { }

    // TODO
    private void SendJoinData(int stationIndex) { }

    // TODO
    private void SendRequestData(int stationIndex, byte id) { }

    // TODO
    private void SendRequestDataToAll(byte id) { }

    // TODO
    private void SendStandbyPointData(bool isJoin) { }

    // TODO
    private bool CanSendData() { return false; }

    // TODO
    protected override void OnReceiveData(INetData netData) { }

    // TODO
    protected override void SetNetData(INetData netData) { }

    // TODO
    private bool SetNetDataPlayingBattle(INetData netData) { return false; }

    // TODO
    private void OnReceiveConfirmEntryData(NetDataColiseumConfirmEntryData netData) { }

    // TODO
    private void RecieveColiseumReadyPointJoin(NetDataColiseumReadyPointJoinData data) { }

    // TODO
    private void EntryPointMember(int pointIndex, int stationIndex) { }

    // TODO
    private void LeavePointMember(int pointIndex, int stationIndex) { }

    // TODO
    private bool CheckAllPlayerReadyOk() { return false; }

    // TODO
    private bool CheckAllPlayerPointOK() { return false; }

    // TODO
    public int GetHostStationIndex() { return 0; }

    // TODO
    protected override void OnSessionEvent(SessionEventData eventData) { }

    // TODO
    private void JoinMine(int stationIndex) { }

    // TODO
    private void JoinOtherPlayer(int stationIndex) { }

    // TODO
    private void LeaveOtherPlayer(int stationIndex) { }

    // TODO
    private void NetworkError() { }

    // TODO
    private FieldPlayerEntity player { get => EntityManager.activeFieldPlayer; }
    public bool isBattle { get; }

    // TODO
    protected override IEnumerator Start() { return null; }

    // TODO
    protected override IEnumerator LoadAsset() { return null; }

    // TODO
    private void LoadReadyPointEffect(EffectFieldID effectID, Action onFinished) { }

    // TODO
    private void SetUp() { }

    // TODO
    private void CreateWarpCollision() { }

    // TODO
    private void CreateFrontDesk() { }

    // TODO
    private void SetUpColiseum() { }

    // TODO
    private void SetBattleReadyPos(int index, GameObject obj) { }

    // TODO
    protected override void Init() { }

    // TODO
    protected override void OnDestroy() { }

    // TODO
    public override void SetMatchingParam(MatchingParam matchingParam) { }

    // TODO
    public void SetZoneData(ZoneID zoneId, int locIndex, Vector2Int gridPos) { }

    // TODO
    public void SetBattleRule(BattleModeID ruleId) { }

    // TODO
    protected override void MyUpdate(float deltaTime) { }

    // TODO
    private void UpdateStateFREE_MOVE() { }

    // TODO
    private bool CheckContactReadyPoint(out int contactIndex)
    {
        contactIndex = 0;
        return false;
    }

    // TODO
    private void UpdateCHECK_CAN_ENTRY() { }

    // TODO
    private void EntryReadyPoint() { }

    // TODO
    private void MovePlayerToReadyPoint(int hitColNum) { }

    // TODO
    private bool IsNullReadyPoint() { return false; }

    // TODO
    private BattleReadyPoint GetReadyPoint(int index) { return default; }

    // TODO
    private void UpdateWAIT_ENTRY_OTHER() { }

    // TODO
    private void LeavePlayerFromReadyPoint() { }

    // TODO
    private void BattleStart() { }

    // TODO
    private void UpdateWAIT_START_MATCHING() { }

    // TODO
    private void UpdateLEAVE() { }

    // TODO
    private bool CanLeave() { return false; }

    // TODO
    private void UpdateControlPlayer(float deltaTime) { }

    // TODO
    private void OnReadyWait() { }

    // TODO
    private void OnLeaveEnd() { }

    // TODO
    private void EntryPoint(int pointIndex, int stationIndex) { }

    // TODO
    private void LeavePoint(int pointIndex, int stationIndex) { }

    // TODO
    private void DisableNPCTalk() { }

    // TODO
    private void LeaveColiseum() { }

    // TODO
    public void ReturnBattle() { }

    // TODO
    private void ReturnBattleMatching() { }

    // TODO
    private void ChangeState(ColiseumState nextState) { }

    // TODO
    public static void EmitLog(string log, LogType logType = LogType.Log) { }

    public enum ColiseumState : int
    {
        INIT = 0,
        FREE_MOVE = 1,
        CHECK_CAN_ENTRY = 2,
        WAIT_ENTRY_OTHER = 3,
        WAIT_START_MATCHING = 4,
        BATTLE = 5,
        LEAVE = 6,
        END = 7,
        ERROR = 8,
    }

    private enum AnswerID : int
    {
        NG = 0,
        OK = 1,
        NONE = 2,
    }
}