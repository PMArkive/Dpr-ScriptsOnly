using Dpr.UI;
using UnityEngine;

namespace Dpr.GMS
{
	public abstract class AUIGMSScrollItem : MonoBehaviour, IUIButton
	{
		protected RectTransform rectTransform;
		protected int currentIndex;
		
		// TODO
		public bool GetActive() { return default; }
		
		// TODO
		public int GetIndex() { return default; }
		
		// TODO
		public RectTransform GetRectTransform() { return default; }
		
		// TODO
		public void SetActive(bool isActive) { }
		
		// TODO
		public void SetIndex(int index) { }
		
		// TODO
		public void Select() { }

		// TODO
		protected abstract void OnSelect();
		
		// TODO
		public void UnSelect() { }

		// TODO
		protected abstract void OnUnSelect();
	}
}