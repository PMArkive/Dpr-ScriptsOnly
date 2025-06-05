using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class PoketchAppRoulette : PoketchAppBase
	{
		[SerializeField]
		private Image _canvasImage;
		[SerializeField]
		private RectTransform _arrowTransform;
		[SerializeField]
		private RectTransform _startButtonTransform;
		[SerializeField]
		private RectTransform _stopButtonTransform;
		[SerializeField]
		private RectTransform _resetButtonTransform;

		[SerializeField]
		[Tooltip("最大回転速度(1s)")]
		private float _maxArrowRotateSpeed;
		[SerializeField]
		[Tooltip("最大回転速度到達時間")]
		private float _maxAccelerationTime;
		[SerializeField]
		[Tooltip("最小停止時間")]
		private float _minDecelerationTime;
		[SerializeField]
		[Tooltip("最大停止時間")]
		private float _maxDecelerationTime;
		[SerializeField]
		[Tooltip("ペンの色")]
		private Color _pencolor = Color.black;

		private PoketchAppRouletteState _state;
		private float _currentRotateZ;
		private float _rotateSpeed;
		private float _timeCount;
		private float _decelerationTime;
		private Sprite _lastSettingSprite;
		private Texture2D _canvasTexture;
		private Color[] _canvasColorBuffer;
		private Color[] _clearColorBuffer;
		private int _texturePixelWidth = 460;
		private int _texturePixelHeight = 460;
		private int _pxWriteThickness = 5;
		private int _lastPosPixelX = -1;
		private int _lastPosPixelY = -1;
		private float _displayMargin = 30.0f;
		private bool _isTouchOld;
		private Vector2 _defaultButtonSize = new Vector2(96.0f, 108.0f);
		private Vector2 _pressedButtonSize = new Vector2(96.0f, 96.0f);
		
		// TODO
		protected override void OnInitialize() { }
		
		// TODO
		protected override void OnUninitialize() { }
		
		// TODO
		protected override void OnOpen() { }
		
		// TODO
		protected override void OnClose() { }
		
		// TODO
		protected override void OnUpdateDraw() { }
		
		// TODO
		protected override void OnUpdateControl([Optional] [DefaultParameterValue(false)] bool isAppControlEnable, [Optional] PoketchButton targetButton, PoketchWindow.TouchState state = PoketchWindow.TouchState.None) { }
		
		// TODO
		private void OnPressedButton(PoketchAppButtonType type) { }
		
		// TODO
		private void OnReleasedButton(PoketchAppButtonType type) { }
		
		// TODO
		private void PlayRoulette() { }
		
		// TODO
		private void StopRoulette() { }
		
		// TODO
		private void ResetCanvas() { }
		
		// TODO
		private void ResetRoulette(bool resetArrow) { }
		
		// TODO
		private void OnUpdateRoulette(float deltaTime) { }
		
		// TODO
		private void SetRotateArrow(float deltaTime, float rotateRate) { }
		
		// TODO
		private void OnUpdateCanvas(float deltaTime) { }
		
		// TODO
		private void DrawCanvasTexture(Color color, int pxX, int pxY, int pxThickness, bool interp) { }
		
		// TODO
		private void SetPixelColor(Color color, int pxX, int pxY, int pxThickness) { }

		private enum PoketchAppRouletteState : int
		{
			Stop = 0,
			Acceleration = 1,
			Deceleration = 2,
		}

		private enum PoketchAppButtonType : int
		{
			Play = 0,
			Stop = 1,
			Reset = 2,
		}
	}
}