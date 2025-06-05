using System.Runtime.InteropServices;
using UnityEngine;

namespace Dpr.UI
{
	public class PoketchAppPokeList : PoketchAppBase
	{
		[SerializeField]
		private Color32 _sickColor = new Color32(128, 128, 128, 0);

		private const float _updateTime = 5000.0f;

		private ZoneID _zoneId;
		private Material _matGrayScale;
		private Material _matSolidColor;
		private PoketchPokeListButton _selecteButton;
		
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
		public override void OnSizeChanged(bool isLarge) { }
		
		// TODO
		private void SetPokeIcons() { }
	}
}