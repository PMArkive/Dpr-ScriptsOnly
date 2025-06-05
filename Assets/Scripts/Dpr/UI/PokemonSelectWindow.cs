using Pml.PokePara;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Dpr.UI
{
	public class PokemonSelectWindow : PokemonWindowBase
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
			public SelectType selectType = SelectType.Default;
			public UnityAction<int> onSelected;

            [Flags]
            public enum SelectType : int
            {
                Default = 1,
                DisableEgg = 2,
                DisableHpZero = 4,
                PofinEat = 10,
            }
        }
	}
}