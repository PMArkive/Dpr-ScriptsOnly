using Pml;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
    public class ShopExchangeItemItem : ShopItemItem
    {
        [SerializeField]
        private Image _tradeItemIcon;
        [SerializeField]
        private Vector2[] _iconSizes = new Vector2[]
        {
            new Vector2(80.0f, 80.0f),
            new Vector2(40.0f, 40.0f),
        };

        private Param _param;

        public Param param { get => _param; }

        // TODO
        public void Setup(ShopBase.ShopType shopType, Param param) { }

        // TODO
        public void SetMessageItemName(int argIndex, int amount) { }

        // TODO
        public void SetMessageTradeItemName(int argIndex, int amount) { }

        // TODO
        public void SetMessagePocketName(int argIndex) { }

        // TODO
        public void AddItem(int amount) { }

        public class Param
        {
            public ItemNo tradeItemNo;
            public int price;
            public Flower flower;
            public Otenki otenki;
            public PalPark palPark;

            // TODO
            public SealID GetSealId(ShopBase.ShopType shopType) { return default; }

            // TODO
            public ItemNo GetItemNo(ShopBase.ShopType shopType) { return default; }

            public class Flower
            {
                public SealID sealId;
            }

            public class Otenki
            {
                public ItemNo itemNo;
            }

            public class PalPark
            {
                public ItemNo itemNo;
                public int parkItemNo;
                public int parkTradeItemNo;
            }
        }
    }
}