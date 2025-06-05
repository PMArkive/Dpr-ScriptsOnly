﻿using Dpr.Battle.Logic;
using Dpr.Battle.View.Objects;
using Dpr.SequenceEditor;
using Pml;
using Pml.Battle;
using Pml.PokePara;
using Pml.WazaData;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLSXContent;

namespace Dpr.Battle.View.Systems
{
    public sealed class BattleViewSystem : BattleViewBase, ISequenceViewSystem
    {
        public const int BTLV_SEQ_SOUND_PLAY_FINISH_WAIT_MAX = 1800;
        public const int UNIQUE_MEMBER_CHANGE_ACT_ARIVE_POKE_CNT = 1;

        private bool m_isFinalize;
        private bool m_isFinalizeFadeSkip;
        private bool m_isFinishLoadObjects;
        private BattleSequenceSystem m_iPtrSequenceSystem;
        private BattleCharacterSystem m_iPtrCharacterSystem;
        private BattleCameraSystem m_iPtrCameraSystem;
        private BattleWeatherSystem m_iPtrWeatherSystem;
        private BattleGroundEffectSystem m_iPtrBattleGroundEffectSystem;
        private BattleStatusEffectObserverSystem m_iPtrStatusEffectObserverSystem;
        private BattleDataTable m_battleDataTable;
        private BattleDefaultPlacementData m_defaultPlacementData;
        private BattleScreenObject m_iPtrScreenObject;
        private Dictionary<BtlvPos, string> m_skrtModelDict;
        private BTLV_WAZA_EFF_PARAM m_wazaParam;
        private BtlvPos[] m_comTargetPoke;
        private BtlvPos[] m_comTargetDamage;
        private BtlvPos[] m_comTargetTrainer;
        private BtlEff m_comEffectId;
        private BallId[] m_effectBallId;
        private BtlvBallInfo[] m_effectBallInfo;
        private int m_comIsVisibleTame;
        private bool m_comIsMigawari;
        private bool m_comMigawariReserve;
        private BtlvPos m_comMigawariReserveTarget;
        private int m_comRepeatNum;
        private bool m_comIsSuccsess;
        private bool m_comIsCritical;
        private int m_subSequence;
        private SequenceSeq m_sequenceSeq;
        private bool m_seqKeepResource;
        private string m_playingSeqFileNameHash;
        private Func<bool> m_pComWaitFunc;
        private bool m_isStartMsgDisplay;
        private int m_wazaMsgFrame;
        private BtlvPos m_beforePlayEffPos;
        private BtlEff m_beforePlayEffNo;
        private bool m_isFieldIndoor;
        private bool m_isFieldStadium;
        private bool m_isFieldRoseTower;
        private bool m_isFieldStadiumWide;
        private bool m_isFieldWaitcamExcept;
        private bool m_reqCheckPinch;
        private bool m_canChangePinch;
        private bool m_isSoundPlayingFinishCheckInvalid;
        private int m_soundPlayingFinishWaitCount;
        private BtlvSound m_pokePinchSound;
        private bool m_preUpdateAudioListenerByMainCamera;
        private DeadActParam m_deadActParam;
        private MemberChangeActParam m_memberChangeActParam;
        private MemberOutActParam m_memberOutActParam;
        private StartGActParam m_startGActParam;
        private EndGActParam m_endGActParam;
        private TrainerTalkParam m_trainerTalkParam;
        private BTLV_ATTR_EFF_PARAM m_attrEffParam;
        private string m_attrSoundEvent;
        private TaskManager m_iPtrTaskManager;
        private TaskManager m_iPtrTaskManagerLate;
        private Stack<Tuple<int, uint, uint>> m_uPtrSoundPlayingIDHash;
        private int m_shadowResolutionBackup;

        // TODO
        public override void CMD_UI_OnFirstSelectActionStart() { }

        // TODO
        public override void CMD_UI_SelectAction_Start(in SelectActionParam param, BTL_ACTION_PARAM_OBJ dest) { }

        // TODO
        public override BtlAction CMD_UI_SelectAction_Wait() { return default; }

        // TODO
        public override void CMD_UI_SelectAction_ForceQuit() { }

        // TODO
        public override void CMD_UI_SelectAction_AllFinished() { }

        // TODO
        public override void CMD_UI_SelectWaza_Start(BTL_POKEPARAM bpp, byte pokeIndex, BTL_ACTION_PARAM_OBJ dest) { }

        // TODO
        public override void CMD_UI_SelectWaza_Restart(byte pokeIndex) { }

