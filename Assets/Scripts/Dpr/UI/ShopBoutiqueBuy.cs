using Audio;
using Dpr.Message;
using Dpr.MsgWindow;
using GameData;
using System.Collections;
using UnityEngine;

namespace Dpr.UI
{
    public class ShopBoutiqueBuy : ShopBoutique
    {
        public override IEnumerator OpOpen()
        {
            _boutiqueType = BoutiqueType.Buy;
            yield return base.OpOpen();
        }

        protected override void SetupScrollViewItemParams()
        {
            _itemParams.Clear();

            var shopData = DataManager.ShopTable.BoutiqueShop;
            for (int i=0; i<shopData.Length; i++)
            {
                var shopItem = shopData[i];
                if ((shopItem.OpenDress >= EvScript.EvWork.SYSFLAG_INDEX.SYSFLAG_END || FlagWork.GetSysFlag(shopItem.OpenDress)) &&
                    PlayerWork.playerSex == IsMaleDress(shopItem.DressNo))
                {
                    var param = new ShopBoutiqueItemItem.Param();
                    param.data = shopItem;
                    _itemParams.Add(param);
                }
            }
        }

        protected override void OnCancel()
        {
            _input.inputEnabled = false;
            AudioManager.Instance.PlaySe(AK.EVENTS.UI_COMMON_CANCEL, null);
            Close(onClosed);
        }

        protected override void OnDecidedSelectItem()
        {
            _input.inputEnabled = false;
            AudioManager.Instance.PlaySe(AK.EVENTS.UI_COMMON_DONE, null);

            int qtyToBuy = _selectShopItem.GetNumForAdd();
            int price = _selectShopItem.param.data.Price;
            var thing = Mathf.Min(price == 0 ? 0 : GetCharge() / price);

            if (thing > 0)
            {
                SequencePurchase(1);
            }
            else
            {
                if (qtyToBuy == 0)
                {
                    (string, string) msgData = GetShopMessageData(SHOP_MESSAGEID.FULL_ITEM, ShopType.Boutique, 0);
                    var param = new MsgWindowParam
                    {
                        useMsgFile = MessageManager.Instance.GetMsgFile(msgData.Item1),
                        labelName = msgData.Item2,
                        inputEnabled = true,
                        inputCloseEnabled = true,
                        onFinishedCloseWindow = () =>
                        {
                            _messageWindow = null;
                            _input.inputEnabled = true;
                        }
                    };

                    OpenMessageWindow(param);
                }
                else
                {
                    (string, string) msgData = GetShopMessageData(SHOP_MESSAGEID.ENOUGH_MONEY, ShopType.Boutique, 0);
                    var param = new MsgWindowParam
                    {
                        useMsgFile = MessageManager.Instance.GetMsgFile(msgData.Item1),
                        labelName = msgData.Item2,
                        inputEnabled = true,
                        inputCloseEnabled = true,
                        onFinishedCloseWindow = () =>
                        {
                            _messageWindow = null;
                            _input.inputEnabled = true;
                        }
                    };

                    OpenMessageWindow(param);
                }
            }
        }

        private void SequencePurchase(int amount)
        {
            (string, string) msgData = GetShopMessageData(SHOP_MESSAGEID.PURCHASE_ITEM_02, ShopType.Boutique, 0);
            var messageFile = msgData.Item1;
            var messageLabel = msgData.Item2;
            var subCharge = amount * _selectShopItem.param.data.Price;

            var param = new MsgWindowParam
            {
                useMsgFile = MessageManager.Instance.GetMsgFile(messageFile),
                labelName = messageLabel,
                inputEnabled = true,
                inputCloseEnabled = false,
                onFinishedShowAllMessage = () =>
                {
                    CreateContextMenuYesNo(contextMenuItem =>
                    {
                        if (contextMenuItem.param.menuId == ContextMenuID.FRIENDLYSHOP_YES)
                        {
                            AudioManager.Instance.PlaySe(AK.EVENTS.S_ME050, null);

                            SubCharge(subCharge);
                            _selectShopItem.AddItem(amount);
                            SetupCharge();

                            (string, string) yesMsgData = GetShopMessageData(SHOP_MESSAGEID.PURCHASE_ITEM_DECISION_01, ShopType.Boutique, 0);
                            messageFile = yesMsgData.Item1;
                            messageLabel = yesMsgData.Item2;
                            var yesParam = new MsgWindowParam
                            {
                                useMsgFile = MessageManager.Instance.GetMsgFile(messageFile),
                                labelName = messageLabel,
                                inputEnabled = true,
                                inputCloseEnabled = false,
                                onFinishedShowAllMessage = () =>
                                {
                                    var yesNoParam = CreateContextMenuYesNoParam();
                                    yesNoParam.seDecide = 0;

                                    CreateContextMenuYesNo(contextMenuItem_ =>
                                    {
                                        if (contextMenuItem_.param.menuId == ContextMenuID.FRIENDLYSHOP_YES)
                                        {
                                            AudioManager.Instance.PlaySe(AK.EVENTS.S_BOU001, null);
                                            ChangeDress();
                                        }
                                        else
                                        {
                                            AudioManager.Instance.PlaySe(AK.EVENTS.UI_COMMON_DECIDE, null);
                                        }

                                        CloseMessageWindow();
                                        _input.inputEnabled = true;
                                        return true;
                                    }, yesNoParam);
                                }
                            };

                            OpenMessageWindow(yesParam);
                        }
                        else
                        {
                            AudioManager.Instance.PlaySe(AK.EVENTS.UI_COMMON_DECIDE, null);
                            CloseMessageWindow();
                            _input.inputEnabled = true;
                        }

                        return true;
                    }, 0);
                }
            };

            OpenMessageWindow(param);
        }
    }
}