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
		
		public int GetIndex()
		{
			return this.index;
		}
		
		public void SetIndex(int index)
		{
			this.index = index;
		}
		
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
		
		public CapsuleInfo GetInfo()
		{
			return this.info;
		}
		
		public void OnSwapStart()
		{
			GameObject.SetActive(this[0],1);
		}
		
		public void OnSwapEnd()
		{
			GameObject.SetActive(this[0],0);
		}
		
		public void OnNotSelectable()
		{
			this.onNotSelectableObject.SetActive(1);
		}
		
		public void OnContextMenuOpen()
		{
			this.contextOpenObject.SetActive(1);
		}
		
		public void OnContextMenuClose()
		{
			this.contextOpenObject.SetActive(0);
		}
	}
}