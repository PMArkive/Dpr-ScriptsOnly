using SmartPoint.AssetAssistant;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Dpr.UI
{
    public class Keyguide : UIWindow
    {
        [SerializeField]
        private RectTransform _guideRoot;
        [SerializeField]
        private KeyguideItem _itemPrefab;
        private Coroutine _coClose;
        private bool _isOpen;

        private void Awake()
        {
            if (_itemPrefab.gameObject.scene.name != null)
            {
                _itemPrefab.transform.SetParent(transform, false);
                _itemPrefab.gameObject.SetActive(false);
            }

            _animator = GetComponentInChildren<Animator>(true);
        }

        public void Open(Param param)
        {
            Sequencer.Start(OpOpen(param));
        }

        public IEnumerator OpOpen(Param param)
        {
            _isOpen = true;
            OnOpen(_prevWindowId);

            if (param != null)
                Setup(param);

            while (_coClose != null)
                yield return null;

            if (_animator != null)
                yield return OpPlayOpenWindowAnimation(_prevWindowId, null);

            _input.inputEnabled = true;
        }

        public void Setup(Param param)
        {
            if (!_isOpen)
                Open(param);

            if (_itemPrefab.transform.parent == _guideRoot)
                _itemPrefab.transform.SetParent(transform, false);

            for (int i=_guideRoot.childCount; i>-1; i--)
                Destroy(_guideRoot.GetChild(i).gameObject);

            _guideRoot.DetachChildren();

            for (int i=0; i<param.itemParams.Count; i++)
            {
                var newItem = Instantiate(_itemPrefab);
                newItem.transform.SetParent(_guideRoot.transform, false);
                newItem.gameObject.SetActive(true);
                newItem.Setup(param.itemParams[i]);
            }
        }

        public void Close(UnityAction<UIWindow> onClosed_)
        {
            _coClose = Sequencer.Start(OpClose(onClosed_));
        }

        public IEnumerator OpClose(UnityAction<UIWindow> onClosed_)
        {
            _isOpen = false;
            UIManager.Instance._ClearKeyguide();

            if (_animator != null)
                yield return OpPlayCloseWindowAnimationAndWaiting(_prevWindowId);

            onClosed_?.Invoke(this);
            _coClose = null;
        }

        public class Param
        {
            public List<KeyguideItem.Param> itemParams = new List<KeyguideItem.Param>();
        }
    }
}