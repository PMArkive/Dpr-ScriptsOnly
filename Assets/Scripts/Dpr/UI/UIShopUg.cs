using Dpr.Message;
using Dpr.SubContents;
using Pml.UgFather;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Dpr.UI
{
	public class UIShopUg : ShopBase
	{
		[SerializeField]
		private UgItemSelectAmount selectUgItemAmount;
		[SerializeField]
		private SellUgItemPanel ugItemPanel;

		private Dictionary<int, UgFatherDataManager.SellItemData> buyItemDataTable = new Dictionary<int, UgFatherDataManager.SellItemData>();
		private List<ShopUgExchangeItemItem.Param> _itemParams = new List<ShopUgExchangeItemItem.Param>();
		private UgFatherDataManager dataManagerPtr;
		private UgShopParam _param;
		private ShowMessageWindow msgWindow = new ShowMessageWindow();
		private MessageMsgFile shopMsgFile;
		private KeyGuideCreater keyguide = new KeyGuideCreater();
		private ShopUgExchangeItemItem _selectShopUgItem;
		private UgFatherDataManager.SellItemData buyItemData;
		private MenuState state;
		private int nowAmount;
		private int tardeUgItemCount;
		private bool isPrevSelectWazaMachine;
		
		// TODO
		public override void OnCreate() { }
		
		// TODO
		public void Open(UgShopParam param, UIWindowID prevWindowId = WINDOWID_PARENT) { }
		
		// TODO
		private IEnumerator OpOpen(UIWindowID prevWindowId) { return default; }
		
		// TODO
		private void CreateBuyItemDataTable() { }
		
		// TODO
		private void OnUpdate(float deltaTime) { }
		
		// TODO
		private void OnUpdateStateSelectItem() { }
		
		private void HideWazaDescription()
		{
			if ((0 < this._itemParams.Length) && (this._wazaItemDescriptionType != 0)) {
			  this._wazaItemDescriptionType = 0;
			  this._itemDescriptionPanel.SetWazaDescriptionType(0);
			}
		}
		
		// TODO
		private bool OnUpdateInput() { return default; }
		
		// TODO
		private void SelectItem() { }
		
		// TODO
		private bool CheckCanBuyItem() { return default; }
		
		private void OnDecideAmount(int amount)
		{
			this.state = (MenuState)3;
			this.nowAmount = this.buyItemData[0] * amount;
		}
		
		// TODO
		private void OnUpdateStateSelectAmount() { }
		
		// TODO
		private void OnUpdateStateConfirm() { }
		
		// TODO
		private void OnSelectYes() { }
		
		// TODO
		private void UpdateUserItemData() { }
		
		private void OnFinishSellProcess()
		{
			this.state = (MenuState)1;
		}
		
		private bool CheckIsEmptySelectItem()
		{
			return this._itemParams.Length < 1;
		}
		
		// TODO
		private void OnRequiredItemData(IUIButton button) { }
		
		// TODO
		private void OnSelectItemScrollViewItem(IUIButton button) { }
		
		// TODO
		private void UpdateItemUI() { }
		
		// TODO
		private void OnUnSelectItemScrollViewItem(IUIButton button) { }
		
		// TODO
		public void Close(UnityAction<UIWindow> onClosed_) { }
		
		// TODO
		private IEnumerator OpClose(UnityAction<UIWindow> onClosed_) { return default; }

		public class UgShopParam
		{
			public UgFatherDataManager.UgShopType shopType;
			public DayOfWeek dayOfWeek;
			public int randomSheed;
		}

		private enum MenuState : int
		{
			Wait = 0,
			SelectItem = 1,
			SelectAmount = 2,
			OpenConfirm = 3,
			WaitSell = 4,
		}
	}
}