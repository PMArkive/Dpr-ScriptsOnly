using Audio;
using SmartPoint.AssetAssistant;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Dpr.UI
{
    public class ContextMenuWindow : UIWindow
    {
        [SerializeField]
        private RectTransform _windowRoot;
        [SerializeField]
        private RectTransform _contentRoot;
        [SerializeField]
        private ContextMenuItem _itemPrefab;
        [SerializeField]
        private Cursor _cursor;
        [SerializeField]
        private Image _imageBg;
        [SerializeField]
        private MenuWindowParam[] _windowParams;
        private readonly int _animStateIn = Animator.StringToHash("in");
        private readonly int _animStateOut = Animator.StringToHash("out");
        private List<ContextMenuItem> _items = new List<ContextMenuItem>();
        private int _selectIndex;
        private VerticalLayoutGroup _verticalLayoutGroup;
        public Func<ContextMenuItem, bool> onClicked;
        public UnityAction<ContextMenuItem> onSelectChanged;
        private Param _param;
        private Vector3 _position = Vector3.zero;

        public ContextMenuItem selectItem { get => _items[_selectIndex]; }

        public void Awake()
        {
            var sceneName = _itemPrefab.gameObject.scene.name;
            if (!string.IsNullOrEmpty(sceneName))
            {
                _itemPrefab.transform.SetParent(transform, false);
                _itemPrefab.gameObject.SetActive(false);
            }

            _animator = GetComponentInChildren<Animator>();
            _cursor.gameObject.SetActive(false);
            _verticalLayoutGroup = _contentRoot.transform.GetComponent<VerticalLayoutGroup>();
        }

        public void Open(Param param)
        {
            StartCoroutine(OpOpen(param));
        }

        public IEnumerator OpOpen(Param param)
        {
            _param = param;
            _position = param.position;

            OnOpen(_prevWindowId);

            _cursor.transform.SetParent(transform, false);
            _cursor.SetActive(false);

            var windowParam = _windowParams[(int)param.windowType];
            _imageBg.sprite = windowParam._bgSprite;
            _verticalLayoutGroup.padding.left = 42;
            _items.Clear();

            var width = param.minItemWidth;
            var contextItems = _contentRoot.GetComponentsInChildren<ContextMenuItem>(true);

            for (int i=0; i<param.itemParams.Length; i++)
            {
                var itemParam = param.itemParams[i];
                var contextItem = i < contextItems.Length ? contextItems[i] : Instantiate(_itemPrefab);
                contextItem.transform.SetParent(_contentRoot, false);
                contextItem.SetActive(true);
                contextItem.Setup(itemParam, windowParam._fontColors, i, param.onSetupMessageArgs);
                _items.Add(contextItem);
            }

            for (int i=_items.Count; i<contextItems.Length; i++)
                _items[i].SetActive(false);

            yield return null;

            for (int i=0; i<_items.Count; i++)
            {
                var item = _items[i];
                float newWidth = item.GetWidth();

                if (width < newWidth)
                    width = newWidth;
            }

            for (int i=0; i<_items.Count; i++)
                _items[i].SetWidth(width);

            yield return null;

            _windowRoot.sizeDelta = (_contentRoot.transform as RectTransform).rect.size;
            _windowRoot.pivot = param.pivot;

            SetPosition(_position);

            // Done twice for some reason
            _cursor.gameObject.SetActive(true);
            _cursor.gameObject.SetActive(true);

            _cursor.Play(Cursor.animStateIn);
            _selectIndex = -1;

            SetSelectIndex(param.selectIndex < 0 ? Mathf.Clamp(-1, 0, param.selectIndex) : param.selectIndex, true);

            yield return OpPlayOpenWindowAnimation(_prevWindowId, null);

            Sequencer.update += OnUpdate;

            _input.inputEnabled = param.isInputEnable;
        }

        public void SetPosition(Vector2 position)
        {
            _position = position;
            _windowRoot.position = position;
        }

        public void Close(UnityAction<UIWindow> onClosed_)
        {
            Sequencer.Start(OpClose(onClosed_));
        }

        public IEnumerator OpClose(UnityAction<UIWindow> onClosed_)
        {
            Sequencer.update -= OnUpdate;

            yield return OpPlayCloseWindowAnimationAndWaiting(_prevWindowId);

            UIManager.Instance._ReleaseUIWindow(this);
            onClosed_?.Invoke(this);
        }

        private void OnUpdate(float deltaTime)
        {
            if (UIManager.Instance.GetCurrentUIWindow<UIWindow>() != this)
                return;

            if (_param.useCancel)
            {
                if (IsPushButton(UIManager.ButtonB))
                {
                    if (_param.seCancel != 0)
                        AudioManager.Instance.PlaySe(_param.seCancel, null);

                    SetSelectIndex(_param.cancelIndex < 0 ? _items.Count - 1 : _param.cancelIndex);
                    onClicked?.Invoke(_items[_selectIndex]);
                    Close(__ => onClosed?.Invoke(this));
                    return;
                }
            }

            if (IsPushButton(UIManager.ButtonA))
            {
                if (_param.seDecide != 0)
                    AudioManager.Instance.PlaySe(_param.seDecide, null);

                _cursor.Play(Cursor.animStateDecide);

                if (onClicked != null)
                {
                    if (onClicked.Invoke(_items[_selectIndex]))
                        Close(__ => onClosed?.Invoke(this));
                }

                return;
            }

            UpdateSelect(deltaTime);
        }

        private bool UpdateSelect(float deltaTime)
        {
            if (_items.Count == 0)
                return false;

            if (_param.useLoopAndRepeat)
            {
                if (IsPushButton(UIManager.StickLDown))
                    MoveIndex(1, true);
                else if (IsRepeatButton(UIManager.StickLDown))
                    MoveIndex(1, false);
                else if (IsPushButton(UIManager.StickLUp))
                    MoveIndex(-1, true);
                else if (IsRepeatButton(UIManager.StickLUp))
                    MoveIndex(-1, false);
                else
                    return false;
            }
            else
            {
                if (IsPushButton(UIManager.StickLDown))
                    MoveIndex(1, false);
                else if (IsPushButton(UIManager.StickLUp))
                    MoveIndex(-1, false);
                else
                    return false;
            }

            return true;
        }

        private void MoveIndex(int move, bool isLoop)
        {
            if (isLoop)
            {
                int index2 = _selectIndex + move + _items.Count;
                int index3 = _items.Count == 0 ? 0 : index2 / _items.Count;

                if (!SetSelectIndex(index2 - index3 * _items.Count))
                    return;
            }
            else
            {
                if (!SetSelectIndex(Mathf.Clamp(_selectIndex + move, 0, _items.Count-1)))
                    return;
            }

            AudioManager.Instance.PlaySe(AK.EVENTS.UI_COMMON_SELECT, null);
        }

        private bool SetSelectIndex(int selectIndex, bool isInitialize = false)
        {
            if (_selectIndex == selectIndex && !isInitialize)
                return false;

            _selectIndex = selectIndex;
            _cursor.transform.SetParent(_items[_selectIndex].transform, false);
            onSelectChanged?.Invoke(_items[_selectIndex]);
            return true;
        }

        [Serializable]
        private class MenuWindowParam
        {
	        public Sprite _bgSprite;
            public Color[] _fontColors;
        }

        public enum CursorType
        {
            Frame = 0,
            Arrow = 1,
        }

        public class Param
        {
	        public MenuWindowType windowType;
            public ContextMenuItem.Param[] itemParams;
            public Vector2 pivot;
            public Vector3 position;
            public int selectIndex;
            public float minItemWidth;
            public int cancelIndex;
            public bool useCancel;
            public bool useLoopAndRepeat;
            public bool isInputEnable;
            public UnityAction<int, ContextMenuItem.Param> onSetupMessageArgs;
            public uint seDecide;
            public uint seCancel;

            public Param()
            {
                pivot = Vector2.zero;
                minItemWidth = 122.0f;
                cancelIndex = -1;
                useCancel = true;
                useLoopAndRepeat = true;
                isInputEnable = true;
                position = Vector3.zero;
                seDecide = AK.EVENTS.UI_COMMON_DECIDE;
                seCancel = AK.EVENTS.UI_COMMON_DECIDE;
            }

            public enum MenuWindowType
            {
                Default = 0,
                Network = 1,
            }
        }
    }
}