        // TODO
        public override bool CMD_UI_SelectWaza_Wait() { return false; }

        // TODO
        public override bool CMD_UI_SelectWaza_End() { return false; }

        // TODO
        public override void CMD_UI_SelectWaza_ForceQuit() { }

        // TODO
        public override void CMD_UI_SelectTarget_Start(byte poke_index, BTL_POKEPARAM bpp, BTL_ACTION_PARAM_OBJ dest) { }

        // TODO
        public override BtlvResult CMD_UI_SelectTarget_Wait() { return default; }

        // TODO
        public override void CMD_UI_SelectTarget_ForceQuit() { }

        // TODO
        public override void CMD_ITEMSELECT_Start(byte bagMode, byte energy, byte reserved_energy, bool fFirstPokemon, bool fBallTargetHide, bool canUseReliveItem) { }

        // TODO
        public override bool CMD_ITEMSELECT_Wait() { return false; }

        // TODO
        public override void CMD_ITEMSELECT_ForceQuit() { }

        // TODO
        public override ItemNo CMD_ITEMSELECT_GetItemID() { return ItemNo.DUMMY_DATA; }

        // TODO
        public override byte CMD_ITEMSELECT_GetTargetIdx() { return 0; }

        // TODO
        public override byte CMD_ITEMSELECT_GetWazaIdx() { return 0; }

        // TODO
        public override void CMD_ITEMSELECT_ReflectUsedItem() { }

        // TODO
        public override void CMD_StartPokeList(PokeSelParam param, BTL_POKEPARAM outMemberParam, uint outMemberIndex, bool fCantEsc, PokeSelResult result) { }

        // TODO
        public override bool CMD_WaitPokeList() { return false; }

        // TODO
        public override void CMD_ForceQuitPokeList() { }

        // TODO
        public override bool CMD_WaitForceQuitPokeList() { return false; }

        // TODO
        public override void CMD_StartPokeSelect(PokeSelParam param, uint outMemberIndex, bool bCancelable, PokeSelResult result) { }

        // TODO
        public override bool CMD_WaitPokeSelect() { return false; }

        // TODO
        public override void CMD_ForceQuitPokeSelect() { }

        // TODO
        public override bool CMD_WaitForceQuitPokeSelect() { return false; }

        // TODO
        public override void CMD_EFFECT_BallThrow(BtlvPos userPos, BtlvPos position, ItemNo item_no, byte yure_cnt, bool f_success, bool f_critical) { }

        // TODO
        public override void CMD_EFFECT_BallThrowTrainer(BtlvPos vpos, ItemNo item_no) { }

        // TODO
        public override bool CMD_EFFECT_WaitBallThrow() { return false; }

        // TODO
        public override bool CMD_EFFECT_WaitBallThrowTrainer() { return false; }

        // TODO
        public bool CheckCanPlayCommand(CommandParam param) { return default; }

        // TODO
        public bool CheckCanPlayCommandWaitCamera(CommandParam param) { return default; }

        // TODO
        public override bool FinalizeApp() { return false; }

        // TODO
        public override bool FinalizeAppForce() { return false; }

        // TODO
        private bool finalizeCommon() { return false; }

        // TODO
        public override bool Initialize() { return false; }

        // TODO
        private void StartLoadObject() { }

        // TODO
        private void StartSetup() { }

        // TODO
        private void SetupLight() { }

        // TODO
        private void SetupWeather() { }

        // TODO
        private void StartGround() { }

        // TODO
        public void SetBattleReflection(Camera reflectionCamera, int reflectionResolutionStage) { }

        // TODO
        private int GetBattleReflectionLayer(bool isEnable) { return 0; }

        // TODO
        public bool SetupGraphic() { return false; }

        // TODO
        private void InitializeSystem() { }

        // TODO
        public override void CMD_StartMsg(BTLV_STRPARAM param) { }

        // TODO
        public override void CMD_StartMsgWaza(byte pokeID, WazaNo waza, BtlPokePos attackerPos, BtlPokePos defenderPos, WazaTarget wazaRange, bool needMessageDisplay) { }

        // TODO
        public override void CMD_StartMsgStd(ushort strID, int[] args) { }

        // TODO
        public override void CMD_StartMsgSet(ushort strID, int[] args) { }

        // TODO
        public override bool CMD_StartMsgTrainer(byte clientID, uint param, bool isKeyWait = false) { return false; }

        // TODO
        public override bool CMD_WaitMsg() { return false; }

        // TODO
        public override bool CMD_WaitMsg_WithoutHide() { return false; }

