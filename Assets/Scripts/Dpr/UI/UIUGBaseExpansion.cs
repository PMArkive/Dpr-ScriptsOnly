using Dpr.SubContents;
using Pml.UgFather;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class UIUGBaseExpansion : UIWindow
	{
		private const int NOT_ENOUGHT_COLOR_INDEX = 1;

		[SerializeField]
		private UIRequiredItem[] uiRequiredItemArray;
		[SerializeField]
		private UIText expansionInfoText;

		private UgFatherDataManager.RequiredExpansionItemData[] requiredItemDataArray;
		private ShowMessageWindow msgWindow = new ShowMessageWindow();
		private bool canExpansion;
		
		// TODO
		public override void OnCreate() { }
		
		// TODO
		public void Open(UIWindowID prevWindowId = WINDOWID_PARENT) { }
		
		// TODO
		private IEnumerator OpOpen(UIWindowID prevWindowId) { return default; }
		
		// TODO
		private void Setup() { }
		
		// TODO
		private void StartMessage() { }
		
		// TODO
		private void OnSelectYes() { }
		
		// TODO
		private void UpdatePlayerItem() { }
		
		// TODO
		public void Close(UnityAction<UIWindow> onClosed_) { }
		
		// TODO
		private IEnumerator OpClose(UnityAction<UIWindow> onClosed_, UIWindowID nextWindowId) { return default; }

		[Serializable]
		public struct UIRequiredItem
		{
			public Image itemIconImage;
			public UIText itemNameText;
			public UIText priceText;
			public UIText haveCountText;
		}
	}
}