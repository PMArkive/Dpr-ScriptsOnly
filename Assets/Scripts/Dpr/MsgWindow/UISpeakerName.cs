using Dpr.Message;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.MsgWindow
{
    public class UISpeakerName
    {
        private TextMeshProUGUI speakerNameText;
        private GameObject speakerContent;

        public void Setup(GameObject speakerContent, MsgWindowDataModel dataModel, float speakerFrameWidthOffset, Sprite frameSpr)
        {
            this.speakerContent = speakerContent;

            float xSize = MessageDataConstants.ASPECT_SCALE.x * (MessageFontDataConstants.FONT_SIZE_TABLE[1] * 12.0f + speakerFrameWidthOffset);

            var speakerFrame = speakerContent.FindDeep("SpeakerFrame", true);
            var speakerFrameTF = speakerFrame.GetComponent<RectTransform>();
            speakerFrameTF.sizeDelta = new Vector2(xSize, speakerFrameTF.sizeDelta.y);

            var nameTextGO = speakerContent.FindDeep("NameText", true);
            speakerNameText = nameTextGO.GetComponent<TextMeshProUGUI>();
            speakerNameText.rectTransform.sizeDelta = new Vector2(xSize, speakerNameText.rectTransform.sizeDelta.y);
            speakerNameText.fontSize = MessageDataConstants.ASPECT_SCALE.x * MessageFontDataConstants.FONT_SIZE_TABLE[1];

            speakerFrame.GetComponent<Image>().sprite = frameSpr;

            FontManager.Instance.ChangeFontMaterial(speakerNameText, 0);
            if (speakerContent.activeSelf)
                speakerContent.SetActive(false);
        }

        public void SetSpeakerName(string speakerName)
        {
            speakerNameText.text = speakerName;
        }

        public void SetSpeakerNameActive(bool active)
        {
            if (speakerContent.activeSelf != active)
                speakerContent.SetActive(active);
        }

        public void SetSpeakerNameFontAsset(TMP_FontAsset fontAsset)
        {
            if (speakerNameText.font == fontAsset)
                return;

            speakerNameText.font = fontAsset;   
            speakerNameText.UpdateFontAsset();
        }
    }
}
