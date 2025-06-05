using Dpr.Message;
using System;
using System.Collections.Generic;

namespace Dpr.UI
{
	public class BattleMatchingSelectTeamMember
	{
		private UIBattleMatching _battleMatchingUIPtr;
		private Action _onFinishState;
		private Action<int, int> _onSelect;
		private Action _onDecide;
		private List<int> _orderPlayers;
		private MessageMsgFile _msgFile;
		private UIInputController _inputController = new UIInputController();
		private bool _closed;
		
		// TODO
		public void Initialize(Action onFinishState, Action<int, int> onSelect, Action onDecide) { }
		
		// TODO
		public void Setup(UIBattleMatching battleMatchingUI) { }
		
		// TODO
		public void PreClose() { }
		
		// TODO
		public void Close() { }
		
		// TODO
		public void OnUpdate(float deltaTime) { }
		
		// TODO
		public void DecideTeam() { }
		
		// TODO
		private void ShowSelectMessage() { }
		
		// TODO
		private void OnSelectMessage(int index) { }
		
		// TODO
		private void DecidePlayer(int index, int stationIndex) { }
		
		// TODO
		public void LoadModel(int index, int stationIndex) { }
		
		// TODO
		public void UnloadModel(int index) { }
		
		// TODO
		private void SetKeyGuide(bool complete = false) { }
	}
}