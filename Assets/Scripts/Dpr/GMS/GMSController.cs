using Dpr.MsgWindow;
using Dpr.NetworkUtils;
using Dpr.SubContents;
using Dpr.UI;
using SmartPoint.AssetAssistant;
using System;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Dpr.GMS
{
	public class GMSController : MonoBehaviour
	{
		private TradeState currentTradeState;
		private AfterErrorDialogActID afterErrorDialogActID;
		private GMSTradeResult gmsTradeResult;
		private PointDataStatus pointDataStatus = PointDataStatus.None;
		private WaitTimer randomWaitTimer = new WaitTimer();
		private bool isMovedCamera;
		private bool isCalledSave;
		private bool canUseGMSNetwork;

		[SerializeField]
		private GMSCamera gmsCamera;
		private UIGMSScene sceneUI;
		private UIPointMarkManager uiGMSMark;
		private UIPointListManager uiPointDataList;
		private UIAchievementAnim uiAchievementAnim;
		private GMSSceneDataModel dataModel = new GMSSceneDataModel();
		private GMSMessageWindow msgWindow = new GMSMessageWindow();
		private GMSResourceLoader resourceLoader = new GMSResourceLoader();
		private GMSResourceLoader asyncResourceLoader = new GMSResourceLoader();
		private UIManager uiManagerPtr;
		private GameObject earthObj;
		private Texture2D bgTexture;
		private EffectEmitter effectEmitter = new EffectEmitter();
		
		// TODO
		private void StartTradeFlow() { }
		
		// TODO
		private void ChangeStateNetworkTrade() { }
		
		// TODO
		private void ResetTradeParam() { }
		
		// TODO
		private void UpdateNetworkTrade(float deltaTime) { }
		
		// TODO
		private void UpdateStartPreSave() { }
		
		// TODO
		private void UpdateStartConnect() { }
		
		// TODO
		private bool CheckConnectInternet() { return default; }
		
		// TODO
		private void OnConnectSuccess() { }
		
		// TODO
		private void StartValidateCheck() { }
		
		// TODO
		private void OnFailedValidate(ValidateResultID resultID) { }
		
		// TODO
		private void OnConnectFalied() { }
		
		// TODO
		private void UpdatePreTradeSave() { }
		
		// TODO
		private void UpdateStartConnectGMSServer(float deltaTime) { }
		
		// TODO
		private bool CheckFatalError() { return default; }
		
		// TODO
		private void UpdateTrading() { }
		
		// TODO
		private void ReceiveTradeData(int pointIndex, byte[] coreData) { }
		
		// TODO
		private void UpdateFinishTrade() { }
		
		// TODO
		private void UpdateFinishTradeDemo() { }
		
		// TODO
		private void OnFinishedTradeDemo(int pointIndex) { }
		
		// TODO
		private void UpdateShowApplicationError() { }
		
		// TODO
		private void ChangeTradeState(TradeState nextState) { }
		
		// TODO
		private void SetAfterErrorDialogAct(AfterErrorDialogActID actID) { }
		
		// TODO
		private void FinishTrade(TradeResult result) { }
		
		// TODO
		private void OnTradeSuccess() { }
		
		// TODO
		private void PlayTradeDemo([Optional] Action onEndDemo) { }
		
		// TODO
		private void OnTradeServerError() { }
		
		// TODO
		private void OnTradeFailed() { }
		
		// TODO
		private bool IsPerformedTrade() { return default; }
		
		// TODO
		private void HideMatchingIcon() { }
		
		// TODO
		private void HideAttentionIcon() { }
		
		// TODO
		private bool WaitSave() { return default; }
		
		// TODO
		[SceneBeforeActivateOperationMethod]
		public IEnumerator ActivateOperation(Transform cluster) { return default; }
		
		// TODO
		private IEnumerator IE_WaitManagerInitialize() { return default; }
		
		// TODO
		private IEnumerator IE_LoadMasterDatas() { return default; }
		
		// TODO
		private void LoadResourcesBackGround() { }
		
		// TODO
		private void SetAllObjectLayer(GameObject target, int layer) { }
		
		// TODO
		private void AppendLoadResource() { }
		
		// TODO
		private void SceneInitialize() { }
		
		// TODO
		private void LoadEffect() { }
		
		// TODO
		private void Start() { }
		
		// TODO
		private void Setup() { }
		
		// TODO
		private void OnDestroy() { }
		
		// TODO
		private void ChangeSceneState(SceneState nextState) { }
		
		// TODO
		private void ChangeSceneStateLaunchAnim() { }
		
		// TODO
		private void ChangeSceneStateModeSelect() { }
		
		// TODO
		private void OnClosedModeSelectMenu() { }
		
		// TODO
		private void OpenSelectTradeMonsBox() { }
		
		// TODO
		private bool CheckHasUnionPenalty() { return default; }
		
		// TODO
		private void StartBrowsingMode() { }
		
		// TODO
		private void ChangeSceneStateBackTitle() { }
		
		// TODO
		private void ChangeSceneStateStartGMSModeAnim() { }
		
		// TODO
		private void ChangeSceneStateEndGMSModeAnim() { }
		
		// TODO
		private void ChangeSceneStateSaveTradeResult() { }
		
		// TODO
		private void ChangeSceneStateMain() { }
		
		// TODO
		private void ChangeSceneStateAchievement() { }
		
		// TODO
		private void ChangeSceneStateReward() { }
		
		// TODO
		private void ChangeSceneStateConfirmContinue() { }
		
		// TODO
		private void OnUpdate(float deltaTime) { }
		
		// TODO
		private void UpdateStateLaunchAnim() { }
		
		// TODO
		private void UpdateStateStartGMSModeAnim(float deltaTime) { }
		
		// TODO
		private void UpdateStateMain(float deltaTime) { }
		
		// TODO
		private void UpdateInput(float deltaTime) { }
		
		// TODO
		private bool CanExitScene() { return default; }
		
		// TODO
		private void BackBoxMenu() { }
		
		// TODO
		private void UpdateStateBackBox() { }
		
		// TODO
		private void UpdateSelectReplaceData() { }
		
		// TODO
		private void UpdateStateEndGMSModeAnim() { }
		
		// TODO
		private void UpdateAchievementAnim() { }
		
		// TODO
		private void UpdateReward() { }
		
		// TODO
		private void UpdateSaveTradeResult() { }
		
		// TODO
		private void UpdatePenalty() { }
		
		// TODO
		private void UpdateCamera(float deltaTime) { }
		
		// TODO
		private void InputCamera() { }
		
		// TODO
		private void OnLateUpdate(float deltaTime) { }
		
		// TODO
		private void UpdatePointMark() { }
		
		// TODO
		private void OnSelectListData(PointHistoryDataModel selectData) { }
		
		// TODO
		private void OpenConfirmReplaceDataMsg() { }
		
		// TODO
		private void JumpPoint(int pointIndex, Action onMoveEnd) { }
		
		// TODO
		private void OpenChoicePointOperationMenu(bool isSelectMarkItem, bool isSelectTop) { }
		
		// TODO
		private void ChoiceMark() { }
		
		// TODO
		private void ChoiceDeleteMark(bool isSelectTop) { }
		
		// TODO
		private void OnChoiceDelete(bool isSelectTop) { }
		
		// TODO
		private void OnChoiceReplaceData() { }
		
		// TODO
		private void JumpNearPoint() { }
		
		// TODO
		private void OnStopCameraMove() { }
		
		// TODO
		private void OnReleaseListInput() { }
		
		// TODO
		private void OnCancelList() { }
		
		// TODO
		private void OpenConfirmStayMessage() { }
		
		// TODO
		private void OnSelectStayData() { }
		
		// TODO
		private void DecideSelectPoint() { }
		
		// TODO
		private void ConfirmExitGMSScene() { }
	}
}