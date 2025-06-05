namespace Dpr.Message
{
    public class LabelTagDataModel
    {
        public int index = -1;
        public MessageEnumData.TagPatternID patternID;
        public MessageEnumData.GroupTagID tagGroupID;
        public MessageEnumData.MsgLangId langID;
        public MessageEnumData.ForceGrmID forceGrmID;
        public ushort tagID;
        public string strValue;
        public int tagParameter;
        public string[] tagWords = new string[0];
        public int forceArticle;

        public bool IsWordTag
        {
            get
            {
                switch (patternID)
                {
                    case MessageEnumData.TagPatternID.Word:
                    case MessageEnumData.TagPatternID.Digit:
                    case MessageEnumData.TagPatternID.GrammarWord:
                    case MessageEnumData.TagPatternID.SpriteFont:
                        return true;

                    default:
                        return false;
                }
            }
        }
    }
}