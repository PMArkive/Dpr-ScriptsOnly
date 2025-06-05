using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class PoketchAppMemo : PoketchAppBase
	{
		[SerializeField]
		private Image _canvasImage;
		[SerializeField]
		private Sprite[] _cursorIconSprites;
		[SerializeField]
		private Image[] _unselectedImages;
		[SerializeField]
		private int _texturePixelWidth = 510;
		[SerializeField]
		private int _texturePixelHeight = 450;
		[SerializeField]
		private Color _pencolor = Color.black;

		private PoketchAppMemoState _state;
		private Image _cursorImage;
		private Texture2D _canvasTexture;
		private Color[] _canvasColorBuffer;
		private int _pxWriteThickness = 11;
		private int _pxEraceThickness = 23;
		private int _lastPosPixelX = -1;
		private int _lastPosPixelY = -1;
		private float _displayMargin = 30.0f;
		private bool _isTouchOld;

		private const float DefaultButtonHeight = 220.0f;
		private const float PressButtonHeight = 208.0f;

		private Vector2 IconSize = new Vector2(64.0f, 64.0f);
		private Vector2 IconOffset = new Vector2(30.0f, 30.0f);
		private Vector2 _defaultIconSize = new Vector2(68.0f, 94.0f);
		private Vector2 _defaultIconOffset = new Vector2(10.0f, -44.0f);
		private bool _isCloseOnce;
		
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
		private void SetState(PoketchAppMemoState state, bool isSetCursor = true) { }
		
		// TODO
		private void OnUpdate(float deltaTime) { }
		
		// TODO
		private void SetCursor(PoketchAppMemoState state) { }
		
		// TODO
		private void DrawCanvasTexture(Color color, int pxX, int pxY, int pxThickness, bool interp) { }
		
		// TODO
		private void SetPixelColor(Color color, int pxX, int pxY, int pxThickness) { }

		private enum PoketchAppMemoState : int
		{
			None = 0,
			Write = 1,
			Erace = 2,
		}
	}
}