        // TODO
        public override void CMD_HideMsg() { }

        // TODO
        public override void CMD_DemoCapture_Start() { }

        // TODO
        public override bool CMD_DemoCapture_Wait() { return false; }

        // TODO
        public override void CMD_ACT_MemberOut_Start(BtlvPos vPos, BtlEff effectNo) { }

        // TODO
        public override bool CMD_ACT_MemberOut_Wait() { return false; }

        // TODO
        public override void CMD_ACT_TameWazaHide(BtlvPos vpos, BTLV_VANISH_FLAG vanishFlag) { }

        // TODO
        public override void CMD_StartMemberChangeAct(BtlPokePos pos, byte clientID, byte memberIdx) { }

        // TODO
        public override bool CMD_WaitMemberChangeAct() { return false; }

        // TODO
        public override void CMD_FakeDisable_Start(BtlPokePos pos, bool fSkipMode) { }

        // TODO
        public override bool CMD_FakeDisable_Wait() { return false; }

        // TODO
        public override void CMD_ChangeForm_Start(BtlvPos vpos) { }

        // TODO
        public override bool CMD_ChangeForm_Wait() { return false; }

        // TODO
        public override void CMD_Hensin_Start(BtlvPos atkVpos, BtlvPos tgtVpos) { }

        // TODO
        public override bool CMD_Hensin_Wait() { return false; }

        // TODO
        private void CMD_ACT_PokeChangeEffect_StartCore(BtlvPos vpos, BtlEff effId, bool isNoLoad) { }

        // TODO
        private bool CMD_ACT_PokeChangeEffect_WaitCore(bool isGChange) { return false; }

        // TODO
        private bool CMD_ACT_PokeChangeEffect_WaitCore_Skip() { return false; }

        // TODO
        public override void CMD_ExpGet_Start(ExpGetDesc desc, ExpGetResult pResult) { }

        // TODO
        public override bool CMD_ExpGet_Wait(ExpGetResult pResult) { return default; }

        // TODO
        public override void CMD_StartRankDownEffect(BtlvPos vpos, byte rankDownVolume, RankEffectViewType viewType) { }

        // TODO
        public override void CMD_StartRankUpEffect(BtlvPos vPos, byte rankUpVolume, RankEffectViewType UnnamedParameter) { }

        // TODO
        public override bool CMD_WaitRankEffect(BtlvPos vPos) { return false; }

        // TODO
        public override void CMD_ACT_Safari_Start(BtlPokePos pokePos, SafariCmd safariCmd, int param) { }

        // TODO
        public override bool CMD_ACT_Safari_Wait() { return false; }

        // TODO
        public void SEQ_CMD_ResetDefaultCamera(int frame, SEQ_DEF_MOVETYPE moveType, SequenceCameraSystem system) { }

        // TODO
        public bool SeqComFunc_IsFlipEffect(BtlvPos target, BtlvPos subTarget) { return false; }

        // TODO
        public BattleViewCharacter SeqComFunc_GetTargetChara(SEQ_DEF_TRAINER trg, int idx = 0) { return default; }

        // TODO
        public BattleViewCharacter SeqComFunc_GetTargetChara(SEQ_DEF_TRAINER_ADD trg, int idx = 0) { return default; }

        // TODO
        public BtlvPos SeqComFunc_GetTargetPoke(SEQ_DEF_POS target, int index = 0) { return BtlvPos.BTL_VPOS_NEAR_1; }

        // TODO
        public BtlvPos SeqComFunc_GetTargetPokeSub(SEQ_DEF_POS target) { return BtlvPos.BTL_VPOS_NEAR_1; }

        // TODO
        public BtlvPos SeqComFunc_GetTargetPoke_Org(int idx) { return BtlvPos.BTL_VPOS_NEAR_1; }

        // TODO
        public void SeqComFunc_GetPokeRelativePos(ref RELARIVE_POKE_OPTION opt, ref Vector3 pRetPos, ref Vector3 pRetRot, ref Vector3 pRetScale, bool isCameraAdjust) { }

        // TODO
        public void SeqComFunc_GetSpecialPos(SEQ_DEF_SPPOS trgType, ref Vector3 retPos, ref Vector3 retRot) { }

        // TODO
        public void SeqComFunc_GetPokeFiledPos(ref Vector3 retPos, ref Vector3 retRot, BtlvPos plater, bool isAttack) { }

        // TODO
        public int SeqComFunc_GetTargetPokeNum(bool isCheck = true) { return 0; }

