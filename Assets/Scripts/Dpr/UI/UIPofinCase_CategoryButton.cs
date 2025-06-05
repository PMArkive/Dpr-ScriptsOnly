using System;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class UIPofinCase_CategoryButton : MonoBehaviour
	{
		public UIPofinCase_CategorySelector.Category category;
		public Action OnEnableCallback;
		private Image image;
		private UIText text;

		private static readonly Color OffColor = new Color32(200, 200, 200, 255);

		public Sprite SelectedImage;
		public Sprite UnselectedImage;
		
		// TODO
		private void Awake() { }
		
		public bool isOn { get; set; }
		
		// TODO
		public void SetOn() { }
		
		// TODO
		public void SetOff() { }
	}
}