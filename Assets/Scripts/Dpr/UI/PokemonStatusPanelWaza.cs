using Pml.PokePara;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class PokemonStatusPanelWaza : PokemonStatusPanelWazaBase
	{
		[SerializeField]
		private DetailParam _detail;
		
		// TODO
		protected override void OpenBagOfWazaMachine() { }
		
		// TODO
		public override void Setup(PokemonParam pokemonParam) { }
		
		// TODO
		protected override void SetupDetail() { }

		[Serializable]
		private class DetailParam
		{
			public Image category;
			public UIText power;
			public UIText hitRate;
			public UIText description;
		}
	}
}