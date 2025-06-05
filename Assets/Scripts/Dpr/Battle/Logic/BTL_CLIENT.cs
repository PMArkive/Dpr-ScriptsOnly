﻿using Pml.PokePara;
using Pml.WazaData;
using Pml;

namespace Dpr.Battle.Logic
{
    public sealed class BTL_CLIENT
    {
        public const int AITRAINER_MSG_MAX = 4;

        private MainModule m_mainModule;
        private BattleEnv m_pBattleEnv;
        private BTL_POKEPARAM m_procPoke;
        private byte m_actCountSum;
        private int m_procActionIndex;
        private BTL_ACTION_PARAM_OBJ m_procActionUIRet = new BTL_ACTION_PARAM_OBJ();
        private int m_currentActionIndex;
        private rec.Data m_recData;
        private rec.Reader m_btlRecReader;
        private RECPLAYER_CONTROL m_recPlayer = new RECPLAYER_CONTROL();
        private ClientMainProc m_mainProc;
        private FieldStatus m_fldSim;
        private ulong m_randContext;
        private Adapter m_adapter;
        private SendDataContainer m_sendDataContainer;
        private SendDataContainer m_receiveDataContainer;
        private Random m_random = new Random();
        private Random m_AIRand = new Random();
        private TrainerMessageManager m_trainerMessageManager;
        private ClientSeq_TrainerMessage m_seq_TrainerMessage;
        private ClientSeq_WinWild m_seq_WinWild;
        private ClientSeq_Capture m_seq_Capture;
        private BattleSimulator m_battleSimulator;
        private BattleDriver m_battleDriver;
        private ServerCommandQueue m_serverCmdQueue;
        private GameTimer m_gameTimer;
        private ServerSendData.CLIENT_LIMIT_TIME m_syncClientTime;
        private ServerSendData.RAIDBOSS_CAPTURE_RESULT m_raidBossCaptureResult;
        private uint m_turnCount;
        private ushort m_EnemyPokeHPBase;
        private SEL_ITEM_WORK[] m_selItemWork = Arrays.InitializeWithDefaultInstances<SEL_ITEM_WORK>((int)BTL_CLIENT_ID.BTL_CLIENT_NUM);
        private byte m_myID;
        private byte m_myType;
        private byte m_myState;
        private bool m_commWaitInfoOn;
        private byte m_bagMode;
        private unsafe byte* m_change_escape_code;
        private bool m_fForceQuitSelAct;
        private byte m_cmdCheckTimingCode;
        private byte[] m_actionCountWork = new byte[(int)BTL_CLIENT_ID.BTL_CLIENT_NUM];
        private byte m_wazaInfoPokeIdx;
        private byte m_wazaInfoWazaIdx;
        private bool m_fAITrainerBGMChanged;
        private bool m_fCommError;
        private bool m_fSelActForceFinish;
        private bool m_fCmdCheckEnable;
        private bool m_fRecPlayEndTimeOver;
        private bool m_fRecPlayEndBufOver;
        private bool m_bRecPlayFadeStarted;
        private bool m_isWaitingAdapterCommand;
        private bool m_isGSelectedThisTurn;
        private bool m_isFirstActionSelectDone;
        private byte m_myChangePokeCnt;
        private byte m_myPuttablePokeCnt;
        private BtlPokePos[] m_myChangePokePos = new BtlPokePos[DefineConstants.BTL_POSIDX_MAX];
        private ushort m_returnDataSerialNumber;
        private ServerSequence m_returnDataServerSeq;
        private ServerRequest m_returnDataServerRequest;
        private unsafe void* m_returnDataPtr;
        private uint m_returnDataSize;
        private unsafe uint* m_dummyReturnData;
        private unsafe ClientSendData.ACTION_SELECT* m_returnData_ActionSelect;
        private unsafe ClientSendData.CLIENT_LIMIT_TIME* m_returnData_ClientLimitTime;
        private unsafe ClientSendData.RAID_BALL_SELECT* m_returnData_RaidBallSelect;
        private ushort m_cmdLimitTime;
        private ushort m_gameLimitTime;
        private ushort m_clientLimitTime;
        private readonly BTL_PARTY m_myParty;
        private byte m_procPokeIdx;
        private byte m_procPokeActIdx;
        private sbyte m_prevPokeIdx;
        private byte m_firstPokeIdx;
        private bool m_fStdMsgChanged;
        private bool m_b1stReadyMsgDisped;
        private BTL_SERVER m_cmdCheckServer;
        private BattleViewBase _m_viewCore;
        private BattleViewBase.ExpGetDesc m_viewExpGetDesc = new BattleViewBase.ExpGetDesc();
        private BattleViewBase.ExpGetResult m_viewExpGetResult = new BattleViewBase.ExpGetResult();
        private BTL_ACTION_PARAM[] m_actionParam = new BTL_ACTION_PARAM[ClientSendData.ACTION_SELECT.ACTIONPARAM_NUM];
        private int[] m_cmdArgs = new int[BattleServerConst.BTL_SERVERCMD_ARG_MAX];
        private VariableArgs m_stdVariableArgs = new VariableArgs();
        private VariableArgs m_tmpVariableArgs;
        private BattleAi m_ai;
        private ushort[] m_AIItem = new ushort[BSP_TRAINER_DATA.USE_ITEM_MAX];
        private sbyte[] m_AIChangeIndex = new sbyte[6]; // TODO: Party size maybe?
        private bool[] m_AITrainerMsgCheckedFlag = new bool[AITRAINER_MSG_MAX];
        private ClientSubProc m_subProc;
        private int m_subSeq;
        private ClientSubProc m_selActProc;
        private int m_selActSeq;
        private BTLV_STRPARAM m_strParam = new BTLV_STRPARAM();
        private BTLV_STRPARAM m_strParamSub = new BTLV_STRPARAM();
        private PokeSelParam m_pokeSelParam = new PokeSelParam();
        private PokeSelResult m_pokeSelResult = new PokeSelResult();
        private ServerCmdProc m_scProc;
        private ServerCommand m_serverCmd;
        private int m_scSeq;
        private BtlPokePos[] m_deadPokePos = new BtlPokePos[DefineConstants.BTL_POSIDX_MAX];
        private bool m_isLiveRecSeedSetup;
        private uint m_liveRecWaitCameraSeq;
        private uint m_liveRecSizeSave;
        private WAZAEFF_SYNCDAMAGE_CMD_WORK m_wazaEffDmgSyncWork = new WAZAEFF_SYNCDAMAGE_CMD_WORK();
        private bool m_bWazaEffectDone;
        private bool m_bSyncEffectDone;
        private FriendshipEffectProc m_frEffectProc = new FriendshipEffectProc();
        private uint m_JK3Joker_PrevTurnAttackToLegends;
        private uint m_JK3Legend_PrevTurnUseKyozyuuzan;

        private const int CHAPTER_CTRL_FRAMES = 45;

