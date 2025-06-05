using DPData;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Dpr.UI
{
	public class PoketchAppColorChanger : PoketchAppBase
	{
		private const float _knobSpan = 52.0f;

		[SerializeField]
		private GameObject _knob;
		[SerializeField]
		private RectTransform _rootKnob;

		private POKETCH_COLOR _colorType;
		
		// TODO
		protected override void OnInitialize() { }
		
		// TODO
		protected override void OnOpen() { }
		
		// TODO
		protected override void OnClose() { }
		
		// TODO
		public override void OnSizeChanged(bool isLarge) { }
		
		// TODO
		protected override void OnUpdateDraw() { }
		
		// TODO
		protected override void OnUpdateControl([Optional][DefaultParameterValue(false)] bool isAppControlEnable, [Optional] PoketchButton targetButton, PoketchWindow.TouchState state = PoketchWindow.TouchState.None) { }
		
		// TODO
		private void SetColorType(POKETCH_COLOR color) { }
		
		// TODO
		private void SetKnob(int index) { }
	}
}