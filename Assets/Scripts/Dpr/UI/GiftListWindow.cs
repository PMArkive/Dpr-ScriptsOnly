using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dpr.UI
{
	public class GiftListWindow : GiftSubWindow
	{
		private static readonly Vector2 MsgWindowAnchorPos = new Vector2(0.0f, 100.0f);

		[SerializeField]
		private UIScrollView scrollView;
		[SerializeField]
		private Cursor cursor;
		private List<GiftListItemInfo> giftListItemInfoList;
		private GiftCompleteWindow completeWindow;
		private GiftErrorWindow errorWindow;
		private int selectIndex;
		private bool isShowComplete;
		private bool isShowError;
		private bool isSerialUsed;
		private GiftNetworkController networkController;
		
		public bool IsNoItem { get; set; }
		
		// TODO
		protected override void OnAddContextMenuYesNoItemParams(List<ContextMenuItem.Param> contextMenuItemParams) { }
		
		// TODO
		protected override void OnDestroy() { }
		
		// TODO
		protected override void OnInitialize() { }
		
		// TODO
		public override void OnUpdate(float deltaTime) { }
		
		// TODO
		public override void Show() { }
		
		// TODO
		public void Setup(GiftListItemInfo[] giftListItemInfos, GiftNetworkController networkController, GiftCompleteWindow completeWindow, GiftErrorWindow errorWindow, bool isSerialUsed) { }
		
		// TODO
		private void OnRequiredItemData(IUIButton button) { }
		
		// TODO
		private void OnSelectItemScrollViewItem(IUIButton button) { }
		
		// TODO
		private void OnUnSelectItemScrollViewItem(IUIButton button) { }
		
		// TODO
		private void RefreshScrollView() { }
		
		// TODO
		private void ShowListMessage() { }
		
		// TODO
		private void CloseWindow() { }
		
		// TODO
		private void ShowErrorWindow(string labelName) { }
		
		// TODO
		private IEnumerator ReceiveGift(int selectIndex) { return default; }
	}
}