        private static readonly check_status_up_item_check_tbl_elem[] check_status_up_item_check_tbl = new check_status_up_item_check_tbl_elem[]
        {
            new check_status_up_item_check_tbl_elem(Pml.Item.ItemData.PrmID.ATTACK_UP,     BTL_POKEPARAM.ValueID.BPP_ATTACK_RANK),
            new check_status_up_item_check_tbl_elem(Pml.Item.ItemData.PrmID.DEFENCE_UP,    BTL_POKEPARAM.ValueID.BPP_DEFENCE_RANK),
            new check_status_up_item_check_tbl_elem(Pml.Item.ItemData.PrmID.SP_ATTACK_UP,  BTL_POKEPARAM.ValueID.BPP_SP_ATTACK_RANK),
            new check_status_up_item_check_tbl_elem(Pml.Item.ItemData.PrmID.SP_DEFENCE_UP, BTL_POKEPARAM.ValueID.BPP_SP_DEFENCE_RANK),
            new check_status_up_item_check_tbl_elem(Pml.Item.ItemData.PrmID.AGILITY_UP,    BTL_POKEPARAM.ValueID.BPP_AGILITY_RANK),
            new check_status_up_item_check_tbl_elem(Pml.Item.ItemData.PrmID.HIT_UP,        BTL_POKEPARAM.ValueID.BPP_HIT_RATIO),
        };
        private static readonly check_cure_sick_item_tbl_elem[] check_cure_sick_item_check_tbl = new check_cure_sick_item_tbl_elem[]
        {
            new check_cure_sick_item_tbl_elem(Pml.Item.ItemData.PrmID.SLEEP_RCV,    WazaSick.WAZASICK_NEMURI),
            new check_cure_sick_item_tbl_elem(Pml.Item.ItemData.PrmID.POISON_RCV,   WazaSick.WAZASICK_DOKU),
            new check_cure_sick_item_tbl_elem(Pml.Item.ItemData.PrmID.BURN_RCV,     WazaSick.WAZASICK_YAKEDO),
            new check_cure_sick_item_tbl_elem(Pml.Item.ItemData.PrmID.ICE_RCV,      WazaSick.WAZASICK_KOORI),
            new check_cure_sick_item_tbl_elem(Pml.Item.ItemData.PrmID.PARALYZE_RCV, WazaSick.WAZASICK_MAHI),
            new check_cure_sick_item_tbl_elem(Pml.Item.ItemData.PrmID.PANIC_RCV,    WazaSick.WAZASICK_KONRAN),
            new check_cure_sick_item_tbl_elem(Pml.Item.ItemData.PrmID.MEROMERO_RCV, WazaSick.WAZASICK_MEROMERO),
        };
        private static sbyte SubProc_UI_SelectAction_trainerMessage_clientID;
        private static TrainerMessageID SubProc_UI_SelectAction_trainerMessage_messageID;

        private int scProc_MSG_StdSE_subSeq;
        private int scProc_MSG_SetSE_subSeq;

        private static readonly getWeatherStartMessageTableElem[] getWeatherStartMessageParamTable = new getWeatherStartMessageTableElem[]
        {
            new getWeatherStartMessageTableElem(BtlWeather.BTL_WEATHER_NONE,       BTL_STRID_STD.ShineStart,      -1),
            new getWeatherStartMessageTableElem(BtlWeather.BTL_WEATHER_SHINE,      BTL_STRID_STD.ShineStart,      BTL_STRID_STD.ShineStart_OnBattleStart),
            new getWeatherStartMessageTableElem(BtlWeather.BTL_WEATHER_RAIN,       BTL_STRID_STD.RainStart,       BTL_STRID_STD.RainStart_OnBattleStart),
            new getWeatherStartMessageTableElem(BtlWeather.BTL_WEATHER_SNOW,       BTL_STRID_STD.SnowStart,       BTL_STRID_STD.SnowStart_OnBattleStart),
            new getWeatherStartMessageTableElem(BtlWeather.BTL_WEATHER_SAND,       BTL_STRID_STD.StormStart,      BTL_STRID_STD.StormStart_OnBattleStart),
            new getWeatherStartMessageTableElem(BtlWeather.BTL_WEATHER_STORM,      BTL_STRID_STD.RainStormStart,  -1),
            new getWeatherStartMessageTableElem(BtlWeather.BTL_WEATHER_DAY,        BTL_STRID_STD.DayStart,        -1),
            new getWeatherStartMessageTableElem(BtlWeather.BTL_WEATHER_TURBULENCE, BTL_STRID_STD.TurbulenceStart, -1),
        };

        private uint scProc_ACT_KinomiPrevWaza_procIdx;
        private int scProc_ACT_FriendshipEffectMsg_effSeq;
        private int scProc_ACT_FriendshipEffectMsg_msgSeq;
        private uint scProc_ACTOP_SwapTokusei_timer;

        private BTL_ACTION_PARAM m_procAction { get => m_actionParam[m_procActionIndex]; }
        private byte m_currentActionCount { get => m_actionCountWork[m_currentActionIndex]; set => m_actionCountWork[m_currentActionIndex] = value; }
        private BattleViewBase m_viewCore { get => _m_viewCore; set => _m_viewCore = value; }

        // TODO
        private void m_viewCore_CMD_EFFECT_DrawEnableTimer(GameTimer.TimerType type, bool enable) { }

        public BTL_CLIENT(MainModule mainModule, BattleEnv pBattleEnv, Adapter adapter, SendDataContainer sendDataContainer, SendDataContainer receiveDataContainer, byte commMode, ushort clientID, byte clientType, BtlBagMode bagMode, bool fRecPlayMode, ulong randSeed)
        {
            unsafe
            {
                m_dummyReturnData =            (uint*)                             BattleUnmanagedMem.Malloc(sizeof(uint));
                m_returnData_ActionSelect =    (ClientSendData.ACTION_SELECT*)     BattleUnmanagedMem.Malloc(sizeof(ClientSendData.ACTION_SELECT));
                m_returnData_ClientLimitTime = (ClientSendData.CLIENT_LIMIT_TIME*) BattleUnmanagedMem.Malloc(sizeof(ClientSendData.CLIENT_LIMIT_TIME));
                m_returnData_RaidBallSelect =  (ClientSendData.RAID_BALL_SELECT*)  BattleUnmanagedMem.Malloc(sizeof(ClientSendData.RAID_BALL_SELECT));
                m_change_escape_code =         (byte*)                             BattleUnmanagedMem.Malloc(sizeof(byte));
            }

            m_pBattleEnv = pBattleEnv;
            m_myID = (byte)clientID;
            m_myType = clientType;
            m_mainModule = mainModule;
            m_procPokeIdx = 0;
            m_viewCore = null;
            m_turnCount = 0;
            m_b1stReadyMsgDisped = false;
            m_isFirstActionSelectDone = false;
            m_tmpVariableArgs = null;

            m_adapter = adapter;
            m_sendDataContainer = sendDataContainer;
            m_receiveDataContainer = receiveDataContainer;
            m_myParty = getPokeCon().GetPartyDataConst(clientID);
            m_serverCmdQueue = new ServerCommandQueue();

            createSimulator();
            createBattleDriver();

            m_gameTimer = new GameTimer();
            m_gameTimer.Initialize();

            m_cmdLimitTime = (ushort)m_mainModule.GetCommandLimitTime();
            m_gameLimitTime = (ushort)m_mainModule.GetGameLimitTime();
            m_clientLimitTime = (ushort)m_mainModule.GetClientLimitTime();

            // Is this right? Compiler did some weird stuff here i think
            m_syncClientTime = default;
            m_raidBossCaptureResult = default;

            m_mainProc = main_Normal;

            m_myState = 0;
            m_cmdCheckServer = null;
            m_commWaitInfoOn = false;
            m_fForceQuitSelAct = false;
            m_cmdCheckTimingCode = 0;
            m_fAITrainerBGMChanged = false;
            m_fCommError = false;
            m_fStdMsgChanged = false;
            m_fCmdCheckEnable = false;
            m_fRecPlayEndTimeOver = false;
            m_fRecPlayEndBufOver = false;
            m_bRecPlayFadeStarted = false;
            m_isWaitingAdapterCommand = false;

            m_random.Initialize();
            m_AIRand.Initialize(randSeed);

            m_fldSim = pBattleEnv.GetFieldStatus();
            m_bagMode = (byte)bagMode;

            RecPlayer_Init(m_recPlayer);

            for (byte i=0; i<m_AIItem.Length; i++)
                m_AIItem[i] = m_mainModule.GetClientUseItem(m_myID, i);

            if (m_myType == (byte)BtlClientType.BTL_CLIENT_TYPE_AI && !fRecPlayMode)
            {
                m_ai = new BattleAi(new BattleAi.SetupParam()
                {
                    mainModule = m_mainModule,
                    pBattleEnv = pBattleEnv,
                    pBattleSimulator = m_battleSimulator,
                    scriptNoBit = m_mainModule.GetClientAIBit(m_myID),
                    randSeed = randSeed,
                    myClientID = (byte)clientID,
                });
            }
            else
            {
                m_ai = null;
            }

            for (int i=0; i<m_AITrainerMsgCheckedFlag.Length; i++)
                m_AITrainerMsgCheckedFlag[i] = false;

            if (m_myType == (byte)BtlClientType.BTL_CLIENT_TYPE_UI && m_mainModule.IsRecordEnable())
                m_recData = new rec.Data();
            else
                m_recData = null;

            if (m_mainModule.IsPlayerSide(m_mainModule.GetClientSide(m_myID)))
                m_mainModule.SetTvNaviData_FrontPoke(m_myParty.GetMemberDataConst(0), m_myParty.GetMemberDataConst(1));

            m_trainerMessageManager = new TrainerMessageManager(m_mainModule);
            m_seq_TrainerMessage = new ClientSeq_TrainerMessage();
            m_seq_WinWild = new ClientSeq_WinWild();
            m_seq_Capture = new ClientSeq_Capture();
            m_viewExpGetDesc.iPtrParty = new PokeParty();

            m_isLiveRecSeedSetup = false;
            m_liveRecWaitCameraSeq = 0;
            m_liveRecSizeSave = 0;
            m_JK3Joker_PrevTurnAttackToLegends = 0;
            m_JK3Legend_PrevTurnUseKyozyuuzan = 0;
        }