        // TODO
        public BtlvPos SeqComFunc_GetTargetCharaVPos(SEQ_DEF_TRAINER target, int index = 0) { return default; }

        // TODO
        public void SeqComFunc_CalcPokeDir(Vector3 nowPos, BtlvPos trgPoke, SEQ_DEF_NODE trgNode, ref Vector3 retRot, bool isVertical) { }

        // TODO
        public void SeqComFunc_CalcPosDir(Vector3 nowPos, Vector3 trgPos, ref Vector3 retRot, bool isVertical) { }

        // TODO
        public void SeqComFunc_MoveRelativePoke(ITranslationObject iPtrObj, int frame, RELARIVE_POKE_OPTION opt, bool isTrainer = false) { }

        // TODO
        public void SeqComFunc_MoveSpecialPos(ITranslationObject iPtrObj, int frame, SEQ_DEF_SPPOS trgType, Vector3 ofs, bool isRotate, bool isFlip) { }

        // TODO
        public void SetTerrainChipVisibility(bool disp) { }

        // TODO
        public void StartWeather(BtlWeather weather) { }

        // TODO
        public void SetSuspendSequenceFunc(SEQ_DEF_WAIT type) { }

        // TODO
        private bool SeqComWaitFunc_Message() { return false; }

        // TODO
        private bool SeqComWaitFunc_LoadPoke() { return false; }

        // TODO
        private bool SeqComWaitFunc_SelectMessage() { return false; }

        // TODO
        private bool SeqComWaitFunc_UIBag() { return false; }

        // TODO
        private bool SeqComWaitFunc_UITrainerName() { return false; }

        // TODO
        private bool SeqComWaitFunc_UIFog() { return false; }

        // TODO
        private bool SeqComWaitFunc_UISeq() { return false; }

        // TODO
        private BallId SeqComFunc_GetEffectBallId(int idx) { return BallId.NULL; }

        // TODO
        public BtlvBallInfo SeqComFunc_GetEffectBallInfo(int idx) { return default; }

        // TODO
        public override void CMD_StartSetup() { }

        // TODO
        private IEnumerator WaitSetupSequence() { return null; }

        // TODO
        private void StartSetView() { }

        // TODO
        private void RegisterCamera() { }

        // TODO
        public override bool CMD_WaitSetup() { return false; }

        // TODO
        private void PlaySequenceStartDemo(bool isKeepResource = true) { }

        // TODO
        private void StartRareSequence(BtlvPos[] posArr, int arrNum, bool isKeepResource = true) { }

        // TODO
        private void CMD_WaitSetup_ThrowSelf() { }

        // TODO
        private void CMD_WaitSetup_ThrowEnemy(bool isComm = false) { }

        // TODO
        private bool CMD_WaitSetup_Comm() { return false; }

        // TODO
        public override bool CMD_InitStartWaitCameraEffect() { return false; }

        // TODO
        public override bool CMD_WaitStartWaitCameraEffect() { return false; }

        // TODO
        public override void CMD_InitFinishWaitCameraEffect() { }

        // TODO
        public override bool CMD_WaitFinishWaitCameraEffect() { return false; }

        // TODO
        public BattleViewSystem(BTLV_INIT_PARAM initParam): base(initParam) { }

        // TODO
        private void InitializeMember() { }

        // TODO
        public override void CMD_ACT_WazaEffect_Start(BtlPokePos atPokePos, BtlPokePos defPokePos, WazaNo waza, byte wazaType, WazaTarget wazaRange, BtlvWazaEffect_TurnType turnType, byte continueCount, bool syncDamageEffect, bool isGShockOccur) { }

        // TODO
        public override bool CMD_ACT_WazaEffect_Wait() { return false; }

        // TODO
        private void StartWazaEffect() { }

        // TODO
        private bool WaitWazaEffect() { return false; }

        // TODO
        private void UpdateCheerSoundOnWazaStart_Damage(BtlvPos pos) { }

        // TODO
        private void UpdateCheerSoundOnWazaStart_Damage(BtlPokePos pos) { }

        // TODO
        private void UpdateCheerSoundOnWazaStart_NotDamage() { }

        // TODO
        private void UpdateCheerSoundOnWazaEnd() { }

        // TODO
        private void StartEgCamWazaStart() { }

        // TODO
        private bool WaitSequence() { return false; }

        // TODO
        private void StartWazaEffectCore() { }

        // TODO
        private void PlaySequenceEffect(BtlEff no, bool isKeepResource = false) { }

        // TODO
        public override void CMD_ACT_DamageEffectSingle_Start(WazaNo wazaID, BtlPokePos defPokePos, TypeAffinity.AboutAffinityID affAbout) { }

