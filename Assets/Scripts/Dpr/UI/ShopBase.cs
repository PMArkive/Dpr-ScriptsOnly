using Audio;
using Dpr.Item;
using Dpr.Message;
using UnityEngine;

namespace Dpr.UI
{
    public class ShopBase : UIWindow
    {
        [SerializeField]
        protected UIScrollView _itemListScrollView;
        [SerializeField]
        protected Cursor _cursor;
        [SerializeField]
        protected ShopItemDescriptionPanel _itemDescriptionPanel;
        [SerializeField]
        protected ShopItemSelectAmount _selectAmount;
        protected const int _wazaItemDescriptionNum = 3;
        protected int _wazaItemDescriptionType;

        protected bool IsCheckOpen()
        {
            return UIManager.Instance.GetReduplicationWindow(this) == null && UIManager.Instance.isFadeTransition;
        }

        protected void UpdateWazaDescription(ItemInfo itemInfo)
        {
            if (itemInfo == null || itemInfo.Category != ItemInfo.CategoryType.WazaMachine)
                return;

            if (IsPushButton(UIManager.ButtonPlusMinus))
            {
                int direction = IsPushButton(GameController.ButtonMask.Plus) ? 1 : -1;
                _wazaItemDescriptionType = (_wazaItemDescriptionType + direction + _wazaItemDescriptionNum) % _wazaItemDescriptionNum;
                _itemDescriptionPanel.SetWazaDescriptionType(_wazaItemDescriptionType);
            }
        }

        public (string, string) GetShopMessageData(SHOP_MESSAGEID shopMessageId, ShopType shopType, int fixedShopId)
        {
            var messages = UIManager.Instance.database.ShopMessage[(int)shopMessageId];

            var strs = new string[9][]
            {
                messages.Message0,
                messages.Message1,
                messages.Message2,
                messages.Message3,
                messages.Message4,
                messages.Message5,
                messages.Message6,
                messages.Message7,
                messages.Message8,
            };

            string[] str = null;
            switch (shopType)
            {
                case ShopType.Friendly:
                    str = strs[0];
                    break;

                case ShopType.Fixed:
                    if (fixedShopId == 2)
                        str = strs[1];
                    else
                        str = strs[0];
                    break;

                case ShopType.Seal:
                    str = strs[2];
                    break;

                case ShopType.BattlePark:
                    str = strs[3];
                    break;

                case ShopType.TobariDepart4F:
                    str = strs[8];
                    break;

                case ShopType.Flower:
                    str = strs[4];
                    break;

                case ShopType.Otenki:
                    str = strs[5];
                    break;

                case ShopType.PalPark:
                    str = strs[7];
                    break;

                case ShopType.Boutique:
                    str = strs[6];
                    break;
            }

            return (str[0], str[1]);
        }

        public bool IsBuy(ShopType shopType)
        {
            switch (shopType)
            {
                case ShopType.Friendly:
                case ShopType.Fixed:
                case ShopType.Seal:
                case ShopType.BattlePark:
                case ShopType.TobariDepart4F:
                    return true;

                default:
                    return false;
            }
        }

        public string GetSelectAmountDescriptionText(ShopType shopType, string messageFile)
        {
            string label;
            switch (shopType)
            {
                case ShopType.Friendly:
                case ShopType.Fixed:
                case ShopType.Seal:
                case ShopType.TobariDepart4F:
                    label = "SS_fld_shop_286";
                    break;

                case ShopType.BattlePark:
                    label = "SS_fld_shop_309";
                    break;

                default:
                    label = "SS_fld_shop_306";
                    break;
            }

            var dataModel = MessageManager.Instance.GetMsgFile(messageFile).GetTextDataModel(label);
            dataModel.ApplyFormat();
            return dataModel.GetAllText();
        }

        protected virtual bool UpdateSelect(float deltaTime, int pagedItemNum, bool enableButtonLR = true)
        {
            if (MoveSelectScrollView(UIManager.StickLDown, 1))
                return true;

            if (MoveSelectScrollView(UIManager.StickLUp, -1))
                return true;

            if (!enableButtonLR)
                return true;

            if (MovePageScrollView(GameController.ButtonMask.R, true))
                return true;

            MovePageScrollView(GameController.ButtonMask.L, false);
            return true;
        }

        private bool MoveSelectScrollView(int button, int move)
        {
            if (!IsPushButton(button) && !IsRepeatButton(button))
            {
                if (IsReleaseButton(button))
                    _itemListScrollView.ResumeMoveSelect();
                else
                    return false;
            }
            else
            {
                if (_itemListScrollView.MoveSelect(move))
                    AudioManager.Instance.PlaySe(AK.EVENTS.UI_COMMON_SELECT, null);
            }

            return true;
        }

        private bool MovePageScrollView(int button, bool move)
        {
            if (!IsPushButton(button) && !IsRepeatButton(button))
            {
                if (IsReleaseButton(button))
                    _itemListScrollView.ResumeMoveSelect();
                else
                    return false;
            }
            else
            {
                if (_itemListScrollView.MovePage(move))
                    AudioManager.Instance.PlaySe(AK.EVENTS.UI_COMMON_SELECT, null);
            }

            return true;
        }

        public enum ShopType : int
        {
            Friendly = 0,
            Fixed = 1,
            Seal = 2,
            BattlePark = 3,
            TobariDepart4F = 4,
            Flower = 5,
            Otenki = 6,
            PalPark = 7,
            Boutique = 8,
            Underground = 9,
        }
    }
}
