using Dpr.MsgWindow;
using SmartPoint.AssetAssistant;
using SmartPoint.Components;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Events;

namespace Dpr.UI
{
    public class UIWindow : MonoBehaviour
    {
        public const UIWindowID WINDOWID_PARENT = (UIWindowID)(-1);
        public const UIWindowID WINDOWID_FIELD = (UIWindowID)(-2);
        public const int MoveLeftButton = 69632;
        public const int MoveRightButton = 278528;
        public const int MoveUpButton = 139264;
        public const int MoveDownButton = 557056;
        public const float TransitionFadeDuration = 0.1f;

        public static readonly Color TransitionFadeFillColor = new Color(0.5450981f, 0.7607843f, 0.9490196f);

        protected UIInputController _input = new UIInputController();
        protected Canvas _canvas;
        protected Animator _animator;
        protected UIAnimationEvent _animEvent;
        protected UITransition.FadeType _transitionFadeType = UITransition.FadeType.None;
        protected UIWindowID _prevWindowId = WINDOWID_PARENT;
        protected MsgWindow.MsgWindow _messageWindow;
        public UIManager.UIInstance instance;
        public UnityAction<UIWindow> onClosed;
        public UnityAction<UIWindow> onPreClose;

        public UIWindowID prevWindowId { get => _prevWindowId; }
        protected bool isCompleteTransition { get => _transitionFadeType == UITransition.FadeType.None; }
        public Canvas canvas { get => _canvas; }
        public UIInputController InputController { get => _input; }
        public bool IsClosing { get; set; }

        private readonly int _animStateIn = Animator.StringToHash("in");
        private readonly int _animStateOut = Animator.StringToHash("out");

        public virtual void OnCreate()
        {
            _canvas = GetComponentInChildren<Canvas>(true);
            _animator = GetComponentInChildren<Animator>(true);
            _animEvent = GetComponentInChildren<UIAnimationEvent>(true);

            if (_animator != null && _animEvent == null)
                _animEvent = _animator.gameObject.AddComponent<UIAnimationEvent>();

            if (_animEvent != null)
                _animEvent.onTransition = OnTransition;
        }

        public void RegisterCloseOnOpenWindow<T>(Color color, float duration, UnityAction<UIWindow> onClosedAction) where T : UIWindow
        {
            IEnumerator OnPreClose()
            {
                var beforeColor = Fader.fillColor;
                Fader.fadeMode = Fader.FadeMode.Color;
                Fader.fillColor = color;
                Fader.FadeOut(duration);

                while (Fader.fadeOutProgress != 1.0f)
                    yield return null;

                Fader.fillColor = beforeColor;
            }

            IEnumerator OnClosed(UIWindow window)
            {
                while (Fader.fadeOutProgress != 1.0f)
                    yield return null;

                var time = Time.realtimeSinceStartup;
                onClosedAction?.Invoke(window);

                while (UIManager.Instance.GetCurrentUIWindow<T>() == null)
                    yield return null;

                time = duration - (Time.realtimeSinceStartup - time);

                while (time > 0.0f)
                {
                    yield return null;
                    time -= Time.deltaTime;
                }

                var beforeColor = Fader.fillColor;
                Fader.fadeMode = Fader.FadeMode.Color;
                Fader.fillColor = color;
                Fader.FadeIn(duration);

                while (Fader.fadeInProgress != 1.0f)
                    yield return null;

                Fader.fillColor = beforeColor;
            }

            onPreClose = (window) => Sequencer.Start(OnPreClose());
            onClosed += (window) => Sequencer.Start(OnClosed(window));
        }

        protected virtual void OnDestroy()
        {
            // Empty
        }

        protected virtual void OnTransition(TransitionID transitionId, UITransition.FadeType fadeType)
        {
            _transitionFadeType = fadeType;
            if (instance.windowId == UIWindowID.CONTEXTMENU)
                return;

            UIManager.Instance.PlayTransition(transitionId, _transitionFadeType, OnTransitionComplete);
        }

