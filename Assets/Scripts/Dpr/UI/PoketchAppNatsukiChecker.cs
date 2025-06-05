using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Dpr.UI
{
	public class PoketchAppNatsukiChecker : PoketchAppBase
	{
		[SerializeField]
		private RectTransform _pokeCanvas;
		[SerializeField]
		private PoketchAppNatsukiCheckerIcon[] _pokeIcons;
		[SerializeField]
		[Tooltip("タッチ判定が生じるまでの時間(&ダブルタップ受付時間)")]
		private float _touchTime = 0.1f;

		private Material _matGrayScale;
		private float _displayMargin = 30.0f;
		private float _touchTimeCount;
		private float _releaseTimeCount;
		private bool _isTouchOld;
		private List<PoketchAppNatsukiCheckerIcon> _activePokeIcons;
		
		// TODO
		protected override void OnInitialize() { }
		
		// TODO
		protected override void OnOpen() { }
		
		// TODO
		protected override void OnClose() { }
		
		// TODO
		protected override void OnUpdateDraw() { }
		
		// TODO
		protected override void OnUpdateControl([Optional] [DefaultParameterValue(false)] bool isAppControlEnable, [Optional] PoketchButton targetButton, PoketchWindow.TouchState state = PoketchWindow.TouchState.None) { }
		
		// TODO
		private void OnUpdate(float deltaTime) { }
	}
}