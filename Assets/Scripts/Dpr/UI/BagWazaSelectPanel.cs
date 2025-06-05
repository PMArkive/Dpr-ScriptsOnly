using Pml.PokePara;
using System;
using UnityEngine;

namespace Dpr.UI
{
	public class BagWazaSelectPanel : MonoBehaviour
	{
		[SerializeField]
		private PokemonStatusWazaItem[] wazaItems;
		[SerializeField]
		protected Cursor _cursor;

		private IndexSelector indexSelector = new IndexSelector(true, true, true);
		private UIInputController inputController = new UIInputController();
		private Action<int> onDecideCallback;
		private Action onCancelCallback;
		
		public bool IsShow { get; set; }
		
		// TODO
		public void Show() { }
		
		// TODO
		public void Hide() { }
		
		// TODO
		public void Setup(PokemonParam pokemonParam, Action<int> onDecideCallback, Action onCancelCallback) { }
		
		// TODO
		public void OnUpdate(float deltaTime) { }
		
		// TODO
		public void OnUpdateSelect(float deltaTime) { }
	}
}