using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Dpr.UI
{
	public class GiftWindow : UIWindow
	{
		private static readonly Vector2 MsgWindowAnchorPos = new Vector2(0.0f, 100.0f);

		[SerializeField]
		private GiftNetworkController networkController;
		[SerializeField]
		private GiftMainMenuWindow mainMenuWindow;
		[SerializeField]
		private GiftSerialCodeWindow serialCodeWindow;
		[SerializeField]
		private GiftDownloadWindow downloadWindow;
		[SerializeField]
		private GiftListWindow listWindow;
		[SerializeField]
		private GiftCompleteWindow completeWindow;
		[SerializeField]
		private GiftHistoryWindow historyWindow;
		[SerializeField]
		private GiftErrorWindow errorWindow;

		private UIMsgWindowController msgWindowController;
		private GiftSubWindow beforeSubWindow;
		private GiftSubWindow currentSubWindow;
		private bool isFirstShowSerialCode;
		private bool isSuccessInternetGo;
		
		// TODO
		public override void OnCreate() { }
		
		// TODO
		protected override void OnAddContextMenuYesNoItemParams(List<ContextMenuItem.Param> contextMenuItemParams) { }
		
		// TODO
		public void Open(UIWindowID prevWindowId) { }
		
		// TODO
		public IEnumerator OpOpen(UIWindowID prevWindowId) { return default; }
		
		// TODO
		public void Close(UnityAction<UIWindow> onClosed_, UIWindowID nextWindowId) { }
		
		// TODO
		public IEnumerator OpClose(UnityAction<UIWindow> onClosed_, UIWindowID nextWindowId) { return default; }
		
		// TODO
		private void OnUpdate(float deltaTime) { }
		
		// TODO
		private void HideAllSubWindows() { }
		
		// TODO
		private void ShowMainMenuWindow() { }
		
		// TODO
		private void ShowSerialCodeWindow(bool isClear) { }
		
		// TODO
		private void ShowDownloadWindow(int min, int max) { }
		
		// TODO
		private void ShowListWindow(GiftListItemInfo[] giftListItemInfos, bool isSerial) { }
		
		// TODO
		private void ShowCompleteWindow() { }
		
		// TODO
		private void ShowHistoryWindow() { }
		
		// TODO
		private void ShowErrorWindow(string labelName, UnityAction<UIWindow> onCloseCallback) { }
		
		// TODO
		private void OnCloseMainMenuWindow(UIWindow subWindow) { }
		
		// TODO
		private void OnCloseSerialCodeWindow(UIWindow subWindow) { }
		
		// TODO
		private void OnCloseListWindow(UIWindow subWindow) { }
		
		// TODO
		private void OnCloseHistoryWindow(UIWindow subWindow) { }
		
		// TODO
		private IEnumerator StartReceiveInternet() { return default; }
		
		// TODO
		private IEnumerator StartReceiveSerialCode() { return default; }
		
		// TODO
		private IEnumerator ConnectInternet(bool isShowWarningSerialCode) { return default; }
		
		// TODO
		private IEnumerator StartAuthenticateSerialCode(string inputCode) { return default; }
		
		// TODO
		private IEnumerator DownloadList(ushort dataNo, bool isSerial) { return default; }
		
		// TODO
		private List<GiftListItemInfo> ConvertGiftDatas(byte[] data) { return default; }
		
		// TODO
		private IEnumerator StartProgress(int max) { return default; }
	}
}