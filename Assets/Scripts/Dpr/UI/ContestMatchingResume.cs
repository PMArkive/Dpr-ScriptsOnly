using Dpr.Contest;
using Dpr.MsgWindow;
using System;
using XLSXContent;

namespace Dpr.UI
{
	public class ContestMatchingResume
	{
		private const float WAIT_TIME = 2.0f;

		private ContestMatchingUI contestMatchingUIPtr;
		private ContestMatchingNetwork networkPtr;
		private ContestMasterDatas contMasterDataPtr;
		private UIInputController inputController = new UIInputController();
		private UISelectorWindow selectorWindowPtr;
		private WaitTimer waitTimer;
		private Action<ContestMatching.FinishPattern> onFinish;
		private ResumeState currentState;
		private int loadCount;
		private bool bIsActive;
		
		// TODO
		public void Initialize(ContestMatchingUI contestMatchingUI, ContestMatchingNetwork network, Action<ContestMatching.FinishPattern> onFinish) { }
		
		// TODO
		public void OnFinalize() { }
		
		// TODO
		private void Reset() { }
		
		// TODO
		public void StartProcess(int stationIndex, UISelectorWindow selectorWindow, ContestMasterDatas contestMasterDatas) { }
		
		// TODO
		private void OnFinishMessage() { }
		
		// TODO
		private bool CheckSameMember() { return default; }
		
		// TODO
		private void LoadCharacterModel(int stationIndex, Action onComplete) { }
		
		// TODO
		public void OnUpdate(float deltaTime) { }
		
		// TODO
		private void UpdateCheckEntry() { }
		
		// TODO
		private void UpdateReady(float deltaTime) { }
		
		// TODO
		private void UpdateWait(float deltaTime) { }
		
		// TODO
		private void ChangeState(ResumeState newState) { }
		
		// TODO
		private void OnChangeState_CheckEntry() { }
		
		// TODO
		private void OnChangeState_Ready() { }
		
		// TODO
		private void OnChangeState_Wait() { }
		
		// TODO
		private void OnChangeState_Finish() { }
		
		// TODO
		private void SetReadyFlag(int stationIndex, bool flag) { }
		
		// TODO
		public void OnLeaveOtherPlayer(int stationIndex) { }
		
		// TODO
		public void Deactivate() { }
		
		// TODO
		public bool IsFinishPreparation() { return default; }
		
		// TODO
		public void OnReceiveReadyData(int stationIndex, NoticeID noticeID) { }

		private enum ResumeState : int
		{
			LoadModel = 0,
			CheckEntry = 1,
			Ready = 2,
			Wait = 3,
			Finish = 4,
		}
	}
}