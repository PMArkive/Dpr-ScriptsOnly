using Audio;
using Dpr.Message;
using Dpr.UI;
using SmartPoint.AssetAssistant;
using System;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;
using XLSXContent;

namespace Dpr.MsgWindow
{
    public class MsgWindowManager : SingletonMonoBehaviour<MsgWindowManager>
    {
        private MsgWindowDataContainer dataContainer = new MsgWindowDataContainer();
        private MsgWindowData msgWindowData;
        private ContextMenuWindow contextMenu;
        [SerializeField]
        private GameObject msgWindowObj;
        private MsgWindow msgWindow;
        private const string YES_NO_MSBT_NAME = "ss_box";
        private readonly string[] YES_NO_LABEL_ARRAY = new string[2] { "SS_box_053", "SS_box_054" };

        private void Start()
        {
            msgWindow = msgWindowObj.GetComponent<MsgWindow>();
            if (msgWindow == null)
                MessageHelper.EmitLog("Failed GetComponent : MsgWindow", LogType.Error);

            Sequencer.Start(IE_StartMsgWindow());
            Sequencer.onDestroy += Destroy;
        }

        private IEnumerator IE_StartMsgWindow()
        {
            while (!UIManager.isInitialized)
                yield return null;

            dataContainer.FormatMsgWindowData(msgWindowData);
            msgWindow.Initialize();

            while (!GameManager.isReady)
                yield return null;

            Sequencer.update -= OnUpdate;
            Sequencer.update += OnUpdate;
        }

        private void OnUpdate(float deltaTime)
        {
            if (msgWindow != null)
                msgWindow.OnUpdate(deltaTime);
        }

        private void Destroy()
        {
            Sequencer.update -= OnUpdate;
            dataContainer.Dispose();

            if (msgWindow != null)
                msgWindow.OnFinalize();
        }

        public MsgWindowDataContainer DataContainer { get => dataContainer; }

        public static void SetMsgWindowData(MsgWindowData msgWindowData)
        {
            Instance.msgWindowData = msgWindowData;
        }

        public MsgWindow MsgWindow { get => msgWindow; }
        public static bool IsOpenWindow { get => Instance.contextMenu != null || Instance.msgWindow.MsgState != MsgWindowDataModel.MsgWindowState.Inactive; }
        public static bool IsOpen { get => Instance.msgWindow.IsOpen; }

        public static MsgWindow OpenMsg(MsgWindowParam msgWindowParam)
        {
            Instance.msgWindow.OpenWindow(msgWindowParam);
            return Instance.msgWindow;
        }

        public static MsgWindow OpenBoardMsg(MsgWindowParam msgWindowParam, int roadsignPattern = 0)
        {
            Instance.msgWindow.OpenBoardWindow(msgWindowParam, roadsignPattern);
            return Instance.msgWindow;
        }

        public static MsgWindow OpenItemGetMsg(MsgWindowParam msgWindowParam)
        {
            Instance.msgWindow.OpenItemGetWindow(msgWindowParam);
            return Instance.msgWindow;
        }

        public static MsgWindow OpenBtlMsg(MsgWindowParam msgWindowParam)
        {
            Instance.msgWindow.OpenBtlMsgWindow(msgWindowParam);
            return Instance.msgWindow;
        }

        public static void CloseMsg()
        {
            if (Instance.msgWindow.IsOpen)
            {
                Instance.msgWindow.CloseWindow();
            }
            else
            {
                MessageHelper.EmitLog("CloseMsg Failed : MsgWindow Not Open!!", LogType.Warning);
                Instance.msgWindow.DoOnCloseCallback();
            }
        }

        public static void ReplaceMsg(MsgWindowParam msgWindowParam)
        {
            if (Instance.msgWindow.IsOpen)
                Instance.msgWindow.ReplaceMessage(msgWindowParam);
            else
                MessageHelper.EmitLog("ReplaceMessage Failed : MsgWindow Not Open!!", LogType.Warning);
        }

        public static void ReplaceBtlMsg(MsgWindowParam msgWindowParam)
        {
            if (Instance.msgWindow.IsOpen)
                Instance.msgWindow.ReplaceBtlMessage(msgWindowParam);
            else
                MessageHelper.EmitLog("ReplaceBtlMsg Failed : MsgWindow Not Open!!", LogType.Warning);
        }

        public static void MoveNextPage()
        {
            if (Instance.msgWindow.IsOpen)
                Instance.msgWindow.MoveNextPage();
            else
                MessageHelper.EmitLog("ReplaceBtlMsg Failed : MsgWindow Not Open!!", LogType.Warning); // Seems like a copy paste error by the devs
        }

        public static void OpenYesNoMenu(Action<int> onSelectChoices, [Optional, DefaultParameterValue(ContextMenuWindow.CursorType.Arrow)] ContextMenuWindow.CursorType cursorType, [Optional, DefaultParameterValue(true)] bool useCancel, [Optional, DefaultParameterValue(true)] bool initSelectYes, [Optional] Action onClosed, uint seDecide = AK.EVENTS.UI_COMMON_DECIDE)
        {
            Instance.OpenContextMenu_YESNO(onSelectChoices, cursorType, initSelectYes, useCancel, onClosed, seDecide);
        }

        public void OpenContextMenu_YESNO(Action<int> onSelectChoices, ContextMenuWindow.CursorType cursorType, bool selectYes, bool useCancel, Action onClosed, uint seDecide = AK.EVENTS.UI_COMMON_DECIDE)
        {
            var param = Instance.CreateContextMenuParam(YES_NO_MSBT_NAME, Instance.YES_NO_LABEL_ARRAY, selectYes ? 0 : 1, cursorType, useCancel, seDecide);
            OpenContextMenu(param, onSelectChoices, onClosed);
        }

