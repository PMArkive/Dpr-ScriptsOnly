using Pml.PokePara;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class PokemonStatusPanelWazaBase : PokemonStatusPanel
	{
		[SerializeField]
		protected RectTransform _contents;
		[SerializeField]
		protected PokemonStatusWazaItem _itemPrefab;
		[SerializeField]
		protected Cursor _cursor;
		[SerializeField]
		protected RectTransform _detailRoot;

		protected List<PokemonStatusWazaItem> _items = new List<PokemonStatusWazaItem>();
		protected int _selectIndex;
		protected bool _showDetail;
		protected VerticalLayoutGroup _verticalLayoutGroup;
		protected PokemonStatusWazaItem _fromSwapItem;
		protected Vector3 _fromSwapPisiton;
		protected int _fromSwapSiblingIndex;
		
		// TODO
		protected virtual void Awake() { }
		
		// TODO
		public virtual void Setup(PokemonParam pokemonParam, bool isContest) { }
		
		// TODO
		protected void SetupItems() { }
		
		// TODO
		protected void SetupKeyguide() { }
		
		// TODO
		protected void ShowDetail(bool enabled) { }
		
		// TODO
		protected virtual void SetupDetail() { }
		
		// TODO
		public override bool OnUpdate(float deltaTime) { return default; }
		
		// TODO
		protected virtual void OpenBagOfWazaMachine() { }
		
		// TODO
		protected bool UpdateSwap(float deltaTime) { return default; }
		
		// TODO
		protected bool UpdateSelect(float deltaTime) { return default; }
		
		// TODO
		protected bool SetSelectIndex(int selectIndex, bool isInitialize = false) { return default; }
	}
}