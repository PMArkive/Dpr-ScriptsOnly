using Dpr.Box;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class BoxListItem : MonoBehaviour
	{
		[SerializeField]
		private Image _bodyImage;
		[SerializeField]
		private Image _bottomImage;
		[SerializeField]
		private Image[] _pokemonChips;
		[SerializeField]
		private CanvasGroup _canvasGroup;
		[SerializeField]
		private Transform _boxRoot;
		[SerializeField]
		private Color32 _grayColor = new Color32(160, 160, 160, 255);

        public bool IsSelected { get; set; }

        private bool[] _isHitSearch = new bool[BoxWork.TRAY_POKE_MAX];
		private bool _isSearchActive;
		
		// TODO
		public void SetPokemonChips(int index, [Optional] BoxWindow.SEARCH_DATA searchData) { }
		
		// TODO
		public void SetWallColor(int tray, Color32 wallColor) { }
		
		// TODO
		public bool ToggleSelect() { return default; }
	}
}