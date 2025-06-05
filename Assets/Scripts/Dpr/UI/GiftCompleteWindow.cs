using DPData.MysteryGift;
using UnityEngine;

namespace Dpr.UI
{
	public class GiftCompleteWindow : GiftSubWindow
	{
		private static readonly Vector2 MsgWindowAnchorPos = new Vector2(0.0f, 100.0f);

		[SerializeField]
		private GiftContentsPanel contentsPanel;
		
		// TODO
		protected override void OnInitialize() { }
		
		// TODO
		public override void OnUpdate(float deltaTime) { }
		
		// TODO
		public override void Show() { }
		
		// TODO
		public void Setup(RecvData data) { }
		
		// TODO
		public void SetInputEnable(bool isEnable) { }
		
		// TODO
		public void ShowMessage(string labelName) { }
	}
}