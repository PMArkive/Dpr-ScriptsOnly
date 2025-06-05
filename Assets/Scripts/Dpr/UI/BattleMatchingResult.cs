using System;

namespace Dpr.UI
{
	public class BattleMatchingResult
	{
		private UIBattleMatching _battleMatchingUIPtr;
		private Action _onFinishState;
		private bool _ready;
		private float _readyWaitTime = 3.0f;
		private float _readyProgressTime;
		private bool _closed;
		
		// TODO
		public void Initialize(Action onFinishState) { }
		
		// TODO
		public void Setup(UIBattleMatching battleMatchingUI) { }
		
		// TODO
		public void PreClose() { }
		
		// TODO
		public void Close() { }
		
		// TODO
		public void OnUpdate(float deltaTime) { }
		
		// TODO
		private void LoadModel() { }
	}
}