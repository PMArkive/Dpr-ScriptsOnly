using Dpr.NetworkUtils;
using System;

namespace Dpr.UI
{
	public class BattleMatchingSelectPokemon
	{
		private UIBattleMatching _battleMatchingUIPtr;
		private UIBattleMatchingPokemonSelect _pokemonSelectUIPtr;
		private Action _onFinishState;
		private Action _onSelect;
		private Action<ushort> _onCountDown;
		private bool _ready;
		private bool _stopped;
		private float _readyWaitTime = 3.0f;
		private float _readyProgressTime;
		private bool _isHost;
		private bool _isCountDown;
		private const int START_UI_COUNTDOWN_COUNT = 10;
		private CountDownTimer _countTimer = new CountDownTimer();
		private State _currentState;
		
		// TODO
		public void Initialize(Action onFinishState, Action onSelect, Action<ushort> onCountDown) { }
		
		// TODO
		public void Setup(UIBattleMatching battleMatchingUI) { }
		
		// TODO
		public void PreClose() { }
		
		// TODO
		public void Close() { }
		
		// TODO
		public void OnUpdate(float deltaTime) { }
		
		// TODO
		private void ChangeState(State state) { }
		
		// TODO
		private void SetPreparationIconReady() { }
		
		// TODO
		private void SetPreparationIconWait() { }
		
		// TODO
		public void SetPreparationIconReady(int stationIndex) { }
		
		// TODO
		public void SetPreparationIconWait(int stationIndex) { }
		
		// TODO
		public void StartCountDown(float startTime) { }
		
		// TODO
		private void UpdateCountDown(float deltaTime) { }
		
		// TODO
		private void Timeup() { }
		
		// TODO
		private bool UpdateCountDownFlow(float deltaTime) { return default; }
		
		// TODO
		private void SetCountDownTime() { }
		
		// TODO
		public void SetCountDownTime(int timeCount) { }
		
		// TODO
		private void CheckShowUICountDown() { }
		
		// TODO
		private void UpdateUITimeText() { }

		private enum State : int
		{
			None = 0,
			Select = 1,
			Wait = 2,
		}
	}
}