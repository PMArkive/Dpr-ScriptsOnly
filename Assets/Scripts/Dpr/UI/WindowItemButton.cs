using UnityEngine;

namespace Dpr.UI
{
	public class WindowItemButton : AWindowItem
	{
		[SerializeField]
		private UIText buttonNameText;

		private UIInputController inputController = new UIInputController();
		
		public override bool IsShowArrowIcon { get => false; }
		public override ItemType ItemType { get => ItemType.Button; }
		
		public void SetButtonText(string text)
		{
			buttonNameText.text = text;
		}
		
		// TODO
		public override bool OnUpdate(float deltaTime) { return default; }
	}
}