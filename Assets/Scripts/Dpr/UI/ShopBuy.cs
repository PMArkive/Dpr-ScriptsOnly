using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Dpr.UI
{
	public class ShopBuy : ShopBase
	{
		[SerializeField]
		private UIText _chargeTitle;
		[SerializeField]
		private UIText _charge;
		private Param _param;
		private List<ShopBuyItemItem.Param> _itemParams = new List<ShopBuyItemItem.Param>();
		private ShopBuyItemItem _selectShopItem;
		
		// TODO
		public override void OnCreate() { }
		
		// TODO
		public void Open(Param param) { }
		
		// TODO
		public IEnumerator OpOpen(Param param) { return default; }
		
		// TODO
		private void SetupCharge() { }
		
		// TODO
		private void OnRequiredItemData(IUIButton button) { }
		
		// TODO
		private void OnSelectItemScrollViewItem(IUIButton button) { }
		
		// TODO
		private void SetupKeyguide() { }
		
		// TODO
		private void OnUnSelectItemScrollViewItem(IUIButton button) { }
		
		// TODO
		public void Close(UnityAction<UIWindow> onClosed_) { }
		
		// TODO
		public IEnumerator OpClose(UnityAction<UIWindow> onClosed_) { return default; }
		
		// TODO
		private void OnUpdate(float deltaTime) { }
		
		// TODO
		private void SequencePurchase(int amount) { }
		
		// TODO
		private int GetCharge() { return default; }
		
		// TODO
		private void SubCharge(int subCharge) { }
		
		// TODO
		protected override void OnAddContextMenuYesNoItemParams(List<ContextMenuItem.Param> contextMenuItemParams) { }

		public class Param
		{
			public ShopType shopType;
			public FriendlyParam friendlyParam;
			public FixedParam fixedParam;
			public TobariDepart4FParam tobariDepart4FParam;
			public BattleParkParam battleParkParam;
			
			// TODO
			public int GetFixedShopId() { return default; }

            public class FriendlyParam
            {
                public ZoneID zoneId;
                public int badgeNum;
            }

            public class FixedParam
            {
                public int shopId;
            }

            public class TobariDepart4FParam
            {
                public int shopId;
            }

            public class BattleParkParam
            {
                public int npcId;
            }
        }
	}
}