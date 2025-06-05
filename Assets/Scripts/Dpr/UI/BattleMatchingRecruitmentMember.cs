using Dpr.NetworkUtils;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Dpr.UI
{
	public class BattleMatchingRecruitmentMember
	{
		private UIBattleMatching _battleMatchingUIPtr;
		private UIInputController _inputController = new UIInputController();
		private Action _onFinishState;
		private Action _onLeave;
		private int _loadingModelCount;
		private Queue<int> _waitLoadModelList = new Queue<int>();
		private bool _ready;
		private bool _closed;
		private float _readyWaitTime = 3.0f;
		private float _readyProgressTime;
		
		// TODO
		public void Initialize(Action onFinishState, Action onLeave) { }
		
		// TODO
		public void Setup(UIBattleMatching battleMatchingUI) { }
		
		// TODO
		public bool CanClose() { return default; }
		
		// TODO
		public void PreClose() { }
		
		// TODO
		public void Close() { }
		
		// TODO
		public void OnUpdate(float deltaTime) { }
		
		// TODO
		public void JoinMember(int index, int stationIndex, [Optional] NetDataBattleMatchingJoin data) { }
		
		// TODO
		private void LoadModel(int index) { }
	}
}