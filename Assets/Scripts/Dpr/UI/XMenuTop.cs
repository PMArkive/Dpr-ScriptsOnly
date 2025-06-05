using Dpr.MsgWindow;
using SmartPoint.AssetAssistant;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Dpr.UI
{
    public class XMenuTop : UIWindow, IViewportChangeHandler, IEventSystemHandler
    {
        [SerializeField]
        private RectTransform _itemRoot;
        [SerializeField]
        private RectTransform _reportWindow;
        [SerializeField]
        private RectTransform _safariRoot;
        [SerializeField]
        private UIText _safariBallNum;
        [SerializeField]
        private RectTransform _messageWindowRoot;
        [SerializeField]
        private RectTransform _gotoTownMapRoot;
        private bool _isActived;
        private GridLayoutGroup _gridLayoutGroup;
        private UnityAction<UIWindow> _saveOnClosed;
        private List<XMenuTopItem> _initItems = new List<XMenuTopItem>();
        private List<XMenuTopItem> _activeItems = new List<XMenuTopItem>();
        private int _selectIndex;
        private const int _upperColumnMax = 4;
        private XMenuTopItem _fromSwapItem;
        private Vector3 _fromSwapPisiton;
        private int _fromSwapSiblingIndex;
        private List<UIManager.DuplicateImageMaterialParam> _duplicate;
        private Coroutine _coroutineTownmapGuideMessage;
        private UIWindowID[] _windowIds = new UIWindowID[9]
        {
            UIWindowID.ZUKAN, UIWindowID.POKEMON, UIWindowID.BAG,     UIWindowID.CARD,
            UIWindowID.MAP,   UIWindowID.SEAL,    UIWindowID.SETTING, UIWindowID.GIFT,
            UIWindowID.REPORT,
        };
        private Param _param;

        // TODO
        private void Awake() { }

        // TODO
        public override void OnCreate() { }

        // TODO
        public void Open(Param param, UIWindowID prevWindowId = WINDOWID_FIELD) { }

        // TODO
        public IEnumerator OpOpen(Param param, UIWindowID prevWindowId) { return null; }

        // TODO
        private void SetupTownmapGuideMessageWindow() { }

        // TODO
        private IEnumerator OpUpdateTownmapGuideMessageWindow() { return null; }

        // TODO
        private void StopTownmapGuideMessageWindow() { }

        // TODO
        void IViewportChangeHandler.OnViewportChange(int screenWidth, int screenHeight) { }

        // TODO
        private void SetupItems() { }

        // TODO
        private bool IsActiveItem(ItemType type) { return false; }

        // TODO
        private bool IsSwap() { return false; }

        // TODO
        private void SetupActiveItems() { }

        // TODO
        public static void CloseForce() { }

        // TODO
        public void Close(UnityAction<UIWindow> onClosed_, bool isRemoveKeyguide, UIWindowID nextWindowId) { }

        // TODO
        public IEnumerator OpClose(UnityAction<UIWindow> onClosed_, bool isRemoveKeyguide, UIWindowID nextWindowId) { return null; }

        // TODO
        private void OnUpdate(float deltaTime) { }

        // TODO
        private bool IsLimitingItem(ItemType itemType) { return false; }

        // TODO
        private void PlaySeDecide(ItemType itemType) { }

        // TODO
        private void OpenItem(ItemType itemType) { }

        // TODO
        private UIWindowID GetWindowId(ItemType itemType) { return UIWindowID.MAP; }

        // TODO
        private void OnItemClosed(UIWindow window) { }

        // TODO
        private void UpdateSwap(float deltaTime) { }

        // TODO
        private void UpdateSelectItem(float deltaTime) { }

        // TODO
        private bool SetSelectIndex(int selectIndex, bool isInitialize = false) { return false; }

        // TODO
        protected override void OpenMessageWindow(MsgWindowParam messageParam) { }

        // TODO
        protected override ContextMenuWindow CreateContextMenuYesNo(Func<ContextMenuItem, bool> onClicked, [Optional] ContextMenuWindow.Param contextMenuParam) { return null; }

        // TODO
        protected override void OnAddContextMenuYesNoItemParams(List<ContextMenuItem.Param> contextMenuItemParams) { }

        public enum ItemType : int
        {
            None = -1,
            Zukan = 0,
            Pokemon = 1,
            Bag = 2,
            Card = 3,
            Map = 4,
            Seal = 5,
            Setting = 6,
            Gift = 7,
            Report = 8,
        }

        public class Param
        {
	        public MenuType menuType;
            public Safari safari;

            [Flags]
            public enum MenuType : int
            {
                Normal = 0,
                Fureai = 1,
                SafariGame = 2,
                UnderGround = 3,
                Mysterious = 4,
            }

            public class Safari
            {
                public int ballNum = 12;
                public UnityAction onRetire;
            }
        } 
    }
}