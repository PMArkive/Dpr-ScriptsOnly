using UnityEngine;

namespace Dpr.UI
{
	public class CapsuleItemButton : MonoBehaviour, IUIButton
	{
		[SerializeField]
		private PokemonIcon pokemonIcon;
		[SerializeField]
		private GameObject swapSelectedObject;
		[SerializeField]
		private GameObject contextOpenObject;
		[SerializeField]
		private GameObject onSealObject;
		[SerializeField]
		private GameObject onNotSelectableObject;

		private int index;
		private RectTransform rectTransform;
		private CapsuleInfo info;
		
		// TODO
		public int GetIndex() { return default; }
		
		// TODO
		public void SetIndex(int index) { }
		
		// TODO
		public RectTransform GetRectTransform() { return default; }
		
		// TODO
		public bool GetActive() { return default; }
		
		// TODO
		public void SetActive(bool isActive) { }
		
		// TODO
		public void Select() { }
		
		// TODO
		public void UnSelect() { }
		
		// TODO
		public void SetInfo(CapsuleInfo info) { }
		
		// TODO
		public CapsuleInfo GetInfo() { return default; }
		
		// TODO
		public void OnSwapStart() { }
		
		// TODO
		public void OnSwapEnd() { }
		
		// TODO
		public void OnNotSelectable() { }
		
		// TODO
		public void OnContextMenuOpen() { }
		
		// TODO
		public void OnContextMenuClose() { }
	}
}