        protected virtual void OnTransitionComplete(UITransition.FadeType fadeType)
        {
            _transitionFadeType = UITransition.FadeType.None;
            if (fadeType == UITransition.FadeType.Out && _animator.GetInteger(UIWindowStateMachine.animParamStateId) == 1)
                EnableMainCameraByUiMode(true);
        }

        protected virtual void OnOpen(UIWindowID prevWindowId)
        {
            _input.inputEnabled = false;
            _transitionFadeType = UITransition.FadeType.None;
            _prevWindowId = prevWindowId;

            UIManager.Instance.SetTransitionWindowIds(prevWindowId, instance.windowId, true);
            UIManager.Instance.SetupSortOrder(this);
            IsClosing = false;
        }

        protected bool IsPushButton(int button, bool isForce = false)
        {
            return _input.IsPushButton(button, isForce);
        }

        protected bool IsReleaseButton(int button, bool isForce = false)
        {
            return _input.IsReleaseButton(button, isForce);
        }

        protected bool IsRepeatButton(int button, bool isForce = false)
        {
            return _input.IsRepeatButton(button, isForce);
        }

        protected bool IsOnButton(int button, bool isForce = false)
        {
            return _input.IsOnButton(button, isForce);
        }

        protected bool IsAccelButton(int button, bool isForce = false)
        {
            return _input.IsAccelButton(button, isForce);
        }

        protected virtual void PlayOpenWindowAnimation(UIWindowID prevWindowId, [Optional] UnityAction onOpend)
        {
            Sequencer.Start(OpPlayOpenWindowAnimation(prevWindowId, onOpend));
        }

        protected virtual IEnumerator OpPlayOpenWindowAnimation(UIWindowID prevWindowId, [Optional] UnityAction onOpend)
        {
            while (!_animator.isActiveAndEnabled)
                yield return null;

            int connectId = GetWindowAnimationConnectId(true, prevWindowId);
            _animator.SetInteger(UIWindowStateMachine.animParamConnectId, connectId);
            _animator.SetInteger(UIWindowStateMachine.animParamStateId, 1);

            while (_animator != null && _animator.GetInteger(UIWindowStateMachine.animParamConnectId) != -1)
                yield return null;

            onOpend?.Invoke();
        }

        protected virtual int GetWindowAnimationConnectId(bool isOpen, UIWindowID windowId)
        {
            if (windowId == WINDOWID_FIELD)
                return 10;

            if (windowId == WINDOWID_PARENT)
                return 0;

            return UIManager.Instance.database.UIWindow[(int)windowId].WindowAnimId;
        }

        protected virtual IEnumerator OpPlayCloseWindowAnimationAndWaiting(UIWindowID nextWindowId)
        {
            _input.inputEnabled = false;
            IsClosing = true;

            UIManager.Instance.SetTransitionWindowIds(instance.windowId, nextWindowId, false);
            if (nextWindowId > WINDOWID_PARENT)
            {
                bool currentWindowCamera = UIManager.Instance.database[(int)instance.windowId].UiCameraMode == 1;
                bool nextWindowCamera =  UIManager.Instance.database[(int)nextWindowId].UiCameraMode == 1;
                UIManager.Instance._CaptureBlueImage(currentWindowCamera && nextWindowCamera);
            }

            EnableMainCameraByUiMode(false);
            OnCloseKeyguide();

            _animator.SetInteger(UIWindowStateMachine.animParamConnectId, GetWindowAnimationConnectId(false, nextWindowId));
            _animator.SetInteger(UIWindowStateMachine.animParamStateId, 2);

            while (_animator != null && _animator.GetInteger(UIWindowStateMachine.animParamConnectId) != -1)
                yield return null;

            IsClosing = false;
        }

        protected virtual bool EnableMainCameraByUiMode(bool enabled)
        {
            if (UIManager.Instance.database[(int)instance.windowId].UiCameraMode == -1)
                return false;

            bool enableCamera = UIManager.Instance.database[(int)instance.windowId].UiCameraMode != 0 && enabled;
            UIManager.Instance.modelView.EnableMainCameraByUiMode(enableCamera);

            return true;
        }

