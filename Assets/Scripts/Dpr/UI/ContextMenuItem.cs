using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Dpr.UI
{
    public class ContextMenuItem : MonoBehaviour, IUIButton
    {
        [SerializeField]
        private UIText _text;
        private Color[] _fontColors;
        private Param _param;
        private int _index;

        public Param param { get => _param; }
        public int index { get => _index; }

        public void Setup(Param param, Color[] fontColors, int index, UnityAction<int, Param> onSetupMessageArgs)
        {
            _fontColors = fontColors;
            _param = param;

            var menuData = UIManager.Instance.GetContextMenuData(param.menuId);
            if (string.IsNullOrEmpty(param.text))
            {
                var messageFile = param.messageFile ?? menuData.MessageFile;
                var messageIndex = param.messageIndex;

                onSetupMessageArgs?.Invoke(index, param);

                if (messageIndex < 0)
                    _text.SetupMessage(messageFile, param.messageLabel ?? menuData.MessageLabel);
                else
                    _text.SetupMessage(messageFile, messageIndex);
            }
            else
            {
                _text.text = param.text;
            }

            _text.color = _fontColors[(int)param.colorType];
            var fitter = _text.gameObject.AddComponent<ContentSizeFitter>();
            fitter.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
        }

        public float GetWidth()
        {
            var tf = GetRectTransform();
            return tf.sizeDelta.x + tf.localPosition.x + tf.localPosition.x;
        }

        public void SetWidth(float width)
        {
            var tf = GetRectTransform();
            tf.sizeDelta = new Vector2(width, tf.sizeDelta.y);
        }

        public void Select(bool enabled)
        {
            // Empty
        }

        public virtual bool GetActive()
        {
            return gameObject.activeSelf;
        }

        public virtual void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }

        public virtual int GetIndex()
        {
            return _index;
        }

        public virtual void SetIndex(int index)
        {
            _index = index;
        }

        public virtual RectTransform GetRectTransform()
        {
            return transform as RectTransform;
        }

        public virtual void Select()
        {
            // Empty
        }

        public virtual void UnSelect()
        {
            // Empty
        }

        public class Param
        {
	        public const ContextMenuID ContextMenuIdUser = (ContextMenuID)10000;

            public ContextMenuID menuId;
            public string messageFile;
            public string messageLabel;
            public int messageIndex = -1;
            public string text;
            public ColorType colorType;

            public enum ColorType : int
            {
                Default = 0,
                FieldWaza = 1,
            }
        }
    }
}