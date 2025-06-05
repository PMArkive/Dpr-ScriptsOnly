using System.Globalization;

namespace Dpr.Message
{
    public class MessageTagDataModel : MessageTagData
    {
        public void SetTagData(TagData tagData)
        {
            index = tagData.tagIndex;
            tagId = tagData.tagID;
            tagGroupId = tagData.groupID;
            patternId = tagData.tagPatternID;
            forceArticle = tagData.forceArticle;
            tagParameter = tagData.tagParameter;
            tagWords = tagData.tagWordArray;
            forceGrmId = tagData.forceGrmID;
        }

        public void SetWordParam(string strValue, int count, int attriGender, int attriInitialSound, int attriArticle, int attriCountability, float strWidth, bool bIsPokemonNickname)
        {
            this.strValue = strValue;
            this.count = count;
            this.attriCountability = attriCountability;
            this.attriInitialSound = attriInitialSound;
            this.attriGender = attriGender;
            this.attriArticle = attriArticle;
            this.strWidth = strWidth;

            var userLang = MessageManager.Instance.UserLanguageID;
            if (bIsPokemonNickname && MessageHelper.IsEFIGS(userLang) && MessageHelper.IsEggName(strValue))
            {
                this.attriArticle = 0;
                this.attriGender = MessageHelper.GetEggNameGender(userLang, attriGender);
                this.attriInitialSound = MessageHelper.GetEggNameInitialSound(userLang, attriInitialSound);
            }
        }

        public void SetWordParam(string strValue, int count, int attriGender, int attriInitialSound, int attriArticle, int attriCountability, float strWidth, MessageEnumData.ForceGrmID forceGrmID)
        {
            this.strValue = strValue;
            this.count = count;
            this.attriCountability = attriCountability;
            this.attriInitialSound = attriInitialSound;
            this.attriGender = attriGender;
            this.attriArticle = attriArticle;
            this.strWidth = strWidth;
            this.forceGrmId = forceGrmID;
        }

        public void SetPlaceWordParam(string strValue, int count, int attriGender, int attriInitialSound, int attriArticle, int attriCountability, float strWidth)
        {
            this.strValue = strValue;
            this.isPlaceWord = true;
            this.count = count;
            this.attriCountability = attriCountability;
            this.attriInitialSound = attriInitialSound;
            this.attriGender = attriGender;
            this.attriArticle = attriArticle;
            this.strWidth = strWidth;
        }

        public void SetGlossaryData(MessageGlossaryParseDataModel glossaryDataModel)
        {
            strValue = glossaryDataModel.GetName();

            if (glossaryDataModel.AttributeDataModel != null)
            {
                attriGender = glossaryDataModel.AttributeDataModel.gender;
                attriInitialSound = glossaryDataModel.AttributeDataModel.initialSound;
                attriArticle = glossaryDataModel.AttributeDataModel.articlePresence;
                attriCountability = glossaryDataModel.AttributeDataModel.countability;
            }
            else
            {
                MessageHelper.EmitLog("ItemGlossaryData : AttributeDataModel is null!!!!!!", UnityEngine.LogType.Error);
            }
        }

        public bool IsAssignmentTag { get => patternId == MessageEnumData.TagPatternID.Word || patternId == MessageEnumData.TagPatternID.Digit; }

        public string GetStrValue()
        {
            if (forceGrmId != MessageEnumData.ForceGrmID.InitialCap)
                return strValue;
            else
                return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(strValue);
        }

        public bool IsCountability()
        {
            if (forceGrmId == MessageEnumData.ForceGrmID.Plural)
                return true;

            return attriCountability == (int)MessageEnumData.AttriCountabilityID.Countable ||
                attriCountability == (int)MessageEnumData.AttriCountabilityID.AlwaysPlural;
        }

        public MessageEnumData.QtyID GetQtyId()
        {
            switch (forceGrmId)
            {
                case MessageEnumData.ForceGrmID.Singular:
                    return MessageEnumData.QtyID.Singular;

                case MessageEnumData.ForceGrmID.Plural:
                    return MessageEnumData.QtyID.Plural;

                default:
                    if (attriCountability == (int)MessageEnumData.AttriCountabilityID.AlwaysPlural)
                        return MessageEnumData.QtyID.Plural;
                    else
                        return MessageHelper.CheckQtyIdByCount(count, languageId);
            }
        }

        public MessageEnumData.GenderID GetGenderId()
        {
            if (forceGrmId == MessageEnumData.ForceGrmID.Masculine)
                return MessageEnumData.GenderID.Masculine;

            if (attriGender > -1)
                return (MessageEnumData.GenderID)attriGender;

            return genderId;
        }

        public bool IsUseArticle()
        {
            if (attriArticle == (int)MessageEnumData.AttriArticleID.NoArticle)
                return forceArticle == 1;
            else
                return true;
        }

        public bool IsUserInputWordTag()
        {
            if (tagGroupId == MessageEnumData.GroupTagID.Name)
            {
                switch ((MessageEnumData.NameID)tagId)
                {
                    case MessageEnumData.NameID.TrainerName:
                    case MessageEnumData.NameID.PokemonName:
                    case MessageEnumData.NameID.PokemonNickname:
                    case MessageEnumData.NameID.PokemonNicknameTwo:
                    case MessageEnumData.NameID.GroupName:
                    case MessageEnumData.NameID.PlayerNickname:
                    case MessageEnumData.NameID.BattleTeam:
                    case MessageEnumData.NameID.BoxName:
                    case MessageEnumData.NameID.TrainerNameUpperCase:
                    case MessageEnumData.NameID.PokemonNicknameUpperCase:
                        return true;

                    default:
                        return false;
                }
            }

            return false;
        }

        public bool IsNameWord()
        {
            if (tagGroupId == MessageEnumData.GroupTagID.Name)
            {
                switch ((MessageEnumData.NameID)tagId)
                {
                    case MessageEnumData.NameID.TrainerName:
                    case MessageEnumData.NameID.PokemonName:
                    case MessageEnumData.NameID.PokemonNickname:
                    case MessageEnumData.NameID.PokemonNicknameTwo:
                    case MessageEnumData.NameID.GroupName:
                    case MessageEnumData.NameID.PlayerNickname:
                    case MessageEnumData.NameID.TrainerNameUpperCase:
                    case MessageEnumData.NameID.PokemonNicknameUpperCase:
                        return true;

                    default:
                        return false;
                }
            }

            return false;
        }

        public MessageEnumData.ENInitialSoundID GetENInitialSoundId()
        {
            return (MessageEnumData.ENInitialSoundID)attriInitialSound;
        }

        public MessageEnumData.FRInitialSoundID GetFRInitialSoundId()
        {
            return (MessageEnumData.FRInitialSoundID)attriInitialSound;
        }

        public MessageEnumData.ITInitialSoundID GetITInitialSoundId()
        {
            return (MessageEnumData.ITInitialSoundID)attriInitialSound;
        }

        public MessageEnumData.ESInitialSoundID GetESInitialSoundId()
        {
            return (MessageEnumData.ESInitialSoundID)attriInitialSound;
        }

        public MessageEnumData.NameID GetNameTagId()
        {
            return (MessageEnumData.NameID)tagId;
        }
    }
}