        // TODO
        private void createSimulator() { }

        // TODO
        private void createBattleDriver() { }

        // TODO
        public void Dispose() { }

        private POKECON getPokeCon()
        {
            return m_pBattleEnv.GetPokeCon();
        }

        // TODO
        private ServerCommandExecutor getServerCmdExecutor() { return null; }

        // TODO
        private void changeMainProc(ClientMainProc proc) { }

        // TODO
        private byte getMyCoverPosNum() { return 0; }

        // TODO
        public bool IsWaitingAdapterCommand() { return false; }

        // TODO
        private bool main_Normal() { return false; }

        // TODO
        private bool main_ChapterSkip() { return false; }

        // TODO
        public unsafe void registerReceivedData(ushort serialNumber, ServerSequence serverSeq, ServerRequest serverReq, in void* data, uint dataSize) { }

        // TODO
        private bool returnToServer() { return false; }

        private void RecPlayer_Init(RECPLAYER_CONTROL ctrl)
        {
            ctrl.skipTurnCount = 0;
            ctrl.seq = 0;
            ctrl.ctrlCode = 0;
            ctrl.fChapterSkip = false;
            ctrl.fFadeOutStart = false;
            ctrl.fFadeOutDone = false;
            ctrl.fTurnIncrement = false;
            ctrl.fLock = false;
            ctrl.fQuit = false;
            ctrl.handlingTimer = 0;
            ctrl.turnCount = 0;
            ctrl.nextTurnCount = 0;
            ctrl.maxTurnCount = 0;
        }

        // TODO
        private void RecPlayer_Setup(RECPLAYER_CONTROL ctrl, uint turnCnt) { }

        // TODO
        private bool RecPlayer_CheckBlackOut(RECPLAYER_CONTROL ctrl) { return false; }

        // TODO
        private void RecPlayer_TurnIncReq(RECPLAYER_CONTROL ctrl) { }

        // TODO
        private RecCtrlCode RecPlayer_GetCtrlCode(RECPLAYER_CONTROL ctrl) { return RecCtrlCode.RECCTRL_NONE; }

        // TODO
        private void RecPlayer_ChapterSkipOn(RECPLAYER_CONTROL ctrl, uint nextTurnNum) { }

        // TODO
        private void RecPlayer_ChapterSkipOff(RECPLAYER_CONTROL ctrl) { }

        // TODO
        private bool RecPlayer_CheckChapterSkipEnd(RECPLAYER_CONTROL ctrl) { return false; }

        // TODO
        private uint RecPlayer_GetNextTurn(RECPLAYER_CONTROL ctrl) { return 0; }

        // TODO
        private bool RecPlayerCtrl_Lock(RECPLAYER_CONTROL ctrl) { return false; }

        // TODO
        private void RecPlayerCtrl_Unlock(RECPLAYER_CONTROL ctrl) { }

        // TODO
        private void RecPlayer_Quit(RECPLAYER_CONTROL ctrl) { }

        // TODO
        private bool RecPlayer_IsActive(RECPLAYER_CONTROL ctrl) { return false; }

        // TODO
        private void RecPlayerCtrl_Main(RECPLAYER_CONTROL ctrl) { }

        // TODO
        private void AIItem_Setup() { }

        // TODO
        private ushort AIItem_CheckUse(BTL_POKEPARAM bpp, BTL_PARTY party) { return 0; }

        // TODO
        private bool check_status_up_item(ushort itemID, BTL_POKEPARAM bpp) { return false; }

        // TODO
        private bool check_cure_sick_item(ushort itemID, BTL_POKEPARAM bpp) { return false; }

        // TODO
        public void SetRecordPlayerMode(rec.Reader recReader) { }

        // TODO
        public void NotifyCommError() { }

        // TODO
        public unsafe void* GetRecordData(ref uint size) { return null; }

        // TODO
        public void AttachViewCore(BattleViewBase viewCore) { }

        // TODO
        public void AttachCmdCheckServer(BTL_SERVER server) { }

        // TODO
        public void DetachCmdCheckServer() { }

        // TODO
        public Adapter GetAdapter() { return null; }

        // TODO
        public GameTimer GetGameTimer() { return null; }

        // TODO
        public uint GetSyncClientTime(BTL_CLIENT_ID clientID) { return 0; }

        // TODO
        public void SetSyncClientTime(in ServerSendData.CLIENT_LIMIT_TIME time) { }

        // TODO
        public bool Main() { return false; }

        // TODO
        public void NotifyFadeoutStartForRecPlay() { }

        // TODO
        public void SetChapterSkip(uint nextTurnNum) { }

        // TODO
        public void StopChapterSkip() { }

        // TODO
        public bool IsRecPlayerMode() { return false; }

        // TODO
        public uint GetRecPlayerMaxChapter() { return 0; }

        // TODO
        public bool IsChapterSkipMode() { return false; }

        // TODO
        private void setDummyReturnData() { }

        // TODO
        private bool setSubProc(ServerRequest serverReq, out bool fRecCtrlLock)
        {
            fRecCtrlLock = false;
            return false;
        }

        // TODO
        private bool callSubProc() { return false; }

        // TODO
        public bool IsGameTimeOver() { return false; }

        // TODO
        public bool IsRecPlayBufOver() { return false; }

        // TODO
        private bool SubProc_UI_Setup(ref int seq) { return false; }

        // TODO
        private bool SubProc_AI_Setup(ref int seq) { return false; }

        // TODO
        private bool SubProc_REC_Setup(ref int seq) { return false; }

        // TODO
        private void enemyPokeHPBase_Update() { }

        // TODO
        private uint enemyPokeHPBase_CheckRatio() { return 0; }

        // TODO
        private BTL_POKEPARAM enemyPokeHPBase_GetTargetPoke() { return null; }

        // TODO
        private void startGameTimeCountDown() { }

        // TODO
        private void cmdLimit_Start() { }

        // TODO
        private bool cmdLimit_CheckOver() { return false; }

        // TODO
        private bool checkSelactForceQuit(ClientSubProc nextProc) { return false; }

        // TODO
        private void cmdLimit_End() { }

        // TODO
        private bool cmdComm_checkError() { return false; }

        // TODO
        private bool setupSelectStartStr(BTL_POKEPARAM procPoke, BTLV_STRPARAM strParam) { return false; }

        // TODO
        private bool checkFriendshipSpecialMessage(BTL_POKEPARAM procPoke, BTLV_STRPARAM strParam) { return false; }

        // TODO
        private void selActSubProc_Set(ClientSubProc proc) { }

        // TODO
        private bool selActSubProc_Call() { return false; }

        // TODO
        private bool SubProc_UI_SelectAction(ref int seq) { return false; }

        // TODO
        private void onFirstActionSelectStart() { }

