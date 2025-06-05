using Dpr.Battle.Logic;
using Dpr.Item;
using Dpr.NetworkUtils;
using Dpr.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.Battle.View.UI
{
    public sealed class BUIActionList : BattleViewUICanvasBase, IResultable<BtlAction>
    {
        [SerializeField]
        private GameObject _xyButtonFrame;
        [SerializeField]
        private GameObject _yButtonFrame;
        [SerializeField]
        private BUIButton _pokeBallButton;
        [SerializeField]
        private BUIButton _situationButton;
        [SerializeField]
        private VerticalLayoutGroup _buttonLayout;
        [SerializeField]
        private List<BUIActionSelectButton> _actionButtons;
        [SerializeField]
        private Image _xyMenuBallIcon;
        private bool _isBallEnable;
        private bool _needOpenBallWindow;
        private bool _isSafari;
        private bool isButtonAction;
        private int _minIndex;
        private int _maxIndex;

        public bool IsReturnable { get; set; }
        public BtlAction Result { get; set; }

        // TODO
        public override void Startup() { }

        // TODO
        public void Initialize(in BattleViewBase.SelectActionParam param) { }

        // TODO
        private List<ItemInfo> GetExistBalls() { return null; }

        public override void OnUpdate(float deltaTime)
        {
            if (!IsFocus)
                return;

            if (isButtonAction)
                return;

            if (NetworkManager.IsShowApplicationErrorDialog())
                return;

            if (BtlvInput.GetPush(UIManager.ButtonA))
            {
                if (IsFocus && !isButtonAction)
                {
                    isButtonAction = true;
                    IsValid = _actionButtons[CurrentIndex].Submit();
                }
            }

            if (BtlvInput.GetPush(UIManager.ButtonX))
                OnSubmitPokeBall();

            if (BtlvInput.GetPush(UIManager.ButtonB))
            {
                if (IsFocus && !isButtonAction && IsReturnable)
                {
                    isButtonAction = true;
                    IsValid = true;
                    Result = BtlAction.BTL_ACTION_ESCAPE;
                    BattleViewCore.Instance.UISystem.PlaySe(AK.EVENTS.UI_COMMON_CANCEL);
                }
            }

            if (BtlvInput.GetPush(UIManager.StickLDown) ||
                BtlvInput.GetRepeat(UIManager.StickLDown))
            {
                PreparaNext(true);
            }

            if (BtlvInput.GetPush(UIManager.StickLUp) ||
                BtlvInput.GetRepeat(UIManager.StickLUp))
            {
                PreparaNext(false);
            }
        }

        // TODO
        protected override void PreparaNext(bool isForward) { }

        protected override void OnShow()
        {
            base.OnShow();
            SelectButton(_actionButtons, CurrentIndex, false);
            BattleViewCore.Instance.UISystem.CursorFrame.SetActive(true);
            isButtonAction = false;
            _onShowComplete?.Invoke();
        }

        // TODO
        public void ResetSelect() { }

        public void UpdateActionButton(bool isPlaySe = true)
        {
            SelectButton(_actionButtons, CurrentIndex, isPlaySe);
        }

        // TODO
        private void OnSubmitPokeBall() { }

        // TODO
        private void OnSubmitActionButton(BUIActionSelectButton button) { }

        // TODO
        private void OnSubmit() { }

        // TODO
        private void OnCancel() { }

        // TODO
        public void SetCursor(ActionButtonType target) { }

        // TODO
        public void ExecuteCurrentButton() { }

        public enum ActionButtonType : int
        {
            Fight = 0,
            Pokemon = 1,
            Bag = 2,
            Escape = 3,
            Return = 4,
            SafariBall = 5,
            SafariFood = 6,
            SafariMud = 7,
            SafariEscape = 8,
        }
    }
}