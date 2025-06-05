namespace Dpr.Message
{
    public class TrainerNickNameWordParam : AWordParamBase
    {
        public TrainerNickNameWordParam(string nickName, int genderId, MessageEnumData.MsgLangId languageId, MessageEnumData.AttriArticleID article = MessageEnumData.AttriArticleID.Article)
        {
            strValue = nickName;
            this.languageId = languageId;
            initialSound = 0;
            countablity = 0;
            count = 1;
            gender = genderId;
            articlePresence = (int)article;
        }
    }
}