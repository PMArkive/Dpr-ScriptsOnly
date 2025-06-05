using Dpr.Contest;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using XLSXContent;

namespace Dpr.UI
{
	public class ContestMatchingPreparation
	{
		private readonly string[] CONTEXTMENU_LABELS = new string[]
		{
            "DP_contest_611", "DP_contest_428",
        };
		private readonly List<UIWindowID> USE_WINDOW_ID_ARRAY = new List<UIWindowID>()
		{
			UIWindowID.CONTEST_POKEMON, UIWindowID.CONTEST_WAZA,
            UIWindowID.CONTEST_CAPSULE, UIWindowID.CONTEST_BOUTIQUE,
        };

		private bool[] activeMemberArray;
		private ushort[] fashionIDArray;
		private ContestMatchingUI contestMatchingUIPtr;
		private ContestMatchingNetwork networkPtr;
		private UISelectorWindow selectorWindowPtr;
		private UIManager uiManager;
		private IContestUIWindow nowOpenWindow;
		private ContestViewSystem wazaViewSystem;
		private ContestMasterDatas contestMasterDatas;
		private Action<ContestMatching.FinishPattern> onFinish;
		private PreparationState currentState;
		private UIMenuState menuState;
		private int loadCount;
		private int currentJoinNum;
		private bool bIsAlreadyChangeFinishPreparation;
		private bool bIsReceivedStageRank;
		private bool bIsCountDown;
		private bool bIsActive;
		
		// TODO
		public void Initialize(ContestMatchingUI contestMatchingUI, ContestMatchingNetwork network, Action<ContestMatching.FinishPattern> onFinish) { }
		
		// TODO
		public void OnFinalize() { }
		
		// TODO
		private void Reset() { }
		
		// TODO
		public void StartProcess(float startCountDown, ContestMasterDatas contestMasterDatas, UISelectorWindow selectorWindow) { }
		
		// TODO
		private void ResetContestParam() { }
		
		// TODO
		private IEnumerator IE_PreLoadUIWindows(float startCountDown) { return default; }
		
		// TODO
		public void OnUpdate(float deltaTime) { }
		
		// TODO
		private void UpdateWaitAllMemberPreparation(float deltaTime) { }
		
		// TODO
		private void UpdateLoadingWazaSquence(float deltaTime) { }
		
		// TODO
		private void UpdateWaitReceivePlayerDatas(float deltaTime) { }
		
		// TODO
		private void UpdateWaitHostContestLevel() { }
		
		// TODO
		private void UpdateLoadMemberModel() { }
		
		// TODO
		private void UpdateWaitAllMemberReady(float deltaTime) { }
		
		// TODO
		private void UpdateCountDown(float deltaTime) { }
		
		// TODO
		private void Timeup() { }
		
		// TODO
		private void ChangeState(PreparationState newState) { }
		
		// TODO
		private void OnChangeStateConfirm() { }
		
		// TODO
		private void OnChangeStateWaitAllMemberPreparation() { }
		
		// TODO
		private void OnChangeStateLoadingWazaSeq() { }
		
		// TODO
		private void OnChangeStateSendPlayerData() { }
		
		// TODO
		private void SendMyEntryDataToAll() { }
		
		// TODO
		private void OnChangeStateSendContestData() { }
		
		// TODO
		private void OnChangeStateLoadMemberModel() { }
		
		// TODO
		private void CheckLoadPlayerModel(int stationIndex, ushort newFashionID, [Optional] Action onComplete) { }
		
		// TODO
		private void OnChangeStateCheckEntryMember() { }
		
		// TODO
		private void LoadNPCModel(int index, int npcDataIndex) { }
		
		// TODO
		private void ShowGoContestSceneMessage() { }
		
		// TODO
		private void OnChangeStateWaitAllMemberReady() { }
		
		// TODO
		private void OnChangeStateFinish() { }
		
		// TODO
		private void ChangeStateUIMenu(UIMenuState newState) { }
		
		// TODO
		private void OpenPokeSelectWindow() { }
		
		// TODO
		private void OpenWazaSelectWindow() { }
		
		// TODO
		private void OpenCapsuleSelectWindow() { }
		
		// TODO
		private void OpenBoutiqueSelectWindow() { }
		
		// TODO
		private void OnFinishPreparation() { }
		
		// TODO
		private T OpenUIWIndow<T>(UIWindowID openWindowID, Action onDecide, Action onCancel) { return default; }
		
		// TODO
		private void OnCompletePreparation(int stationIndex) { }
		
		// TODO
		public void OnChangeHostMine() { }
		
		// TODO
		public void OnLeaveOtherPlayer(int stationIndex) { }
		
		// TODO
		private void ForceCloseUIWindow() { }
		
		// TODO
		public void Deactivate() { }
		
		// TODO
		public bool IsFinishPreparation() { return default; }
		
		// TODO
		public void OnReceiveCountDownData(CountDownNetData timeData) { }
		
		// TODO
		private bool CheckTimeUp() { return default; }
		
		// TODO
		public void OnReceiveEntryNPCData(ContestEntryNPCNetData entryNPCData) { }
		
		// TODO
		public void OnReceiveEntryPlayerData(int stationIndex) { }
		
		// TODO
		public void OnReceiveContestInfoData(ContestInfoNetData contestData) { }
		
		// TODO
		public void OnReceiveReadyData(int stationIndex, NoticeID noticeID) { }

		private enum PreparationState : int
		{
			Confirm = 0,
			UIMenu = 1,
			WaitAllMemberPreparation = 2,
			LoadingWazaSquence = 3,
			SendPlayerData = 4,
			WaitReceivePlayerDatas = 5,
			WaitHostContestLevel = 6,
			SendContestData = 7,
			LoadMemberModel = 8,
			CheckEntryMember = 9,
			WaitAllMemberReady = 10,
			Finish = 11,
		}

		private enum UIMenuState : int
		{
			PokeSelect = 0,
			WazaSelect = 1,
			CapsuleSelect = 2,
			BoutiqueSelect = 3,
		}
	}
}