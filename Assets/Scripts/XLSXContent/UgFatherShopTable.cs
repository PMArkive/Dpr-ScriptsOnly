using System;
using UnityEngine;

namespace XLSXContent
{
    [Serializable]
    public class UgFatherShopTable : ScriptableObject
    {
        public Sheetbuy01[] buy01;
        public Sheetbuy01diz[] buy01diz;
        public Sheetbuy02[] buy02;
        public Sheetbuy02diz[] buy02diz;
        public Sheetsale01[] sale01;
        public Sheetsale02[] sale02;
        public SheetshopListData[] shopListData;

        public Sheetbuy01 this[int index] => buy01[index];

        [Serializable]
        public class Sheetbuy01 : SheetBuyBase { }

        [Serializable]
        public class Sheetbuy01diz : SheetBuydizBase { }

        [Serializable]
        public class Sheetbuy02 : SheetBuyBase { }

        [Serializable]
        public class Sheetbuy02diz : SheetBuydizBase { }

        public class SheetBuydizBase : SheetBuyBase
        {
            public bool Sunday;
            public bool Monday;
            public bool Tuesday;
            public bool Wednesday;
            public bool Thursday;
            public bool Friday;
            public bool Saturday;
        }

        public class SheetBuyBase
        {
            public int UgItemID;
            public int Category;
            public int unit;
            public int Badge;
            public bool zukanflag;
            public int sysFlag;
            public int ExchangeItemID;
            public int lotteryrate;
            public int[] DExchangeItem;
            public int[] PExchangeItem;
            public string MsItemLabel;
            public string MsItemInfoLabel;
        }

        [Serializable]
        public class Sheetsale01
        {
            public int UgItemID;
            public int ExchangeItemID;
            public int DExchangeItem;
            public int PExchangeItem;
            public string MsItemLabel;
            public string MsItemInfoLabel;
        }

        [Serializable]
        public class Sheetsale02
        {
            public int UgItemID;
            public int ExchangeItemID;
            public int ExchangeItem;
            public string MsItemLabel;
            public string MsItemInfoLabel;
        }

        [Serializable]
        public class SheetshopListData
        {
            public int[] categoryItemNum;
        }
    }
}