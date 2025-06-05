using DG.Tweening;
using UnityEngine;

namespace Dpr.MsgWindow
{
    public sealed class WindowAnimator
    {
        private AnimType wndAnimType;
        private DOTweenAnimation openAnimTween;
        private DOTweenAnimation canvasFadeTween;
        private CanvasGroup canvasGroup;
        private RectTransform contentRect;
        private AnimState currentState;
        private float timer;
        private bool bIsAnimation;

        public void Initialize(AnimType wndAnimType, GameObject frameObj, GameObject contentObj)
        {
            this.wndAnimType = wndAnimType;
            canvasGroup = frameObj.GetComponent<CanvasGroup>();
            contentRect = contentObj.GetComponent<RectTransform>();
            canvasFadeTween = frameObj.GetComponent<DOTweenAnimation>();
            openAnimTween = contentObj.GetComponent<DOTweenAnimation>();
            ResetAnim();
        }

        public void ResetAnim()
        {
            bIsAnimation = false;
            currentState = AnimState.Wait;
            timer = 0.0f;
            canvasGroup.alpha = 0.0f;
            contentRect.localScale = Vector3.one;
            contentRect.localPosition = Vector3.zero;
        }

        public bool IsAnimation { get => bIsAnimation; }

        public void SetAnimType(AnimType openAnimType)
        {
            wndAnimType = openAnimType;
        }

        public AnimState CurrentState { get => currentState; }

        public void OpenWindow()
        {
            currentState = AnimState.Open;
            timer = 0.0f;
            bIsAnimation = true;

            if (wndAnimType == AnimType.Immediate)
                DoPlayImmediateAnimation(true);
            else if (wndAnimType == AnimType.Scaling)
                DoPlayScalingAnimation(true);
        }

        public void CloseWindow()
        {
            currentState = AnimState.Close;
            timer = 0.0f;
            bIsAnimation = true;

            if (wndAnimType == AnimType.Immediate)
                DoPlayImmediateAnimation(false);
            else if (wndAnimType == AnimType.Scaling)
                DOPlayBackwards();
        }

        private void DoPlayScalingAnimation(bool forward)
        {
            if (forward)
            {
                canvasGroup.alpha = 0.0f;
                contentRect.localScale = Vector3.zero;
                DOPlayForward();
            }
            else
            {
                DOPlayBackwards();
            }
        }

        private void DOPlayForward()
        {
            openAnimTween.DORestart();
            canvasFadeTween.DORestart();
        }

        private void DOPlayBackwards()
        {
            openAnimTween.DOPlayBackwards();
            canvasFadeTween.DOPlayBackwards();
        }

        private void DoPlayImmediateAnimation(bool forward)
        {
            bIsAnimation = false;

            if (forward)
            {
                contentRect.localScale = Vector3.one;
                canvasGroup.alpha = 1.0f;
                currentState = AnimState.FinishedOpen;
            }
            else
            {
                contentRect.localScale = Vector3.zero;
                canvasGroup.alpha = 0.0f;
                currentState = AnimState.FinishedClose;
            }
        }

        public void ChangeTweenAnimationEnd()
        {
            openAnimTween.DOComplete();
            canvasFadeTween.DOComplete();
        }

        public void OnUpdate(float deltaTime)
        {
            if (!bIsAnimation)
                return;

            timer += deltaTime;

            switch (currentState)
            {
                case AnimState.Open:
                    if (timer < canvasFadeTween.duration)
                        return;

                    OnCompletedOpen();
                    break;

                case AnimState.Close:
                    if (timer < canvasFadeTween.duration)
                        return;

                    OnCompletedClose();
                    break;
            }
        }

        public void OnCompletedOpen()
        {
            bIsAnimation = false;
            currentState = AnimState.FinishedOpen;
            timer = 0.0f;
        }

        public void OnCompletedClose()
        {
            bIsAnimation = false;
            currentState = AnimState.FinishedClose;
            timer = 0.0f;
        }

        public enum AnimType : int
        {
            Scaling = 0,
            Split = 1,
            Immediate = 2,
        }

        public enum AnimState : int
        {
            Wait = 0,
            Open = 1,
            FinishedOpen = 2,
            Close = 3,
            FinishedClose = 4,
        }
    }
}