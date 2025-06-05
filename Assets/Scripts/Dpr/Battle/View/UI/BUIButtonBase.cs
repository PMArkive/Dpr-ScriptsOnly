using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Dpr.Battle.View.UI
{
    [RequireComponent(typeof(Image))]
    public abstract class BUIButtonBase<T> : UIBehaviour, IBattleUIButton<T>
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

        // TODO
        protected override void OnDestroy() { }

        // TODO
        public T SetOnSelected(Action onSelected) { return default(T); }

        // TODO
        public T SetOnSubmit(Action onSubmit) { return default(T); }

        // TODO
        public bool Submit() { return false; }

        // TODO
        protected virtual void OnChangeState(StateType type) { }

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