using Dpr.Item;
using Dpr.UI;
using Pml.Item;
using System;
using System.Collections.Generic;
using UnityEngine;
using XLSXContent;

namespace Pml.UgFather
{
    public class UgFatherDataManager
    {
        public const string UNDER_GROUND_MSBT_NAME = "dlp_underground";
        public const int MAX_SHOP_ITEM_NUM = 10;
        private const int MAX_EXPANSION_ITEM_NUM = 5;
        private const int LIMIT_LOOP_COUNT = 100;

        public static UgFatherDataManager Instance { get; } = new UgFatherDataManager();
        public UgFatherPos UGFPos { get; set; }
        public UgFatherExpansion UGFExpansion { get; set; }
        public UgFatherShopTable UGFShop { get; set; }

        public UgFatherShopTable.Sheetbuy01[] UGFBuyTamaS { get => UGFShop.buy01; }
        public UgFatherShopTable.Sheetbuy02[] UGFBuyTamaL { get => UGFShop.buy02; }
        public UgFatherShopTable.Sheetbuy01diz[] UGFBuyTamaS_Diz { get => UGFShop.buy01diz; }
        public UgFatherShopTable.Sheetbuy02diz[] UGFBuyTamaL_Diz { get => UGFShop.buy02diz; }
        public UgFatherShopTable.Sheetsale01[] UGFSalePedestal { get => UGFShop.sale01; }
        public UgFatherShopTable.Sheetsale02[] UGFSaleItem { get => UGFShop.sale02; }
        public UgFatherShopTable.SheetshopListData[] UGFShopListData { get => UGFShop.shopListData; }

        public void Initialize(UgFatherPos ugfPos, UgFatherExpansion ugfExpansion, UgFatherShopTable ugfShop)
        {
            UGFPos = ugfPos;
            UGFExpansion = ugfExpansion;
            UGFShop = ugfShop;
        }

        // TODO
        public void SetupUgShopItems(UgShopType shopType, int randomSeed, DayOfWeek dayOfWeek, List<ShopUgExchangeItemItem.Param> itemParamList) { }

        // TODO
        private int LotShopItemRate(int randomSeed) { return 0; }

        // TODO
        private void LotShopUgSItemList(List<ShopUgExchangeItemItem.Param> itemList, int randomSeed, byte priceRate, DayOfWeek dayOfWeek) { }

        // TODO
        private void LotShopUgLItemList(List<ShopUgExchangeItemItem.Param> itemList, int randomSeed, byte priceRate, DayOfWeek dayOfWeek) { }

        // TODO
        private UgFatherShopTable.SheetBuyBase[] GetUGFBuyDatasByCategory(in UgFatherShopTable.SheetBuyBase[] datas, UgItemCategory category) { return null; }

        // TODO
        private UgFatherShopTable.SheetBuyBase[] GetUGFBuyPedestalDatas(in UgFatherShopTable.SheetBuydizBase[] datas, DayOfWeek dayOfWeek) { return null; }

        // TODO
        private bool CheckZukanFlag(bool isNeedCheckZukanFlag) { return false; }

        // TODO
        private bool CheckBadgeNum(int needBadheNum) { return false; }

        // TODO
        private bool CheckDayOfWeek(UgFatherShopTable.SheetBuydizBase data, DayOfWeek dayOfWeek) { return false; }

        // TODO
        private bool CheckSystemFlag(int systemFlagIndex) { return false; }

        // TODO
        private void LotUGFBuyDatasByCategory(in UgFatherShopTable.SheetBuyBase[] datas, UgItemCategory category, int randomSeed, int lotNum, byte priceRate, List<ShopUgExchangeItemItem.Param> itemList) { }

        // TODO
        private ShopUgExchangeItemItem.Param CreateShopUgItemParam(UgFatherShopTable.SheetBuyBase data, byte priceRate) { return default; }

        // TODO
        public SellItemData CreateShopUgExchangeItemData(ShopUgExchangeItemItem.Param param) { return default; }

        // TODO
        public SellItemData CreatePedestalSellItemData(int ugItemId) { return null; }

        // TODO
        public ItemInfo.CategoryType[] CreateSellItemCategoryArray() { return null; }

        // TODO
        public SellItemData CreateSellItemDataByIndex(int index) { return null; }

        public bool IsMaxExpansion { get => UGFExpansion.Expansion.Length <= PlayerWork.ugSaveData.ugRecord.myBase.expansionStatus; }

        // TODO
        public RequiredExpansionItemData[] CreateRequierdUgBaseExpantionItemDatas() { return null; }

        public enum UgUIWindowType : int
        {
            None = 0,
            TradeUgItemS = 1,
            TradeUgItemL = 2,
            SellItemUg = 3,
            SellUgItem = 4,
            Expantion = 5,
        }

        public enum UgShopType : int
        {
            UgShop_S = 0,
            UgShop_L = 1,
        }

        private enum UgItemCategory : int
        {
            Drill = 0,
            Tama = 1,
            Pedestal = 2,
            WazaMachine = 3,
        }

        public class SellItemData
        {
            public Sprite iconSpr;
            public int ugItemID;
            public int price;
            public int unit;
            public int haveCount;
        }

        public class RequiredExpansionItemData
        {
            public int ugItemId;
            public int price;
            public int haveCount;

            public RequiredExpansionItemData(int ugItemId, int price)
            {
                this.ugItemId = ugItemId;
                this.price = price;

                var itemID = UgItemManager.Instance.GetItemId(ugItemId);
                haveCount = itemID < 1 ? UgItemWork.GetItemInfo(itemID).count : ItemWork.GetItemInfo(itemID).count;
            }

            public bool IsEnought { get => price <= haveCount; }
        }
    }
}