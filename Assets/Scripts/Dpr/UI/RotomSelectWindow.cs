using Pml.PokePara;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Dpr.UI
{
	public class RotomSelectWindow : PokemonWindowBase
	{
		[SerializeField]
		private PokemonModelView _modelView;
		private Param _param;
		
		// TODO
		public override void OnCreate() { }
		
		// TODO
		public void Open(Param param, UIWindowID prevWindowId) { }
		
		// TODO
		public IEnumerator OpOpen(Param param, UIWindowID prevWindowId) { return default; }
		
		// TODO
		public void Close(UnityAction<UIWindow> onClosed_, UIWindowID nextWindowId) { }
		
		// TODO
		public IEnumerator OpClose(UnityAction<UIWindow> onClosed_, UIWindowID nextWindowId) { return default; }
		
		// TODO
		private void OnUpdate(float deltaTime) { }
		
		// TODO
		private void OnSelectChangedPartyItem(PokemonPartyItem partyItem, int selectIndex) { }
		
		// TODO
		private void SetupModelView(PokemonParam pokemonParam) { }
		
		// TODO
		private void OnClickPartyItem(PokemonPartyItem partyItem, int selectIndex) { }

		public class Param : BaseParam
		{
			public List<bool> selects = new List<bool>();
			public UnityAction<int> onSelected;
		}
	}
}