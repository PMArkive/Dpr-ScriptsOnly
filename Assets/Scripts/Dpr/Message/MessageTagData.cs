namespace Dpr.Message
{
    public class MessageTagData
    {
        public MessageEnumData.TagPatternID patternId;
        public MessageEnumData.MsgLangId languageId;
        public MessageEnumData.GroupTagID tagGroupId;
        public int tagId;
        public string strValue;
        public int intValue;
        public float strWidth;
        public int index;
        public int tagParameter;
        public MessageEnumData.GenderID genderId;
        public int count;
        public MessageEnumData.QtyID refTargetQtyId;
        public MessageEnumData.ForceGrmID forceGrmId;
        public int forceArticle;
        public MessageTagDataModel refTagData;
        public string[] tagWords;
        public int attriGender;
        public int attriArticle;
        public int attriCountability;
        public int attriInitialSound;
        public bool isPlaceWord;
    }
}