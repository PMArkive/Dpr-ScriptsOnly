using System;

namespace Dpr.Message
{
    [Serializable]
    public class TextParameter
    {
        public MessageEnumData.MsgLangId langId = MessageEnumData.MsgLangId.JPN;
        public float baseLineHeight;
        public float lineHeight;
        public FontSize[] absFontSizeArray;

        [Serializable]
        public class FontSize
        {
	        public MessageEnumData.UIFontSizeID fontSizeId = MessageEnumData.UIFontSizeID.M;
            public int fontSize;
        }
    }
}