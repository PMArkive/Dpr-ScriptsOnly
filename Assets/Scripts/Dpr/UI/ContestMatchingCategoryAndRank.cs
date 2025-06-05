using Dpr.Contest;
using Dpr.Message;
using System;
using XLSXContent;

namespace Dpr.UI
{
	public class ContestMatchingCategoryAndRank
	{
		private readonly string[] contextMenuLabels = new string[]
		{
            "DP_contest_672", "DP_contest_673",
        };

		private CategoryID[] categoryIds;
		private RankID[] rankIds;
		private ContestMatchingUI contestMatchingUIPtr;
		private ContestMatchingNetwork networkPtr;
		private UISelectorWindow selectorWindowPtr;
		private ContestConfigDatas contConfigDataPtr;
		private MessageMsgFile msgFile;
		private UIInputController inputController = new UIInputController();
		private Action onFinishState;
		private Action<ContestMatching.FinishPattern> onFinish;
		private SelectState currentState;
		private int[] receiveSkillPointArray;
		private int nowSelectPlayerIndex;
		private int transferPlayerIndex = -1;
		private int initSelectPlayerIndex;
		private bool bLockPlayerAction;
		private bool bIsOpenConfirmMsg;
		private bool bIsSelectOwner;
		private bool bIsActive;
		private bool bIsAllMemberDpClear;
		private bool bIsAlreadySelected;
		
		// TODO
		public void Initialize(ContestMatchingUI contestMatchingUI, ContestMatchingNetwork network, Action onFinishState, Action<ContestMatching.FinishPattern> onFinishMatching) { }
		
		// TODO
		public void OnFinalize() { }
		
		// TODO
		private void Reset() { }
		
		// TODO
		public void StartProcess(UISelectorWindow selectorWindow, ContestConfigDatas contConfigData) { }
		
		// TODO
		public void OnUpdate(float deltaTime) { }
		
		// TODO
		private void UpdateWaitLotteryCategoryAndRank() { }
		
		// TODO
		private int GetReceiveCount() { return default; }
		
		// TODO
		private void UpdateSelectCategoryAndRank(float deltaTime) { }
		
		// TODO
		private void UpdateInput() { }
		
		// TODO
		private void OnSelectLeaveYes() { }
		
		// TODO
		private void OnSelectLeaveNo() { }
		
		// TODO
		private void StartSelectCategoryAndRank() { }
		
		// TODO
		private void OpenSelectorWindow() { }
		
		// TODO
		private void TransforNextPlayer(int nextStationIndex) { }
		
		// TODO
		private void OnItemEvent(UISelectorWindow.WindowItemID itemID) { }
		
		// TODO
		private void OnChangeCategory() { }
		
		// TODO
		private void OnPushDecideButton() { }
		
		// TODO
		private T GetWindowItem<T>(UISelectorWindow.WindowItemID itemID) { return default; }
		
		// TODO
		public void OnReceiveChoice(ChoiceNetData choiceData) { }
		
		// TODO
		public void OnReceivePlayerSkillData(SkillPointNetData skillData) { }
		
		// TODO
		private bool CanReceivePlayerSkill(int stationIndex) { return default; }
		
		// TODO
		private void LotCategoryAndRankBySkill() { }
		
		// TODO
		private int CalcTotalPlayerSkillPoint() { return default; }
		
		// TODO
		private RankID LotteryEntryRankBySkillPoint(float aveSkillPoint) { return default; }
		
		// TODO
		private void LotRandomCategoryAndRank() { }
		
		// TODO
		private string[] GetCanEntryCategoryName() { return default; }
		
		// TODO
		private string[] GetCanEntryRankName(CategoryID categoryID) { return default; }
		
		// TODO
		private void DecideCategoryAndRank() { }
		
		// TODO
		private void UpdateWaitAllPlayerReady(float deltaTime) { }
		
		// TODO
		private void UpdateFinish(float deltaTime) { }
		
		// TODO
		public void OnLeaveOtherPlayer(int stationIndex) { }
		
		// TODO
		public void OnChangeHostMine() { }
		
		// TODO
		private int GetSkillPoint(PlayerSkill skillID) { return default; }
		
		// TODO
		public void OnChangeHostOtherPlayer() { }
		
		// TODO
		public void Deactivate() { }
		
		// TODO
		public void OnReceiveCountDownData(CountDownNetData timeData) { }
		
		// TODO
		public void OnReceiveCategoryAndRank(CategoryAndRankNetData categoryAndRankData) { }
		
		// TODO
		public void OnReceiveReadyData(int stationIndex, NoticeID noticeID) { }
		
		// TODO
		private void SendDecideCategoryAndRank() { }

		private enum SelectState : int
		{
			WaitLotteryCategoryAndRank = 0,
			SelectCategoryAndRank = 1,
			WaitAllPlayerReady = 2,
			Finish = 3,
		}
	}
}