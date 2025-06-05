using UnityEngine;

namespace Dpr.UI
{
	public class WindowItemSelector : AWindowItem
	{
		private UIInputController inputController = new UIInputController();

		[SerializeField]
		private UIText titleText;
		[SerializeField]
		private UIText nameText;
		[SerializeField]
		private bool isLoop = true;

		private string[] textArray;
		
		public override bool IsShowArrowIcon { get => textArray.Length > 1; }
		public override ItemType ItemType { get => ItemType.Selector; }
		
		// TODO
		public void SetNameArray(string[] strArray) { }
		
		// TODO
		public void SetText(string text) { }
		
		// TODO
		public void SetTitleText(string msbt, string label) { }
		
		// TODO
		public void SetTitleText(string text) { }
		
		// TODO
		public override bool OnUpdate(float deltaTime) { return default; }
		
		// TODO
		public void DecIndex() { }
		
		// TODO
		public void AddIndex() { }
		
		// TODO
		private void UpdateText() { }
	}
}