        // TODO
        public override bool CMD_ACT_DamageEffectSingle_Wait() { return false; }

        // TODO
        public override void CMD_ACT_DamageEffectPlural_Start(uint pokeCnt, TypeAffinity.AboutAffinityID affAbout, byte[] pokeID, TypeAffinity.AffinityID[] pokeAffinity, WazaNo waza) { }

        // TODO
        public override bool CMD_ACT_DamageEffectPlural_Wait() { return false; }

        // TODO
        public override void CMD_ACT_MigawariDamageEffect_Start(WazaNo wazaID, BtlPokePos migawariPos, TypeAffinity.AboutAffinityID affAbout) { }

        // TODO
        public override bool CMD_ACT_MigawariDamageEffect_Wait() { return false; }

        // TODO
        private bool CMD_ACT_DamageEffect_WaitCore() { return false; }

        // TODO
        public override void CMD_StartDeadAct(BtlPokePos pokePos, bool isKillCountEffectExist) { }

        // TODO
        public override bool CMD_WaitDeadAct() { return false; }

        // TODO
        public override void CMD_ACT_SimpleHPEffect_Start(BtlPokePos pokePos) { }

        // TODO
        public override bool CMD_ACT_SimpleHPEffect_Wait() { return false; }

        // TODO
        public override void CMD_AddEffect(BtlEff effectNo) { }

        // TODO
        public override bool CMD_WaitEffect() { return false; }

        // TODO
        public override void CMD_AddEffectByPos(BtlvPos vpos, BtlEff effectNo) { }

        // TODO
        public override bool CMD_WaitEffectByPos() { return false; }

        // TODO
        public override void CMD_AddEffectByDir(BtlvPos vpos_from, BtlvPos vpos_to, BtlEff effectNo) { }

        // TODO
        public override bool CMD_WaitEffectByDir() { return false; }

        // TODO
        public override void CMD_AddEffectBySide(BtlvPos vpos_from, BtlvPos vpos_to, BtlEff effectNo) { }

        // TODO
        public override bool CMD_WaitEffectBySide() { return false; }

        // TODO
        public override void CMD_ChangeWheather(BtlWeather weather) { }

        // TODO
        public override bool CMD_ChangeWheather_Wait() { return false; }

        // TODO
        public override void CMD_ChangeGround(BtlGround type) { }

        // TODO
        public override bool CMD_ChangeGround_Wait() { return false; }

        // TODO
        public override void CMD_TokWin_DispStart(BtlPokePos pos, bool fFlash) { }

        // TODO
        public void CMD_TokWin_DispStartEx(BtlPokePos pos, TokuseiNo overrideTokusei = TokuseiNo.NULL) { }

        // TODO
        public override bool CMD_TokWin_DispWait(BtlPokePos pos) { return false; }

        // TODO
        public override void CMD_QuitTokWin(BtlPokePos pos) { }

        // TODO
        public override bool CMD_QuitTokWinWait(BtlPokePos pos) { return false; }

        // TODO
        public override void CMD_TokWin_Renew_Start(BtlPokePos pos) { }

        // TODO
        public override bool CMD_TokWin_Renew_Wait(BtlPokePos pos) { return false; }

        // TODO
        public override void CMD_StartCommWait() { }

        // TODO
        public override bool CMD_WaitCommWait() { return false; }

        // TODO
        public override void CMD_ResetCommWaitInfo() { }

        // TODO
        public override void CMD_ItemAct_Start(BtlPokePos pos) { }

        // TODO
        public override bool CMD_ItemAct_Wait(BtlPokePos pos) { return false; }

        // TODO
        public override void CMD_KinomiAct_Start(BtlPokePos pos) { }

        // TODO
        public override bool CMD_KinomiAct_Wait(BtlPokePos pos) { return false; }

        // TODO
        public override void CMD_TrainerIn_Win(BtlvPos position) { }

        // TODO
        public override void CMD_TrainerIn_Lose(BtlvPos position) { }

        // TODO
        public override bool CMD_WaitTrainerIn() { return false; }

        // TODO
        public override void CMD_PlayWinBGM() { }

        // TODO
        public override void CMD_PlaySE(SoundType SENo) { }

        // TODO
        public override bool CMD_IsSEFinished(SoundType SENo) { return default; }

        // TODO
        public override void CMD_ACT_MoveMember_Start(byte clientID, BtlvPos vpos1, BtlvPos vpos2, byte posIdx1, byte posIdx2) { }

