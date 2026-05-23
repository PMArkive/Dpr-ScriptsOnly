using Dpr.EvScript;
using Dpr.Item;
using Dpr.Message;
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
        public UgFatherPos UGFPos { get; private set; }
        public UgFatherExpansion UGFExpansion { get; private set; }
        public UgFatherShopTable UGFShop { get; private set; }

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

        public void SetupUgShopItems(UgShopType shopType, int randomSeed, DayOfWeek dayOfWeek, List<ShopUgExchangeItemItem.Param> itemParamList)
        {
            itemParamList.Clear();

            if (shopType == UgShopType.UgShop_S)
                LotShopUgSItemList(itemParamList, randomSeed, (byte)LotShopItemRate(randomSeed), dayOfWeek);
            else
                LotShopUgLItemList(itemParamList, randomSeed, (byte)LotShopItemRate(randomSeed), dayOfWeek);
        }

        private int LotShopItemRate(int randomSeed)
        {
            return randomSeed % 2;
        }

        private void LotShopUgSItemList(List<ShopUgExchangeItemItem.Param> itemList, int randomSeed, byte priceRate, DayOfWeek dayOfWeek)
        {
            var catNums = UGFShop.shopListData[0].categoryItemNum;

            if (FlagWork.GetFlag(EvWork.FLAG_INDEX.FE_C04R0801_MISSION2))
            {
                LotUGFBuyDatasByCategory(GetUGFBuyDatasByCategory(UGFShop.buy01, UgItemCategory.Drill),   UgItemCategory.Drill,
                    randomSeed, catNums[(int)UgItemCategory.Drill],   priceRate, itemList);
            }

            LotUGFBuyDatasByCategory(GetUGFBuyDatasByCategory(UGFShop.buy01, UgItemCategory.Tama),        UgItemCategory.Tama,
                randomSeed, catNums[(int)UgItemCategory.Tama],        priceRate, itemList);

            LotUGFBuyDatasByCategory(GetUGFBuyPedestalDatas(UGFShop.buy01diz, dayOfWeek),                 UgItemCategory.Pedestal,
                randomSeed, catNums[(int)UgItemCategory.Pedestal],    priceRate, itemList);

            LotUGFBuyDatasByCategory(GetUGFBuyDatasByCategory(UGFShop.buy01, UgItemCategory.WazaMachine), UgItemCategory.WazaMachine,
                randomSeed, catNums[(int)UgItemCategory.WazaMachine], priceRate, itemList);
        }

        private void LotShopUgLItemList(List<ShopUgExchangeItemItem.Param> itemList, int randomSeed, byte priceRate, DayOfWeek dayOfWeek)
        {
            var catNums = UGFShop.shopListData[1].categoryItemNum;

            LotUGFBuyDatasByCategory(GetUGFBuyDatasByCategory(UGFShop.buy02, UgItemCategory.Tama),        UgItemCategory.Tama,
                randomSeed, catNums[(int)UgItemCategory.Tama],        priceRate, itemList);

            LotUGFBuyDatasByCategory(GetUGFBuyPedestalDatas(UGFShop.buy02diz, dayOfWeek),                 UgItemCategory.Pedestal,
                randomSeed, catNums[(int)UgItemCategory.Pedestal],    priceRate, itemList);

            LotUGFBuyDatasByCategory(GetUGFBuyDatasByCategory(UGFShop.buy02, UgItemCategory.WazaMachine), UgItemCategory.WazaMachine,
                randomSeed, catNums[(int)UgItemCategory.WazaMachine], priceRate, itemList);
        }

        private UgFatherShopTable.SheetBuyBase[] GetUGFBuyDatasByCategory(in UgFatherShopTable.SheetBuyBase[] datas, UgItemCategory category)
        {
            return Array.FindAll(datas, __ => (UgItemCategory)__.Category == category &&
                                              CheckBadgeNum(__.Badge) &&
                                              CheckZukanFlag(__.zukanflag) &&
                                              CheckSystemFlag(__.sysFlag));
        }

        private UgFatherShopTable.SheetBuyBase[] GetUGFBuyPedestalDatas(in UgFatherShopTable.SheetBuydizBase[] datas, DayOfWeek dayOfWeek)
        {
            return Array.FindAll(datas, __ => CheckZukanFlag(__.zukanflag) &&
                                              CheckBadgeNum(__.Badge) &&
                                              CheckDayOfWeek(__, dayOfWeek) &&
                                              CheckSystemFlag(__.sysFlag));
        }

        private bool CheckZukanFlag(bool isNeedCheckZukanFlag)
        {
            return !isNeedCheckZukanFlag || ZukanWork.GetZenkokuFlag();
        }

        private bool CheckBadgeNum(int needBadheNum)
        {
            return needBadheNum <= EvDataManager.Instanse.GetBadgeCount();
        }

        private bool CheckDayOfWeek(UgFatherShopTable.SheetBuydizBase data, DayOfWeek dayOfWeek)
        {
            switch (dayOfWeek)
            {
                case DayOfWeek.Sunday:    return data.Sunday;
                case DayOfWeek.Monday:    return data.Monday;
                case DayOfWeek.Tuesday:   return data.Tuesday;
                case DayOfWeek.Wednesday: return data.Wednesday;
                case DayOfWeek.Thursday:  return data.Thursday;
                case DayOfWeek.Friday:    return data.Friday;
                case DayOfWeek.Saturday:  return data.Saturday;
                default:                  return false;
            }
        }

        private bool CheckSystemFlag(int systemFlagIndex)
        {
            return systemFlagIndex < 0 || FlagWork.GetFlag(systemFlagIndex);
        }

        private void LotUGFBuyDatasByCategory(in UgFatherShopTable.SheetBuyBase[] datas, UgItemCategory category, int randomSeed, int lotNum, byte priceRate, List<ShopUgExchangeItemItem.Param> itemList)
        {
            if (lotNum > datas.Length)
                return;

            var items = new int[lotNum];
            var buyBases = new UgFatherShopTable.SheetBuyBase[lotNum];

            for (int i=0; i<items.Length; i++)
                items[i] = -1;

            Array.Sort(datas, (a, b) => a.lotteryrate - b.lotteryrate);

            int lotteryTotal = 0;
            for (int i=0; i<datas.Length; i++)
                lotteryTotal += datas[i].lotteryrate;

            int slotCount = 0;
            if (slotCount < lotNum)
            {
                for (int i=0; i<LIMIT_LOOP_COUNT; i++)
                {
                    if (lotteryTotal > 0)
                    {
                        if (datas.Length > 0)
                        {
                            var roll = (i + 1) * randomSeed % lotteryTotal;

                            for (int j=0; j<datas.Length; j++)
                            {
                                var itemData = datas[j];

                                // Item already rolled, ignore
                                if (Array.FindIndex(items, __ => itemData.UgItemID == __) >= 0)
                                    continue;

                                if (roll < itemData.lotteryrate)
                                {
                                    items[slotCount] = itemData.UgItemID;
                                    buyBases[slotCount] = datas[j];

                                    // Remove rates from all items with that ID
                                    for (int k=0; k<datas.Length; k++)
                                        if (datas[k].UgItemID == itemData.UgItemID)
                                            lotteryTotal -= itemData.lotteryrate;

                                    // Slot filled
                                    slotCount++;
                                    break;
                                }
                            }
                        }

                        // Filled all the slots
                        if (slotCount >= lotNum)
                            break;
                    }
                    else // No more rates to roll into
                    {
                        break;
                    }
                }

                if (slotCount > 1)
                {
                    if (slotCount < buyBases.Length)
                        Array.Resize(ref buyBases, slotCount);

                    if (category == UgItemCategory.Pedestal)
                    {
                        var itemManager = UgItemManager.Instance;
                        // BUG: This compares a to a
                        Array.Sort(buyBases, (a, b) => itemManager.GetPedestalData(a.UgItemID).sort.CompareTo(itemManager.GetPedestalData(a.UgItemID).sort));
                    }
                    else
                    {
                        Array.Sort(buyBases, (a, b) => a.UgItemID.CompareTo(b.UgItemID));
                    }
                }
            }

            var msgFile = MessageManager.Instance.GetMsgFile(UNDER_GROUND_MSBT_NAME);
            var halfSpaceChar = MessageHelper.ConvertUnicodeToChar(MessageDataConstants.HALF_SPACE_CODE);

            for (int i=0; i<buyBases.Length; i++)
            {
                var buyBase = buyBases[i];
                if (buyBase == null)
                    continue;

                var shopUgItem = CreateShopUgItemParam(buyBase, priceRate);
                if (shopUgItem.unit > 1)
                {
                    MessageWordSetHelper.SetDigitWord(0, shopUgItem.unit);
                    shopUgItem.unitText = string.Format("{0}{1}", halfSpaceChar, msgFile.GetFormattedMessage("DLP_underground_737"));
                }

                itemList.Add(shopUgItem);
            }
        }

        private ShopUgExchangeItemItem.Param CreateShopUgItemParam(UgFatherShopTable.SheetBuyBase data, byte priceRate)
        {
            return new ShopUgExchangeItemItem.Param
            {
                ugItemID = data.UgItemID,
                category = data.Category,
                tradeUgItemNo = data.ExchangeItemID,
                price = PlayerWork.cassetVersion == CassetVersion.DPR_B ? data.DExchangeItem[priceRate] : data.PExchangeItem[priceRate],
                unit = data.unit,
                itemLabel = data.MsItemLabel,
            };
        }

        public SellItemData CreateShopUgExchangeItemData(ShopUgExchangeItemItem.Param param)
        {
            var sellItemData = new SellItemData();

            var ugItemInfo = UgItemWork.GetItemInfo(param.tradeUgItemNo);

            UgItemInfo.LoadItemIcon(param.tradeUgItemNo, spr => sellItemData.iconSpr = spr);

            _ = MessageManager.Instance.GetNameMessage(MessageDataConstants.UG_ITEM_FILE_NAME, param.itemLabel);

            sellItemData.ugItemID = ugItemInfo.UgItemId;
            sellItemData.haveCount = ugItemInfo.count;
            sellItemData.price = param.price;
            sellItemData.unit = param.unit;

            return sellItemData;
        }

        public SellItemData CreatePedestalSellItemData(int ugItemId)
        {
            var param = new SellItemData();

            var saleItem = Array.Find(UGFShop.sale01, x => x.UgItemID == ugItemId);
            if (saleItem != null)
            {
                var ugItemInfo = UgItemWork.GetItemInfo(saleItem.ExchangeItemID);

                UgItemInfo.LoadItemIcon(saleItem.ExchangeItemID, spr => param.iconSpr = spr);

                _ = MessageManager.Instance.GetNameMessage(MessageDataConstants.UG_ITEM_FILE_NAME, saleItem.MsItemLabel);

                param.ugItemID = ugItemInfo.UgItemId;
                param.haveCount = ugItemInfo.count;
                param.price = PlayerWork.cassetVersion == CassetVersion.DPR_B ? saleItem.DExchangeItem : saleItem.PExchangeItem;
            }

            return param;
        }

        public ItemInfo.CategoryType[] CreateSellItemCategoryArray()
        {
            var categories = new List<ItemInfo.CategoryType>();

            for (int i=0; i<UGFShop.sale02.Length; i++)
            {
                var id = UgItemManager.Instance.GetItemId(UGFShop.sale02[i].UgItemID);
                var itemInfo = ItemWork.GetItemInfo(id);

                if (!categories.Contains(itemInfo.Category))
                    categories.Add(itemInfo.Category);
            }

            return categories.ToArray();
        }

        public SellItemData CreateSellItemDataByIndex(int index)
        {
            var param = new SellItemData();

            var saleItem = (index < UGFShop.sale02.Length) ? UGFShop.sale02[index] : UGFShop.sale02[0];
            var ugItemInfo = UgItemWork.GetItemInfo(saleItem.ExchangeItemID);

            UgItemInfo.LoadItemIcon(saleItem.ExchangeItemID, spr => param.iconSpr = spr);

            _ = MessageManager.Instance.GetNameMessage(MessageDataConstants.UG_ITEM_FILE_NAME, saleItem.MsItemLabel);

            param.ugItemID = ugItemInfo.UgItemId;
            param.haveCount = ugItemInfo.count;
            param.price = saleItem.ExchangeItem;

            return param;
        }

        public bool IsMaxExpansion { get => UGFExpansion.Expansion.Length <= PlayerWork.ugSaveData.ugRecord.myBase.expansionStatus; }

        public RequiredExpansionItemData[] CreateRequierdUgBaseExpantionItemDatas()
        {
            if (IsMaxExpansion)
                return null;

            var arr = new RequiredExpansionItemData[MAX_EXPANSION_ITEM_NUM];
            var expansion = UGFExpansion.Expansion[PlayerWork.ugSaveData.ugRecord.myBase.expansionStatus];

            arr[0] = new RequiredExpansionItemData(expansion.ugItemID01, expansion.amount01);
            arr[1] = new RequiredExpansionItemData(expansion.ugItemID02, expansion.amount02);
            arr[2] = new RequiredExpansionItemData(expansion.ugItemID03, expansion.amount03);
            arr[3] = new RequiredExpansionItemData(expansion.ugItemID04, expansion.amount04);
            arr[4] = new RequiredExpansionItemData(expansion.ugItemID05, expansion.amount05);

            return arr;
        }

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