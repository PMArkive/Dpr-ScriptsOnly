using Dpr.Message;
using Dpr.MsgWindow;
using Dpr.NetworkUtils;
using Dpr.SubContents;
using Dpr.Trainer;
using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Dpr.UI
{
	public class ContestMatchingUI : MonoBehaviour
	{
		private const string WAIT_ICON_TEX_NAME = "cmn_net_pl_wait_02";
		private const string READY_ICON_TEX_NAME = "cmn_net_pl_wait_01";
		private const string SEARCH_PLAYER_LABEL = "DP_contest_602";
		private const string EMPTY_PLAYER_LABEL = "DP_contest_666";

		private const float SHOW_MSG_TIME = 2.0f;
		private const int START_UI_COUNTDOWN_COUNT = 10;

		private readonly string[] YESNO_CONTEXTMENU_LABELS = new string[]
		{
            "DP_contest_292", "DP_contest_293",
        };
		private readonly Vector2 MSG_WINDOW_ANCHOR_POS = new Vector2(15.0f, 110.0f);

		[SerializeField]
		private UIContMatchingPlayerBoard[] _playerBoardArray;
		[SerializeField]
		private MultiModelView modelView;
		[SerializeField]
		private UIRemainingCountDown remainigCountDown;
		[SerializeField]
		private UIText countTimeText;
		[SerializeField]
		private GameObject timerObj;

		private CountDownTimer countTimer = new CountDownTimer();
		private ShowMessageWindow msgWindow = new ShowMessageWindow();
		private KeyGuideCreater _keyGuideCreator = new KeyGuideCreater();
		private MessageMsgFile msgFile;
		private MsgWindowManager msgWindowManager;
		private Transform keyguideParent;
		
		// TODO
		public void Initialize() { }
		
		// TODO
		private Sprite GetSprite(string texName) { return default; }
		
		// TODO
		public void OnFinalize() { }
		
		public int GetNowViewModelCount { get => modelView.ModelViewCount; }
		
		// TODO
		public bool HasViewModelByIndex(int index) { return default; }
		
		// TODO
		public void ShowKeyGuide(SubContentsPatternID patternID) { }
		
		// TODO
		public void CloseKeyGuide(Action onClosed) { }
		
		// TODO
		public void OnJoinMine(int playerIndex) { }
		
		// TODO
		public void OnLeavePlayer(int index) { }
		
		// TODO
		public void OnExitPlayer(int index) { }
		
		// TODO
		public void LoadCharacterModel(int index, TrainerType trainerType, int colorID, string modelPath, Action<GameObject> onComplete) { }
		
		// TODO
		public void DestroyAllCahracterModel() { }
		
		// TODO
		public void DestroyCharacterModel(int index) { }
		
		// TODO
		public void ChangeAllModelMotion(int motionIndex) { }
		
		// TODO
		public void ChangeModelMotion(int index, int motionIndex) { }
		
		// TODO
		public void ResetAllPlayerName() { }
		
		// TODO
		public void SetPlayerName(int index, string name) { }
		
		// TODO
		public void SetPlayerName(int index, string name, MessageEnumData.MsgLangId langId) { }
		
		// TODO
		public void SetEmptyPlayerName(int index) { }
		
		// TODO
		public void ShowPreparatioIconReady(int index) { }
		
		// TODO
		public void ShowPreparatioIconWait(int index) { }
		
		// TODO
		public void HidePreparatioIcon(int index) { }
		
		// TODO
		public void ResetPreparatioIcon() { }
		
		public int CountTime { get => countTimer.RemainingCount; }
		public bool IsFinishCountDown { get => !countTimer.IsCountDown; }
		
		// TODO
		public string GetCountDownMinutStr() { return default; }
		
		// TODO
		public string GetCountDownSecondStr() { return default; }
		
		// TODO
		public void StartCountDown(float startTime) { }
		
		// TODO
		public bool UpdateCountDown(float startTime) { return default; }
		
		// TODO
		public void SetCountDownTime(int timeCount) { }
		
		// TODO
		private void CheckShowUICountDown() { }
		
		// TODO
		private void UpdateUITimeText() { }
		
		// TODO
		public void ShowCountDownTimer() { }
		
		// TODO
		public void HideCountDownTimer() { }
		
		// TODO
		private void SetTimerActive(bool active) { }
		
		// TODO
		public void SetTimerObjActive(bool active) { }
		
		// TODO
		public bool IsWindowOpen() { return default; }
		
		// TODO
		public MsgWindowDataModel.MsgWindowState GetMsgState() { return default; }
		
		// TODO
		public void ShowMessageWindow(string label, [Optional] Action onFinishMessage, bool isShowloadingIcon = false) { }
		
		// TODO
		public void ShowMsgWindowAndContextMenu(string label, string[] contextLabels, [Optional] Action<int> onSelect) { }
		
		// TODO
		public void ShowConfirmYesNoMsg(string message, [Optional] Action onSelectYes, [Optional] Action onSelectNo) { }
		
		// TODO
		public void ShowConfirmLeaveSessionMsg([Optional] Action onSelectYes, [Optional] Action onSelectNo) { }
		
		// TODO
		public void ShowAutoCloseMessageWindow(string label, [Optional] Action onClosed) { }
		
		// TODO
		public void ShowInputCloseMessageWindow(string label, [Optional] Action onCloseed) { }
		
		// TODO
		public void CloseMessageWindow() { }
		
		// TODO
		public void OpenContextMenu(string[] contextLabels, Action<int> onSelect) { }
		
		// TODO
		public void CloseContextMenu() { }
	}
}