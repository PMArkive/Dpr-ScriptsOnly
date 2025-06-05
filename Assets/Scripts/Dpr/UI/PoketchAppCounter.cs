using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class PoketchAppCounter : PoketchAppBase
	{
		[SerializeField]
		private Image _countImage0001;
		[SerializeField]
		private Image _countImage0010;
		[SerializeField]
		private Image _countImage0100;
		[SerializeField]
		private Image _countImage1000;
		[SerializeField]
		private Sprite[] _numberSprites;

		private int _count;
		
		// TODO
		protected override void OnInitialize() { }
		
		// TODO
		protected override void OnOpen() { }
		
		// TODO
		protected override void OnClose() { }
		
		// TODO
		public override void OnAppChanged() { }
		
		// TODO
		protected override void OnUpdateDraw() { }
		
		// TODO
		protected override void OnUpdateControl([Optional][DefaultParameterValue(false)] bool isAppControlEnable, [Optional] PoketchButton targetButton, PoketchWindow.TouchState state = PoketchWindow.TouchState.None) { }
		
		// TODO
		private void SetCount(int count) { }
	}
}