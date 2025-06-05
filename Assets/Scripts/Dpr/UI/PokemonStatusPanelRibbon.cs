using Pml.PokePara;
using System.Collections.Generic;
using UnityEngine;

namespace Dpr.UI
{
	public class PokemonStatusPanelRibbon : PokemonStatusPanel
	{
		[SerializeField]
		private UIScrollView _scrollView;
		[SerializeField]
		private Cursor _cursor;
		[SerializeField]
		private UIText _name;
		[SerializeField]
		private RectTransform _descRoot;
		[SerializeField]
		private UIText _description;
		[SerializeField]
		private UIText _empty;

		private bool _isSelectRibon;
		private int _selectIndex;
		private int _columnMax = 5;
		private List<PokemonStatusRibbonItem.Param> _itemParams = new List<PokemonStatusRibbonItem.Param>();
		
		// TODO
		private void Awake() { }
		
		// TODO
		public override void Setup(PokemonParam pokemonParam) { }
		
		// TODO
		private bool IsShowAbutton() { return default; }
		
		// TODO
		private void OnRequiredItemData(IUIButton button) { }
		
		// TODO
		private void OnSelectItemScrollViewItem(IUIButton button) { }
		
		// TODO
		private void OnUnSelectItemScrollViewItem(IUIButton button) { }
		
		// TODO
		public override bool OnUpdate(float deltaTime) { return default; }
		
		// TODO
		private bool UpdateSelect(float deltaTime) { return default; }
		
		// TODO
		private void SelectRibonMode(bool enabled) { }
	}
}