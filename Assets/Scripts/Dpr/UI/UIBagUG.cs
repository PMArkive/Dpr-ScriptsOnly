using Dpr.Item;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class UIBagUG : UIWindow
	{
		[SerializeField]
		private UIButtonSelector categorySelector;
		[SerializeField]
		private UIScrollView scrollView;
		[SerializeField]
		private Cursor cursor;
		[SerializeField]
		private GameObject noItemTextObject;
		[SerializeField]
		private UIText descriptionHeaderNameText;
		[SerializeField]
		private UIText descriptionText;
		[SerializeField]
		private Image itemViewImage;

		private List<UgItemInfo> itemInfoList;
		private BagUGCategoryButton currentCategoryButton;
		private Coroutine removeNewIconCoroutine;
		
		// TODO
		public override void OnCreate() { }
		
		// TODO
		public void Open(UIWindowID prevWindowId = WINDOWID_PARENT) { }
		
		// TODO
		public IEnumerator OpOpen(UIWindowID prevWindowId) { return default; }
		
		// TODO
		public void Close(UnityAction<UIWindow> onClosed_, UIWindowID nextWindowId) { }
		
		// TODO
		public IEnumerator OpClose(UnityAction<UIWindow> onClosed_, UIWindowID nextWindowId) { return default; }
		
		// TODO
		private void OnUpdate(float deltaTime) { }
		
		// TODO
		private void OnUpdateSelect(float deltaTime) { }
		
		// TODO
		private void UpdateKeyGuide() { }
		
		// TODO
		private void OnSelectCategoryButton(IUIButton button) { }
		
		// TODO
		private void OnUnSelectCategoryButton(IUIButton button) { }
		
		// TODO
		private void OnRequiredItemData(IUIButton button) { }
		
		// TODO
		private void OnSelectItemScrollViewItem(IUIButton button) { }
		
		// TODO
		private void OnUnSelectItemScrollViewItem(IUIButton button) { }
		
		// TODO
		private void SetupCategoryButtons() { }
		
		// TODO
		private void ReloadScrollView(int selectIndex = 0, float scrollPos = 0.0f) { }
		
		// TODO
		private void SetCursor(IUIButton button) { }
		
		// TODO
		private void ClearItemInfo() { }
		
		// TODO
		private void SetItemInfo(UgItemInfo itemInfo) { }
		
		// TODO
		private void StartRemoveNew(BagUGItemButton itemButton) { }
		
		// TODO
		private void CancelRemoveNew() { }
		
		// TODO
		private bool IsIncludeNewItemInCurrentList() { return default; }
	}
}