using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class PoketchAppDWatch : PoketchAppBase
	{
		[SerializeField]
		private Image[] _hourNumImages;
		[SerializeField]
		private Image[] _minuteNumImages;
		[SerializeField]
		private Sprite[] _numSprites;

		private int _hour;
		private int _minute;

		[SerializeField]
		private PoketchButton _targetButton;
		[SerializeField]
		private PoketchWindow.TouchState _state;
		
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
	}
}