        // TODO
        public override bool CMD_ACT_MoveMember_Wait() { return false; }

        // TODO
        public override void CMD_YESNO_Start(bool b_cancel, YesNoMode yesno_mode) { }

        // TODO
        public override bool CMD_YESNO_Wait(out BtlYesNo result)
        {
            result = default;
            return default;
        }

        // TODO
        public override void CMD_YESNO_ForceQuit() { }

        // TODO
        public override void CMD_EFFECT_SetGaugeStatus(Sick sick, BtlvPos pos) { }

        // TODO
        public override void CMD_EFFECT_DrawEnableTimer(GameTimer.TimerType type, bool enable) { }

        // TODO
        public override void CMD_FinalizeFadeSkip() { }

        // TODO
        private void PlaySequenceCore(string path, bool keepResource = false) { }

        // TODO
        private void PlaySequenceWaza(BTLV_WAZA_EFF_PARAM param) { }

        // TODO
        private string GetWazaSequencePath(ref BTLV_WAZA_EFF_PARAM param, ref bool? isNormalSeq) { return default; }

        // TODO
        private bool IsWazaMsgCommandSeq() { return false; }

        // TODO
        private void StartWazaMsgCommand() { }

        // TODO
        private bool WaitWazaMsgCommand() { return false; }

        // TODO
        public void OnUpdate(float deltaTime) { }

        // TODO
        public void OnLateUpdate(float deltaTime) { }

        // TODO
        private void UpdateSequence() { }

        // TODO
        private void UpdateSuspendSequenceSystem() { }

        // TODO
        private bool IsSuspendSequenceSystem { get; }

        // TODO
        private void CheckPokePinch() { }

        // TODO
        private void StartLoadSequence() { }

        // TODO
        private bool IsSoundPlayingFinishCheckInvalid { get; }

        private InitializeSequenceStateType InitializeSequenceState { get; set; }
        private SetupSequenceStateType SetupSequenceState { get; set; }
        private SetupCommSequenceType SetupCommSequence { get; set; }
        private SetupRaidSequenceType SetupRaidSequence { get; set; }
        private WazaSequenceType WazaSequence { get; set; }
        private EndSequenceType EndSequence { get; set; }

        public bool IsStencilEnable { get; set; }

        // TODO
        private bool IsAllTaskFinished { get; }

        public float blurry { get; set; }

        // TODO
        public Dictionary<BtlvPos, string> PositionForModelIDDict { get; set; }

        public bool IsApplicationPause { get; set; }

        // TODO
        public void ResetAll() { }

        // TODO
        private void ResetEnvironmentParams() { }

        // TODO
        private void ResetQualitySettings() { }

        // TODO
        private void ResetHitBack() { }

        // TODO
        private bool CheckCanPlayEffect(BtlvPos vPos, BtlEff effectNo) { return false; }

        // TODO
        private void ResetCheckCanPlayEffect() { }

        // TODO
        private BallId GetCaptureBall(BtlvPos vPos, out bool isStrangeBall)
        {
            isStrangeBall = false;
            return BallId.NULL;
        }

        // TODO
        private BtlvBallInfo GetBallInfo(BtlvPos vPos) { return default; }

        // TODO
        public override BtlRule GetBattleRule() { return BtlRule.BTL_RULE_SINGLE; }

        // TODO
        public PartyDesc GetPartySetupParam(byte clientId) { return null; }

        // TODO
        public BTLV_WAZA_EFF_PARAM GetWazaParam() { return default; }

        // TODO
        public BTLV_WAZA_EFF_PARAM SetWazaParam(BTLV_WAZA_EFF_PARAM param) { return default; }

        // TODO
        public BTLV_ATTR_EFF_PARAM GetAttrEffParam() { return default; }

        // TODO
        public string GetSoundEventName() { return null; }

        // TODO
        public TrainerTalkParam GetTrainerTalkParam() { return default; }

        // TODO
        public BtlvMode GetBtlvMode() { return default; }

        // TODO
        private void ResetDefaultCamera(int frame = 0, EaseFunc moveType = EaseFunc.LINEAR) { }

        // TODO
        private void ResetDefaultCamera(int frame, EaseFunc moveType, BattleCameraSystem system) { }

        // TODO
        private void ResetDefaultCameraParam(int frame, EaseFunc moveType, SequenceCameraSystem system, Vector3 pos, Vector3 target, float fov, float depthNear, float depthFar) { }

        // TODO
        private void GetDefaultCamera(ref Vector3 pos, ref Vector3 target, ref float fov, ref float depthNear, ref float depthFar) { }

