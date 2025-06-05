using Audio;
using SmartPoint.AssetAssistant;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Dpr.UI
{
    public class DialogWindow : UIWindow
    {
        [SerializeField]
        private UIText dialogText;
        [Header("入力受付までの待ち時間")]
        [SerializeField]
        private float inputEnableWaitTime = 1.5f;
        private int addSortingOrder;
        private bool isCancelSE;

        public override void OnCreate()
        {
            base.OnCreate();
            _animator = GetComponentInChildren<Animator>();
        }

        public void Open(Action<UIText> setDialogText, int addSortingOrder = 0, UIWindowID prevWindowId = WINDOWID_FIELD, bool cancelSE = false)
        {
            this.addSortingOrder = addSortingOrder;
            isCancelSE = cancelSE;
            dialogText.text = null;
            setDialogText?.Invoke(dialogText);
            Sequencer.Start(OpOpen(prevWindowId));
        }

        public IEnumerator OpOpen(UIWindowID prevWindowId)
        {
            OnOpen(prevWindowId);
            _canvas.sortingOrder = addSortingOrder + 0x4001;
            yield return OpPlayOpenWindowAnimation(prevWindowId, null);

            Sequencer.update += OnUpdate;
            yield return new WaitForSeconds(inputEnableWaitTime);

            _input.inputEnabled = true;
        }

        public void Close(UnityAction<UIWindow> onClosed_, UIWindowID nextWindowId)
        {
            Sequencer.Start(OpClose(onClosed_, nextWindowId));
        }

        public IEnumerator OpClose(UnityAction<UIWindow> onClosed_, UIWindowID nextWindowId)
        {
            Sequencer.update -= OnUpdate;
            yield return OpPlayCloseWindowAnimationAndWaiting(nextWindowId);

            UIManager.Instance._ReleaseUIWindow(this);
            onClosed_?.Invoke(this);
        }

        private void OnUpdate(float deltaTime)
        {
            var currWindow = UIManager.Instance.GetCurrentUIWindow<UIWindow>();
            if (currWindow != this)
                return;

            if (!IsPushButton(UIManager.ButtonA, false) && !IsPushButton(UIManager.ButtonB, false))
                return;

            AudioManager.Instance.PlaySe(isCancelSE ? AK.EVENTS.UI_COMMON_CANCEL : AK.EVENTS.UI_COMMON_DECIDE, null);
            Close(onClosed, _prevWindowId);
        }
    }
}