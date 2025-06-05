using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class PoketchAppKichenTimer : PoketchAppBase
	{
		[SerializeField]
		[Tooltip("背景アニメーションの切り替え間隔")]
		private float _bgAniamationTime = 0.3f;
		[SerializeField]
		[Tooltip("ボタン明滅の切り替え間隔")]
		private float _buttonBlinkTime = 0.5f;
		[SerializeField]
		private Image _secondsImage01;
		[SerializeField]
		private Image _secondsImage10;
		[SerializeField]
		private Image _minutesImage01;
		[SerializeField]
		private Image _minutesImage10;
		[SerializeField]
		private Sprite[] _numberSprites;
		[SerializeField]
		private Image _bgImage01;
		[SerializeField]
		private Image _bgImage02;
		[SerializeField]
		private Image _bgImage03;
		[SerializeField]
		private Sprite[] _bgSprites01;
		[SerializeField]
		private Sprite[] _bgSprites02;
		[SerializeField]
		private Sprite[] _bgSprites03;

		private TimerState _state;
		private float _timer;
		private int _displayMinutes;
		private int _displaySeconds;
		private TimerBgState _bgState;
		private float _bgAnimationTimeCount;
		private bool _isButtonVisible = true;

		private const float PRESSED_OFFSET_Y = -10.0f;

		private float _buttonBlinkTimeCount;
		private Vector3 _defaultStartButtonPosition;
		private Vector3 _defaultStopButtonPosition;
		private Vector3 _pressedStartButtonPosition;
		private Vector3 _pressedStopButtonPosition;
		
		// TODO
		protected override void OnInitialize() { }
		
		// TODO
		protected override void OnOpen() { }
		
		// TODO
		protected override void OnClose() { }
		
		// TODO
		public override void OnSizeChanged(bool isLarge) { }
		
		// TODO
		public override void OnAppChanged() { }
		
		// TODO
		protected override void OnUpdateDraw() { }
		
		// TODO
		protected override void OnUpdateControl([Optional] [DefaultParameterValue(false)] bool isAppControlEnable, [Optional] PoketchButton targetButton, PoketchWindow.TouchState state = PoketchWindow.TouchState.None) { }
		
		// TODO
		private void StartTimer() { }
		
		// TODO
		private void StopTimer() { }
		
		// TODO
		private void ResetTimer(bool isPlaySE = true) { }
		
		// TODO
		private void OnCountFinished() { }
		
		// TODO
		private void SetTimer(int minutes, int seconds) { }
		
		// TODO
		private void AddTimerSeconds01(int addSeconds01) { }
		
		// TODO
		private void AddTimerSeconds10(int addSeconds10) { }
		
		// TODO
		private void AddTimerMinutes01(int addMinutes01) { }
		
		// TODO
		private void AddTimerMinutes10(int addMinutes10) { }
		
		// TODO
		private void SetTimerDisplay(float seconds) { }
		
		// TODO
		private void SetTimerDisplay(int minutes, int seconds) { }
		
		// TODO
		private void SetBgSprites(TimerBgState state) { }
		
		// TODO
		private void SetButtonsVisible(bool visible) { }

		private enum TimerState : int
		{
			Idle = 0,
			Stop = 1,
			CountDown = 2,
			Finished = 3,
			End = 4,
		}

		private enum TimerButtonType : int
		{
			Start = 0,
			Stop = 1,
			Reset = 2,
			Seconds01_Up = 3,
			Seconds01_Down = 4,
			Seconds10_Up = 5,
			Seconds10_Down = 6,
			Minutes01_Up = 7,
			Minutes01_Down = 8,
			Minutes10_Up = 9,
			Minutes10_Down = 10,
			End = 11,
		}

		private enum TimerBgState : int
		{
			Idle = 0,
			Finished01 = 1,
			Finished02 = 2,
			CountDown = 3,
		}
	}
}