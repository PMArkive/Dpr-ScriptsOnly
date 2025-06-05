using System.Runtime.InteropServices;
using UnityEngine;

namespace Dpr.UI
{
	public class PoketchAppAnalogClock : PoketchAppBase
	{
		[SerializeField]
		private RectTransform _hour;
		[SerializeField]
		private RectTransform _minutes;
		
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
		protected override void OnUpdateControl([Optional] [DefaultParameterValue(false)] bool isAppControlEnable, [Optional] PoketchButton targetButton, PoketchWindow.TouchState state = PoketchWindow.TouchState.None) { }
		
		// TODO
		private void SetTime(int hour, int minutes) { }
	}
}