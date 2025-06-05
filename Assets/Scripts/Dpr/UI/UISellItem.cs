using Dpr.Item;
using nn.account;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Dpr.UI
{
	public class UISellItem : UIWindow
	{
		private const string SellPriceValueMessageLabel = "SS_bag_067";
		private const string SellNoPriceValueMessageLabel = "SS_bag_072";
		private const string QuestionSellItemMessageLabel = "SS_bag_073";
		private const string NotSellItemMessageLabel = "SS_bag_074";
		private const string ConfirmSellItemMessageLabel = "SS_bag_069";
		private const string SellItemResultMessageLabel = "SS_bag_075";
		private const string SellMultipleItemResultMessageLabel = "SS_bag_076";

		[SerializeField]
		private BagItemPanel bagItemPanel;
		[SerializeField]
		private UIText sellItemPriceText;

		private readonly int _animStateIn = Animator.StringToHash("in");
		private readonly int _animStateOut = Animator.StringToHash("out");

        private ItemListMemory itemListMemory;
		private UIMsgWindowController msgWindowController;
		private bool isWaitUpdate;
		
		// TODO
		public override void OnCreate() { }
		
		// TODO
		public void Open() { }
		
		// TODO
		public IEnumerator OpOpen() { return default; }
		
		// TODO
		public void Close(UnityAction<UIWindow> onClosed_) { }
		
		// TODO
		public IEnumerator OpClose(UnityAction<UIWindow> onClosed_) { return default; }
		
		// TODO
		private void OnUpdate(float deltaTime) { }
		
		// TODO
		private void OnUpdateDefault() { }
		
		// TODO
		private void OnUpdateSelectAmount() { }
		
		// TODO
		private void UpdateKeyGuide() { }
		
		// TODO
		private void SetupBagItemPanel() { }
		
		// TODO
		private void ShowItemContextMenu(ItemInfo item)
        {
			// TODO
			void DecideAction(int amount) { }
        }
		
		// TODO
		private void UpdateSellItemPriceText(ItemInfo item) { }
		
		// TODO
		private void OnSelectAmountValueChanged(int amount) { }
		
		// TODO
		private void OnChangeBagPanelSelectItem(BagItemButton bagItemButton) { }
	}
}