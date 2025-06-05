using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Dpr.UI
{
    public class UIRegisterItemShortcut : UIWindow
    {
        private const string QuestionReisterItemMessageLabel = "SS_bag_347";
        private const string QuestionReisterItemOnAllItemRegisteredMessageLabel = "SS_bag_348";
        private const string QuestionSwapButtonItemMessageLabel = "SS_bag_349";
        private const string ResultRegisterItemMessageLabel = "SS_bag_350";
        private const string ResultSwapItemMessageLabel = "SS_bag_351";

        [SerializeField]
        private Image bgImage;
        [SerializeField]
        private RegisterItemButton[] registerItemButtons;
        [SerializeField]
        private Image[] arrowImages;
        [SerializeField]
        private Color unselectArrowColor = Color.white;
        [SerializeField]
        private Color selectArrowColor = Color.white;
        [SerializeField]
        private Sprite unselectButtonBaseSprite;
        [SerializeField]
        private Sprite selectButtonBaseSprite;
        [SerializeField]
        private Sprite disableButtonBaseSprite;
        private readonly int _animStateIn = Animator.StringToHash("in");
        private readonly int _animStateOut = Animator.StringToHash("out");
        private UIMsgWindowController msgWindowController;
        private UIInputController inputController;
        private BootType bootType;
        private ushort registerItemNo;
        private Action<ushort> onUseCallBack;
        private int selectIndex = -1;
        private bool isAllRegistered;

        // TODO
        public static ushort GetHighPriorityShortcutItemNo() { return 0; }

        // TODO
        public static int GetRegisteredShortcutItemCount() { return 0; }

        // TODO
        public override void OnCreate() { }

        // TODO
        public void OpenRegister(ushort registerItemNo) { }

        // TODO
        public void OpenUse(Action<ushort> onUseCallBack) { }

        // TODO
        public IEnumerator OpOpen() { return null; }

        // TODO
        public void Close(UnityAction<UIWindow> onClosed_) { }

        // TODO
        public IEnumerator OpClose(UnityAction<UIWindow> onClosed_) { return null; }

        // TODO
        private void OnUpdate(float deltaTime) { }

        // TODO
        private void SetSelectIndex(int index) { }

        // TODO
        private void SetButtonBaseSprite(RegisterItemButton button, bool isSelected) { }

        // TODO
        private void ShowSelectButtonMessage() { }

        // TODO
        private void Register() { }

        private enum BootType : int
        {
            Register = 0,
            Use = 1,
        }
    }
}