using SmartPoint.AssetAssistant;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
    public class ModelViewBase : MonoBehaviour
    {
        [SerializeField]
        protected Image _imageModelBg;
        [SerializeField]
        protected RawImage _rawImageModelView;
        protected Transform _transBg;

        public RawImage rawImageModelView { get => _rawImageModelView; }

        protected virtual void Awake()
        {
            _transBg = _imageModelBg.transform.parent;
        }

        protected virtual void OnEnable()
        {
            Sequencer.lateUpdate += OnLateUpdate;
        }

        protected virtual void OnDisable()
        {
            Sequencer.lateUpdate -= OnLateUpdate;
        }

        public void Clear(bool isFinish = false)
        {
            if (isFinish)
            {
                _imageModelBg.transform.SetParent(_transBg, false);
                _imageModelBg.transform.SetSiblingIndex(0);
            }

            UIManager.Instance.modelView.ClearModelView(isFinish);
        }

        public void UpdateTexture()
        {
            if (_rawImageModelView == null)
                return;

            _rawImageModelView.texture = UIManager.Instance.modelView.GetModelViewRenderTexture();
        }

        public void SetRawImageAlpha(float alpha)
        {
            _rawImageModelView.color = new Color(_rawImageModelView.color.r, _rawImageModelView.color.g, _rawImageModelView.color.b, alpha);
        }

        private void OnLateUpdate(float deltaTime)
        {
            UpdateTexture();
            UpdateAnimation(deltaTime);
        }

        protected virtual void UpdateAnimation(float deltaTime)
        {
            // Empty
        }
    }
}