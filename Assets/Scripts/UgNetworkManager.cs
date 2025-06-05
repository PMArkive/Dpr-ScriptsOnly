using DPData;
using Dpr.Message;
using Dpr.NetworkUtils;
using Dpr.SubContents;
using INL1;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UgNetworkManager : NetUseManager<UgNetworkManager>
{
	public const int SESSION_PLAYER_MAX_COUNT = 8;

	private PosData[] posDataList = new PosData[12]; // TODO: Find constant for this?
	private int posDataIndex;

	[SerializeField]
	private int Debug_Minute;
	[SerializeField]
	private int Debug_Sec;
	[SerializeField]
	private int Debug_KousekiNum;

	public static IlcaNetSessionNetworkType connectType = IlcaNetSessionNetworkType.Lan;
	public static MatchingType matchingType;
	public static string password;
	public bool isJustJoin = true;
	private int MyStationIndex = -1;
	private bool IsDigTableReady;
	private List<int> IgnoreSendList = new List<int>();
	public Action<INetData> OnReceiveDigFossilNetData;
	public Action<int> OnDigEndOtherPlayer;
	public Action<int> OnLeaveOther;
	public int digFossileMainPlayerStationIndex;
	public Action<bool> OnDigFossilJoinPermission;
	private int DigJoinMemberCount;

    // TODO
    private bool isKousekiBonus { get; }

    // TODO
    private float KousekiBonusTime { get; set; }

    // TODO
    private byte KousekiCount { get; set; }

    // TODO
    private int BonusTimeMinute { get; }

    // TODO
    private int BonusTimeSec { get; }

    // TODO
    private bool IsKousekiFull { get; }

    public int DigTonariMemberCount { set; get; }

    public Action<NetSecretBaseData> OnSecretBaseEnter;
	public List<(int, Vector2Int)> tonarihoriList = new List<(int, Vector2Int)>();
	public bool isMainKasekihori;
	public List<UgOnlinePlayerData> ugOnlinePlayerDatas = new List<UgOnlinePlayerData>(SESSION_PLAYER_MAX_COUNT);
	private bool isSwim;
	private NetDigAttackData netDigAttackData = new NetDigAttackData();
	private NetUgJoinData netJoinData = new NetUgJoinData();
	private NetSecretBaseData netSecretBaseData = new NetSecretBaseData();
	private NetSecretBaseInfo netSecretBaseInfo = new NetSecretBaseInfo();
	private NetSecretBaseUpdate netSecretBaseUpdate = new NetSecretBaseUpdate();
	private NetDigData netDigData = new NetDigData();
	private NetDigJoinData netDigJoinData = new NetDigJoinData();
	private NetJoinDigPermission netJoinDigPermission = new NetJoinDigPermission();
	private NetDigEndData netDigEndData = new NetDigEndData();
	private NetDigJoinMemberCount netDigJoinMemberCount = new NetDigJoinMemberCount();
	private NetRequestData netReqData = new NetRequestData();
	private NetCharacterStateData netStateData = new NetCharacterStateData();
	private NetPlayerNameData netPlayerNameData = new NetPlayerNameData();
	private NetPosData netPosData = new NetPosData();
	private NetPosZoneData netPosZoneData = new NetPosZoneData();
	private NetZoneData netZoneData = new NetZoneData();
	private NetKousekiAdd netKousekiAdd = new NetKousekiAdd();
	private NetBonusStart netBonusStart = new NetBonusStart();
	private NetRemainBonusTime netRemainBonusTime = new NetRemainBonusTime();
	private NetKousekiCount netKousekiCount = new NetKousekiCount();
	private NetNaminoriData netNaminoriData = new NetNaminoriData();
	private NetDigTableData netDigTableData = new NetDigTableData();
	private OpcState.OnlineState ReserveState = OpcState.OnlineState._NULL;

	[SerializeField]
	private int _Debug_SecBase_StationIdx = 1;

	[Button("Debug_OnReceiveSecretBase_Info", "秘密基地生成", new object[0])]
	public int Button01;
	[Button("Debug_OnReceivePlayerNameData", "名前情報受信", new object[0])]
	public int Button02;
	[Button("Debug_OnReceiveDigPointData", "となりほり生成", new object[0])]
	public int Button06;
	
	// TODO
	public void OnZoneChange() { }
	
	// TODO
	private void RemoveNotSameZoneCharacters() { }
	
	// TODO
	protected override void OnSessionEvent(SessionEventData eventData) { }
	
	// TODO
	public void OnCrash() { }
	
	// TODO
	protected override IEnumerator Start() { return default; }
	
	// TODO
	protected override void MyUpdate(float deltaTime) { }
	
	// TODO
	private void OnLeaveOtherPlayer(int stationIndex, bool useExitEffect) { }
	
	// TODO
	protected override void OnDestroy() { }
	
	// TODO
	public override void SetMatchingParam(MatchingParam matchingParam) { }
	
	// TODO
	protected override void Init() { }
	
	// TODO
	public void SetAndSendMyPlayerState(OpcState.OnlineState state) { }
	
	// TODO
	public void SetMyEmoticon(OpcState.OnlineState state)
	{
		// TODO
		bool CheckRecruiment() { return default; }
    }
	
	// TODO
	public OpcState.OnlineState GetMyPlayerState() { return default; }
	
	// TODO
	public void DeleteAllOpcCharacter() { }
	
	// TODO
	public List<OpcController> GetTargetStateOpc(OpcState.OnlineState state) { return default; }
	
	// TODO
	public void SendSecretBaseInfo(ZoneID zoneID) { }
	
	// TODO
	private void SendSecretBaseInfo(int stationIndex) { }
	
	// TODO
	private void SendMyJoinData(int stationIndex) { }
	
	// TODO
	private void SendReqData(int stationIndex, string dataType) { }
	
	// TODO
	public void SendOnZoneChange() { }
	
	// TODO
	private void SendZondeData(int stationIndex) { }
	
	// TODO
	public void SendOnJoinNewPlayer(SessionEventData eventData) { }
	
	// TODO
	public void SendOnOtherPlayerToSameZone(int stationIndex) { }
	
	// TODO
	public void SendSameZone(bool isSendForce = false) { }
	
	// TODO
	public void SendOtherZone() { }
	
	// TODO
	public void SendOnPlayDigFossil(Vector2Int mainPos, DigPos digPos1, DigPos digPos2) { }
	
	// TODO
	public void SendUpdateDigFossil(int stationIndex = -1) { }
	
	// TODO
	public void SendOnJoinDigFossil(int stationIndex, Vector2Int gridPos) { }
	
	// TODO
	public void SendJoinDigPermission(int stationIndex, bool isOK) { }
	
	// TODO
	public void SendDigJoinMemberCount() { }
	
	// TODO
	public void SendOnFinishDigFossil() { }
	
	// TODO
	public void SendDigAttack(Vector2 position, bool isHammer) { }
	
	// TODO
	public void SendOnEnterSecretBase(int stationIndex) { }
	
	// TODO
	public void SendMySecretBaseData(int stationIndex) { }
	
	// TODO
	public void SendMySecretBaseUpdateNotice() { }
	
	// TODO
	public void SendKousekiAdd(int num) { }
	
	// TODO
	public void SendStartKousekiBonus() { }
	
	// TODO
	public void SendRemainBonusTime(int stationIndex) { }
	
	// TODO
	public void SendKousekiNum(int stationIndex) { }
	
	// TODO
	private void SendStateData(int stationIndex) { }
	
	// TODO
	private void SendPlayerNameData(int stationIndex) { }
	
	// TODO
	public void SendToSameZonePlayers<T>(ANetData<T> netData, bool isReliable = true) { }
	
	// TODO
	public void SendToOtherZonePlayers<T>(ANetData<T> netData, bool isReliable) { }
	
	// TODO
	private bool isOtherScene { get; }
	
	// TODO
	protected override void OnReceiveData(INetData netData) { }
	
	// TODO
	private void OnReceiveJoinData(INetData netData) { }
	
	// TODO
	private void OnReceiveStateData(INetData netData) { }
	
	// TODO
	private void OnReceiveZoneData(INetData netData) { }
	
	// TODO
	private void OnReceiveRequestData(INetData netData) { }
	
	// TODO
	private void OnReceiveSecretBase_Info(INetData netData) { }
	
	// TODO
	private void OnReceiveSecretBaseData(INetData netData) { }
	
	// TODO
	private void OnReceiveSecretBaseUpdate(INetData netData) { }
	
	// TODO
	private void OnReceiveNaminoriData(INetData netData) { }
	
	// TODO
	private void OnReceiveDigTableData(INetData netData) { }
	
	// TODO
	private void OnReceiveDigPointData(INetData netData) { }
	
	// TODO
	private void OnReceiveJoinDigPermission(NetJoinDigPermission permission) { }
	
	// TODO
	private void OnReceiveDigJoinData(INetData netData) { }
	
	// TODO
	private void OnReceivePlayerNameData(INetData netData) { }
	
	// TODO
	private void OnReceiveAddKouseki(INetData netData) { }
	
	// TODO
	private void OnReceiveBonusStart(INetData netData) { }
	
	// TODO
	private void OnReceiveRemainBonusTime(INetData netData) { }
	
	// TODO
	private void OnReceiveKousekiCount(INetData netData) { }
	
	// TODO
	public bool SetZoneID(int stationIndex, ZoneID zoneID) { return default; }
	
	// TODO
	public void SetSecretBaseInfo(int stationIndex, PosZoneData ugSecretBaseInfo) { }
	
	// TODO
	public void SetPlayerNameData(int stationIndex, NetPlayerName playerName) { }
	
	// TODO
	public void SetPlayerPosition(int stationIndex, Vector3 pos) { }
	
	// TODO
	protected override IEnumerator LoadAsset() { return default; }
	
	// TODO
	public void ClearTonarihoriList() { }
	
	// TODO
	private void MakeJoinData() { }
	
	// TODO
	private void OnCreateOpc(int stationIndex) { }
	
	// TODO
	private bool CheckJoinTonarihori(NetDigJoinData netData) { return default; }
	
	// TODO
	public void SetReserveEmoticon() { }
	
	// TODO
	public void RedoEmoticon() { }
	
	// TODO
	private void Debug_OnReceiveSecretBase_Info() { }
	
	// TODO
	private void Debug_OnReceivePlayerNameData() { }
	
	// TODO
	private void Debug_OnReceiveDigPointData() { }

	public class UgOnlinePlayerData
	{
		public ZoneID nowZoneID;
		public Vector3 position;
		public PosZoneData secretBaseInfo;
		public PlayerNameData playerNameData = new PlayerNameData();
		public OpcState.OnlineState onlineState;
		public bool isNaminori;
		public bool isJoinTonarihori;
		public bool isEnteredSecretBase;
		
		public bool isNull { get => nowZoneID == ZoneID.C01; }
		
		public UgOnlinePlayerData()
		{
			Clear();
		}
		
		public void Clear()
		{
            nowZoneID = ZoneID.C01;
            playerNameData.nickName = "";
            secretBaseInfo.zoneID = ZoneID.C01;
            playerNameData.genderid = 0;
            playerNameData.lanugageId = 0;
            position = Vector3.zero;
            onlineState = OpcState.OnlineState.NONE;
            isNaminori = false;
            isJoinTonarihori = false;
            isEnteredSecretBase = false;
        }
	}
}