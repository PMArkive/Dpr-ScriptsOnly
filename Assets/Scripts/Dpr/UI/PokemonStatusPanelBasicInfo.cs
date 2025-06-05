using Pml.PokePara;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class PokemonStatusPanelBasicInfo : PokemonStatusPanel
	{
		[SerializeField]
		private UIText _zukanNo;
		[SerializeField]
		private UIText _name;
		[SerializeField]
		private UIText _playerName;
		[SerializeField]
		private UIText _playerId;
		[SerializeField]
		private UIText _exp;
		[SerializeField]
		private UIText _remainExp;
		[SerializeField]
		private Slider _sliderExp;
		[SerializeField]
		private UIText _item;
		[SerializeField]
		private UIText _itemDescription;
		[SerializeField]
		private Image _itemIcon;
		[SerializeField]
		private TypePanel[] _types;
		[SerializeField]
		private Image[] _pokeruses;
		[SerializeField]
		private Image _rareType;
		[SerializeField]
		private Image _placeMark;
		[SerializeField]
		private RectTransform _markRoot;
		[SerializeField]
		private RectTransform _itemRoot;
		[SerializeField]
		private PokemonStatusMarkSetting _markSetting;

		private List<PokemonStatusMark> _marks = new List<PokemonStatusMark>();
		private bool _isMarkMode;
		
		// TODO
		private void Awake() { }
		
		// TODO
		public override void Setup(PokemonParam pokemonParam) { }
		
		// TODO
		private void SetupKeyguide(PokemonParam pokemonParam) { }
		
		// TODO
		private void SetupMarks() { }
		
		// TODO
		public override void Select(bool enabled) { }
		
		// TODO
		public override bool OnUpdate(float deltaTime) { return default; }
		
		// TODO
		private void SetMarkMode(bool enabled) { }
		
		// TODO
		private void ShowItem(bool enabled) { }
		
		// TODO
		private void OnCloseMarkSetting() { }
	}
}