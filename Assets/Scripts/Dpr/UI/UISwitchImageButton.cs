using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class UISwitchImageButton : MonoBehaviour, IUIButton
	{
		[SerializeField]
		private int id;
		[SerializeField]
		private Image image;
		[SerializeField]
		private Sprite unSelectSprite;
		[SerializeField]
		private Sprite selectSprite;

		private int index;
		private RectTransform rectTransform;
		
		public int Id { get => id; }
		
		public bool IsSelected { get; set; }
		
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
	}
}