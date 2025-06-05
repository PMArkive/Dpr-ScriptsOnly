using Dpr.Item;
using Pml;
using System;
using UnityEngine;

namespace Dpr.UI
{
    public class ShopItemDescriptionPanel : ItemDescriptionPanel
    {
        [SerializeField]
        private Stock _stock;
        [SerializeField]
        private Vector2[] _iconSizes = new Vector2[2]
        {
            new Vector2(80.0f, 80.0f), new Vector2(40.0f, 40.0f),
        };
        private ShopBase.ShopType _shopType = (ShopBase.ShopType)(-1);
        private ShopItemItem _itemItem;

        // TODO
        public void Set(ShopBase.ShopType shopType, ShopItemItem itemItem) { }

        // TODO
        private void Set(ShopBase.ShopType shopType, SealInfo item) { }

        // TODO
        private void Set(SealInfo item, bool isChangeShowWaza = true) { }

        // TODO
        public void Set(ShopBase.ShopType shopType, ItemInfo item) { }

        // TODO
        public void SetWazaDescriptionType(int type) { }

        // TODO
        protected override void SetWazaPower(WazaNo wazaNo, string messageLabel, string messageLabelInvalid) { }

        // TODO
        protected override void SetWazaHitPer(WazaNo wazaNo, string messageLabel, string messageLabelInvalid) { }

        // TODO
        public void Set(ShopBase.ShopType shopType, UgItemInfo ugItem) { }

        // TODO
        private void Set(UgItemInfo ugItem, bool isChangeShowWaza = true) { }

        // TODO
        private void SetUnderGround(UgItemInfo ugItemInfo) { }

        [Serializable]
        private class Stock
        {
            public UIText num;
            public BagIconPanel bag;
        }
    }
}