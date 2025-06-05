using Audio;
using Dpr.Message;
using Dpr.MsgWindow;
using GameData;
using System.Collections;
using System.Collections.Generic;

namespace Dpr.UI
{
    public class ShopBoutiqueChange : ShopBoutique
    {
        public override IEnumerator OpOpen()
        {
            _boutiqueType = BoutiqueType.Change;
            yield return base.OpOpen();
        }

        protected override void SetupScrollViewItemParams()
        {
            _selectIndex = SetupBoutiqueItemParams(_itemParams);
        }

        public static int SetupBoutiqueItemParams(List<ShopBoutiqueItemItem.Param> itemParams)
        {
            itemParams.Clear();

            int select = 0;
            var dressData = DataManager.CharacterDressData.Data;
            for (int i=0; i<dressData.Length; i++)
            {
                var dress = dressData[i];
                if (PlayerWork.playerSex != IsMaleDress(dress.Index))
                    continue;

                bool toAdd;
                switch ((DressType)(dress.Index % 100))
                {
                    case DressType.Default:
                        toAdd = true;
                        break;

                    case DressType.Contest:
                    case DressType.Bicycle:
                        toAdd = false;
                        break;

                    case DressType.Platinum:
                        toAdd = FlagWork.GetFlag(EvScript.EvWork.FLAG_INDEX.FE_STAYLE_003);
                        break;

                    case DressType.Summer:
                        toAdd = PlayerWork.playerData.mystatus.dp_clear;
                        break;

                    default:
                        var shopData = DataManager.GetBoutiqueShopData(dress.Index);
                        toAdd = shopData == null || FlagWork.GetFlag(shopData.DressGet);
                        break;
                }

                if (toAdd)
                {
                    var param = new ShopBoutiqueItemItem.Param();
                    param.dressData = dress;
                    itemParams.Add(param);
                    if (PlayerWork.playerFashion == dress.Index)
                        select = itemParams.Count - 1;
                }
            }

            return select;
        }

        protected override void OnCancel()
        {
            AudioManager.Instance.PlaySe(AK.EVENTS.UI_COMMON_CANCEL, null);
            _input.inputEnabled = false;

            var param = new MsgWindowParam
            {
                useMsgFile = MessageManager.Instance.GetMsgFile("ss_fld_dressup"),
                labelName = "SS_fld_dressup_021",
                inputEnabled = true,
                inputCloseEnabled = false,
                onFinishedShowAllMessage = () =>
                {
                    CreateContextMenuYesNo(contextMenuItem_ =>
                    {
                        CloseMessageWindow();
                        _input.inputEnabled = true;

                        if (contextMenuItem_.param.menuId == ContextMenuID.FRIENDLYSHOP_YES)
                            Close(onClosed);

                        return true;
                    }, null);
                }
            };

            OpenMessageWindow(param);
        }

        protected override void OnDecidedSelectItem()
        {
            AudioManager.Instance.PlaySe(AK.EVENTS.UI_COMMON_DONE, null);
            if (PlayerWork.playerFashion == _selectShopItem.characterDressData.Index)
                return;

            _input.inputEnabled = false;

            var param = new MsgWindowParam
            {
                useMsgFile = MessageManager.Instance.GetMsgFile("ss_fld_dressup"),
                labelName = "SS_fld_dressup_018",
                inputEnabled = true,
                inputCloseEnabled = false,
                onFinishedShowAllMessage = () =>
                {
                    var contextParam = CreateContextMenuYesNoParam();
                    contextParam.seDecide = 0;
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
                    }, contextParam);
                }
            };

            OpenMessageWindow(param);
        }

        public enum DressType : int
        {
            Default = 0,
            Contest = 1,
            Platinum = 3,
            Summer = 8,
            Bicycle = 13,
        }
    }
}