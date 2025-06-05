using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class PoketchAppDowsing : PoketchAppBase
	{
		[SerializeField]
		private RectTransform _sonarCanvas;
		[SerializeField]
		private RectTransform _sonarRoot;
		[SerializeField]
		private RectTransform _circleInner;
		[SerializeField]
		private RectTransform _circleOuter;
		[SerializeField]
		private Image _circleInnerImage;
		[SerializeField]
		private Image _circleOuterImage;
		[SerializeField]
		private Image[] _itemImages;
		[SerializeField]
		private float _sonarWaitTime = 0.5f;
		[SerializeField]
		private float _sonarTime = 2.0f;
		[SerializeField]
		private float _sonarSize = 200.0f;
		[SerializeField]
		private float _sonarThicness = 10.0f;

		private PoketchAppDowsingState _state;
		private float _sonarTimeCount;
		private Vector2 _windowMin;
		private Vector2 _windowMax;
		private FieldPoketch.DowsingResult _result;
		private List<Image> _findItemImageList;

		private const float CenterOffsetRateY = 0.06999999f;

		private Vector2Int _playerPosition = new Vector2Int(0, 0);
		
		// TODO
		protected override void OnInitialize() { }
		
		// TODO
		protected override void OnOpen() { }
		
		// TODO
		protected override void OnClose() { }
		
		// TODO
		protected override void OnUpdateDraw() { }
		
		// TODO
		protected override void OnUpdateControl([Optional][DefaultParameterValue(false)] bool isAppControlEnable, [Optional] PoketchButton targetButton, PoketchWindow.TouchState state = PoketchWindow.TouchState.None) { }
		
		// TODO
		private void StartDowsing() { }
		
		// TODO
		private void UpdateDowsing(float deltaTime) { }
		
		// TODO
		private void SetSonarAlpha(float alpha) { }

		private enum PoketchAppDowsingState : int
		{
			None = 0,
			OnSonar = 1,
			SonarFindItem = 2,
			SonarFindItemSomewhere = 3,
			End = 4,
		}
	}
}