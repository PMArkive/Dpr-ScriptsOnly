using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class PokemonParty : MonoBehaviour
	{
		[SerializeField]
		private RectTransform _contentRoot;
		[SerializeField]
		private RectTransform _basePlateRoot;
		[SerializeField]
		private Sprite[] _spriteBasePlates;

		private List<PokemonPartyItem> _activeItems;
		private int _selectIndex;
		private VerticalLayoutGroup _verticalLayoutGroup;
		private PokemonPartyItem _fromSwapItem;
		private int _fromSwapSiblingIndex;
		private UnityAction<PokemonPartyItem, PokemonPartyItem> _onSwapChanged;
		private PokemonPartyItem _fromItemSwapItem;
		private UnityAction<PokemonPartyItem, PokemonPartyItem, bool, bool> _onItemSwapChanged;
		private bool _isActived;
		private UIInputController _input;
		public UnityAction<PokemonPartyItem, int> onClicked;
		public UnityAction<PokemonPartyItem, int> onSelectChanged;
		private Param _param;
		
		public Param param { get => _param; }
		public List<PokemonPartyItem> items { get => _activeItems; }
		public int selectIndex { get => _selectIndex; }
		
		// TODO
		private void Awake() { }
		
		// TODO
		public void Setup(Param param) { }
		
		// TODO
		private void SetupActiveItems() { }
		
		// TODO
		public void SetActive(bool enabled, bool isSelectChanged = false) { }
		
		// TODO
		public bool OnUpdate(float deltaTime, UIInputController input) { return default; }
		
		// TODO
		private void UpdateSelect(float deltaTime) { }
		
		// TODO
		private bool UpdateSwap(float deltaTime) { return default; }
		
		// TODO
		private bool UpdateItemSwap(float deltaTime) { return default; }
		
		// TODO
		public bool SetSelectIndex(int selectIndex, bool isInitialize = false) { return default; }
		
		// TODO
		public void ResetSelectIndex() { }
		
		// TODO
		public PokemonPartyItem GetSelectedItem() { return default; }
		
		// TODO
		public void BeginSwap(UnityAction<PokemonPartyItem, PokemonPartyItem> onSwapChanged) { }
		
		// TODO
		public bool IsSwapMode() { return default; }
		
		// TODO
		public void BeginItemSwap(UnityAction<PokemonPartyItem, PokemonPartyItem, bool, bool> onSwapChanged) { }
		
		// TODO
		public void SetBasePlateType(int index, int plateType) { }

		public class Param
		{
			public List<PokemonPartyItem.Param> itemParams = new List<PokemonPartyItem.Param>();
			public int selectIndex;
			public bool isMultiBattle;
		}
	}
}