        // TODO
        private void GetDefaultCamera_Target(ref Vector3 pos, ref Vector3 target, ref float fov, ref float depthNear, ref float depthFar) { }

        // TODO
        private void GetDefaultCameraParam(Size playerSize, Size enemySize, bool isExistGPoke, ref Vector3 pos, ref Vector3 target, ref float fov, ref float near, ref float far) { }

        // TODO
        public float GetTimeZoneSensorScale() { return 0.0f; }

        // TODO
        private BattleEffectComponentData GetBattleEffectComponentData() { return default; }

        // TODO
        private bool WaitLoadSequence() { return false; }

        // TODO
        private bool WaitSequenceResource() { return false; }

        // TODO
        private bool IsExistGPoke() { return false; }

        // TODO
        private bool IsExistGPokeSide(bool playerSide) { return false; }

        // TODO
        public string GetBattleModelPath(string idx) { return null; }

        // TODO
        public string GetBttleWazaModelPath(string idx) { return null; }

        // TODO
        public string GetBallModelPath(int idx) { return null; }

        // TODO
        public void ResetPokemon(BtlvPos vPos, int frame, SEQ_DEF_MOVETYPE moveType, SEQ_DEF_DEFAULT_PLACEMENT placement = SEQ_DEF_DEFAULT_PLACEMENT.SEQ_DEF_DEFAULT_PLACEMENT_DEFAULT) { }

        // TODO
        private void SwapPokeModel(BtlvPos vPos1, BtlvPos vPos2) { }

        // TODO
        public void GetDefaultPokePos(BtlvPos vPos, ref Vector3 pos, ref int deg, SEQ_DEF_DEFAULT_PLACEMENT placement = SEQ_DEF_DEFAULT_PLACEMENT.SEQ_DEF_DEFAULT_PLACEMENT_DEFAULT) { }

        // TODO
        public BOPokemon GetPokeModel(BtlvPos vPos) { return default; }

        // TODO
        public Size GetPokeSize(BattleViewSide side, bool isGPoke = false) { return default; }

        // TODO
        private void SetVisiblePokeObject(bool value) { }

        // TODO
        public void ResetTrainer(BtlvPos vPos, bool isOrigin, SEQ_DEF_DEFAULT_PLACEMENT placement = SEQ_DEF_DEFAULT_PLACEMENT.SEQ_DEF_DEFAULT_PLACEMENT_DEFAULT) { }

        // TODO
        private void GetDefaultTrainerPos(BtlvPos vPos, ref Vector3 pPos, ref int pDeg, bool isOrigin, SEQ_DEF_DEFAULT_PLACEMENT placement) { }

        // TODO
        public BattleViewCharacter GetTrainerModel(BtlvPos vPos) { return default; }

        // TODO
        private void SetVisibleTrainerObject(bool value) { }

        // TODO
        private void SetVisibleBattleObject(bool value) { }

        // TODO
        private void SetEnableMotionWaitB(bool isEnable) { }

        // TODO
        public BattleScreenObject GetScreenObject() { return default; }

        // TODO
        public void SetReqCheckPinch(bool value) { }

        // TODO
        public bool IsReqCheckPinch() { return false; }

        // TODO
        public void SetCanChangePinch(bool value) { }

        // TODO
        public bool IsCanChangePinch() { return false; }

        // TODO
        public void SetIsSoundPlayingFinishCheckInvalid(bool value) { }

        // TODO
        private void SaveFog() { }

        // TODO
        private bool UIFog_Wait() { return false; }

        // TODO
        private void SetComTargetReset() { }

        // TODO
        private bool CheckEgCamWazaStart() { return false; }

        // TODO
        private void SetupWazaTarget(BtlvPos atkPos, BtlvPos defPos, WazaTarget wazaRange) { }

        // TODO
        private void SetupWazaTarget_AllFunc(BtlvPos atkPos, ref BtlvPos[] retArray, bool enemyOnly) { }

        // TODO
        private bool IsDefGPoke() { return false; }

        // TODO
        private BtlvWazaEffect_TurnType GetUniqWazaSeqTurnType(BtlvPos vPos, WazaNo no, BtlvWazaEffect_TurnType turnType) { return default; }

        // TODO
        public void CheckWazaDataPath_Particle(ref string path, int idx, bool isBallEffect, bool isCapture, bool isAttributeEffect, bool isStreamLineEffect) { }

        // TODO
        private bool IsFieldStadium { get; }

        // TODO
        private bool IsFieldRoseTower { get; }