        // TODO
        private bool needDisplayTipsForG() { return false; }

        // TODO
        private bool isRandomWaitCameraEnable() { return false; }

        // TODO
        private bool DecideTrainerMessage_OnSelectAction(ref sbyte clientID, ref TrainerMessageID messageID) { return false; }

        // TODO
        private sbyte DecideTrainerMessage_OnSelectAction_FirstDamage() { return 0; }

        // TODO
        private bool IsTrainerMessageEnable_OnSelectAction_FirstDamage(byte clientID) { return false; }

        // TODO
        private sbyte DecideTrainerMessage_OnSelectAction_LastPokeHpHalf() { return 0; }

        // TODO
        private bool IsTrainerMessageEnable_OnSelectAction_LastPokeHpHalf(byte clientID) { return false; }

        // TODO
        private bool SubProc_REC_SelectAction(ref int seq) { return false; }

        // TODO
        private void setNullActionRecplay() { }

        // TODO
        private bool selact_Start(ref int seq) { return false; }

        // TODO
        private void selact_startMsg(BTLV_STRPARAM strParam) { }

        // TODO
        private void selact_ClearWorks() { }

        // TODO
        private bool selact_ForceQuit(ref int seq) { return false; }

        // TODO
        private void setActionForce(ref BTL_ACTION_PARAM pActionParam, BTL_POKEPARAM poke) { }

        // TODO
        private bool selact_Root(ref int seq) { return false; }

        // TODO
        private void setupSelectActionUIParam(BattleViewBase.SelectActionParam pViewParam, BTL_POKEPARAM pActPoke, byte actPokeIdx) { }

        // TODO
        private byte calcAddActionCountSum(byte pokeIdx) { return 0; }

        // TODO
        private void setupCurrentPokeActionPtr() { }

        // TODO
        private bool selact_root_start(ref int seq) { return false; }

        // TODO
        private void incrementAddActionCount() { }

        // TODO
        private void decrementAddActionCount() { }

        // TODO
        private bool selact_root_friendship_msg_wait(ref int seq) { return false; }

        // TODO
        private bool selact_root_wait_msg_check(ref int seq) { return false; }

        // TODO
        private bool selact_root_sel_main(ref int seq) { return false; }

        // TODO
        private bool canStartG(BTL_POKEPARAM pPoke) { return false; }

        // TODO
        private bool selact_Fight(ref int seq) { return false; }

        // TODO
        private bool needGButtonDisplay(BTL_POKEPARAM pActPoke) { return false; }

        // TODO
        private bool selact_SelectChangePokemon(ref int seq) { return false; }

        // TODO
        private bool selact_Item(ref int seq) { return false; }

        // TODO
        private bool canSelectItem(BTLV_STRPARAM pCantMessage) { return false; }

        // TODO
        private bool canUseItem(BTLV_STRPARAM pCantMessage, ushort itemno, byte procPokeIdx) { return false; }

        // TODO
        private bool canUseBall(BTLV_STRPARAM pCantMessage, ushort itemno, byte procPokeIdx) { return false; }

        // TODO
        private void registerLastSelectedBall(uint itemno) { }

        // TODO
        private BTL_POKEPARAM getBallTarget() { return null; }

        // TODO
        private bool checkBallTargetHide() { return false; }

        // TODO
        private bool selact_Escape(ref int seq) { return false; }

        // TODO
        private bool canSelectEscape(BTLV_STRPARAM pCantMessage) { return false; }

        // TODO
        private bool needEscapeConfirm(BTLV_STRPARAM pConfirmMessage) { return false; }

        // TODO
        private bool selact_CheckFinish(ref int seq) { return false; }

        // TODO
        private void setupSelActReturnData() { }

        // TODO
        private void storeActionSelectSendData(BTL_ACTION_PARAM[] actionParamArray, uint actionNum) { }

        // TODO
        private unsafe void storeActionSelectSendData(BTL_ACTION_PARAM* actionParamArray, uint actionNum) { }

        // TODO
        private void sendSelectedRaidActionIconID() { }

        // TODO
        private void clearSelectedRaidActionIconID() { }

        // TODO
        private bool selact_Finish(ref int seq) { return false; }

        // TODO
        private void selItemWork_Init() { }

        // TODO
        private void selItemWork_Reserve(byte pokeIdx, ushort itemID, bool bFromPokeSelect) { }

        // TODO
        private bool selItemWork_IsFromPokeSelect(byte pokeIdx) { return false; }

        // TODO
        private void selItemWork_Restore(byte pokeIdx) { }

        // TODO
        private void selItemWork_Quit() { }

        // TODO
        private bool checkActionForceSet(BTL_POKEPARAM bpp, ref BTL_ACTION_PARAM action) { return false; }

        // TODO
        public bool IsCheerMode() { return false; }

        // TODO
        private bool checkWazaForceSet(BTL_POKEPARAM bpp, ref BTL_ACTION_PARAM action) { return false; }

        // TODO
        private void setWaruagakiAction(ref BTL_ACTION_PARAM dst, BTL_POKEPARAM bpp) { }

        // TODO
        private bool is_unselectable_waza(BTL_POKEPARAM bpp, WazaNo waza, BTLV_STRPARAM strParam) { return false; }

        // TODO
        private bool is_unselectable_target(BTL_POKEPARAM bpp, WazaNo waza, BtlPokePos targetPos, BTLV_STRPARAM strParam) { return false; }

        // TODO
        private byte storeSelectableWazaFlag(BTL_POKEPARAM bpp, bool checkGWaza, bool[] dst) { return 0; }

        // TODO
        public CantEscapeCode isForbidPokeChange(BTL_POKEPARAM procPoke, out byte pokeID, out ushort tokuseiID)
        {
            pokeID = 0;
            tokuseiID = 0;
            return CantEscapeCode.CANTESC_START;
        }

        // TODO
        public CantEscapeCode isForbidEscape(ref byte pokeID, ref ushort tokuseiID) { return CantEscapeCode.CANTESC_START; }

        // TODO
        private CantEscapeCode checkForbidChangeEscapeCommon(BTL_POKEPARAM procPoke, ref byte pokeID, ref ushort tokuseiID) { return CantEscapeCode.CANTESC_START; }

        // TODO
        private bool checkForbitEscapeEffective_Kagefumi(BTL_POKEPARAM procPoke) { return false; }

        // TODO
        private bool checkForbitEscapeEffective_Arijigoku(BTL_POKEPARAM procPoke) { return false; }

        // TODO
        private bool checkForbitEscapeEffective_Jiryoku(BTL_POKEPARAM procPoke) { return false; }

        // TODO
        private void changeAI_InitWork() { }

        // TODO
        public bool changeAI_CheckReserve(byte pokeIndexWithinParty) { return false; }

        // TODO
        private void changeAI_SetReserve(byte outPokeIdx, byte inPokeIdx) { }

        // TODO
        public bool IsPuttablePokemonExist() { return false; }

        // TODO
        private BTL_POKEPARAM changeAI_SupposeEnemy(BtlPokePos basePos) { return null; }

        // TODO
        private bool SubProc_AI_SelectAction(ref int seq) { return false; }

        // TODO
        private byte getAIPokeActNum(BTL_POKEPARAM pPoke) { return 0; }

        // TODO
        private BTL_ACTION_PARAM buildActionParamFromAiResult(ref BTL_ACTION_PARAM actionParam, byte actPokeIndex, BTL_POKEPARAM actPoke, BTL_PARTY actPokeParty, in BattleAi.Result aiResult) { return default; }

        // TODO
        private void buildActionParamFromAiResult_Fight(ref BTL_ACTION_PARAM actionParam, BTL_POKEPARAM actPoke, in BattleAi.Result aiResult) { }

        // TODO
        private void buildActionParam_Safari(ref BTL_ACTION_PARAM actionParam, byte actPokeIndex, BTL_POKEPARAM actPoke) { }

        // TODO
        private bool canStartGForNPC(BTL_POKEPARAM pActPoke) { return false; }

