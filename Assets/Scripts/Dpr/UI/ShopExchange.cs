using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Dpr.UI
{
    public class ShopExchange : ShopBase
    {
        [SerializeField]
        private UIText _guide;
        [SerializeField]
        private ShopTradeItemDescriptionPanel _tradeItemDescriptionPanel;
        private Param _param;
        private List<ShopExchangeItemItem.Param> _itemParams = new List<ShopExchangeItemItem.Param>();
        private ShopExchangeItemItem _selectShopItem;

        // TODO
        public override void OnCreate() { }

        // TODO
        public void Open(Param param) { }

        // TODO
        public IEnumerator OpOpen(Param param) { return default; }

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
        private void SequenceExchange(int amount) { }

        // TODO
        protected override void OnAddContextMenuYesNoItemParams(List<ContextMenuItem.Param> contextMenuItemParams) { }

        public class Param
        {
            public ShopType shopType = ShopType.Otenki;
            public PalParkParam palParkParam;

            public int GetFixedShopId()
            {
                return -1;
            }

            public class PalParkParam
            {
                public int shopId;
            }
        }
    }
}