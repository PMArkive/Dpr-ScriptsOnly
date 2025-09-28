using AK;
using Dpr.Battle.Logic;
using Dpr.Battle.View.Systems;
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

        public bool IsReturnable { get; private set; }
        public BtlAction Result { get; private set; }

        public override void Startup()
        {
            base.Startup();

            _isSafari = BattleViewCore.Instance.ViewSystem.GetBattleRule() == BtlRule.BTL_RULE_SAFARI;

            var isTutorial = BattleViewCore.Instance.ViewSystem.GetMainModule().GetBattleViewSystem().IsTutorial();
            _buttonLayout.padding.bottom = isTutorial ? ((int)_actionButtons[0].rectTransform.sizeDelta.y) * 3 : 0;

            CurrentIndex = _isSafari ? 5 : 0;

            _pokeBallButton.SetOnSubmit(() => Result = BtlAction.BTL_ACTION_ITEM);

            foreach (var button in _actionButtons)
                button.SetOnSubmit(() => OnSubmitActionButton(button));
        }

        public void Initialize(in BattleViewBase.SelectActionParam param)
        {
            IsValid = false;
            Result = BtlAction.BTL_ACTION_NULL;
            IsReturnable = param.fReturnable;
            _isBallEnable = !_isSafari || param.isBallShortcutEnable;
            _minIndex = -1;
            _maxIndex = -1;

            for (int i=0; i<_actionButtons.Count; i++)
            {
                bool active;
                bool visible;

                if (!_isSafari)
                {
                    switch ((ActionButtonType)i)
                    {
                        case ActionButtonType.Fight:
                            active = param.buttonMode_Fight != BattleViewBase.ButtonMode.PASSIVE;
                            visible = param.buttonMode_Fight != BattleViewBase.ButtonMode.INVISIBLE;
                            break;

                        case ActionButtonType.Pokemon:
                            active = param.buttonMode_Pokemon != BattleViewBase.ButtonMode.PASSIVE;
                            visible = param.buttonMode_Pokemon != BattleViewBase.ButtonMode.INVISIBLE;
                            break;

                        case ActionButtonType.Bag:
                            active = param.buttonMode_Bag != BattleViewBase.ButtonMode.PASSIVE;
                            visible = param.buttonMode_Bag != BattleViewBase.ButtonMode.INVISIBLE;
                            break;

                        case ActionButtonType.Escape:
                            visible = param.buttonMode_Escape != BattleViewBase.ButtonMode.INVISIBLE;

                            if (visible)
                            {
                                active = param.buttonMode_Escape != BattleViewBase.ButtonMode.PASSIVE;

                                if (IsReturnable)
                                {
                                    active = false;
                                    visible = false;
                                }
                            }
                            else
                            {
                                active = false;
                            }
                            break;

                        case ActionButtonType.Return:
                            visible = param.buttonMode_Escape != BattleViewBase.ButtonMode.INVISIBLE;

                            if (visible)
                            {
                                active = param.buttonMode_Escape != BattleViewBase.ButtonMode.PASSIVE;

                                if (!IsReturnable)
                                {
                                    active = false;
                                    visible = false;
                                }
                            }
                            else
                            {
                                active = false;
                            }
                            break;

                        default:
                            active = false;
                            visible = false;
                            break;
                    }
                }
                else
                {
                    switch ((ActionButtonType)i)
                    {
                        case ActionButtonType.SafariBall:
                        case ActionButtonType.SafariFood:
                        case ActionButtonType.SafariMud:
                        case ActionButtonType.SafariEscape:
                            active = true;
                            visible = true;
                            break;

                        default:
                            active = false;
                            visible = false;
                            break;
                    }
                }

                if (visible)
                {
                    if (_minIndex == -1)
                        _minIndex = i;
                    _maxIndex = i;
                }
                _actionButtons[i].Initialize((ActionButtonType)i, i, active);
                _actionButtons[i].SetActive(visible);
            }

            SelectButton(_actionButtons, CurrentIndex, false);

            _xyButtonFrame.SetActive(!_isSafari || param.isBallShortcutEnable);

            var balls = GetExistBalls();
            if (balls.Count != 0 && !_isSafari)
            {
                var selectedBall = balls[0].BallID;
                for (int i=0; i<balls.Count; i++)
                {
                    if (balls[i].Id == BattleViewUISystem.lastSelectedBallItemNo)
                        selectedBall = balls[i].BallID;
                }

                _xyMenuBallIcon.sprite = UIManager.Instance.GetSpriteMonsterBall(selectedBall);
                _needOpenBallWindow = BattleViewCore.Instance.UISystem.PokeBallList.Initialize(balls, () => IsValid = _pokeBallButton.Submit());
            }
            else
            {
                _needOpenBallWindow = false;
            }
        }

        private List<ItemInfo> GetExistBalls()
        {
            return ItemWork.GetItemInfosByCategory(ItemInfo.CategoryType.Ball);
        }

        public override void OnUpdate(float deltaTime)
        {
            if (!IsFocus)
                return;

            if (isButtonAction)
                return;

            if (NetworkManager.IsShowApplicationErrorDialog())
                return;

            if (BtlvInput.GetPush(UIManager.ButtonA))
                ExecuteCurrentButton();

            if (BtlvInput.GetPush(UIManager.ButtonX))
                OnSubmitPokeBall();

            if (BtlvInput.GetPush(UIManager.ButtonB))
                OnCancel();

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

        protected override void PreparaNext(bool isForward)
        {
            if (BtlvInput.GetAny() && !BtlvInput.GetAnyPush() &&
                ((CurrentIndex == _minIndex && !isForward) || (CurrentIndex == _maxIndex && isForward)))
                return;

            do
            {
                base.PreparaNext(isForward);

                if (CurrentIndex >= _actionButtons.Count)
                    CurrentIndex = 0;
                if (CurrentIndex < 0)
                    CurrentIndex = _actionButtons.Count - 1;
            }
            while (!_actionButtons[CurrentIndex].IsActive());
        }

        protected override void OnShow()
        {
            base.OnShow();
            SelectButton(_actionButtons, CurrentIndex, false);
            BattleViewCore.Instance.UISystem.CursorFrame.SetActive(true);
            isButtonAction = false;
            _onShowComplete?.Invoke();
        }

        public void ResetSelect()
        {
            CurrentIndex = (int)(_isSafari ? ActionButtonType.SafariBall : ActionButtonType.Fight);
        }

        public void UpdateActionButton(bool isPlaySe = true)
        {
            SelectButton(_actionButtons, CurrentIndex, isPlaySe);
        }

        private void OnSubmitPokeBall()
        {
            if (IsFocus && _isBallEnable && !isButtonAction)
            {
                isButtonAction = true;

                var ballList = BattleViewCore.Instance.UISystem.PokeBallList;
                if (ballList.SetOpenBallInfo() == BUIPokeBallList.BallListState.Many)
                {
                    Hide(false, null);

                    if (_needOpenBallWindow)
                        ballList.Show(null);
                }

                BattleViewCore.Instance.UISystem.PlaySe(EVENTS.UI_COMMON_MENU_OPEN);
            }
        }

        private void OnSubmitActionButton(BUIActionSelectButton button)
        {
            switch (button.ButtonType)
            {
                case ActionButtonType.Fight:
                    Result = BtlAction.BTL_ACTION_FIGHT;
                    break;

                case ActionButtonType.Pokemon:
                    Result = BtlAction.BTL_ACTION_CHANGE;
                    break;

                case ActionButtonType.Bag:
                    Result = BtlAction.BTL_ACTION_ITEM;
                    break;

                case ActionButtonType.Escape:
                case ActionButtonType.SafariEscape:
                    Result = BtlAction.BTL_ACTION_ESCAPE;
                    break;

                case ActionButtonType.Return:
                    CurrentIndex = 0;
                    Result = BtlAction.BTL_ACTION_FIGHT;
                    break;

                case ActionButtonType.SafariBall:
                    Result = BtlAction.BTL_ACTION_SAFARI_BALL;
                    break;

                case ActionButtonType.SafariFood:
                    Result = BtlAction.BTL_ACTION_SAFARI_ESA;
                    break;

                case ActionButtonType.SafariMud:
                    Result = BtlAction.BTL_ACTION_SAFARI_DORO;
                    break;
            }
        }

        private void OnSubmit()
        {
            ExecuteCurrentButton();
        }

        private void OnCancel()
        {
            if (IsFocus && !isButtonAction && IsReturnable)
            {
                isButtonAction = true;
                IsValid = true;
                Result = BtlAction.BTL_ACTION_ESCAPE;
                BattleViewCore.Instance.UISystem.PlaySe(EVENTS.UI_COMMON_CANCEL);
            }
        }

        public void SetCursor(ActionButtonType target)
        {
            SelectButton(_actionButtons, (int)target);
            CurrentIndex = (int)target;
        }

        public void ExecuteCurrentButton()
        {
            if (IsFocus && !isButtonAction)
            {
                isButtonAction = true;
                IsValid = _actionButtons[CurrentIndex].Submit();
            }
        }

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