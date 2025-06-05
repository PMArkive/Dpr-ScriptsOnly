using System;

namespace Dpr.UI
{
	public class BattleMatchingSelectRule
	{
		private UIBattleMatching _battleMatchingUIPtr;
		private UIInputController _inputController = new UIInputController();
		private Action _onSelectMember;
		private Action _onDecideMember;
		private Action _onLeave;
		private Action _onRule;
		private Action _onFinishState;
		private SelectRuleState currentState;
		private bool _closed;
		private bool _opendLeaveMsg;
		private bool _isWaitDecideRule;
		private float _readyWaitTime = 3.0f;
		private float _readyProgressTime;
		private int nowSelectPlayerIndex;
		
		// TODO
		public void Initialize(Action onFinishState, Action onSelectMember, Action onDecideMember, Action onRule, Action onLeave) { }
		
		// TODO
		public void Setup(UIBattleMatching battleMatchingUI) { }
		
		// TODO
		public void PreClose() { }
		
		// TODO
		public void Close() { }
		
		// TODO
		public void OnUpdate(float deltaTime) { }
		
		// TODO
		private void UpdateSelectMine() { }
		
		// TODO
		public void SelectMember() { }
		
		// TODO
		private void UpdateWaitOtherDecide() { }
		
		// TODO
		private void OnSelectMember(int index) { }
		
		// TODO
		private void WaitSelectMember() { }
		
		// TODO
		private void SelectRule() { }
		
		// TODO
		public void WaitSelectRule(int stationIndex) { }
		
		// TODO
		public void SetReady() { }
		
		// TODO
		private void UpdateReady(float deltaTime) { }
		
		// TODO
		private void CloseAllMsg() { }

		private enum SelectRuleState : int
		{
			None = 0,
			SelectMine = 1,
			SelectOther = 2,
			Ready = 3,
			Finish = 4,
		}
	}
}