        protected virtual void OnCloseKeyguide()
        {
            var keyguide = UIManager.Instance.GetKeyguide(null, false);

            if (keyguide != null && keyguide.transform.parent == transform)
                keyguide.Close(null);
        }

        protected virtual void OpenMessageWindow(MsgWindowParam messageParam)
        {
            if (!messageParam.inputEnabled)
                messageParam.inputEnabled = true;

            // TODO: Double check the conditional here, what is going on?
            if (_messageWindow != null && _messageWindow.IsOpen && _messageWindow.IsEnabledCloseSelf == messageParam.inputCloseEnabled)
            {
                _messageWindow.ReplaceMessage(messageParam);
            }
            else
            {
                CloseMessageWindow();
                _messageWindow = MsgWindowManager.OpenMsg(messageParam);
            }
        }

        protected virtual void CloseMessageWindow()
        {
            if (_messageWindow == null)
                return;

            _messageWindow.CloseWindow();
            _messageWindow = null;
        }

        protected virtual bool IsActiveMessageWindow()
        {
            if (_messageWindow == null)
                return false;

            return _messageWindow.MsgState != MsgWindowDataModel.MsgWindowState.Inactive && _messageWindow.IsEnabledCloseSelf;
        }

        protected ContextMenuWindow.Param CreateContextMenuYesNoParam()
        {
            var contextMenuItemParams = new List<ContextMenuItem.Param>();
            OnAddContextMenuYesNoItemParams(contextMenuItemParams);

            var windowParam = new ContextMenuWindow.Param
            {
                itemParams = contextMenuItemParams.ToArray(),
                pivot = new Vector2(1.0f, 0.0f),
                position = _messageWindow.CalcContextMenuPos(),
                useLoopAndRepeat = false
            };

            return windowParam;
        }

        protected virtual ContextMenuWindow CreateContextMenuYesNo(Func<ContextMenuItem, bool> onClicked, uint SeDecide)
        {
            var windowParam = CreateContextMenuYesNoParam();
            windowParam.seDecide = SeDecide;

            return CreateContextMenuYesNo(onClicked, windowParam);
        }

        protected virtual ContextMenuWindow CreateContextMenuYesNo(Func<ContextMenuItem, bool> onClicked, [Optional] ContextMenuWindow.Param contextMenuParam)
        {
            if (contextMenuParam == null)
                contextMenuParam = CreateContextMenuYesNoParam();

            var window = UIManager.Instance.CreateUIWindow<ContextMenuWindow>(UIWindowID.CONTEXTMENU);
            window.onClosed = __ => { /* Empty */ };
            window.onClicked = onClicked;
            window.Open(contextMenuParam);

            return window;
        }

        protected virtual void OnAddContextMenuYesNoItemParams(List<ContextMenuItem.Param> contextMenuItemParams)
        {
            // Empty
        }

        protected IEnumerator FadeTransition<T>(Color color, float duration, Action action) where T : UIWindow
        {
            UIManager.Instance.EnableFadeTransition(true);
            _input.inputEnabled = false;

            var beforeFillColor = Fader.fillColor;
            Fader.fadeMode = Fader.FadeMode.Color;
            Fader.fillColor = color;
            Fader.FadeOut(duration);

            while (Fader.fadeOutProgress != 1.0f)
                yield return null;

            var time = Time.realtimeSinceStartup;
            action?.Invoke();

            while (UIManager.Instance.GetCurrentUIWindow<T>() == null)
                yield return null;

            time = duration - (Time.realtimeSinceStartup - time);
            while (time > 0.0f)
            {
                yield return null;
                time -= Time.deltaTime;
            }

            Fader.FadeIn(duration);

            while (Fader.fadeInProgress != 1.0f)
                yield return null;

            Fader.fillColor = beforeFillColor;
            UIManager.Instance.EnableFadeTransition(false);
        }
    }
}