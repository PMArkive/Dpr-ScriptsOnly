using SmartPoint.AssetAssistant;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
    public class Cursor : MonoBehaviour
    {
        [SerializeField]
        private Image[] _frameImages;
        [SerializeField]
        private Sprite[] _frameSprites;
        public static readonly int animStateIn = Animator.StringToHash("in");
        public static readonly int animStateOut = Animator.StringToHash("out");
        public static readonly int animStateDecide = Animator.StringToHash("decide");
        public static readonly int animStateWait = Animator.StringToHash("wait");
        public static readonly int animStateNull = Animator.StringToHash("null");
        protected Animator _animator;
        protected Coroutine _opPlay;

        public Animator animator { get => _animator; }

        private void Awake()
        {
            _animator = GetComponentInChildren<Animator>(true);
        }

        private void OnDestroy()
        {
            if (_opPlay != null)
            {
                Sequencer.Stop(_opPlay);
                _opPlay = null;
            }
        }

        public void SetActive(bool enabled)
        {
            if (enabled)
            {
                gameObject.SetActive(true);
                Play(animStateIn, 0, 0.0f);
            }
            else
            {
                if (!IsActived())
                {
                    gameObject.SetActive(false);
                }
                else
                {
                    gameObject.SetActive(true);
                    Play(animStateOut, 0, 0.0f);
                }
            }
        }

        public bool IsActived()
        {
            if (_animator == null)
                return false;

            if (_animator.GetCurrentAnimatorStateInfo(0).shortNameHash == animStateIn)
                return true;

            if (_animator.GetCurrentAnimatorStateInfo(0).shortNameHash == animStateWait)
                return true;

            return false;
        }

        public bool Play(int animState, int layer = 0, float startTime = 0.0f)
        {
            if (_animator == null)
                return false;

            if (_animator.GetCurrentAnimatorStateInfo(0).shortNameHash == animState)
                return true;

            if (_opPlay != null)
                Sequencer.Stop(_opPlay);

            _opPlay = Sequencer.Start(OpPlay(animState, layer, startTime));
            return true;
        }

        private IEnumerator OpPlay(int animState, int layer, float startTime)
        {
            while (!_animator.isActiveAndEnabled)
                yield return null;

            _animator.Play(animState, layer, startTime);
            _opPlay = null;
        }

        public void SetFrameSprite(int index)
        {
            for (int i=0; i<_frameImages.Length; i++)
                _frameImages[i].sprite = _frameSprites[index];
        }
    }
}