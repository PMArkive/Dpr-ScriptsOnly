using SmartPoint.AssetAssistant;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Dpr.UI
{
    public class UITransition : MonoBehaviour
    {
        protected readonly int _animStateIn = Animator.StringToHash("in_01");
        protected readonly int _animStateOut = Animator.StringToHash("out_01");
        protected Animator _animator;
        protected Coroutine _coroutine;
        protected UnityAction<FadeType> _onComplete;
        protected FadeType _fadeType = FadeType.None;

        protected void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public virtual void PlayFade(FadeType fadeType, UnityAction<FadeType> onComplete)
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
                _onComplete?.Invoke(_fadeType);
            }

            _fadeType = fadeType;
            _onComplete = onComplete;

            _coroutine = Sequencer.Start(OpPlayFade());
        }

        protected virtual IEnumerator OpPlayFade()
        {
            var animState = _fadeType == FadeType.Out ? _animStateOut : _animStateIn;
            _animator.Play(animState, 0, 0.0f);

            while (_animator.GetCurrentAnimatorStateInfo(0).shortNameHash != animState)
                yield return null;

            while (_animator.GetCurrentAnimatorStateInfo(0).shortNameHash == animState)
                yield return null;

            _onComplete?.Invoke(_fadeType);

            _coroutine = null;
            _fadeType = FadeType.None;
            _onComplete = null;
        }

        public enum FadeType : int
        {
            None = -1,
            In = 0,
            Out = 1,
        }
    }
}