        // TODO
        private bool IsFieldStadiumWide { get; }

        // TODO
        private bool IsFieldWaitcamExceptreturn { get; }

        // TODO
        public Stack<Tuple<int, uint, uint>> GetSoundPlayingIDHashTable() { return null; }

        // TODO
        public BattleSequenceSystem GetSequenceSystem() { return default; }

        // TODO
        public BattleCharacterSystem GetCharacterSystem() { return default; }

        // TODO
        public SequenceCameraSystem GetCameraSystem() { return default; }

        // TODO
        public BattleWeatherSystem GetBattleWeatherSystem() { return default; }

        // TODO
        public BattleGroundEffectSystem GetBattleGroundEffectSystem() { return default; }

        // TODO
        public BattleViewUISystem GetHUD() { return null; }

        // TODO
        public TaskManager GetTaskManager() { return default; }

        // TODO
        public TaskManager GetTaskManagerLate() { return default; }

        // TODO
        private bool IsGosanke(BTL_POKEPARAM pokeParam) { return false; }

        // TODO
        private bool IsGosanke(PokemonParam pokeParam) { return false; }

        // TODO
        private string GetGosankeThrowSeq(uint friendShip) { return ""; }

        public enum BattleViewSide : int
        {
            PLAYER_SIDE = 0,
            ENEMY_SIDE = 1,
        }

        public enum InitializeSequenceStateType : int
        {
            Unregistered = -1,
            InitSystem = 0,
            WaitLoadData = 1,
            WaitLoadGraphic = 2,
            SetupData = 3,
            Finish = 4,
        }

        public enum SetupSequenceStateType : int
        {
            NONE = 0,
            WILD_IN = 1,
            WILD_RARE = 2,
            TRAINER_IN = 3,
            ENEMY_TRAINER = 4,
            ENEMY_RARE = 5,
            SELF_TRAINER = 6,
            SELF_RARE = 7,
            COMM_WAIT = 8,
            RAID_WAIT = 9,
            SEQ_WAIT = 10,
            G_SIGNAL_IN = 11,
            G_SIGNAL_WAIT = 12,
            SIMPLE_IN = 13,
            SIMPLE_WAIT = 14,
            SAFARI_IN = 15,
            SAFARI_RARE = 16,
            FINISH = 17,
        }

        public enum SetupCommSequenceType : int
        {
            Unregistered = -1,
            SETUP = 0,
            INTRO = 1,
            THROW_1ST = 2,
            RARE_1ST = 3,
            THROW_2ND = 4,
            RARE_2ND = 5,
            FINISH = 6,
        }

        public enum SetupRaidSequenceType : int
        {
            Unregistered = -1,
            SETUP = 0,
            INTRO = 1,
            RAID_RARE = 2,
            SELF_TRAINER = 3,
            SELF_RARE = 4,
            FINISH = 5,
        }

        public enum WazaSequenceType : int
        {
            SEQ_SETUP = 0,
            SEQ_MIGAWARI_CHECK = 1,
            SEQ_MIGAWARI_OUT = 2,
            SEQ_MIGAWARI_OUT_UPDATE = 3,
            SEQ_CAMERA_PLAY = 4,
            SEQ_CAMERA_PLAY_START = 5,
            SEQ_CAMERA_PLAY_WAIT = 6,
            SEQ_WAZA_PLAY = 7,
            SEQ_WAZA_PLAY_WAIT = 8,
            SEQ_FORMCHANGE = 9,
            SEQ_FORMCHANGE_WAIT = 10,
            SEQ_FORMCHANGE_END = 11,
            SEQ_MIGAWARI_IN = 12,
            SEQ_MIGAWARI_IN_UPDATE = 13,
            SEQ_END = 14,
        }

        public enum EndSequenceType : int
        {
            FADE = 0,
            START = 1,
            WAIT_OBJECT = 2,
            WAIT_FIELD_OBJECT = 3,
            MEMORY_WAIT = 4,
            RENDERER = 5,
            FINISH = 6,
        }

        public enum CommandTarget : int
        {
            TARGET_ATK = 0,
            TARGET_DEF = 1,
            MAX = 2,
        }

        public enum SequenceSeq : int
        {
            NONE = 0,
            START_LOAD = 1,
            WAIT_PRELOAD = 2,
            WAIT_LOAD = 3,
            WAIT_WAZA_MSG = 4,
            UPDATE_SEQUENCE = 5,
            FINISH = 6,
            SOUND_WAIT = 7,
            SEQ_LOAD_START = 8,
        }
    }
}