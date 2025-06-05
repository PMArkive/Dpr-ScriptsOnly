using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Dpr.Battle.View.UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public abstract class BattleViewUICanvasBase : MonoBehaviour
    {
        [Header("[TransitionType]")]
        [Tooltip("遷移種別")]
        [SerializeField]
        protected TransitionType _transitionType;
        [Header("[TransitionParams]")]
        [SerializeField]
        protected TransitionParams _transitionParams = TransitionParams.Factory();
        private RectTransform _cachedRectTransform;
        protected CanvasGroup _canvasGroup;
        protected Action _onShowComplete;
        protected Action _onHideComplete;

        public RectTransform RectTransform
        {
            get
            {
                if (_cachedRectTransform != null)
                    return _cachedRectTransform;

                _cachedRectTransform = transform as RectTransform;
                return _cachedRectTransform;
            }
        }
        protected int MaxIndex { get; set; }
        public CanvasGroup CanvasGroup { get => this.GetComponentThis(ref _canvasGroup); }
        public int CurrentIndex { get; set; }
        public bool IsFocus { get; set; }
        public bool IsShow { get; set; }
        public bool IsValid { get; set; }
        public bool IsTransition { get; set; }
        public BattleUIAnimationState animationState { get; set; }
        public bool isOpenState { get => animationState == BattleUIAnimationState.Opening || animationState == BattleUIAnimationState.Opened; }
        public bool isCloseState { get => animationState == BattleUIAnimationState.closing || animationState == BattleUIAnimationState.Closed; }

        // TODO
        private void OnDestroy() { }

        // TODO
        public virtual void Startup() { }

        // TODO
        public virtual void Reset() { }

        // TODO
        public virtual void UnInitialize() { }

        // TODO
        public abstract void OnUpdate(float deltaTime);

        // TODO
        public void Show([Optional] Action onComplete) { }

        // TODO
        public void Hide([Optional, DefaultParameterValue(false)] bool isForce, [Optional] Action onComplete) { }

        // TODO
        protected void PlayTransitionAnimation(bool isShow) { }

        // TODO
        private IEnumerator OnPlayAnimationCor(float time) { return null; }

        // TODO
        protected virtual void PreparaNext(bool isForward) { }

        // TODO
        public virtual void ForceHide() { }

        // TODO
        protected virtual void OnShow() { }

        // TODO
        protected virtual void OnHide() { }

        // TODO
        protected virtual void OnPlayAnimation() { }

        // TODO
        protected virtual void SetAlpha(float alpha, float duration = 0.0f) { }

        // TODO
        protected void SelectButton<T>(ICollection<T> buttons, int index, bool isPlaySe = true) { }

        public enum TransitionType : byte
        {
            FadeInOut = 0,
            SlideInOut = 1,
            Animator = 2,
        }

        public enum BattleUIAnimationState : int
        {
            None = 0,
            Opening = 1,
            Opened = 2,
            closing = 3,
            Closed = 4,
        }

        [Serializable]
        public struct TransitionParams
        {
            [Tooltip("表示位置")]
            public Vector2 HideAnchorPosition;
            [Tooltip("非表示位置")]
            public Vector2 ShowAnchorPosition;
            public Ease Ease;
            public float Duration;
            public float Delay;

            public static TransitionParams Factory()
            {
                return new TransitionParams()
                {
                    HideAnchorPosition = Vector2.zero,
                    ShowAnchorPosition = Vector2.zero,
                    Ease = Ease.OutSine,
                    Duration = 0.25f,
                    Delay = 0.0f,
                };
            }
        }
    }
}