        // TODO
        private void decideRaidBossGWazaAction(ref BTL_ACTION_PARAM destAction) { }

        // TODO
        private BtlPokePos decideRaidBossGWazaTarget() { return BtlPokePos.POS_1ST_0; }

        // TODO
        private void correctRaidBossGWazaTarget_JK3(RaidBoss.SelectTargetParam pSelectParam) { }

        // TODO
        private WazaNo decideRaidBossWaza(BTL_POKEPARAM boss, BTL_POKEPARAM target) { return WazaNo.AAMUHANMAA; }

        // TODO
        private bool isRaidBossGWazaUseTurn(BTL_POKEPARAM boss) { return false; }

        // TODO
        private bool canRaidBossUseGWazaIfNotG(BTL_POKEPARAM boss) { return false; }

        // TODO
        public byte countPuttablePokemons(byte[] list) { return 0; }

        // TODO
        private byte countPuttablePokemons_sub(byte[] list, byte numFrontPos) { return 0; }

        // TODO
        private unsafe void sortPuttablePokemonList(byte* list, byte numPoke, BTL_POKEPARAM target, BtlPokePos posForCheckEffect) { }

        // TODO
        private bool changeAI_IsSpecialMons(BTL_POKEPARAM bpp) { return false; }

        // TODO
        private bool isExistHPRecoverEffect(BtlPokePos pos) { return false; }

        // TODO
        private void setupPokeSelParam(byte numSelect, PokeSelParam param, PokeSelResult result) { }

        // TODO
        private void storePokeSelResult(PokeSelResult res) { }

        // TODO
        private void storePokeSelResult_ForceQuit() { }

        // TODO
        private byte storeMyChangePokePos(BtlPokePos[] myCoverPos) { return 0; }

        // TODO
        private bool SubProc_UI_SelectChangeOrEscape(ref int seq) { return false; }

        // TODO
        private bool SubProc_UI_SelectPokemonForCover(ref int seq) { return false; }

        // TODO
        private bool SubProc_UI_SelectPokemonForChange(ref int seq) { return false; }

        // TODO
        private bool SubProc_AI_SelectPokemon(ref int seq) { return false; }

        // TODO
        private void sortChangePos(BtlPokePos[] posAry, uint posCnt) { }

        // TODO
        private bool SubProc_REC_SelectPokemon(ref int seq) { return false; }

        // TODO
        private bool selectPokemonUI_Core(ref int seq, bool bForceChangeMode) { return false; }

        // TODO
        private bool SubProc_UI_ConfirmIrekae(ref int seq) { return false; }

        // TODO
        private bool SubProc_UI_RecordData(ref int seq) { return false; }

        // TODO
        private bool SubProc_REC_ExitCommTrainer(ref int seq) { return false; }

        // TODO
        private bool SubProc_UI_ExitCommTrainer(ref int seq) { return false; }

        // TODO
        private bool SubProc_ExitCommTrainer(ref int seq, bool isRecPlayMode) { return false; }

        // TODO
        private BtlResult expandServerResult(out ResultCause resultCause)
        {
            resultCause = ResultCause.RESULT_CAUSE_TIMEOVER;
            return BtlResult.BTL_RESULT_LOSE;
        }

        // TODO
        private bool getVsCommTrainerExitMessage(BTLV_STRPARAM strParam, BtlResult battleResult, bool isMultiMode) { return false; }

        // TODO
        private bool isEnemyClientDouble() { return false; }

        // TODO
        private void trainerGraphicIn(int client_idx) { }

        // TODO
        private void msgWinningTrainerStart() { }

        // TODO
        private bool SubProc_REC_ExitForNPC(ref int seq) { return false; }

        // TODO
        private bool SubProc_UI_ExitForNPC(ref int seq) { return false; }

        // TODO
        private bool SubProc_REC_ExitForSubwayTrainer(ref int seq) { return false; }

        // TODO
        private bool SubProc_UI_ExitForSubwayTrainer(ref int seq) { return false; }

        // TODO
        private bool SubProc_ExitForSubwayTrainer(ref int seq, bool isRecPlayMode) { return false; }

        // TODO
        private void setupSubwayTrainerMsg(BtlResult result, byte client_idx) { }

        // TODO
        public void GetBonusMoneyGettingStr(BTLV_STRPARAM strParam, uint bonus) { }

        // TODO
        private void setBonusMoneyGettingStr(BTLV_STRPARAM strParam, uint bonus) { }

        // TODO
        private bool SubProc_UI_WinWild(ref int seq) { return false; }

        // TODO
        private bool SubProc_UI_LoseWild(ref int seq) { return false; }

        // TODO
        private bool SubProc_UI_ForceQuitWild(ref int seq) { return false; }

        // TODO
        private bool SubProc_UI_CaptureWild(ref int seq) { return false; }

        // TODO
        private bool SubProc_UI_NotifyTimeUp(ref int seq) { return false; }

        // TODO
        private void getTimeUpMessage(out uint strID, out BtlStrType strType)
        {
            strID = 0;
            strType = BtlStrType.BTL_STRTYPE_NULL;
        }

        // TODO
        private void getTimeUpMessage_ClientLimitTime(out uint strID, out BtlStrType strType)
        {
            strID = 0;
            strType = BtlStrType.BTL_STRTYPE_NULL;
        }

        // TODO
        private bool SubProc_UI_FadeOut(ref int seq) { return false; }

        // TODO
        private bool SubProc_REC_FadeOut(ref int seq) { return false; }

        // TODO
        public bool isEvolveEnablePokeExsist() { return false; }

        // TODO
        private bool SubProc_UI_SendLastDataAgain(ref int seq) { return false; }

        // TODO
        private bool SubProc_UI_SendClientLimitTime(ref int seq) { return false; }

        // TODO
        private bool SubProc_UI_SyncClientLimitTime(ref int seq) { return false; }

        // TODO
        private bool SubProc_UI_RaidBossCapture_Start(ref int seq) { return false; }

        // TODO
        private uint getRaidBossCaptureStartSeqNo() { return 0; }

        // TODO
        private bool SubProc_UI_RaidBossCapture_SelectBall(ref int seq) { return false; }

        // TODO
        private bool SubProc_UI_RaidBossCapture_Result(ref int seq) { return false; }

        // TODO
        private bool SubProc_UI_LoseRaid(ref int seq) { return false; }

        // TODO
        private bool SubProc_REC_ServerCmd(ref int seq) { return false; }

        // TODO
        private ServerCmdProc dispatchServerCmdProc(ServerCommand cmd) { return null; }

        // TODO
        private bool SubProc_UI_ServerCmd(ref int seq) { return false; }

        // TODO
        private bool SubProc_AI_ServerCmd(ref int seq) { return false; }

        // TODO
        private void storeWazaEffectSyncDamageParams(WAZAEFF_SYNCDAMAGE_CMD_WORK work, ServerCommand[] pTargetCmdList) { }

        // TODO
        private bool putWazaEffSyncDamage(WAZAEFF_SYNCDAMAGE_CMD_WORK work) { return false; }

        // TODO
        private bool scProc_ACT_MemberOutMsg(ref int seq, int[] args) { return false; }

        // TODO
        private ushort checkMemberOutStrID(byte clientID, byte pokeID, out bool fClientArg)
        {
            fClientArg = false;
            return 0;
        }

