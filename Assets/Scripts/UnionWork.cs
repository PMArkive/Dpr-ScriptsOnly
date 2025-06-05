using DPData;
using Dpr.Message;
using Dpr.NetworkUtils;
using System;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;

public static class UnionWork
{
    public static byte COMMUNITY_MAX_PLAYER_NUM = 8;
    public static byte GLOBAL_MAX_PLAYER_NUM = 16;
    public static byte COLISEUM_MAX_PLAYER_NUM_NOT_MULTI = 2;
    public static byte COLISEUM_MAX_PLAYER_NUM_MULTI = 4;
    public static Vector3 startPos = new Vector3(-7.0f, 0.0f, 10.5f);
    public static Vector3 startPosGlobal = new Vector3(-14.5f, 0.0f, 19.5f);
    public static Vector3 startPosColiseum = new Vector3(-8.0f, 0.0f, 10.0f);
    public static Vector3 fallStartPos = new Vector3(-7.0f, 0.0f, 10.0f);
    public const int PENARTY_COUNTER = 30;
    public const float GURUGURU_HEIGHT_UP = 10;
    public const int DEFAULT_LOCATOR_INDEX = 1;
    public static Vector2Int RETURN_DEFAULT_GRID_POSITION = new Vector2Int(7, 6);
    public static bool isGaming = false;
    public static int tvRecodeTopicCount = 5;
    public const int matchMemberMax = 5;
    public static int hostIndex;
    public static BattleModeID battleMode = 0;
    public static OpcState.OnlineState targetOpcState;
    private static BoxState boxState;
    private static bool isBoxError = false;
    public static ZoneID returnZoneID;
    public static Vector3 position;
    public static Vector2Int returnGridPos;
    public static ZoneID ymenuReturnZoneID;
    public static float ymenuReturnHeight;
    public static Vector2Int ymenuReturnGridPos;
    public static CommunicationState communicationState;
    private static bool isRecruiment;
    private static bool isTalking;
    private static bool isMatchWait = false;
    public static int nowTargetStationIndex;
    public static int nowTargetCassetVersion;
    public const float MaxPenaltyTime = 1800;
    private static float PenaltyTime = 0.0f;

    public static FieldPlayerEntity player { get; }

    // TODO
    public static void SetBoxState(BoxState state) { }

    // TODO
    public static void SetCommunicationState(CommunicationState state) { }

    // TODO
    public static void SetCommunicationState(OpcState.OnlineState opcState) { }

    // TODO
    public static CommunicationState GetCommunicationState() { return CommunicationState.NONE; }

    // TODO
    public static BoxState GetBoxState() { return BoxState.NONE; }

    // TODO
    public static void SetBoxError(bool isError) { }

    // TODO
    public static bool GetBoxError() { return false; }

    // TODO
    public static void SetZoneID(ZoneID zone) { }

    // TODO
    public static ZoneID GetZoneID() { return ZoneID.UNKNOWN; }

    // TODO
    public static void SetReturnPosition(Vector3 pos) { }

    // TODO
    public static void SetReturnGridPosition(Vector2Int gridPos) { }

    // TODO
    public static void SetIsYmenu(bool flag) { }

    // TODO
    public static bool GetIsYmenu() { return false; }

    // TODO
    public static void SetYmenuZoneID(ZoneID zone) { }

    // TODO
    public static ZoneID GetYmenuZoneID() { return ZoneID.UNKNOWN; }

    // TODO
    public static void SetYmenuGridPosition(Vector2Int gridPos) { }

    // TODO
    public static Vector2Int GetYmenuGridPosition() { return Vector2Int.zero; }

    // TODO
    public static void SetYmenuHeight(float height) { }

    // TODO
    public static float GetYmenuHeight() { return 0.0f; }

    // TODO
    public static void SetIsGaming(bool flag) { }

    // TODO
    public static bool GetIsGaming() { return false; }

    // TODO
    public static void SetIsTalk(bool flag) { }

    // TODO
    public static bool GetIsTalk() { return false; }

    // TODO
    public static void SetIsRecruiment(bool flag) { }

    // TODO
    public static bool GetIsRecruiment() { return false; }

    // TODO
    public static void SetBattleMode(BattleModeID battleModeID) { }

    // TODO
    public static BattleModeID GetBattleMode() { return BattleModeID.Single; }

    // TODO
    public static void SetIsMatchWait(bool flag) { }

    // TODO
    public static bool GetIsMatchWait() { return false; }

    // TODO
    public static void SetHostIndex(int index) { }

    // TODO
    public static int GetHostIndex() { return 0; }

    // TODO
    public static float GetReadyPosX(int pointIndex) { return 0.0f; }

    // TODO
    public static float GetReadyPosZ(int pointIndex) { return 0.0f; }

    // TODO
    public static void SetTargetOpcState(OpcState.OnlineState state) { }

    // TODO
    public static OpcState.OnlineState GetTargetOpcState() { return OpcState.OnlineState.NONE; }

    // TODO
    public static int GetMyStationIndex() { return 0; }

    // TODO
    public static string CreateSpeakerName(string userName, MessageEnumData.MsgLangId langId, int cassetVersion) { return null; }

