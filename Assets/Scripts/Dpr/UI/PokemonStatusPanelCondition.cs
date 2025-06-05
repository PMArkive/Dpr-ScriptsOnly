using Pml.PokePara;
using System.Collections;
using UnityEngine;

namespace Dpr.UI
{
	public class PokemonStatusPanelCondition : PokemonStatusPanel
	{
		[SerializeField]
		private ConditionFur _fur;
		[SerializeField]
		private ConditionRaderChart _rader;
		[SerializeField]
		private UIText _likeTaste;
		
		// TODO
		private void Awake() { }
		
		// TODO
		public override void Setup(PokemonParam pokemonParam) { }
		
		// TODO
		private IEnumerator OpUpdateConditions() { return default; }
		
		// TODO
		private void OnEnable() { }
		
		// TODO
		private void OnDisable() { }
		
		// TODO
		public override void Select(bool enabled) { }
		
		// TODO
		public override bool OnUpdate(float deltaTime) { return default; }
	}
}