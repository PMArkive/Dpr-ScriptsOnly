using Pml.PokePara;
using System;
using UnityEngine;

namespace Dpr.UI
{
	public class PokemonStatusPanelContestWaza : PokemonStatusPanelWazaBase
	{
		[SerializeField]
		private DetailParam _detail;
		
		// TODO
		protected override void Awake() { }
		
		// TODO
		public override void Setup(PokemonParam pokemonParam) { }
		
		// TODO
		protected override void OpenBagOfWazaMachine() { }
		
		// TODO
		protected override void SetupDetail() { }

		[Serializable]
		private class DetailParam
		{
			public UIText description;
			public RectTransform contents;
			public PokemonStatusContestWazaAppealItem prefab;
		}
	}
}