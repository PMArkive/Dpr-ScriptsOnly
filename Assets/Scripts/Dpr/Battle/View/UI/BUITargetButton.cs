using Dpr.Battle.Logic;
using Dpr.UI;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.Battle.View.UI
{
	public sealed class BUITargetButton : BUIButtonBase<BUITargetButton>
	{
		[SerializeField]
		private PokemonIcon _pokeIcon;
		[SerializeField]
		private Image _sexIcon;
		[SerializeField]
		private Image _effectiveFrame;
		[SerializeField]
		private TextMeshProUGUI _effectiveText;
		[SerializeField]
		private Image _effectiveImage;
		[SerializeField]
		private CanvasGroup _canvasGroup;
		[SerializeField]
		private Sprite[] _bgSprite;
		[SerializeField]
		private Sprite[] _frameSprite;
		
		public bool IsGrayOut { get; set; }
		
		// TODO
		public bool Initialize(BTL_POKEPARAM btlParam, bool isSelected, bool isPlayerSide, [Optional] Sprite effectiveSprite, string effectiveStr = "") { return default; }
		
		// TODO
		public bool InitializeForAppearanceDisable(BTL_POKEPARAM btlParam, bool isSelected, bool isPlayerSide, [Optional] Sprite effectiveSprite, string effectiveStr = "") { return default; }
		
		// TODO
		private bool SetEnable(bool isPlayerSide) { return default; }
		
		// TODO
		private void SetPokemon(BTL_POKEPARAM btlParam, bool isPlayerSide) { }
		
		// TODO
		private void SetDisablePokemon() { }
		
		// TODO
		private bool SetDisable() { return default; }
		
		// TODO
		private bool SetAppearanceDisable() { return default; }
		
		// TODO
		private void SetEffective(bool isPlayerSide, bool isSelected, [Optional] Sprite effectiveSprite, string effectiveStr = "") { }

		private enum ButtonType : int
		{
			Player = 0,
			Enemy = 1,
			Disable = 2,
		}
	}
}