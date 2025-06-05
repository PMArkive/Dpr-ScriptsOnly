using SmartPoint.AssetAssistant;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Dpr.UI
{
    public class AutoSaveWindow : UIWindow
    {
        public const int SORTING_ORDER = 16484;

        public override void OnCreate()
        {
            base.OnCreate();
            _animator = GetComponentInChildren<Animator>(true);
        }

        public void Open(UIWindowID prevWindowId)
        {
            Sequencer.Start(OpOpen(prevWindowId));
        }

        public IEnumerator OpOpen(UIWindowID prevWindowId)
        {
            OnOpen(prevWindowId);
            _canvas.sortingOrder = SORTING_ORDER;
            yield return OpPlayOpenWindowAnimation(prevWindowId, null);
            Sequencer.update += OnUpdate;
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
            _ = UIManager.Instance.GetCurrentUIWindow<UIWindow>() != this;
        }
    }
}