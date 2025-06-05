using Dpr.EvScript;
using Pml;
using System;
using UnityEngine;

namespace XLSXContent
{
    [Serializable]
    public class ShopTable : ScriptableObject
    {
        public SheetFS[] FS;
        public SheetFixedShop[] FixedShop;
        public SheetFlowerShop[] FlowerShop;
        public SheetRibonShop[] RibonShop;
        public SheetSealShop[] SealShop;
        public SheetBPShop[] BPShop;
        public SheetOtenkiShop[] OtenkiShop;
        public SheetBoutiqueShop[] BoutiqueShop;
        public SheetPalParkShop[] PalParkShop;
        public SheetTobariDepartment4FShop[] TobariDepartment4FShop;

        public SheetFS this[int index] => FS[index];

        [Serializable]
        public class SheetFS
        {
            public ItemNo ItemNo;
            public int BadgeNum;
            public ZoneID ZoneID;
        }

        [Serializable]
        public class SheetFixedShop
        {
            public ItemNo ItemNo;
            public int ShopID;
        }

        [Serializable]
        public class SheetFlowerShop
        {
            public SealID SealNo;
            public ItemNo ItemNo;
            public int Price;
        }

        [Serializable]
        public class SheetRibonShop
        {
            public int Price;
        }

        [Serializable]
        public class SheetSealShop
        {
            public SealID SealNo;
            public int Price;
            public DayOfWeek Week;
        }

        [Serializable]
        public class SheetBPShop
        {
            public ItemNo ItemNo;
            public int NPCID;
        }

        [Serializable]
        public class SheetOtenkiShop
        {
            public ItemNo ItemNo;
            public ItemNo RequestItem;
            public int Price;
        }

        [Serializable]
        public class SheetBoutiqueShop
        {
            public int DressNo;
            public EvWork.SYSFLAG_INDEX OpenDress;
            public EvWork.FLAG_INDEX DressGet;
            public int Price;
        }

        [Serializable]
        public class SheetPalParkShop
        {
            public ItemNo ItemNo;
            public ItemNo ItemNo2;
            public int Price;
            public int ShopID;
            public int ParkNameID;
            public int ParkNameNazo;
        }

        [Serializable]
        public class SheetTobariDepartment4FShop
        {
            public int UgItemID;
            public int price;
            public int ShopID;
        }
    }
}