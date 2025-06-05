namespace Dpr.Message
{
    public class StringWordParam : AWordParamBase
    {
        public StringWordParam(string str, MessageEnumData.MsgLangId languId, float strWidth = -1.0f)
        {
            strValue = str;
            this.strWidth = strWidth;
            languageId = languId;
            count = 1;
        }
    }
}