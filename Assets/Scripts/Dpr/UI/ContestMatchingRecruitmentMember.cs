using Dpr.Contest;
using Dpr.NetworkUtils;
using System;

namespace Dpr.UI
{
	public class ContestMatchingRecruitmentMember
	{
		private JoinPlayerData[] joinPlayerDataArray;
		private ContestMatchingUI contestMatchingUIPtr;
		private ContestMatchingNetwork networkPtr;
		private UIInputController inputController = new UIInputController();
		private NetworkManager networkManager;
		private Action onFinishState;
		private Action<ContestMatching.FinishPattern> onFinish;
		private RecruitmentState currentState;
		private int loadCount;
		private bool bLockPlayerAction;
		private bool bIsOpenConfirmMsg;
		private bool bIsActive;
		
		// TODO
		public void Initialize(ContestMatchingUI contestMatchingUI, ContestMatchingNetwork network, Action onFinishState, Action<ContestMatching.FinishPattern> onFinishMatching) { }
		
		// TODO
		public void OnFinalize() { }
		
		// TODO
		private void Reset() { }
		
		// TODO
		public void StartProcess(int stationIndex, float startCountDown) { }
		
		// TODO
		private void CheckModelLoadCompleted() { }
		
		// TODO
		public void OnUpdate(float deltaTime) { }
		
		// TODO
		private void UpdateWaitJoinMember(float deltaTime) { }
		
		// TODO
		private void CheckMatchingRecruitmentMemberInit(float deltaTime) { }
		
		// TODO
		private void UpdateWaitSkip(float deltaTime) { }
		
		// TODO
		private void UpdateWaitAllReady(float deltaTime) { }
		
		// TODO
		private void FixSessionPlayerUIInfo() { }
		
		// TODO
		private bool CheckMemberReady(float deltaTime) { return default; }
		
		// TODO
		private void FinishRecruitmentMember() { }
		
		// TODO
		private void CheckMemberActive() { }
		
		// TODO
		private void UpdateInput() { }
		
		// TODO
		private void OnSelectLeaveYes() { }
		
		// TODO
		private void OnSelectLeaveNo() { }
		
		// TODO
		private void HideMatchingUI() { }
		
		// TODO
		private void SetSkipFlag(int stationIndex, bool flag) { }
		
		// TODO
		private void ChangeState_WaitAllReady() { }
		
		// TODO
		public void OnJoinOtherPlayer(int stationIndex) { }
		
		// TODO
		public void OnLeaveMine() { }
		
		// TODO
		public void OnLeaveOtherPlayer(int stationIndex) { }
		
		// TODO
		public void OnChangeHostMine() { }
		
		// TODO
		public void OnChangeHostOtherPlayer() { }
		
		// TODO
		public void Deactivate() { }
		
		// TODO
		public void OnReceiveCountDownData(CountDownNetData timeData) { }
		
		// TODO
		public void OnReceivePlayerData(NetPlayerInfo playerInfo) { }
		
		// TODO
		public void OnReceiveReadyData(int stationIndex, NoticeID noticeID) { }

		private enum RecruitmentState : int
		{
			WaitJoinMember = 0,
			WaitAllReady = 1,
			WaitSkip = 2,
			Retry = 3,
			Finish = 4,
		}

		private class JoinPlayerData
		{
			public string playerName;
			public int cassetVersion;
			public ushort fashion;
			public bool isDpClear;
			
			public void Clear()
			{
				playerName = string.Empty;
				cassetVersion = 0;
				fashion = 0;
				isDpClear = false;
			}
		}
	}
}