        // TODO
        private bool scProc_ACT_MemberOut(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_MemberIn(ref int seq, int[] args) { return false; }

        // TODO
        private bool IsTrainerMessageEnable_OnLastPokeIn(byte clientID) { return false; }

        // TODO
        private void StartTrainerMessage(byte clientID, TrainerMessageID messageID) { }

        // TODO
        private bool UpdateTrainerMessage() { return false; }

        // TODO
        private ushort checkMemberPutStrID(BTL_POKEPARAM putPoke) { return 0; }

        // TODO
        private ushort getMemberPutStrID(BTL_POKEPARAM putPoke, BTL_POKEPARAM opponentPoke) { return 0; }

        // TODO
        private bool scProc_MSG_Std(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_MSG_StdSE(ref int seq, int[] args) { return false; }

        // TODO
        private unsafe bool scproc_msgStdCore(ref int seq, ushort strID, int* args, int argsLen) { return false; }

        // TODO
        private bool scProc_MSG_Set(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_MSG_SetSE(ref int seq, int[] args) { return false; }

        // TODO
        private unsafe bool scproc_msgSetCore(ref int seq, ushort strID, int* args, int argsLen) { return false; }

        // TODO
        private bool scProc_MSG_Waza(ref int seq, int[] args) { return false; }

        // TODO
        private bool needWazaMessageDisplay(WazaNo wazano, WazaTarget wazaRange, BtlPokePos attackerPos, BtlPokePos targetPos) { return false; }

        // TODO
        private bool scProc_ACT_WazaEffect(ref int seq, int[] args) { return false; }

        // TODO
        private WazaEffectCmdProcResult scproc_wazaEffProc_Start(int[] args) { return WazaEffectCmdProcResult.WAZAEFF_CMD_RESULT_NO_PROC; }

        // TODO
        private bool wazaEff_IsOmitFriendAttackEffect(WazaNo waza, WazaTarget wazaRange, BtlPokePos atkPokePos, BtlPokePos defPokePos) { return false; }

        // TODO
        private WazaTarget checkWazaRange(WazaNo waza, BtlPokePos atPokePos) { return WazaTarget.TARGET_OTHER_SELECT; }

        // TODO
        private bool scProc_ACT_TameWazaHide(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_WazaDmg(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_WazaDmg_Plural(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_WazaIchigeki(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_SickIcon(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_ConfDamage(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_Dead(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_Relive(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_RankDown(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_RankUp(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_IncWeatherPassedTurn(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_SetSpActPriority(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_SetActionRecord(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_AddEscapeInfo(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_GWallBreak(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_GWallGaugeAdd(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_GWallGaugeSub(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_GWallGaugeInit(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_GWallDecRepairTurn(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_GWallRepair(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_G_Start(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_G_End(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_G_IncTurn(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_GGauge_Inc(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_GGauge_Empty(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_RaidBoss_DecReinforceTurn(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_RaidBoss_SetReinforceTurn(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_RaidBoss_SetAngry(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_RaidBoss_GWazaUseSchedule_DecTurn(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_RaidBoss_GWazaUseSchedule_SetUsed(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_RaidBoss_GWazaUseSchedule_Reset(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_GRights_Transfer(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_GRights_Invalidate(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_GRights_IncTurn(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_GRights_Get(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_GRights_Get_MySelf(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_GRights_Get_Others(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_RaidBattleStatus_IncAllDeadCount(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_RaidBattleStatus_IncTurnCountAfterAllDead(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_RaidBattleStatus_ResetTurnCountAfterAllDead(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_RaidResult(ref int seq, int[] args) { return false; }

        // TODO
        private void setupRaidRewardParam(BattleViewBase.RaidRewardParam pRewardParam) { }

        // TODO
        private bool scProc_ACT_SummarizedGShockEffect(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACTOP_BattleTalk(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_TurnStart(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_G_Start(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_G_End(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACTOP_WeatherStart(ref int seq, int[] args) { return false; }

        // TODO
        private bool needWeatherStartEffect(ChangeWeatherCause cause) { return false; }

        // TODO
        private int getWeatherStartMessage(BtlWeather weather, ChangeWeatherCause cause) { return 0; }

        // TODO
        private bool scProc_ACT_WeatherEnd(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_WeatherEnd(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_SimpleHP(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_UseItem(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_KinomiPrevWaza(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_Kill(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_Move(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_Move(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_MigawariCreate(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_MigawariDelete(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_Hensin(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_Hensin(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_MigawariDamage(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_PlayWinBGM(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_MsgWinHide(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_FriendshipEffect(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_FriendshipEffectMsg(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_Exp_InitParam(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_Exp_AddParam(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_Exp(ref int seq, int[] args) { return false; }

        // TODO
        private void updatePokeParamByLevelUp(in BattleViewBase.ExpGetResult result) { }

        // TODO
        private bool copyWaza(PokemonParam pDest, PokemonParam pSrc) { return false; }

        // TODO
        private bool scProc_OP_AddExp(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ExArg(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ExAssignClient_Start(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_AddWazaHandler(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_RemoveWazaHandler(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_RemoveForceWazaHandler(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_RemoveForceAllWazaHandler(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_AddTokuseiHandler(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_RemoveTokuseiHandler(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_SwapTokuseiHandler(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_AddItemHandler(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_RemoveItemHandler(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_AddPosHandler(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_RemovePosHandler(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_AddSideHandler(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_RemoveSideHandler(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_SleepSideHandler(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_WakeSideHandler(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_AddFieldHandler(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_RemoveFieldHandler(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_AddDefaultPowerUpHandler(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_RemoveDefaultPowerUpHandler(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_AddRaidBossHandler(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_RemoveRaidBossHandler(ref int seq, int[] args) { return false; }

        // TODO
        public bool PrintCallback(PrintCallbackArg arg) { return false; }

        // TODO
        private bool scProc_ACT_BallThrow(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_BallThrowCaptured(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_BallThrowForbidden(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACTOP_ChangeTokusei(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACTOP_SwapTokusei(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_FakeDisable(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_EffectSimple(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_EffectByPos(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_PluralEx2ndHit(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_EffectByVector(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_EffectBySide(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_EffectField(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_ChangeForm(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_ChangeForm(ref int seq, int[] args) { return false; }

        // TODO
        private void updateClientPublicInformation_FormNo(in BTL_POKEPARAM poke) { }

        // TODO
        private bool scProc_TOKWIN_In(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_TOKWIN_Out(ref int seq, int[] args) { return false; }

        // TODO
        private void notifyTokuseiToAI(byte pokeID) { }

        // TODO
        private bool scProc_OP_HpMinus(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_HpPlus(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_PPMinus(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_PPMinus_Org(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_WazaUsed(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_IncWazaUsedCount(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_IncWazaKillCount(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_HpZero(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_PPPlus(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_PPPlus_Org(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_RankUp(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_RankDown(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_RankSet8(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_RankRecover(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_RankReset(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_RankUpReset(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_AddCritical(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_SickSet(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_CurePokeSick(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_CureWazaSick(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_MemberIn(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_ChangePokeType(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_ExPokeType(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_WSTurnCheck(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_ConsumeItem(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_UpdateUseWaza(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_SetContFlag(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_ResetContFlag(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_SetTurnFlag(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_ResetTurnFlag(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_SetPermFlag(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_SetBattleFlag(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_RemoveBattleFlag(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_IncBattleCount_Unique(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_IncBattleCount_Client(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_IncBattleCount_Side(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_IncPokeTurnCount(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_ChangeTokusei(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_SetItem(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_UpdateWazaNumber(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_OutClear(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_DeadClear(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_AddFldEff(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_AddFldEffDepend(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_ChangeGround(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_DelFldEffDepend(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_RemoveFldEff(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_SetPokeCounter(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_SetPokePermCounter(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_AddPokePermCounter(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_IncKillCount(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_BatonTouch(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_MigawariCreate(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_MigawariDelete(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_SetFakeSrc(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_FakeDisable(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_ClearConsumedItem(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_CureSickDependPoke(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_AddWazaDamage(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_TurnCheck(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_IncFieldTurn(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_SetDoryoku(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_AddEffort_G(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_StartPosEff(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_RemovePosEff(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_UpdatePosEffectParam(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_PGLRecord(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_SideEffect_Add(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_SideEffect_Remove(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_SideEffect_IncTurnCount(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_SideEffect_Swap(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_PublishClientInformation_AppaearPokemon(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_PublishClientInformation_HavePokemonItem(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_SetStatus(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_SetWeight(ref int seq, int[] args) { return false; }

        // TODO
        private VariableArgs PushTmpVariableArgsWork(VariableArgs newArgs) { return null; }

        // TODO
        private void PopTmpVariableArgsWork(VariableArgs oldArgs) { }

        // TODO
        private byte GetVariableArgsCount() { return 0; }

        // TODO
        private int GetVariableArgs(byte idx) { return 0; }

        // TODO
        public byte GetClientID() { return 0; }

        // TODO
        public BTL_PARTY GetParty() { return null; }

        // TODO
        public BtlWeather GetWeather() { return BtlWeather.BTL_WEATHER_NONE; }

        // TODO
        public uint GetTurnCount() { return 0; }

        // TODO
        public BtlPokePos GetProcPokePos() { return BtlPokePos.POS_1ST_0; }

        // TODO
        public bool IsUnselectableWaza(BTL_POKEPARAM bpp, WazaNo waza) { return false; }

        // TODO
        private bool scProc_OP_DecBattleCount_Unique(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_Safari(ref int seq, int[] args) { return false; }

        // TODO
        public bool CanChangePoke(BTL_POKEPARAM bpp) { return false; }

        public enum PrintCallbackArg : int
        {
            PRINTCB_RUN = 0,
            PRINTCB_JUST_DONE = 1,
            PRINTCB_AFTER_DONE = 2,
        }

        public enum CantEscapeCode : int
        {
            CANTESC_START = 0,
            CANTESC_KAGEFUMI = 0,
            CANTESC_ARIJIGOKU = 1,
            CANTESC_JIRYOKU = 2,
            CANTESC_TOOSENBOU = 3,
            CANTESC_FAIRY_LOCK = 4,
            CANTESC_MAX = 5,
            CANTESC_NULL = 5,
        }

        private delegate bool ClientMainProc();

        private delegate bool ClientSubProc(ref int seq);

        private delegate bool ServerCmdProc(ref int seq, int[] args);

        private enum RecCtrlCode : int
        {
            RECCTRL_NONE = 0,
            RECCTRL_QUIT = 1,
            RECCTRL_CHAPTER = 2,
        }

        private sealed class RECPLAYER_CONTROL
        {
            public byte seq;
            public byte ctrlCode;
            public bool fChapterSkip;
            public bool fFadeOutStart;
            public bool fFadeOutDone;
            public bool fTurnIncrement;
            public bool fLock;
            public bool fQuit;
            public ushort handlingTimer;
            public ushort turnCount;
            public ushort nextTurnCount;
            public ushort maxTurnCount;
            public ushort skipTurnCount;
        }

        private sealed class SEL_ITEM_WORK
        {
            public ushort itemNo;
            public bool bFromPokeSelect;
        }

        private enum WazaEffectCmdProcResult : int
        {
            WAZAEFF_CMD_RESULT_NO_PROC = 0,
            WAZAEFF_CMD_RESULT_PROC_NO_SYNC = 1,
            WAZAEFF_CMD_RESULT_PROC_SYNC = 2,
        }

        private sealed class VariableArgs
        {
            private int[] m_args = new int[BattleServerConst.BTL_SERVERCMD_ARG_MAX];
            private byte m_cnt;

            public void Dispose()
            {
                // Empty
            }

            public VariableArgs()
            {
                Clear();
            }

            public void Clear()
            {
                m_cnt = 0;
                for (int i=0; i<m_args.Length; i++)
                    m_args[i] = 0;
            }

            // TODO
            public void Setup(int[] cmd_args) { }

            // TODO
            public byte GetCount() { return 0; }

            // TODO
            public int GetArg(byte idx) { return 0; }
        }

        private sealed class WAZAEFF_SYNCDAMAGE_CMD_WORK
        {
            public uint cmdCount;
            public StoreElem[] store = Arrays.InitializeWithDefaultInstances<StoreElem>(BattleServerConst.BTL_SERVERCMD_ARG_MAX);

            public sealed class StoreElem
            {
                public ServerCmdProc cmdProc;
                public ServerCommand cmd;
                public int[] cmdArgs = new int[BattleServerConst.BTL_SERVERCMD_ARG_MAX];
                public int seq;
                public bool bDone;
                public VariableArgs variableArgs = new VariableArgs();
            }
        }

        private enum SelActRootSeq : int
        {
            SELACT_ROOTSEQ_START = 0,
            SELACT_ROOTSEQ_FRIENDSHIP_MSG_WAIT = 1,
            SELACT_ROOTSEQ_WAIT_MSG_CHECK = 2,
            SELACT_ROOTSEQ_WAIT_MSG_WAIT = 3,
            SELACT_ROOTSEQ_SEL_START = 4,
            SELACT_ROOTSEQ_SEL_MAIN = 5,
            SELACT_ROOTSEQ_WAIT_UI_RESTART = 6,
            SELACT_ROOTSEQ_FREEFALL_WARN = 7,
            SELACT_ROOTSEQ_FREEFALL_WARN_MSG = 8,
            SELACT_ROOTSEQ_FREEFALL_WARN_WAIT = 9,
        }

        private sealed class FriendshipEffectProc
        {
            private MainModule m_mainModule;
            private POKECON m_pokeCon;
            private BattleViewBase m_viewCore;
            private byte m_myID;
            private byte m_numCoverPos;
            private byte m_searchIdx;
            private int m_step;

            public FriendshipEffectProc()
            {
                m_mainModule = null;
                m_pokeCon = null;
                m_viewCore = null;
                m_myID = (byte)BTL_CLIENT_ID.BTL_CLIENT_NULL;
                m_numCoverPos = 0;
                m_searchIdx = 0;
                m_step = -1;
            }

            public void Dispose()
            {
                // Empty
            }

            // TODO
            public void Start(MainModule mainModule, POKECON pokeCon, BattleViewBase viewCore, byte myID, byte numCoverPos) { }

            // TODO
            public bool Wait() { return false; }

            // TODO
            private int checkEffectNo(BTL_POKEPARAM bpp) { return 0; }

            // TODO
            public static bool S_IsEnable(BTL_POKEPARAM bpp) { return false; }
        }

        private enum main_NormalSeq : int
        {
            SEQ_READ_ACMD = 0,
            SEQ_EXEC_CMD = 1,
            SEQ_RETURN_TO_SV = 2,
            SEQ_RETURN_TO_SV_QUIT = 3,
            SEQ_RECPLAY_CTRL = 4,
            SEQ_RECPLAY_STOP = 5,
            SEQ_BGM_FADEOUT = 6,
            SEQ_WAIT_RECPLAY_FADEOUT = 7,
            SEQ_COMM_ERROR = 8,
            SEQ_WAIT_CLEANUP_FOR_COMM_ERROR = 9,
            SEQ_QUIT = 10,
        }

        private enum main_ChapterSkipSeq : int
        {
            SEQ_RECPLAY_START = 0,
            SEQ_RECPLAY_READ_ACMD = 1,
            SEQ_RECPLAY_EXEC_CMD = 2,
            SEQ_RECPLAY_RETURN_TO_SV = 3,
            SEQ_RECPLAY_FADEIN = 4,
            SEQ_RECPLAY_QUIT = 5,
        }

        private enum SeqRecPlayerCtrl_Main : int
        {
            SEQ_DEFAULT = 0,
            SEQ_FADEOUT = 1,
            SEQ_STAY = 2,
        }

        private struct check_status_up_item_check_tbl_elem
        {
            public Pml.Item.ItemData.PrmID itemParamID;
            public BTL_POKEPARAM.ValueID rankID;

            public check_status_up_item_check_tbl_elem(Pml.Item.ItemData.PrmID itemParamID, BTL_POKEPARAM.ValueID rankID)
            {
                this.itemParamID = itemParamID;
                this.rankID = rankID;
            }
        }

        private struct check_cure_sick_item_tbl_elem
        {
            public Pml.Item.ItemData.PrmID itemParamID;
            public WazaSick sickID;

            public check_cure_sick_item_tbl_elem(Pml.Item.ItemData.PrmID itemParamID, WazaSick sickID)
            {
                this.itemParamID = itemParamID;
                this.sickID = sickID;
            }
        }

        private enum SeqSubProc_UI_SelectAction : int
        {
            SEQ_START_0 = 0,
            SEQ_DEMOCAPTURE_WAIT = 1,
            SEQ_START_1 = 2,
            SEQ_TRAINER_MESSAGE_SWITCH = 3,
            SEQ_TRAINER_MESSAGE_START = 4,
            SEQ_TRAINER_MESSAGE_WAIT = 5,
            SEQ_CAMERA_INIT = 6,
            SEQ_CAMERA_WAIT = 7,
            SEQ_SELACT_START = 8,
            SEQ_SELACT_WAIT = 9,
        }

        private enum SeqSubProc_REC_SelectAction : int
        {
            SEQ_FIRST = 0,
            SEQ_NONE = 1,
            SEQ_START_WAIT = 2,
            SEQ_CAMERA_RUNNING = 3,
            SEQ_END_WAIT = 4,
        }

        private enum Seqselact_Fight : int
        {
            SEQ_START = 0,
            SEQ_SELECT_WAZA_START = 1,
            SEQ_SELECT_WAZA_WAIT = 2,
            SEQ_SELECT_WAZA_END = 3,
            SEQ_CHECK_WAZA_TARGET = 4,
            SEQ_SELECT_TARGET_START = 5,
            SEQ_SELECT_TARGET_WAIT = 6,
            SEQ_WAIT_UNSEL_WAZA_MSG = 7,
            SEQ_WAIT_UNSEL_TARGET_MSG = 8,
            SEQ_DONE = 9,
        }

        private enum Seqselact_Item : int
        {
            SEQ_START = 0,
            SEQ_SELECT_START = 1,
            SEQ_SELECT_WAIT = 2,
            SEQ_FORCE_QUIT = 3,
            SEQ_CANT_USE_START = 4,
            SEQ_CANT_USE_WAIT = 5,
        }

        private enum Seqselact_Escape : int
        {
            SEQ_INIT = 0,
            SEQ_CANT_MSG_START = 1,
            SEQ_CANT_MSG_WAIT = 2,
            SEQ_CONFIRM_MSG_START = 3,
            SEQ_CONFIRM_MSG_WAIT = 4,
            SEQ_CONFIRM_YESNO = 5,
            SEQ_RETURN_ESCAPE = 6,
        }

        private enum SEQ_SubProc_AI_SelectAction : int
        {
            SEQ_INIT = 0,
            SEQ_POKE_START = 1,
            SEQ_AI_START = 2,
            SEQ_AI_WAIT = 3,
            SEQ_NEXT_POKE = 4,
            SEQ_SAFARI = 5,
            SEQ_END = 6,
        }

        private enum SeqselectPokemonUI_Core : int
        {
            SEQ_INIT = 0,
            SEQ_SELECT_ROOT = 1,
            SEQ_TIMELIMIT_OVER = 2,
            SEQ_SELECT_END = 3,
            SEQ_PROC_QUIT_ROOT = 4,
            SEQ_COMM_WAIT = 5,
            SEQ_PROC_QUIT_END = 6,
        }

        private enum SeqSubProc_UI_ConfirmIrekae : int
        {
            SEQ_INIT = 0,
            SEQ_START_CONFIRM = 1,
            SEQ_WAIT_CONFIRM = 2,
            SEQ_WAIT_POKESELECT = 3,
            SEQ_DONT_CHANGE = 4,
            SEQ_RETURN = 5,
        }

        private enum SeqSubProc_ExitCommTrainer : int
        {
            SEQ_START = 0,
            SEQ_SHOWDOWN_MESSAGE_START = 1,
            SEQ_SHOWDOWN_MESSAGE_WAIT_WIN = 2,
            SEQ_SHOWDOWN_MESSAGE_WAIT_LOSE = 3,
            SEQ_LOSE_BGM_FADEOUT_WAIT = 4,
        }

        private enum SeqSubProc_UI_ExitForNPC : int
        {
            SEQ_INIT = 0,
            SEQ_WIN_START = 1,
            SEQ_WIN_WAIT_TR1_IN = 2,
            SEQ_WIN_WAIT_TR1_MSG = 3,
            SEQ_WIN_WAIT_TR1_OUT = 4,
            SEQ_WIN_WAIT_TR2_IN = 5,
            SEQ_WIN_WAIT_TR2_MSG = 6,
            SEQ_WIN_GET_MONEY_MSG = 7,
            SEQ_WIN_GET_MONEY = 8,
            SEQ_WIN_BONUS_MONEY = 9,
            SEQ_LOSE_START = 10,
            SEQ_LOSE_WAIT_MSG1 = 11,
            SEQ_END = 12,
        }

        private enum SeqSubProc_ExitForSubwayTrainer : int
        {
            SEQ_START = 0,
            SEQ_INIT = 1,
            SEQ_WAIT_TRAINER_IN = 2,
            SEQ_WAIT_MSG = 3,
            SEQ_WAIT_TRAINER_OUT = 4,
            SEQ_WAIT_TRAINER2_IN = 5,
            SEQ_WAIT_MSG2 = 6,
        }

        private enum SeqSubProc_UI_FadeOut : int
        {
            SEQ_START = 0,
            SEQ_FADEOUT_START = 1,
            SEQ_FAIDEOUT_WAIT = 2,
            SEQ_END = 3,
        }

        private enum SeqSubProc_UI_RaidBossCapture_SelectBall : int
        {
            SEQ_START = 0,
            SEQ_SELECTBALL_START = 1,
            SEQ_SELECTBALL_WAIT = 2,
            SEQ_END = 3,
        }

        private enum SeqSubProc_UI_RaidBossCapture_Result : int
        {
            SEQ_START = 0,
            SEQ_BALLTHROW_START = 1,
            SEQ_BALLTHROW_WAIT = 2,
            SEQ_CAPTURED = 3,
            SEQ_ESCAPE = 4,
            SEQ_ESCAPE_ACT_START = 5,
            SEQ_ESCAPE_ACT_WAIT = 6,
            SEQ_JOKER_BALLTHROW_START = 7,
            SEQ_JOKER_BALLTHROW_WAIT = 8,
            SEQ_END = 9,
        }

        private enum SeqSubProc_UI_LoseRaid : int
        {
            SEQ_START = 0,
            SEQ_EFFECT_START = 1,
            SEQ_EFFECT_WAIT = 2,
            SEQ_END = 3,
        }

        private enum SeqscProc_ACT_MemberIn : int
        {
            SEQ_TRAINER_MSG_SWITCH = 0,
            SEQ_TRAINER_MSG_START = 1,
            SEQ_TRAINER_MSG_WAIT = 2,
            SEQ_MEMBERIN_MSG_START = 3,
            SEQ_MEMBERIN_MSG_WAIT = 4,
            SEQ_MEMBERIN_ACT = 5,
        }

        private struct getWeatherStartMessageTableElem
        {
            public BtlWeather weather;
            public int strID_others;
            public int strID_onBattleStart;

            public getWeatherStartMessageTableElem(BtlWeather weather, int strID_others, int strID_onBattleStart)
            {
                this.weather = weather;
                this.strID_others = strID_others;
                this.strID_onBattleStart = strID_onBattleStart;
            }
        }

        private enum SeqscProc_ACT_BallThrow : int
        {
            SEQ_START_BALL_THROW = 0,
            SEQ_WAIT_BALL_THROW = 1,
            SEQ_DONE = 2,
        }

        private enum SeqscProc_ACT_BallThrowForbidden : int
        {
            SEQ_START = 0,
            SEQ_BALLTHROW_START = 1,
            SEQ_BALLTHROW_WAIT = 2,
            SEQ_MSG_START = 3,
            SEQ_MSG_WAIT = 4,
            SEQ_END = 5,
        }

        private enum Seq_ACT_Safari : int
        {
            Start = 0,
            Throw0 = 1,
            Throw1 = 2,
            Throw2 = 3,
            Throw3 = 4,
            Yousumi0 = 5,
            Yousumi1 = 6,
            Yousumi2 = 7,
            End = 8,
        }
    }
}