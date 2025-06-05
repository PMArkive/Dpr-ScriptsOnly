using UnityEngine;

namespace Dpr.UI
{
	public class GiftSerialCodeWindow : GiftSubWindow
	{
		private const int CodeMinLength = 5;
		private const int CodeMaxLength = 16;
		private const int SplitCodeLength = 4;

		[SerializeField]
		private UIText[] codeTexts;
		private bool isShowSoftwareKeyboard;
		private bool isEnableUpdate;
		
		public string InputSerialCode { get; set; }
		
		// TODO
		protected override void OnInitialize() { }
		
		// TODO
		public override void Show() { }
		
		// TODO
		public override void OnUpdate(float deltaTime) { }
		
		// TODO
		public void ClearTexts() { }
		
		// TODO
		private (bool, string) OnInputCheck(string resultText, SoftwareKeyboard.ErrorState errorState) { return default; }
		
		// TODO
		private void SetSerialCodeText(string text) { }
		
		// TODO
		private void ShowSoftwareKeyboard() { }
	}
}