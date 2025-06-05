using Audio;
using Dpr.Message;
using Dpr.MsgWindow;
using System.Collections.Generic;
using UnityEngine.Events;

namespace Dpr.UI
{
    public class TownmapWindowBase : UIWindow
    {
        protected override void OnOpen(UIWindowID prevWindowId)
        {
            AudioManager.Instance.PlaySe(AK.EVENTS.UI_MAP_OPEN, null);
            base.OnOpen(prevWindowId);
        }

        public virtual void Close(UnityAction<UIWindow> onClosed_, UIWindowID nextWindowId)
        {
            // Empty
        }

        protected bool IsPlayerFly()
        {
            return GameManager.mapInfo[(int)PlayerWork.zoneID].Fly;
        }

        protected virtual bool IsFly(Townmap.Cell cell)
        {
            return IsPlayerFly() && Townmap.Cell.UseData(cell) && cell.IsFly(true);
        }

        protected void Fly(Townmap townmap)
        {
            AudioManager.Instance.PlaySe(AK.EVENTS.UI_COMMON_DONE, null);
            var cell = townmap.GetCurrentCell();

            bool paired = FlagWork.GetSysFlag(EvScript.EvWork.SYSFLAG_INDEX.SYS_FLAG_PAIR);
            bool isFly = IsFly(cell);

            if (!paired && isFly)
            {
                _input.inputEnabled = false;

                MessageWordSetHelper.SetPlaceNameWord(0, GameManager.mapInfo[(int)cell.data.zoneID].FlyingPlaceName);
                OpenMessageWindow(new MsgWindowParam()
                {
                    useMsgFile = MessageManager.Instance.GetMsgFile("dp_townmap"),
                    labelName = "DP_townmap_001",
                    inputEnabled = true,
                    inputCloseEnabled = false,
                    onFinishedShowAllMessage = () =>
                    {
                        CreateContextMenuYesNo(contextMenuItem =>
                        {
                            CloseMessageWindow();

                            if (contextMenuItem.param.menuId == ContextMenuID.MAP_FLY_YES)
                            {
                                UIManager.onWazaFly?.Invoke(cell.data.zoneID, cell.data.MapInfoLocatorIndex);
                                UIManager.Instance.CloseXMenu(onClosed_ => Close(onClosed_, WINDOWID_FIELD));
                            }
                            else
                            {
                                _input.inputEnabled = true;
                            }

                            return true;
                        }, 0);
                    }
                });
            }
            else
            {
                string msgFile = null;
                string labelName = null;
                if (!UIManager.Instance.IsFureaiLimit() && paired && UIManager.IsLeanFly())
                {
                    FieldManager.fwMng.SetPartnerNameToLabel(0);
                    msgFile = "dp_scenario3";
                    labelName = "DP_menu_msg2_2255";
                }
                else if (Townmap.Cell.UseData(cell) && cell.IsFly(false) && cell.IsView())
                {
                    msgFile = "ss_pokedex";
                    labelName = IsPlayerFly() ? "SS_pokedex_182" : "SS_pokedex_181";
                }

                if (string.IsNullOrEmpty(msgFile))
                    return;

                OpenMessageWindow(new MsgWindowParam()
                {
                    useMsgFile = MessageManager.Instance.GetMsgFile(msgFile),
                    labelName = labelName,
                    inputEnabled = true,
                    inputCloseEnabled = false,
                    onFinishedCloseWindow = () => _messageWindow = null
                });
            }
        }

        protected override void OnAddContextMenuYesNoItemParams(List<ContextMenuItem.Param> contextMenuItemParams)
        {
            contextMenuItemParams.Add(new ContextMenuItem.Param() { menuId = ContextMenuID.MAP_FLY_YES });
            contextMenuItemParams.Add(new ContextMenuItem.Param() { menuId = ContextMenuID.MAP_FLY_NO });
        }
    }
}