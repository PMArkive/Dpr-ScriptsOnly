using SmartPoint.AssetAssistant;
using UnityEngine;

namespace Dpr.UI
{
    public class NowLoading : UIWindow
    {
        [SerializeField]
        private Animator _animatorLoading;
        private float _waitTime;
        private float _progressTime;
        private bool _isWaiting;

        private void Awake()
        {
            SetActive(false);
        }

        public void Open(float waitTime = 5.0f, int sortOrder = 16390)
        {
            Sequencer.update += OnUpdate;
            _progressTime = 0.0f;
            _isWaiting = true;
            Setup(waitTime, sortOrder);
        }

        public void Close()
        {
            Sequencer.update -= OnUpdate;
            UIManager.Instance._ReleaseUIWindow(this);
        }

        public void Setup(float waitTime = 5.0f, int sortOrder = 16390)
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
        }

        private void SetActive(bool active)
        {
            _animatorLoading.gameObject.SetActive(active);
        }
    }
}