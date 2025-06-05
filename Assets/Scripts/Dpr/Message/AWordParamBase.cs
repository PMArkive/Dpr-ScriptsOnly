namespace Dpr.Message
{
    public abstract class AWordParamBase
    {
        protected string strValue = string.Empty;
        protected MessageEnumData.MsgLangId languageId;
        protected int count = 1;
        protected int gender = -1;
        protected int initialSound = -1;
        protected int countablity = -1;
        protected int articlePresence = -1;
        protected float strWidth = -1.0f;
        protected bool bIsPokemonNickname;

        public virtual void SetWordParam(MessageTagDataModel tagDataModel)
        {
            tagDataModel.languageId = languageId;
            tagDataModel.SetWordParam(strValue, count, gender, initialSound, articlePresence, countablity, strWidth, bIsPokemonNickname);
        }
    }
}