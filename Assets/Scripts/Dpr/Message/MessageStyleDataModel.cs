using UnityEngine;

namespace Dpr.Message
{
    public class MessageStyleDataModel : MessageStyleData
    {
        public int styleIndex;
        public Color fontColor = Color.black;
        public int fontSize;
        public int maxTextWidth;

        public Color GetFontColor { get => fontColor; }

        public MessageStyleDataModel(int styleIndex, MessageStyleData formatData)
        {
            this.styleIndex = styleIndex;
            strNum = formatData.strNum;
            fontSizeId = formatData.fontSizeId;
            fontColorIndex = formatData.fontColorIndex;
            fontSize = MessageFontDataConstants.FONT_SIZE_TABLE[fontSizeId];

            if (strNum < 8)
            {
                maxTextWidth = (strNum + 1) * fontSize;
            }
            else
            {
                maxTextWidth = (strNum + 2) * fontSize;
                if (fontColorIndex > -1)
                    fontColor = MessageFontDataConstants.FONT_COLOR_ARRAY[fontColorIndex].GetColor();
            }
        }
    }
}