        public static void OpenCustomMenu(string msbtName, string[] labelNameArray, Action<int> onSelectChoices, [Optional, DefaultParameterValue(ContextMenuWindow.CursorType.Arrow)] ContextMenuWindow.CursorType cursorType, [Optional, DefaultParameterValue(true)] bool useCancel, [Optional, DefaultParameterValue(0)] int initSelectIndex, [Optional] Action onClosed, uint seDecide = AK.EVENTS.UI_COMMON_DECIDE)
        {
            Instance.OpenContextMenu_Custom(msbtName, labelNameArray, onSelectChoices, cursorType, useCancel, initSelectIndex, onClosed, seDecide);
        }

        public void OpenContextMenu_Custom(string msbtName, string[] labelNameArray, Action<int> onSelectChoices, ContextMenuWindow.CursorType cursorType, bool useCancel, int initSelectIndex, Action onClosed, uint seDecide = AK.EVENTS.UI_COMMON_DECIDE)
        {
            var param = Instance.CreateContextMenuParam(msbtName, labelNameArray, initSelectIndex, cursorType, useCancel, seDecide);
            OpenContextMenu(param, onSelectChoices, onClosed);
        }

        public static void OpenCustomMenu(string[] textArray, Action<int> onSelectChoices, [Optional, DefaultParameterValue(ContextMenuWindow.CursorType.Arrow)] ContextMenuWindow.CursorType cursorType, [Optional, DefaultParameterValue(true)] bool useCancel, [Optional, DefaultParameterValue(0)] int initSelectIndex, [Optional] Action onClosed, uint seDecide = AK.EVENTS.UI_COMMON_DECIDE)
        {
            Instance.OpenContextMenu_Custom(textArray, onSelectChoices, cursorType, useCancel, initSelectIndex, onClosed, seDecide);
        }

        public void OpenContextMenu_Custom(string[] textArray, Action<int> onSelectChoices, ContextMenuWindow.CursorType cursorType, bool useCancel, int initSelectIndex, Action onCloseed, uint seDecide = AK.EVENTS.UI_COMMON_DECIDE)
        {
            var param = Instance.CreateContextMenuParam(textArray, initSelectIndex, cursorType, useCancel, seDecide);
            OpenContextMenu(param, onSelectChoices, onCloseed);
        }

        public void CloseContextMenu()
        {
            if (contextMenu == null)
                return;

            contextMenu.Close(null);
            contextMenu = null;
        }

        private ContextMenuWindow.Param CreateContextMenuParam(string msbtName, string[] labelNameArray, int initSelectIndex, ContextMenuWindow.CursorType cursorType, bool useCancel, uint seDecide)
        {
            var msbtFile = MessageManager.Instance.GetMsgFile(msbtName);
            if (msbtFile == null)
                return null;

            var options = new string[labelNameArray.Length];
            for (int i=0; i<labelNameArray.Length; i++)
                options[i] = msbtFile.GetFormattedMessage(labelNameArray[i]);

            return CreateContextMenuParam(options, initSelectIndex, cursorType, useCancel, seDecide);
        }

        private ContextMenuWindow.Param CreateContextMenuParam(string[] textArray, int initSelectIndex, ContextMenuWindow.CursorType cursorType, bool useCancel, uint seDecide)
        {
            var param = new ContextMenuWindow.Param();
            param.itemParams = new ContextMenuItem.Param[textArray.Length];

            for (int i=0; i<textArray.Length; i++)
            {
                param.itemParams[i] = new ContextMenuItem.Param();
                param.itemParams[i].text = textArray[i];
                param.itemParams[i].menuId = (ContextMenuID)i;
            }

            param.position = msgWindow.CalcContextMenuPos();
            param.pivot = new Vector2(1.0f, 0.0f);
            param.selectIndex = initSelectIndex;
            param.useCancel = useCancel;
            param.useLoopAndRepeat = false;
            param.seDecide = seDecide;

            if (msgWindow.IsOpen && msgWindow.IsNetwork)
                param.windowType = ContextMenuWindow.Param.MenuWindowType.Network;

            return param;
        }

        private void OpenContextMenu(ContextMenuWindow.Param menuParam, Action<int> onSelectChoices, Action onClosed)
        {
            if (menuParam == null)
            {
                MessageHelper.EmitLog("ContextMenuWindow Param is null!!!", LogType.Error);
                onSelectChoices?.Invoke(-1);
            }
            else
            {
                if (MsgWindow.IsOpen)
                    msgWindow.HideKeywaitIcon();

                contextMenu = UIManager.Instance.CreateUIWindow<ContextMenuWindow>(UIWindowID.CONTEXTMENU);
                contextMenu.onClicked = menuItem =>
                {
                    contextMenu = null;
                    onSelectChoices?.Invoke((int)menuItem.param.menuId);
                    return true;
                };
                contextMenu.onClosed = uiWindow =>
                {
                    onClosed?.Invoke();
                    contextMenu = null;
                };

                AudioManager.Instance.PlaySe(AK.EVENTS.UI_COMMON_DECIDE, null);
                contextMenu.Open(menuParam);

                if (!gameObject.activeSelf)
                    contextMenu.transform.localScale = Vector3.zero;
            }
        }

        public static void ClearMsgWindowCallbackFunc()
        {
            if (Instance.msgWindow == null)
                return;

            Instance.msgWindow.ClearCallbackFunc();
        }
    }
}