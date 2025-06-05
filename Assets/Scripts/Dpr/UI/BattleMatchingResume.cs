using System;

namespace Dpr.UI
{
	public class BattleMatchingResume
	{
		private UIBattleMatching _battleMatchingUIPtr;
		private Action _onFinishState;
		private Action<bool> _onSelect;
		private Action _onLeve;
		private bool _resume;
		private bool _ready;
		private bool _closed;
		private bool _finished;
		private float _readyWaitTime = 3.0f;
		private float _readyProgressTime;
		private UIInputController _inputController = new UIInputController();
		
		// TODO
		public void Initialize(Action onFinishState, Action<bool> onSelect, Action onLeve) { }
		
		// TODO
		public void Setup(UIBattleMatching battleMatchingUI) { }
		
		// TODO
		public void PreClose() { }
		
		// TODO
		public void Close() { }
		
		// TODO
		public void OnUpdate(float deltaTime) { }
		
		// TODO
		private void ShowSelectResume() { }
		
		// TODO
		private void OnSelectResume(int index) { }
		
		// TODO
		private void ShowSelectLeave() { }
		
		// TODO
		private void OnSelectLeave(int index) { }
		
		// TODO
		private void OnSelect(bool resume) { }
		
		// TODO
		public void Resume() { }
	}
}