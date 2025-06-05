using Pml;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Dpr.UI
{
	public class PoketchAppPokeHistory : PoketchAppBase
	{
		[SerializeField]
		private PokemonIcon[] _icons;
		private Material _matGrayScale;
		private List<(MonsNo monsNo, int formno)> _pokeList;
		
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
	}
}