using AK;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Dpr.Battle.View.UI
{
    [RequireComponent(typeof(Image))]
    public abstract class BUIButtonBase<T> : UIBehaviour, IBattleUIButton<T> where T : BUIButtonBase<T>
    {
        private static readonly Color DisableColor = new Color(0.8f, 0.8f, 0.8f);

        [SerializeField]
        protected Image _backgroundImage;
        [SerializeField]
        protected Image _foregroundImage;
        [SerializeField]
        protected TextMeshProUGUI _text;
        [SerializeField]
        protected int _index = -1;
        [SerializeField]
        protected TransitionType _transition;
        [SerializeField]
        protected StateType _state;
        protected bool _isSelected;
        protected bool _isEnabele = true;
        private RectTransform _cachedRectTransform;
        protected Action _onSelected;
        protected Action _onSubmit;

        public bool IsSelected { get => _isSelected; set => OnChangeState(value ? StateType.Selected : StateType.None); }
        public RectTransform rectTransform { get => this.GetComponentThis(ref _cachedRectTransform); }
        public StateType State { get => _state; }
        public int Index { get => _index; set => _index = value; }
        public string Text
        {
            get
            {
                if (_text != null && _text.text != null)
                    return _text.text;

                return string.Empty;
            }
            set
            {
                if (_text != null)
                    _text.text = value;
            }
        }

        protected override void OnDestroy()
        {
            _cachedRectTransform = null;
            _onSelected = null;
            base.OnDestroy();
        }

        public T SetOnSelected(Action onSelected)
        {
            _onSelected = onSelected;
            return (T)this;
        }

        public T SetOnSubmit(Action onSubmit)
        {
            _onSubmit = onSubmit;
            return (T)this;
        }

        public bool Submit()
        {
            if (_isEnabele)
            {
                BattleViewCore.Instance.UISystem.PlaySe(EVENTS.UI_COMMON_DECIDE);
                BattleViewCore.Instance.UISystem.CursorFrame.Play(Dpr.UI.Cursor.animStateDecide);
                _onSubmit?.Invoke();
                return true;
            }
            else
            {
                BattleViewCore.Instance.UISystem.PlaySe(EVENTS.UI_COMMON_BEEP);
                return false;
            }
        }

        protected virtual void OnChangeState(StateType type)
        {
            if (_index == -1)
                return;

            _state = type;
            _isSelected = type == StateType.Selected;

            if (type != StateType.Selected)
                return;

            _onSelected?.Invoke();

            var cursor = BattleViewCore.Instance.UISystem.CursorFrame;
            cursor.transform.SetParent(transform);
            ((RectTransform)cursor.transform).sizeDelta = Vector3.zero;
            cursor.transform.localPosition = Vector3.zero;
            ((RectTransform)cursor.transform).anchoredPosition = Vector2.zero;
        }

        public enum TransitionType : int
        {
            Scale = 0,
            Sprite = 1,
        }

        public enum StateType : int
        {
            None = 0,
            Selected = 1,
        }
    }
}