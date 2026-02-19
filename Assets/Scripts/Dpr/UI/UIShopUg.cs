using AK;
using Audio;
using Dpr.Message;
using Dpr.SubContents;
using Pml.UgFather;
using SmartPoint.AssetAssistant;
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
		
		public override void OnCreate()
		{
			base.OnCreate();

			dataManagerPtr = UgFatherDataManager.Instance;

			ugItemPanel.Initialize();
			selectUgItemAmount.Hide();

			state = MenuState.Wait;

			shopMsgFile = MessageManager.Instance.GetMsgFile("ss_fld_shop");

			_itemListScrollView.Initialize(OnRequiredItemData, OnSelectItemScrollViewItem, OnUnSelectItemScrollViewItem);

			msgWindow.Setup(UgFatherDataManager.UNDER_GROUND_MSBT_NAME, PlayerWork.config.msg_speed);
		}
		
		public void Open(UgShopParam param, UIWindowID prevWindowId = WINDOWID_PARENT)
		{
			_param = param;
			Sequencer.Start(OpOpen(prevWindowId));
		}
		
		private IEnumerator OpOpen(UIWindowID prevWindowId)
		{
			OnOpen(prevWindowId);

			keyguide.Open(SubContentsPatternID.ShopUg, transform);

			AudioManager.Instance.SetBgmEvent(EVENTS.DUCKON_BGM);

			_cursor.transform.SetParent(transform);
			_cursor.SetActive(false);

			_selectShopUgItem = null;

			dataManagerPtr.SetupUgShopItems(_param.shopType, _param.randomSheed, _param.dayOfWeek, _itemParams);
			CreateBuyItemDataTable();

			_itemListScrollView.Setup(_itemParams.Count);

			_wazaItemDescriptionType = 0;
			_itemDescriptionPanel.SetWazaDescriptionType(_wazaItemDescriptionType);

			yield return OpPlayOpenWindowAnimation(_prevWindowId, null);

			Sequencer.update -= OnUpdate;
			Sequencer.update += OnUpdate;

			state = MenuState.SelectItem;
			_input.inputEnabled = true;

			_cursor.SetActive(true);
        }
		
		// TODO
		private void CreateBuyItemDataTable() { }
		
		// TODO
		private void OnUpdate(float deltaTime) { }
		
		// TODO
		private void OnUpdateStateSelectItem() { }
		
		private void HideWazaDescription()
		{
			if (_itemParams.Count > 0 && _wazaItemDescriptionType != 0)
			{
				_wazaItemDescriptionType = 0;
				_itemDescriptionPanel.SetWazaDescriptionType(0);
			}
		}
		
		// TODO
		private bool OnUpdateInput() { return default; }
		
		// TODO
		private void SelectItem() { }
		
		// TODO
		private bool CheckCanBuyItem() { return default; }
		
		// TODO
		private void OnDecideAmount(int amount) { }
		
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
			state = MenuState.SelectItem;
			nowAmount = 0;
		}
		
		private bool CheckIsEmptySelectItem()
		{
			return _itemParams.Count < 1;
		}
		
		// TODO
		private void OnRequiredItemData(IUIButton button) { }
		
		// TODO
		private void OnSelectItemScrollViewItem(IUIButton button) { }
		
		private void UpdateItemUI()
		{
			_itemDescriptionPanel.Set(ShopType.Underground, _selectShopUgItem);

			if (_selectShopUgItem.IsUnderGroundItem())
			{
				_itemDescriptionPanel.SetWazaDescriptionType(_wazaItemDescriptionType);
				if (isPrevSelectWazaMachine)
				{
					keyguide.ReplaceKeyguid(SubContentsPatternID.ShopUg);
					isPrevSelectWazaMachine = false;
				}
			}
			else if (_selectShopUgItem.GetItemInfo().IsWazaMachine())
            {
                if (!isPrevSelectWazaMachine)
                {
                    keyguide.ReplaceKeyguid(SubContentsPatternID.ShopUg_WazaMachine);
                    isPrevSelectWazaMachine = true;
                }
            }
			else
			{
                if (isPrevSelectWazaMachine)
                {
                    keyguide.ReplaceKeyguid(SubContentsPatternID.ShopUg);
                    isPrevSelectWazaMachine = false;
                }
            }

			ugItemPanel.ShowSellItemPanel(buyItemDataTable[_selectShopUgItem.param.ugItemID]);
		}
		
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