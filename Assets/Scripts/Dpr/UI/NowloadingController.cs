using SmartPoint.AssetAssistant;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
    public class NowloadingController : MonoBehaviour
    {
        [SerializeField]
        private Animator _animatorLoading;
        [SerializeField]
        private Image _imageBackground;
        private float _waitTime;
        private float _progressTime;
        private bool _isWaiting;
        private static readonly int animStatePlay = Animator.StringToHash("CmnLoadMon1");
        private float _animLength;
        private float _animTime;

        private void Awake()
        {
            UIManager.Instance.RegisterNowloading(this);
            SetActive(false);
        }

        public void Open(float waitTime = 5.0f, int sortOrder = 16390)
        {
            Sequencer.update -= OnUpdate;
            Sequencer.update += OnUpdate;

            if (!gameObject.activeSelf)
            {
                _progressTime = 0.0f;
                _isWaiting = true;
                gameObject.SetActive(true);
                _animTime = 0.0f;
            }

            Setup(waitTime, sortOrder);
        }

        public void Close()
        {
            Sequencer.update -= OnUpdate;
            gameObject.SetActive(false);
        }

        private void Setup(float waitTime = 5.0f, int sortOrder = 16390)
        {
            if (_isWaiting)
            {
                _isWaiting = _progressTime < waitTime;
                _waitTime = waitTime;
            }

            var canvas = GetComponent<Canvas>();
            if (canvas != null)
                canvas.sortingOrder = sortOrder;

            SetActive(!_isWaiting);
        }

        private void OnUpdate(float deltaTime)
        {
            if (_isWaiting)
            {
                _progressTime += deltaTime;
                if (_waitTime <= _progressTime)
                {
                    SetActive(true);
                    _isWaiting = false;
                }
            }

            if (_animatorLoading.isActiveAndEnabled)
            {
                _animatorLoading.Play(animStatePlay, 0, _animTime);
                _animTime += 0.03333334f / _animLength;
            }
        }

        private void SetActive(bool active)
        {
            _animatorLoading.speed = 0.0f;

            var clipInfo = _animatorLoading.GetCurrentAnimatorClipInfo(0);
            if (clipInfo.Length != 0)
                _animLength = clipInfo[0].clip.length;

            _animatorLoading.gameObject.SetActive(active);
        }

        public void EnableBackground(bool enabled)
        {
            _imageBackground.gameObject.SetActive(enabled);
        }
    }
}
