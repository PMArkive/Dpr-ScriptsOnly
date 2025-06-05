using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class PoketchAppDotArt : PoketchAppBase
	{
		[SerializeField]
		private Image _canvasImage;
		[SerializeField]
		private Vector2 _dotSize;
		[SerializeField]
		private Color[] _fillColors;

		private Sprite _lastSettingSprite;
		private Texture2D _canvasTexture;
		private Color[] _canvasColorBuffer;
		private int[] _canvasColorIndexBuffer;

		private const int TEXTURE_PIXEL_WIDTH = 32;
		private const int TEXTURE_PIXEL_HEIGHT = 24;

		private int _lastPosPixelX = -1;
		private int _lastPosPixelY = -1;
		private float _displayMargin = 30.0f;
		private bool _isTouchOld;
		private bool _isModified = true;
		
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
		protected override void OnUpdateControl([Optional][DefaultParameterValue(false)] bool isAppControlEnable, [Optional] PoketchButton targetButton, PoketchWindow.TouchState state = PoketchWindow.TouchState.None) { }
		
		// TODO
		private void OnFillDot(int line, int colmun) { }
		
		// TODO
		private void OnUpdate(float deltaTime) { }
		
		// TODO
		private void DrawCanvasTexture(int pxX, int pxY, bool interp) { }
		
		// TODO
		private void SetPixelColor(int pxX, int pxY, int addColorIndex) { }
		
		// TODO
		private void ClearColorIndexBuffer() { }
		
		// TODO
		private void InitializeColorIndexBuffer() { }
		
		// TODO
		private void LoadColorIndexBuffer() { }
		
		// TODO
		private void SaveColorIndexBuffer() { }
	}
}