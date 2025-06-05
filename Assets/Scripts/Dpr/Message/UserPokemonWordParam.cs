namespace Dpr.Message
{
    public class UserPokemonWordParam : AWordParamBase
    {
        public void SetPokemonParam(string nickName, int genderId, MessageEnumData.MsgLangId languageId, int initialSound = 0)
        {
            strValue = nickName;
            gender = genderId;
            this.initialSound = initialSound;
            this.languageId = languageId;
            count = 1;
            countablity = 0;
            articlePresence = 1;
            bIsPokemonNickname = true;
        }

        public void SetPokemonEggParam(string nickName, int gender, int initialSound, MessageEnumData.MsgLangId languageId)
        {
            strValue = nickName;
            this.languageId = languageId;
            this.gender = gender;
            this.initialSound = initialSound;
            countablity = 0;
            articlePresence = 0;
        }
    }
}