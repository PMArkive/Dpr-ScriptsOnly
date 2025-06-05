using Dpr.Message;
using TMPro;
using UnityEngine;

namespace Dpr.MsgWindow
{
    public class MsgTextContainer : MonoBehaviour
    {
        [SerializeField]
        private RectTransform contentRect;
        [SerializeField]
        private WindowMsgText[] uiTextArray;
        [SerializeField]
        private WindowMsgText sizeTagText;
        [SerializeField]
        private TMP_FontAsset emptyFont;
        private WaitTimer msgTimer = new WaitTimer();
        private Vector2 startPosition;
        private float textHight;
        private float scrollTextDuration;
        private float textLinePaddingOffset;
        private int topTextObjIndex;
        private int defaultTextNum;

        public void Initialize(float scrollTextDuration, float textLinePaddingOffset)
        {
            this.scrollTextDuration = scrollTextDuration;
            this.textLinePaddingOffset = textLinePaddingOffset;

            float contentScaleX = contentRect.localScale.x * MessageDataConstants.ASPECT_SCALE.x;
            float contentScaleY = contentRect.localScale.y * MessageDataConstants.ASPECT_SCALE.y;
            contentRect.localScale = new Vector3(contentScaleX, contentScaleY, contentRect.localScale.z);

            var sizeTagTF = this.FindDeep("SizeTagMessage", true).GetComponent<RectTransform>();
            sizeTagTF.localScale = new Vector3(contentScaleX, contentScaleY, contentRect.localScale.z);

            topTextObjIndex = 0;
            defaultTextNum = uiTextArray.Length;
            msgTimer.SetLimitTime(scrollTextDuration);
            if (defaultTextNum < 1)
            {
                MessageHelper.EmitLog("defaultTextNum is 0. Please confirm inspector : [uiTextArray]", LogType.Log);
                return;
            }

            for (int i=0; i<uiTextArray.Length; i++)
            {
                uiTextArray[i].Initialize();
                uiTextArray[i].SetPositionYByIndex(i, textLinePaddingOffset);
            }

            sizeTagText.Initialize();
            textHight = uiTextArray[topTextObjIndex].TextHeight * MessageDataConstants.ASPECT_SCALE.y;
        }

        public void ResetUIText()
        {
            topTextObjIndex = 0;
            contentRect.anchoredPosition = Vector2.zero;

            for (int i=0; i<uiTextArray.Length; i++)
            {
                uiTextArray[i].ResetText();
                uiTextArray[i].SetPositionYByIndex(i, textLinePaddingOffset);
            }

            sizeTagText.ResetText();
        }

        public void Clear()
        {
            topTextObjIndex = 0;
            contentRect.anchoredPosition = Vector2.zero;

            for (int i=0; i<uiTextArray.Length; i++)
            {
                uiTextArray[i].ResetText();
            }

            sizeTagText.ResetText();
        }

        public void ResetTextColor()
        {
            for (int i=0; i<uiTextArray.Length; i++)
                uiTextArray[i].ResetColor();
        }

        public void OnFinalize()
        {
            Clear();
        }

        public float FontSize { get => uiTextArray[0].FontSize; }

        public void SetTextEnabled(bool hasSizetag)
        {
            sizeTagText.SetTextEnable(hasSizetag);
            
            for (int i=0; i<uiTextArray.Length; i++)
                uiTextArray[i].SetTextEnable(!hasSizetag);
        }

        public void SetUseFontAsset(TMP_FontAsset useFontAsset)
        {
            for (int i=0; i<uiTextArray.Length; i++)
                uiTextArray[i].SetFontAsset(useFontAsset, VerticalAlignmentOptions.Capline);

            sizeTagText.SetFontAsset(useFontAsset, VerticalAlignmentOptions.Middle);
        }

        public void ChangeUnknownFont()
        {
            for (int i=0; i<uiTextArray.Length; i++)
                uiTextArray[i].SetFontAsset(emptyFont, VerticalAlignmentOptions.Geometry);
        }

        public void SetTextParam(float fontSize, float width)
        {
            for (int i=0; i<uiTextArray.Length; i++)
            {
                uiTextArray[i].SetTextWidth(width);
                uiTextArray[i].SetFontSize(fontSize);
            }

            sizeTagText.SetTextWidth(width);
            sizeTagText.SetFontSize(fontSize);
        }

        public void SetFontSize(float fontSize)
        {
            for (int i=0; i<uiTextArray.Length; i++)
                uiTextArray[i].SetFontSize(fontSize);

            sizeTagText.SetFontSize(fontSize);
        }

        public void SetTextColor(Color newColor)
        {
            for (int i=0; i<uiTextArray.Length; i++)
                uiTextArray[i].SetTextColor(newColor);
        }

        public void SetMessage(int textIndex, string message, bool hasSizetag)
        {
            if (hasSizetag)
            {
                sizeTagText.SetText(message);
            }
            else
            {
                var index = textIndex - (uiTextArray.Length == 0 ? 0 : (textIndex / uiTextArray.Length)) * uiTextArray.Length;
                uiTextArray[index].SetText(message);
            }
        }

        private int LastTextIndex { get => topTextObjIndex + uiTextArray.Length; }

        public void StartMovePositionY()
        {
            msgTimer.ResetTimer();
            startPosition = contentRect.anchoredPosition;
        }

        public bool MovingPosition(float deltaTime)
        {
            bool isFinish = msgTimer.IsFinishWait(deltaTime);
            contentRect.anchoredPosition = startPosition + new Vector2(0.0f, msgTimer.Ratio * textHight);

            if (!isFinish)
                return true;

            var index = topTextObjIndex - (uiTextArray.Length == 0 ? 0 : (topTextObjIndex / uiTextArray.Length)) * uiTextArray.Length;
            uiTextArray[index].SetPositionYByIndex(LastTextIndex, textLinePaddingOffset);
            topTextObjIndex++;
            return false;
        }
    }
}