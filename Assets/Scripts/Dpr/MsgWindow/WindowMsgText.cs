using Dpr.Message;
using TMPro;
using UnityEngine;

namespace Dpr.MsgWindow
{
    public class WindowMsgText : MonoBehaviour
    {
        private TextMeshProUGUI text;
        private RectTransform textRect;
        private Color defaultColor;

        public float TextHeight { get => textRect.sizeDelta.y; }
        public float FontSize { get => text.fontSize; }

        public void Initialize()
        {
            textRect = GetComponent<RectTransform>();
            text = GetComponent<TextMeshProUGUI>();
            defaultColor = text.color;
            FontManager.Instance.ChangeFontMaterial(text, 0);
        }

        public void ResetText()
        {
            text.text = string.Empty;
        }

        public void ResetColor()
        {
            text.color = defaultColor;
        }

        public void SetPositionYByIndex(int index, float lineSpace)
        {
            float y = -((textRect.sizeDelta.y + lineSpace) * index);
            textRect.anchoredPosition = new Vector2(textRect.anchoredPosition.x, y);
            text.text = string.Empty;
        }

        public void SetTextEnable(bool enabled)
        {
            if (text.enabled != enabled)
                text.enabled = enabled;
        }

        public void SetTextWidth(float width)
        {
            if (textRect.sizeDelta.x != width)
                textRect.sizeDelta = new Vector2(width, textRect.sizeDelta.y);
        }

        public void SetFontSize(float fontSize)
        {
            if (text.fontSize != fontSize)
                text.fontSize = fontSize;
        }

        public void SetFontAsset(TMP_FontAsset newFontAsset, VerticalAlignmentOptions vAlignment)
        {
            if (text.font != newFontAsset)
            {
                text.font = newFontAsset;
                text.UpdateFontAsset();
                text.verticalAlignment = vAlignment;
                CreateStrFontTexture("");
            }
        }

        public void SetText(string messageStr)
        {
            text.text = messageStr;
        }

        public void SetTextColor(Color textColor)
        {
            text.color = textColor;
        }

        public void CreateStrFontTexture(string messageStr)
        {
            text.text = messageStr;
            text.ForceMeshUpdate(true, false);
        }
    }
}