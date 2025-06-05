using Dpr.BallDeco;
using Dpr.Item;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
    public class ShopItemItem : MonoBehaviour, IUIButton
    {
        [SerializeField]
        protected Image _icon;
        [SerializeField]
        protected UIText _name;
        [SerializeField]
        protected UIText _price;
        protected ShopBase.ShopType _shopType = (ShopBase.ShopType)(-1);
        protected int _index;
        protected ItemInfo _itemInfo;
        protected SealInfo _sealInfo;
        protected UgItemInfo _ugItemInfo;

        public int index { get => _index; }

        public ItemInfo GetItemInfo()
        {
            return _itemInfo;
        }

        public SealInfo GetSealInfo()
        {
            return _sealInfo;
        }

        public UgItemInfo GetUgItemInfo()
        {
            return _ugItemInfo;
        }

        public bool IsWazaMachine()
        {
            switch (_shopType)
            {
                case ShopBase.ShopType.Seal:
                case ShopBase.ShopType.TobariDepart4F:
                case ShopBase.ShopType.Flower:
                case ShopBase.ShopType.Boutique:
                    return false;

                default:
                    return _itemInfo.IsWazaMachine();
            }
        }

        public bool IsBall()
        {
            switch (_shopType)
            {
                case ShopBase.ShopType.Seal:
                case ShopBase.ShopType.TobariDepart4F:
                case ShopBase.ShopType.Flower:
                case ShopBase.ShopType.Boutique:
                    return false;

                default:
                    return _itemInfo.Category == ItemInfo.CategoryType.Ball;
            }
        }

        public virtual int GetNumForAdd()
        {
            switch (_shopType)
            {
                case ShopBase.ShopType.Seal:
                case ShopBase.ShopType.Flower:
                    return BallDecoWork.GetCanAddSealCount(_sealInfo.SealId);

                case ShopBase.ShopType.TobariDepart4F:
                    return UgItemInfo.ItemMaxCount - _ugItemInfo.count;

                default:
                    return ItemInfo.ItemMaxCount - _itemInfo.count;
            }
        }

        public virtual bool GetActive()
        {
            return gameObject.activeSelf;
        }

        public virtual void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }

        public virtual int GetIndex()
        {
            return _index;
        }

        public virtual void SetIndex(int index)
        {
            _index = index;
        }

        public virtual RectTransform GetRectTransform()
        {
            return transform as RectTransform;
        }

        public virtual void Select()
        {
            // Empty
        }

        public virtual void UnSelect()
        {
            // Empty
        }
    }
}