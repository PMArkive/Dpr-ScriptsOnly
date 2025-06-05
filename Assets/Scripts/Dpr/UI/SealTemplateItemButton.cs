using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class SealTemplateItemButton : MonoBehaviour, IUIButton
	{
		[SerializeField]
		private Image sealIconImage;
		[SerializeField]
		private UIText nameText;
		[SerializeField]
		private UIText countText;

		private int index;
		private RectTransform rectTransform;
		
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
		public void Set(int sealId, int count) { }
	}
}