    // TODO
    public static TvRecodeData GetNetRecodeData(TvWork.RecordData recordData) { return default(TvRecodeData); }

    // TODO
    public static TvWork.RecordData GetNetRecodeData(TvRecodeData recordData) { return null; }

    // TODO
    public static TvWork.RecordData GetTvRecodeData(NetDataRecodeData netDataRecode) { return null; }

    // TODO
    public static void SetInitNpcTalk(bool initNpcTalk) { }

    // TODO
    public static void SetPenartyCounter(int penartyCounter) { }

    // TODO
    public static void SetPenartyTime() { }

    // TODO
    public static bool CheckDateTime() { return false; }

    // TODO
    public static PLAYER_NETWORK_DATA GetNetworkData() { return default(PLAYER_NETWORK_DATA); }

    // TODO
    public static void SetNetWorkData(PLAYER_NETWORK_DATA data) { }

    // TODO
    private static void SettingFallParam() { }

    // TODO
    public static void UnionSave() { }

    // TODO
    public static int GetLangId(byte langByte) { return 0; }

    // TODO
    public static void LoadBattleRuleSelectUI() { }

    // TODO
    public static void UnloadBattleRuleSelectUI() { }

    // TODO
    public static bool CheckIsOpenUIWindow() { return false; }

    // TODO
    public static bool CheckNetworkState() { return false; }

    // TODO
    public static IEnumerator WaitNetworkSessionStateGaming(Action<bool> messegeEnabledFunc, [Optional] Action startFunc, [Optional] Action endFunc, [Optional] Action errorFunc) { return null; }

    // TODO
    public static void StartFadeOut() { }

    // TODO
    public static void StartFadeIn() { }

    // TODO
    public static IEnumerator StartFadeOutCallBack(Action fadeOutEnd) { return null; }

    // TODO
    public static IEnumerator Fade([Optional] Action fadeOutEnd, [Optional] Action fadeInEnd) { return null; }

    // TODO
    public static IEnumerator ReStartUnion(Action start, Action clear) { return null; }

    // TODO
    public static void Leave(Action animEndFunc) { }

    // TODO
    public static void StartGuruGuruJoinAnimation([Optional] Action fallEndFinc) { }

    // TODO
    public static void StartGuruGuruLeaveAnimation([Optional] Action risingEndFinc) { }

    // TODO
    public static IEnumerator StartHeight(int height, float upSpeed) { return null; }

    // TODO
    public static IEnumerator LerpLeave(Action animEndFunc) { return null; }

    // TODO
    public static void SetUpKeyGuideUI() { }

    // TODO
    public static void CloseKeyGuideUI() { }

    // TODO
    public static void ShowDebugTextSessionEvent(SessionEventData sessionEvent) { }

    // TODO
    public static void ShowDebugTextSessionStatus() { }

    // TODO
    public static void PlayeSE(uint seId) { }

    // TODO
    public static void SetPenaltyTime() { }

    // TODO
    public static bool IsPenalty() { return false; }

    // TODO
    public static void ResetPenalty() { }

    // TODO
    public static void UpdatePenaltyTime(float deltatime) { }

    // TODO
    public static float GetPenaltyTime() { return 0.0f; }

    public enum LeaveState : int
    {
        LEAVE = 0,
        RESTART = 1,
    }

    public enum ILCA_NET_ERROR_LEVEL : int
    {
        LIGHT_ERROR = 0,
        HEAVY_ERROR_ONE = 1,
        HEAVY_ERROR_TWO = 2,
        NONE = 3,
    }

    public enum BoxState : int
    {
        NONE = 0,
        INVALID_DATA = 1,
        ERROR_SERVER = 2,
        ERROR_MINE = 3,
        ERROR_OTHER = 4,
        CANCEL = 5,
        CANCEL_SELECT = 6,
        CLOSE = 7,
    }

    public enum CommunicationState : int
    {
        NONE = 0,
        BATTLE = 1,
        TRADE = 2,
        RECODE = 3,
        GREETING = 4,
        BALL_DECO = 5,
        COMMUNICATION = 6,
    }

    public struct TvRecodePersonalityData
    {
        public bool isEmpty;
        public int BranchData;
        public TV_STR_DATA PlayerName;
    }

    public struct TvRecodeBallDecorationData
    {
        public bool isEmpty;
        public int BranchData;
        public int Trainer;
    }

    public struct TvRecodeKasekihoriData
    {
        public bool isEmpty;
        public int BranchData;
        public int ItemNo;
        public TV_STR_DATA PlayerName;
    }

    public struct TvRecodeStatueData
    {
        public bool isEmpty;
        public int BranchData;
        public int StatueCount;
        public TV_STR_DATA PlayerName;
    }

    public struct TvRecodeFashionData
    {
        public bool isEmpty;
        public int BranchData;
        public int Style;
        public int PlaceNo;
        public TV_STR_DATA PlayerName;
    }

    public struct TvRecodeData
    {
        public TvRecodePersonalityData tvRecodePersonalityData;
        public TvRecodeBallDecorationData tvRecodeBallDecorationData;
        public TvRecodeKasekihoriData tvRecodeKasekihoriData;
        public TvRecodeStatueData tvRecodeStatueData;
        public TvRecodeFashionData tvRecodeFashionData;
    }
}