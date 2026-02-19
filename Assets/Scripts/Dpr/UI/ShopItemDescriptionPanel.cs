using Dpr.Item;
using Dpr.Message;
using Pml;
using Pml.Item;
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

        public void Set(ShopBase.ShopType shopType, ShopItemItem itemItem)
        {
            _itemItem = itemItem;
            _shopType = shopType;

            var sex = PlayerWork.playerSex;
            ItemInfo.CategoryType category;

            switch (shopType)
            {
                case ShopBase.ShopType.Seal:
                case ShopBase.ShopType.Flower:
                    Set(shopType, itemItem.GetSealInfo());
                    category = ItemInfo.CategoryType.Important;
                    break;

                case ShopBase.ShopType.TobariDepart4F:
                    Set(shopType, itemItem.GetUgItemInfo());
                    category = ItemInfo.CategoryType.Important;
                    break;

                case ShopBase.ShopType.Underground:
                    if (UgItemManager.Instance.GetItemId(itemItem.GetUgItemInfo().UgItemId) < 1)
                    {
                        SetUnderGround(itemItem.GetUgItemInfo());
                        category = ItemInfo.CategoryType.Important;
                    }
                    else
                    {
                        itemNameText.SetupMessage("ss_fld_shop", "SS_fld_shop_212");
                        wazaNameText.text = null;
                        Set(shopType, itemItem.GetItemInfo());
                        category = itemItem.GetItemInfo().Category;
                    }
                    break;

                default:
                    Set(shopType, itemItem.GetItemInfo());
                    category = itemItem.GetItemInfo().Category;
                    break;
            }

            _stock.bag.Initialize(sex);
            _stock.bag.Set((int)category);
        }

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

        private void SetUnderGround(UgItemInfo ugItemInfo)
        {
            if (ugItemInfo == null)
                return;

            UgItemInfo.LoadItemIcon(ugItemInfo.UgItemId, sprite => itemIconImage.sprite = sprite);

            itemNameText.SetFormattedText(() => MessageWordSetHelper.SetUgItemNameWord(0, ugItemInfo.UgItemId), "ss_fld_shop", "SS_fld_shop_318");
            descriptionText.text = ugItemInfo.DescriptionText;
            _stock.num.SetFormattedText(() => MessageWordSetHelper.SetDigitWord(0, ugItemInfo.count), null, null);
            wazaNameText.text = null;

            itemIconImage.enabled = true;
        }

        [Serializable]
        private class Stock
        {
            public UIText num;
            public BagIconPanel bag;
        }
    }
}