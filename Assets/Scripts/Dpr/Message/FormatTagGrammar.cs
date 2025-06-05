using System.Text;

namespace Dpr.Message
{
    public class FormatTagGrammar
    {
        public string FormatENTag(MessageEnumData.ENID enId, MessageTagDataModel tagDataModel)
        {
            if (tagDataModel == null)
            {
                // Log that was supposedly commented out
                //MessageHelper.EmitLog("tagDataModel is null", LogType.Error);
                return string.Empty;
            }

            switch (enId)
            {
                case MessageEnumData.ENID.DefArt:
                    return GetEN_DefArtWord(tagDataModel, false);

                case MessageEnumData.ENID.DefArtCap:
                    return GetEN_DefArtWord(tagDataModel, true);

                case MessageEnumData.ENID.IndArt:
                    return GetEN_IndArtWord(tagDataModel, false);

                case MessageEnumData.ENID.IndArtCap:
                    return GetEN_IndArtWord(tagDataModel, true);

                default:
                    return string.Empty;
            }
        }

        private string GetEN_DefArtWord(MessageTagDataModel tagDataModel, bool isCap)
        {
            if (!tagDataModel.IsUseArticle())
                return string.Empty;
            
            if (isCap) return "The ";
            else return "the ";
        }

        private string GetEN_IndArtWord(MessageTagDataModel tagDataModel, bool isCap)
        {
            if (!tagDataModel.IsUseArticle())
                return string.Empty;

            if (!tagDataModel.IsCountability())
                return string.Empty;

            if (tagDataModel.GetQtyId() == MessageEnumData.QtyID.Plural)
                return string.Empty;

            if (string.IsNullOrEmpty(tagDataModel.strValue))
                return string.Empty;

            if (CheckENInitialSound(tagDataModel.strValue, tagDataModel.GetENInitialSoundId()) == MessageEnumData.InitialSoundID.Vowel)
            {
                if (isCap) return "An ";
                else return "an ";
            }
            else
            {
                if (isCap) return "A ";
                else return "a ";
            }
        }

        private MessageEnumData.InitialSoundID CheckENInitialSound(string str, MessageEnumData.ENInitialSoundID initialSound)
        {
            switch (initialSound)
            {
                case MessageEnumData.ENInitialSoundID.Consonant:
                    return MessageEnumData.InitialSoundID.Consonant;

                case MessageEnumData.ENInitialSoundID.Vowel:
                    return MessageEnumData.InitialSoundID.Vowel;

                default:
                    char firstLetter = str.ToCharArray()[0];
                    for (int i = 0; i < MessageDataConstants.VOWEL_TABLE.Length; i++)
                    {
                        if (MessageDataConstants.VOWEL_TABLE[i] == firstLetter)
                            return MessageEnumData.InitialSoundID.Vowel;
                    }
                    return MessageEnumData.InitialSoundID.Consonant;
            }
        }

        public string FormatFRTag(MessageEnumData.FRID frId, MessageTagDataModel tagDataModel)
        {
            if (tagDataModel == null)
            {
                // Log that was supposedly commented out
                //MessageHelper.EmitLog("tagDataModel is null", LogType.Error);
                return string.Empty;
            }

            switch (frId)
            {
                case MessageEnumData.FRID.DefArt:
                    return GetFRDefArtWord(tagDataModel, false);

                case MessageEnumData.FRID.DefArtCap:
                    return GetFRDefArtWord(tagDataModel, true);

                case MessageEnumData.FRID.IndArt:
                    return GetFRIndArtWord(tagDataModel, false);

                case MessageEnumData.FRID.IndArtCap:
                    return GetFRIndArtWord(tagDataModel, true);

                case MessageEnumData.FRID.A_DefArt:
                    return GetFR_A_DefArtWord(tagDataModel, false);

                case MessageEnumData.FRID.A_DefArtCap:
                    return GetFR_A_DefArtWord(tagDataModel, true);

                case MessageEnumData.FRID.De_DefArt:
                    return GetFR_De_DefArtWord(tagDataModel, false);

                case MessageEnumData.FRID.De_DefArtCap:
                    return GetFR_De_DefArtWord(tagDataModel, true);

                case MessageEnumData.FRID.De:
                    return GetDeWord(tagDataModel, false);

                case MessageEnumData.FRID.DeCap:
                    return GetDeWord(tagDataModel, true);

                case MessageEnumData.FRID.Que:
                    return GetQueWord(tagDataModel, false);

                case MessageEnumData.FRID.QueCap:
                    return GetQueWord(tagDataModel, true);

                default:
                    // Log that was supposedly commented out, string.Format result is ignored otherwise
                    //MessageHelper.EmitLog(string.Format("FRID Not Use Id : {0}", frId), LogType.Error);
                    return string.Empty;
            }
        }

        public string GetElisionStr(MessageTagDataModel tagDataModel, string[] tagWords)
        {
            if (CheckFRInitialsVowel(tagDataModel) == MessageEnumData.InitialSoundID.Vowel)
                return tagWords[1];
            else
                return tagWords[0];
        }

        private string GetFRDefArtWord(MessageTagDataModel tagDataModel, bool isCap)
        {
            if (!tagDataModel.IsUseArticle())
                return string.Empty;

            if (tagDataModel.IsCountability() && tagDataModel.GetQtyId() == MessageEnumData.QtyID.Plural)
            {
                if (isCap) return "Les ";
                else return "les ";
            }
            else if (CheckFRInitialsVowel(tagDataModel) == MessageEnumData.InitialSoundID.Vowel)
            {
                if (isCap) return "L'";
                else return "l'";
            }
            else if (tagDataModel.GetGenderId() == MessageEnumData.GenderID.Masculine)
            {
                if (isCap) return "Le ";
                else return "le ";
            }
            else
            {
                if (isCap) return "La ";
                else return "la ";
            }
        }

        private string GetFRIndArtWord(MessageTagDataModel tagDataModel, bool isCap)
        {
            if (!tagDataModel.IsUseArticle())
                return string.Empty;

            if (!tagDataModel.IsCountability())
                return string.Empty;

            if (tagDataModel.GetQtyId() == MessageEnumData.QtyID.Plural)
            {
                if (isCap) return "Des ";
                else return "des ";
            }
            else if (tagDataModel.GetGenderId() == MessageEnumData.GenderID.Masculine)
            {
                if (isCap) return "Un ";
                else return "un ";
            }
            else
            {
                if (isCap) return "Une ";
                else return "une ";
            }
        }

        private string GetFR_A_DefArtWord(MessageTagDataModel tagDataModel, bool isCap)
        {
            if (!tagDataModel.IsCountability())
            {
                if (isCap) return "À ";
                else return "à ";
            }
            else if (tagDataModel.GetQtyId() == MessageEnumData.QtyID.Plural)
            {
                if (isCap) return "Aux ";
                else return "aux ";
            }
            else if (CheckFRInitialsVowel(tagDataModel) == MessageEnumData.InitialSoundID.Vowel)
            {
                if (isCap) return "À l'";
                else return "à l'";
            }
            else if (tagDataModel.GetGenderId() == MessageEnumData.GenderID.Masculine)
            {
                if (isCap) return "Au ";
                else return "au ";
            }
            else
            {
                if (isCap) return "À la ";
                else return "à la ";
            }
        }

        private string GetFR_De_DefArtWord(MessageTagDataModel tagDataModel, bool isCap)
        {
            if (tagDataModel.IsCountability() && tagDataModel.GetQtyId() == MessageEnumData.QtyID.Plural)
            {
                if (isCap) return "Des ";
                else return "des ";
            }
            else if (CheckFRInitialsVowel(tagDataModel) == MessageEnumData.InitialSoundID.Vowel)
            {
                if (isCap) return "De l'";
                else return "de l'";
            }
            else if (tagDataModel.GetGenderId() == MessageEnumData.GenderID.Masculine)
            {
                if (isCap) return "Du ";
                else return "du ";
            }
            else
            {
                if (isCap) return "De la ";
                else return "de la ";
            }
        }

        private string GetDeWord(MessageTagDataModel tagDataModel, bool isCap)
        {
            if (CheckFRInitialsVowel(tagDataModel) == MessageEnumData.InitialSoundID.Vowel)
            {
                if (isCap) return "D'";
                else return "d'";
            }
            else
            {
                if (isCap) return "De ";
                else return "de ";
            }
        }

        private string GetQueWord(MessageTagDataModel tagDataModel, bool isCap)
        {
            if (CheckFRInitialsVowel(tagDataModel) == MessageEnumData.InitialSoundID.Vowel)
            {
                if (isCap) return "Qu'";
                else return "qu'";
            }
            else
            {
                if (isCap) return "Que ";
                else return "que ";
            }
        }

        private MessageEnumData.InitialSoundID CheckFRInitialsVowel(MessageTagDataModel tagDataModel)
        {
            switch (tagDataModel.GetFRInitialSoundId())
            {
                case MessageEnumData.FRInitialSoundID.NoElision:
                    return MessageEnumData.InitialSoundID.Consonant;

                case MessageEnumData.FRInitialSoundID.YesElision:
                    return MessageEnumData.InitialSoundID.Vowel;

                default:
                    var str = tagDataModel.strValue;
                    if (string.IsNullOrEmpty(str) || str.Length <= 0)
                        return MessageEnumData.InitialSoundID.Consonant;

                    char firstLetter = str.ToCharArray()[0];
                    if (MessageHelper.IsFRVowel(firstLetter))
                    {
                        if (!IsNickName(tagDataModel.tagGroupId, tagDataModel.tagId))
                            return MessageEnumData.InitialSoundID.Vowel;

                        switch (str)
                        {
                            case "Ouisticram":
                            case "Okéoké":
                            case "Ouistempo":
                                return MessageEnumData.InitialSoundID.Consonant;

                            default:
                                return MessageEnumData.InitialSoundID.Vowel;
                        }
                    }
                    else
                    {
                        if (firstLetter == 'h' || firstLetter == 'H')
                        {
                            if (!IsNickName(tagDataModel.tagGroupId, tagDataModel.tagId))
                                return MessageEnumData.InitialSoundID.Consonant;

                            switch (str)
                            {
                                case "Herbizarre":
                                case "Hypnomade":
                                case "Hypotrempe":
                                case "Hypocéan":
                                case "Héliatronc":
                                case "Hyporoi":
                                case "Hélédelle":
                                case "Hippopotas":
                                case "Hippodocus":
                                case "Hexagel":
                                case "Hélionceau":
                                case "Hastacuda":
                                case "Hexadron":
                                case "Hydragon":
                                    return MessageEnumData.InitialSoundID.Vowel;

                                // This seems like an error in the actual code where this case and the default should be inverted
                                case "Hydragla":
                                    return MessageEnumData.InitialSoundID.Consonant;

                                default:
                                    return MessageEnumData.InitialSoundID.Vowel;
                            }
                        }
                        else if (str[0] == 'y' || str[0] == 'Y')
                        {
                            if (str.Length < 2)
                                return MessageEnumData.InitialSoundID.Vowel;
                            else if (!MessageHelper.IsFRVowel(str[1]))
                                return MessageEnumData.InitialSoundID.Vowel;
                            else
                                return MessageEnumData.InitialSoundID.Consonant;
                        }
                        else
                        {
                            return MessageEnumData.InitialSoundID.Consonant;
                        }
                    }
            }
        }

        private bool IsNickName(MessageEnumData.GroupTagID groupTagId, int tagId)
        {
            if (groupTagId != MessageEnumData.GroupTagID.Name)
                return false;

            switch ((MessageEnumData.NameID)tagId)
            {
                case MessageEnumData.NameID.PokemonName:
                case MessageEnumData.NameID.PokemonNickname:
                case MessageEnumData.NameID.PokemonNicknameTwo:
                case MessageEnumData.NameID.PokemonNicknameUpperCase:
                    return true;

                default:
                    return false;
            }
        }

        public string FormatITTag(MessageEnumData.ITID itId, MessageTagDataModel tagDataModel)
        {
            if (tagDataModel == null)
            {
                // Log that was supposedly commented out
                //MessageHelper.EmitLog("tagDataModel is null", LogType.Error);
                return string.Empty;
            }

            switch (itId)
            {
                case MessageEnumData.ITID.DefArt:
                    return GetIT_DefArtWord(tagDataModel, false);

                case MessageEnumData.ITID.DefArtCap:
                    return GetIT_DefArtWord(tagDataModel, true);

                case MessageEnumData.ITID.IndArt:
                    return GetIT_IndArtWord(tagDataModel, false);

                case MessageEnumData.ITID.IndArtCap:
                    return GetIT_IndArtWord(tagDataModel, true);

                case MessageEnumData.ITID.Di_DefArt:
                    return GetDi_DefArtWord(tagDataModel, false);

                case MessageEnumData.ITID.Di_DefArtCap:
                    return GetDi_DefArtWord(tagDataModel, true);

                case MessageEnumData.ITID.Su_DefArt:
                    return GetSu_DefArtWord(tagDataModel, false);

                case MessageEnumData.ITID.Su_DefArtCap:
                    return GetSu_DefArtWord(tagDataModel, true);

                case MessageEnumData.ITID.A_DefArt:
                    return GetIT_A_DefArtWord(tagDataModel, false);

                case MessageEnumData.ITID.A_DefArtCap:
                    return GetIT_A_DefArtWord(tagDataModel, true);

                case MessageEnumData.ITID.In_DefArt:
                    return GetIn_DefArtWord(tagDataModel, false);

                case MessageEnumData.ITID.In_DefArtCap:
                    return GetIn_DefArtWord(tagDataModel, true);

                case MessageEnumData.ITID.Ed:
                    return GetEdWord(tagDataModel, false);

                case MessageEnumData.ITID.EdCap:
                    return GetEdWord(tagDataModel, true);

                case MessageEnumData.ITID.Ad:
                    return GetAdWord(tagDataModel, false);

                case MessageEnumData.ITID.AdCap:
                    return GetAdWord(tagDataModel, true);

                default:
                    // Log that was supposedly commented out, string is presumed
                    //MessageHelper.EmitLog(string.Format("ITID Not Use Id : {0}", itId), LogType.Error);
                    return string.Empty;
            }
        }

        public string GetDateITStr(MessageTagDataModel tagDataModel, string[] tagWords)
        {
            switch (tagDataModel.count)
            {
                case 0:
                case 8:
                case 11:
                    return tagWords[0];

                default:
                    return tagWords[1];
            }
        }

        private string GetIT_DefArtWord(MessageTagDataModel tagDataModel, bool isCap)
        {
            if (!tagDataModel.IsUseArticle())
                return string.Empty;

            var initialSound = CheckITInitialsVowel(tagDataModel.strValue, tagDataModel.GetITInitialSoundId());

            if (!tagDataModel.IsCountability() && tagDataModel.GetQtyId() == MessageEnumData.QtyID.Plural)
            {
                if (initialSound != MessageEnumData.InitialSoundID.Consonant2 && initialSound != MessageEnumData.InitialSoundID.Consonant)
                {
                    if (isCap) return "L'";
                    else return "l'";
                }
                else if (tagDataModel.GetGenderId() == MessageEnumData.GenderID.Feminine)
                {
                    if (isCap) return "La ";
                    else return "la ";
                }
                else if (initialSound == MessageEnumData.InitialSoundID.Consonant)
                {
                    if (isCap) return "Il ";
                    else return "il ";
                }
                else
                {
                    if (isCap) return "Lo ";
                    else return "lo ";
                }
            }
            else if (tagDataModel.GetGenderId() != MessageEnumData.GenderID.Masculine)
            {
                if (isCap) return "Le ";
                else return "le ";
            }
            else if (initialSound == MessageEnumData.InitialSoundID.Consonant)
            {
                if (isCap) return "I ";
                else return "i ";
            }
            else
            {
                if (isCap) return "Gli ";
                else return "gli ";
            }
        }

        private string GetIT_IndArtWord(MessageTagDataModel tagDataModel, bool isCap)
        {
            if (!tagDataModel.IsUseArticle())
                return string.Empty;

            var initialSound = CheckITInitialsVowel(tagDataModel.strValue, tagDataModel.GetITInitialSoundId());

            if (!tagDataModel.IsCountability())
            {
                if (initialSound == MessageEnumData.InitialSoundID.Vowel ||
                    initialSound == MessageEnumData.InitialSoundID.VowelA ||
                    initialSound == MessageEnumData.InitialSoundID.VowelE)
                {
                    if (isCap) return "Dell'";
                    else return "dell'";
                }
                else if (tagDataModel.GetGenderId() != MessageEnumData.GenderID.Masculine)
                {
                    if (isCap) return "Della ";
                    else return "della ";
                }
                else if (initialSound == MessageEnumData.InitialSoundID.Consonant)
                {
                    if (isCap) return "Del ";
                    else return "del ";
                }
                else
                {
                    if (isCap) return "Dello ";
                    else return "dello ";
                }
            }
            else if (tagDataModel.GetQtyId() == MessageEnumData.QtyID.Plural)
            {
                if (tagDataModel.GetGenderId() != MessageEnumData.GenderID.Masculine)
                {
                    if (isCap) return "Delle ";
                    else return "delle ";
                }
                else if (initialSound == MessageEnumData.InitialSoundID.Consonant)
                {
                    if (isCap) return "Dei ";
                    else return "dei ";
                }
                else
                {
                    if (isCap) return "Degli ";
                    else return "degli ";
                }
            }
            else if (tagDataModel.GetGenderId() == MessageEnumData.GenderID.Masculine)
            {
                if (initialSound == MessageEnumData.InitialSoundID.Consonant2)
                {
                    if (isCap) return "Uno ";
                    else return "uno ";
                }
                else
                {
                    if (isCap) return "Un ";
                    else return "un ";
                }
            }
            else
            {
                switch (initialSound)
                {
                    case MessageEnumData.InitialSoundID.Consonant2:
                    case MessageEnumData.InitialSoundID.Consonant:
                        if (isCap) return "Una ";
                        else return "una ";

                    default:
                        if (isCap) return "Un'";
                        else return "un'";
                }
            }
        }

        private string GetDi_DefArtWord(MessageTagDataModel tagDataModel, bool isCap)
        {
            var initialSound = CheckITInitialsVowel(tagDataModel.strValue, tagDataModel.GetITInitialSoundId());

            if (!tagDataModel.IsUseArticle())
            {
                if (isCap) return "Di ";
                else return "di ";
            }
            else if (!tagDataModel.IsCountability() || tagDataModel.GetQtyId() != MessageEnumData.QtyID.Plural)
            {
                switch (initialSound)
                {
                    case MessageEnumData.InitialSoundID.Consonant2:
                    case MessageEnumData.InitialSoundID.Consonant:
                        if (tagDataModel.GetGenderId() == MessageEnumData.GenderID.Feminine)
                        {
                            if (isCap) return "Della ";
                            else return "della ";
                        }
                        else if (initialSound == MessageEnumData.InitialSoundID.Consonant)
                        {
                            if (isCap) return "Del ";
                            else return "del ";
                        }
                        else
                        {
                            if (isCap) return "Dello ";
                            else return "dello ";
                        }

                    default:
                        if (isCap) return "Dell'";
                        else return "dell'";
                }
            }
            else if (tagDataModel.GetGenderId() == MessageEnumData.GenderID.Masculine)
            {
                if (initialSound == MessageEnumData.InitialSoundID.Consonant)
                {
                    if (isCap) return "Dei ";
                    else return "dei ";
                }
                else
                {
                    if (isCap) return "Degli ";
                    else return "degli ";
                }
            }
            else
            {
                if (isCap) return "Delle ";
                else return "delle ";
            }
        }

        private string GetSu_DefArtWord(MessageTagDataModel tagDataModel, bool isCap)
        {
            var initialSound = CheckITInitialsVowel(tagDataModel.strValue, tagDataModel.GetITInitialSoundId());

            if (!tagDataModel.IsUseArticle())
            {
                if (isCap) return "Su ";
                else return "su ";
            }
            else if (!tagDataModel.IsCountability() || tagDataModel.GetQtyId() != MessageEnumData.QtyID.Plural)
            {
                switch (initialSound)
                {
                    case MessageEnumData.InitialSoundID.Consonant2:
                    case MessageEnumData.InitialSoundID.Consonant:
                        if (tagDataModel.GetGenderId() == MessageEnumData.GenderID.Feminine)
                        {
                            if (isCap) return "Sulla ";
                            else return "sulla ";
                        }
                        else if (initialSound == MessageEnumData.InitialSoundID.Consonant)
                        {
                            if (isCap) return "Sul ";
                            else return "sul ";
                        }
                        else
                        {
                            if (isCap) return "Sullo ";
                            else return "sullo ";
                        }

                    default:
                        if (isCap) return "Sull'";
                        else return "sull'";
                }
            }
            else if (tagDataModel.GetGenderId() == MessageEnumData.GenderID.Masculine)
            {
                if (initialSound == MessageEnumData.InitialSoundID.Consonant)
                {
                    if (isCap) return "Sui ";
                    else return "sui ";
                }
                else
                {
                    if (isCap) return "Sugli ";
                    else return "sugli ";
                }
            }
            else
            {
                if (isCap) return "Sulle ";
                else return "sulle ";
            }
        }

        private string GetIT_A_DefArtWord(MessageTagDataModel tagDataModel, bool isCap)
        {
            var initialSound = CheckITInitialsVowel(tagDataModel.strValue, tagDataModel.GetITInitialSoundId());

            if (!tagDataModel.IsUseArticle())
            {
                if (isCap) return "A ";
                else return "a ";
            }
            else if (!tagDataModel.IsCountability() || tagDataModel.GetQtyId() != MessageEnumData.QtyID.Plural)
            {
                switch (initialSound)
                {
                    case MessageEnumData.InitialSoundID.Consonant2:
                    case MessageEnumData.InitialSoundID.Consonant:
                        if (tagDataModel.GetGenderId() == MessageEnumData.GenderID.Feminine)
                        {
                            if (isCap) return "Alla ";
                            else return "alla ";
                        }
                        else if (initialSound == MessageEnumData.InitialSoundID.Consonant)
                        {
                            if (isCap) return "Al ";
                            else return "al ";
                        }
                        else
                        {
                            if (isCap) return "Allo ";
                            else return "allo ";
                        }

                    default:
                        if (isCap) return "All'";
                        else return "all'";
                }
            }
            else if (tagDataModel.GetGenderId() == MessageEnumData.GenderID.Masculine)
            {
                if (initialSound == MessageEnumData.InitialSoundID.Consonant)
                {
                    if (isCap) return "Ai ";
                    else return "ai ";
                }
                else
                {
                    if (isCap) return "Agli ";
                    else return "agli ";
                }
            }
            else
            {
                if (isCap) return "Alle ";
                else return "alle ";
            }
        }

        private string GetIn_DefArtWord(MessageTagDataModel tagDataModel, bool isCap)
        {
            var initialSound = CheckITInitialsVowel(tagDataModel.strValue, tagDataModel.GetITInitialSoundId());

            if (!tagDataModel.IsUseArticle())
            {
                if (isCap) return "In ";
                else return "in ";
            }
            else if (!tagDataModel.IsCountability() || tagDataModel.GetQtyId() != MessageEnumData.QtyID.Plural)
            {
                switch (initialSound)
                {
                    case MessageEnumData.InitialSoundID.Consonant2:
                    case MessageEnumData.InitialSoundID.Consonant:
                        if (tagDataModel.GetGenderId() == MessageEnumData.GenderID.Feminine)
                        {
                            if (isCap) return "Nella ";
                            else return "nella ";
                        }
                        else if (initialSound == MessageEnumData.InitialSoundID.Consonant)
                        {
                            if (isCap) return "Nel ";
                            else return "nel ";
                        }
                        else
                        {
                            if (isCap) return "Nello ";
                            else return "nello ";
                        }

                    default:
                        if (isCap) return "Nell'";
                        else return "nell'";
                }
            }
            else if (tagDataModel.GetGenderId() == MessageEnumData.GenderID.Masculine)
            {
                if (initialSound == MessageEnumData.InitialSoundID.Consonant)
                {
                    if (isCap) return "Nei ";
                    else return "nei ";
                }
                else
                {
                    if (isCap) return "Negli ";
                    else return "negli ";
                }
            }
            else
            {
                if (isCap) return "Nelle ";
                else return "nelle ";
            }
        }

        private string GetEdWord(MessageTagDataModel tagDataModel, bool isCap)
        {
            var initialSound = CheckITInitialsVowel(tagDataModel.strValue, tagDataModel.GetITInitialSoundId());

            if (initialSound == MessageEnumData.InitialSoundID.VowelE)
            {
                if (isCap) return "Ed ";
                else return "ed ";
            }
            else
            {
                if (isCap) return "E ";
                else return "e ";
            }
        }

        private string GetAdWord(MessageTagDataModel tagDataModel, bool isCap)
        {
            var initialSound = CheckITInitialsVowel(tagDataModel.strValue, tagDataModel.GetITInitialSoundId());

            if (initialSound == MessageEnumData.InitialSoundID.VowelA)
            {
                if (isCap) return "Ad ";
                else return "ad ";
            }
            else
            {
                if (isCap) return "A ";
                else return "a ";
            }
        }

        private MessageEnumData.InitialSoundID CheckITInitialsVowel(string str, MessageEnumData.ITInitialSoundID initialSound)
        {
            if (string.IsNullOrEmpty(str))
                return MessageEnumData.InitialSoundID.Consonant;

            switch (initialSound)
            {
                case MessageEnumData.ITInitialSoundID.ConsonantOthers:
                    return MessageEnumData.InitialSoundID.Consonant;

                case MessageEnumData.ITInitialSoundID.S_Consonant:
                    return MessageEnumData.InitialSoundID.Consonant2;

                case MessageEnumData.ITInitialSoundID.Vowel:
                    return MessageEnumData.InitialSoundID.Vowel;

                default:
                    char firstChar = str.ToCharArray()[0];

                    if (firstChar == 'a' || firstChar == 'A')
                        return MessageEnumData.InitialSoundID.VowelA;

                    for (int i=0; i<MessageDataConstants.VOWEL_E_IT_TABLE.Length; i++)
                        if (firstChar == MessageDataConstants.VOWEL_E_IT_TABLE[i])
                            return MessageEnumData.InitialSoundID.VowelE;

                    // First letter check only
                    switch (firstChar)
                    {
                        case 'I':
                        case 'i':
                        case 'O':
                        case 'o':
                        case 'U':
                        case 'u':
                            return MessageEnumData.InitialSoundID.Vowel;

                        case 'X':
                        case 'x':
                        case 'Z':
                        case 'z':
                            return MessageEnumData.InitialSoundID.Consonant2;
                    }

                    if (str.ToCharArray().Length < 2)
                        return MessageEnumData.InitialSoundID.Consonant;

                    char secondChar = str.ToCharArray()[1];

                    // First letters that require a check on the second letter
                    switch (firstChar)
                    {
                        case 'G':
                        case 'g':
                            if (secondChar == 'n' || secondChar == 'N') return MessageEnumData.InitialSoundID.Consonant2;
                            else return MessageEnumData.InitialSoundID.Consonant;

                        case 'H':
                        case 'h':
                            return MessageEnumData.InitialSoundID.Vowel;

                        case 'P':
                        case 'p':
                            switch (secondChar)
                            {
                                case 'N':
                                case 'n':
                                case 'S':
                                case 's':
                                    return MessageEnumData.InitialSoundID.Consonant2;

                                default:
                                    return MessageEnumData.InitialSoundID.Consonant;
                            }

                        case 'S':
                        case 's':
                            switch (secondChar)
                            {
                                case 'A':
                                case 'a':
                                case 'E':
                                case 'e':
                                case 'I':
                                case 'i':
                                case 'O':
                                case 'o':
                                case 'U':
                                case 'u':
                                case 'Y':
                                case 'y':
                                case 'È':
                                case 'è':
                                case 'É':
                                case 'é':
                                    return MessageEnumData.InitialSoundID.Consonant;

                                default:
                                    return MessageEnumData.InitialSoundID.Consonant2;
                            }

                        case 'T':
                        case 't':
                            switch (secondChar)
                            {
                                case 'S':
                                case 's':
                                    return MessageEnumData.InitialSoundID.Consonant2;

                                default:
                                    return MessageEnumData.InitialSoundID.Consonant;
                            }

                        case 'Y':
                        case 'y':
                            switch (secondChar)
                            {
                                case 'A':
                                case 'a':
                                case 'E':
                                case 'e':
                                case 'I':
                                case 'i':
                                case 'O':
                                case 'o':
                                case 'U':
                                case 'u':
                                case 'Y':
                                case 'y':
                                case 'È':
                                case 'è':
                                case 'É':
                                case 'é':
                                    return MessageEnumData.InitialSoundID.Consonant2;

                                default:
                                    return MessageEnumData.InitialSoundID.Consonant;
                            }

                        default:
                            return MessageEnumData.InitialSoundID.Consonant;
                    }
            }
        }

        public string FormatDETag(MessageEnumData.DEID deId, MessageTagDataModel tagDataModel)
        {
            if (tagDataModel == null)
            {
                // Log that was supposedly commented out
                //MessageHelper.EmitLog("tagDataModel is null", LogType.Error);
                return string.Empty;
            }

            switch (deId)
            {
                case MessageEnumData.DEID.DefArtNom:
                    return GetDE_DefArtNomWord(tagDataModel, false);

                case MessageEnumData.DEID.DefArtNomCap:
                    return GetDE_DefArtNomWord(tagDataModel, true);

                case MessageEnumData.DEID.IndArtNom:
                    return GetDE_IndArtNomWord(tagDataModel, false);

                case MessageEnumData.DEID.IndArtNomCap:
                    return GetDE_IndArtNomWord(tagDataModel, true);

                case MessageEnumData.DEID.DefArtAcc:
                    return GetDefArtAccWord(tagDataModel, false);

                case MessageEnumData.DEID.DefArtAccCap:
                    return GetDefArtAccWord(tagDataModel, true);

                case MessageEnumData.DEID.IndArtAcc:
                    return GetIndArtAccWord(tagDataModel, false);

                case MessageEnumData.DEID.IndArtAccCap:
                    return GetIndArtAccWord(tagDataModel, true);

                default:
                    // Log that was supposedly commented out, string.Format result is ignored otherwise
                    //MessageHelper.EmitLog(string.Format("DEID Not Use Id : {0}", deId), LogType.Error);
                    return string.Empty;
            }
        }

        private string GetDE_DefArtNomWord(MessageTagDataModel tagDataModel, bool isCap)
        {
            if (!tagDataModel.IsUseArticle())
                return string.Empty;

            if (tagDataModel.IsCountability() && tagDataModel.GetQtyId() == MessageEnumData.QtyID.Plural)
            {
                if (isCap) return "Die ";
                else return "die ";
            }

            switch (tagDataModel.GetGenderId())
            {
                case MessageEnumData.GenderID.Masculine:
                    if (isCap) return "Der ";
                    else return "der ";

                case MessageEnumData.GenderID.Feminine:
                    if (isCap) return "Die ";
                    else return "die ";

                default:
                    if (isCap) return "Das ";
                    else return "das ";
            }
        }

        private string GetDE_IndArtNomWord(MessageTagDataModel tagDataModel, bool isCap)
        {
            if (!tagDataModel.IsUseArticle())
                return string.Empty;

            if (!tagDataModel.IsCountability() || tagDataModel.GetQtyId() == MessageEnumData.QtyID.Plural)
                return string.Empty;

            switch (tagDataModel.GetGenderId())
            {
                case MessageEnumData.GenderID.Feminine:
                    if (isCap) return "Eine ";
                    else return "eine ";

                default:
                    if (isCap) return "Ein ";
                    else return "ein ";
            }
        }

        private string GetDefArtAccWord(MessageTagDataModel tagDataModel, bool isCap)
        {
            if (!tagDataModel.IsUseArticle())
                return string.Empty;

            if (tagDataModel.IsCountability() && tagDataModel.GetQtyId() == MessageEnumData.QtyID.Plural)
            {
                if (isCap) return "Die ";
                else return "die ";
            }

            switch (tagDataModel.GetGenderId())
            {
                case MessageEnumData.GenderID.Masculine:
                    if (isCap) return "Den ";
                    else return "den ";

                case MessageEnumData.GenderID.Feminine:
                    if (isCap) return "Die ";
                    else return "die ";

                default:
                    if (isCap) return "Das ";
                    else return "das ";
            }
        }

        private string GetIndArtAccWord(MessageTagDataModel tagDataModel, bool isCap)
        {
            if (!tagDataModel.IsUseArticle())
                return string.Empty;

            if (!tagDataModel.IsCountability() || tagDataModel.GetQtyId() == MessageEnumData.QtyID.Plural)
                return string.Empty;

            switch (tagDataModel.GetGenderId())
            {
                case MessageEnumData.GenderID.Masculine:
                    if (isCap) return "Einen ";
                    else return "einen ";

                case MessageEnumData.GenderID.Feminine:
                    if (isCap) return "Eine ";
                    else return "eine ";

                default:
                    if (isCap) return "Ein ";
                    else return "ein ";
            }
        }

        public string FormatESTag(MessageEnumData.ESID esId, MessageTagDataModel tagDataModel)
        {
            if (tagDataModel == null)
            {
                // Log that was supposedly commented out
                //MessageHelper.EmitLog("tagDataModel is null", LogType.Error);
                return string.Empty;
            }

            switch (esId)
            {
                case MessageEnumData.ESID.DefArt:
                    return GetES_DefArtWord(tagDataModel, false);

                case MessageEnumData.ESID.DefArtCap:
                    return GetES_DefArtWord(tagDataModel, true);

                case MessageEnumData.ESID.IndArt:
                    return GetES_IndArtWord(tagDataModel, false);

                case MessageEnumData.ESID.IndArtCap:
                    return GetES_IndArtWord(tagDataModel, true);

                case MessageEnumData.ESID.De_DefArt:
                    return GetES_De_DefArtWord(tagDataModel, false);

                case MessageEnumData.ESID.De_DefArtCap:
                    return GetES_De_DefArtWord(tagDataModel, true);

                case MessageEnumData.ESID.A_DefArt:
                    return GetES_A_DefArtWord(tagDataModel, false);

                case MessageEnumData.ESID.A_DefArtCap:
                    return GetES_A_DefArtWord(tagDataModel, true);

                case MessageEnumData.ESID.DefArt_TrTypeAndName:
                    return GetDefArt_TrTypeAndNameWord(tagDataModel, false);

                case MessageEnumData.ESID.DefArtCap_TrTypeAndName:
                    return GetDefArt_TrTypeAndNameWord(tagDataModel, true);

                case MessageEnumData.ESID.A_DefArt_TrTypeAndName:
                    return GetA_DefArt_TrTypeAndNameWord(tagDataModel);

                case MessageEnumData.ESID.De_DefArt_TrTypeAndName:
                    return GetDe_DefArt_TrTypeAndNameWord(tagDataModel);

                case MessageEnumData.ESID.y_e:
                    return Gety_eWord(tagDataModel, false);

                case MessageEnumData.ESID.Y_E:
                    return Gety_eWord(tagDataModel, true);

                case MessageEnumData.ESID.o_u:
                    return Geto_uWord(tagDataModel, false);

                case MessageEnumData.ESID.O_U:
                    return Geto_uWord(tagDataModel, true);

                default:
                    // Log that was supposedly commented out, string.Format result is ignored otherwise
                    //MessageHelper.EmitLog(string.Format("ESID Not Use Id : {0}", esId), LogType.Error);
                    return string.Empty;
            }
        }

        private string GetES_DefArtWord(MessageTagDataModel tagDataModel, bool isCap)
        {
            if (!tagDataModel.IsUseArticle())
                return string.Empty;

            if (!tagDataModel.IsCountability() || tagDataModel.GetQtyId() == MessageEnumData.QtyID.Singular)
            {
                if (tagDataModel.GetGenderId() == MessageEnumData.GenderID.Masculine ||
                    tagDataModel.GetESInitialSoundId() == MessageEnumData.ESInitialSoundID.TonicaA)
                {
                    if (isCap) return "El ";
                    else return "el ";
                }
                else
                {
                    if (isCap) return "La ";
                    else return "la ";
                }
            }
            else
            {
                if (tagDataModel.GetGenderId() == MessageEnumData.GenderID.Masculine)
                {
                    if (isCap) return "Los ";
                    else return "los ";
                }
                else
                {
                    if (isCap) return "Las ";
                    else return "las ";
                }
            }
        }

        private string GetES_IndArtWord(MessageTagDataModel tagDataModel, bool isCap)
        {
            if (!tagDataModel.IsUseArticle())
                return string.Empty;

            if (!tagDataModel.IsCountability())
                return string.Empty;

            if (tagDataModel.GetQtyId() == MessageEnumData.QtyID.Plural)
            {
                if (tagDataModel.GetGenderId() == MessageEnumData.GenderID.Masculine)
                {
                    if (isCap) return "Unos ";
                    else return "unos ";
                }
                else
                {
                    if (isCap) return "Unas ";
                    else return "unas ";
                }
            }
            else
            {
                if (tagDataModel.GetGenderId() == MessageEnumData.GenderID.Masculine ||
                    tagDataModel.GetESInitialSoundId() == MessageEnumData.ESInitialSoundID.TonicaA)
                {
                    if (isCap) return "Un ";
                    else return "un ";
                }
                else
                {
                    if (isCap) return "Una ";
                    else return "una ";
                }
            }
        }

        private string GetES_De_DefArtWord(MessageTagDataModel tagDataModel, bool isCap)
        {
            if (!tagDataModel.IsCountability() || tagDataModel.GetQtyId() == MessageEnumData.QtyID.Singular)
            {
                if (tagDataModel.GetGenderId() == MessageEnumData.GenderID.Masculine ||
                    tagDataModel.GetESInitialSoundId() == MessageEnumData.ESInitialSoundID.TonicaA)
                {
                    if (isCap) return "Del ";
                    else return "del ";
                }
                else
                {
                    if (isCap) return "De la ";
                    else return "de la ";
                }
            }
            else
            {
                if (tagDataModel.GetGenderId() == MessageEnumData.GenderID.Masculine)
                {
                    if (isCap) return "De los ";
                    else return "de los ";
                }
                else
                {
                    if (isCap) return "De las ";
                    else return "de las ";
                }
            }
        }

        private string GetES_A_DefArtWord(MessageTagDataModel tagDataModel, bool isCap)
        {
            if (!tagDataModel.IsCountability() || tagDataModel.GetQtyId() == MessageEnumData.QtyID.Singular)
            {
                if (tagDataModel.GetGenderId() == MessageEnumData.GenderID.Masculine ||
                    tagDataModel.GetESInitialSoundId() == MessageEnumData.ESInitialSoundID.TonicaA)
                {
                    if (isCap) return "Al ";
                    else return "al ";
                }
                else
                {
                    if (isCap) return "A la ";
                    else return "a la ";
                }
            }
            else
            {
                if (tagDataModel.GetGenderId() == MessageEnumData.GenderID.Masculine)
                {
                    if (isCap) return "A los ";
                    else return "a los ";
                }
                else
                {
                    if (isCap) return "A las ";
                    else return "a las ";
                }
            }
        }

        private string GetDefArt_TrTypeAndNameWord(MessageTagDataModel tagDataModel, bool isCap)
        {
            if (!tagDataModel.IsUseArticle())
                return string.Empty;

            if (!tagDataModel.IsCountability())
                return string.Empty;

            if (tagDataModel.GetQtyId() == MessageEnumData.QtyID.Plural)
            {
                if (tagDataModel.GetGenderId() == MessageEnumData.GenderID.Masculine)
                {
                    if (isCap) return "Los ";
                    else return "los ";
                }
                else
                {
                    if (isCap) return "Las ";
                    else return "las ";
                }
            }
            else
            {
                if (tagDataModel.GetGenderId() == MessageEnumData.GenderID.Masculine ||
                    tagDataModel.GetESInitialSoundId() == MessageEnumData.ESInitialSoundID.TonicaA)
                {
                    if (isCap) return "El ";
                    else return "el ";
                }
                else
                {
                    if (isCap) return "La ";
                    else return "la ";
                }
            }
        }

        private string GetA_DefArt_TrTypeAndNameWord(MessageTagDataModel tagDataModel)
        {
            if (!tagDataModel.IsCountability())
                return "a ";

            if (tagDataModel.GetQtyId() == MessageEnumData.QtyID.Plural)
            {
                switch (tagDataModel.GetGenderId())
                {
                    case MessageEnumData.GenderID.Masculine:
                        return "a los ";

                    default:
                        return "a las ";
                }
            }
            else
            {
                if (tagDataModel.GetGenderId() == MessageEnumData.GenderID.Masculine ||
                    tagDataModel.GetESInitialSoundId() == MessageEnumData.ESInitialSoundID.TonicaA)
                {
                    return "al ";
                }
                else
                {
                    return "a la ";
                }
            }
        }

        private string GetDe_DefArt_TrTypeAndNameWord(MessageTagDataModel tagDataModel)
        {
            if (!tagDataModel.IsCountability())
                return "de ";

            if (tagDataModel.GetQtyId() == MessageEnumData.QtyID.Plural)
            {
                switch (tagDataModel.GetGenderId())
                {
                    case MessageEnumData.GenderID.Masculine:
                        return "de los ";

                    default:
                        return "de las ";
                }
            }
            else
            {
                if (tagDataModel.GetGenderId() == MessageEnumData.GenderID.Masculine ||
                    tagDataModel.GetESInitialSoundId() == MessageEnumData.ESInitialSoundID.TonicaA)
                {
                    return "del ";
                }
                else
                {
                    return "de la ";
                }
            }
        }

        private string Gety_eWord(MessageTagDataModel tagDataModel, bool isCap)
        {
            if (string.IsNullOrEmpty(tagDataModel.strValue))
                return string.Empty;

            switch (tagDataModel.GetESInitialSoundId())
            {
                case MessageEnumData.ESInitialSoundID.AutoDetected:
                    char firstChar = tagDataModel.strValue.ToCharArray()[0];

                    for (int i=0; i<MessageDataConstants.VOWEL_TABLE.Length; i++)
                    {
                        if (firstChar == MessageDataConstants.VOWEL_TABLE[i])
                        {
                            if (isCap) return "E ";
                            else return "e ";
                        }
                    }

                    if (isCap) return "Y ";
                    else return "y ";

                case MessageEnumData.ESInitialSoundID.Cacophony_y:
                    if (isCap) return "E ";
                    else return "e ";

                default:
                    if (isCap) return "Y ";
                    else return "y ";
            }
        }

        private string Geto_uWord(MessageTagDataModel tagDataModel, bool isCap)
        {
            switch (tagDataModel.GetESInitialSoundId())
            {
                case MessageEnumData.ESInitialSoundID.Cacophony_o:
                    if (isCap) return "U ";
                    else return "u ";

                default:
                    if (isCap) return "O ";
                    else return "o ";
            }
        }

        public string FormatKorTag(MessageEnumData.KorID korId, MessageTagDataModel tagDataModel)
        {
            if (tagDataModel == null)
                return string.Empty;

            if (korId == MessageEnumData.KorID.Particle)
                return GetParticleStr(tagDataModel.tagParameter, tagDataModel.refTagData);

            return string.Empty;
        }

        private string GetParticleStr(int tagParameter, MessageTagDataModel tagDataModel)
        {
            int particlePatternCode;

            switch (tagDataModel.patternId)
            {
                case MessageEnumData.TagPatternID.Word:
                    particlePatternCode = GetParticlePatternCode(GetLastString(tagDataModel.strValue));
                    break;

                default:
                    particlePatternCode = GetParticlePatternCodeByDigit(tagDataModel.count);
                    break;
            }

            // Log that was supposedly commented out, string.Format result is ignored otherwise
            //MessageHelper.EmitLog(string.Format("Particle : Patchum {0} - code : {1}", tagParameter, particlePatternCode), LogType.Error);

            if (particlePatternCode < -1)
                return string.Empty;

            switch (tagParameter)
            {
                // Eun (은) / Neun (는), topic/subject particle
                case 1:
                    if (particlePatternCode > 0) return "은";
                    else return "는";
                // Eul (을) / Reul (를), object particle for accusative case
                case 2:
                    if (particlePatternCode > 0) return "을";
                    else return "를";
                // I (이) / Ga (가), identifier or subject particle for nominative case
                case 3:
                    if (particlePatternCode > 0) return "이";
                    else return "가";
                // Gwa (과) / Wa (와), "and" or "with/as with"
                case 4:
                    if (particlePatternCode > 0) return "과";
                    else return "와";
                // Eu[ro] (으[로]) / [Ro] ([로]), instrumental case
                case 5:
                    if (particlePatternCode > 0 && particlePatternCode != 8) return "으";
                    else return string.Empty;
                // I[yeo] (이[여]) / [Yeo] ([여]), vocative marker (exclamation)
                case 6:
                    if (particlePatternCode > 0) return "이";
                    else return string.Empty;
                // A (아) / Ya (야), vocative marker
                case 7:
                    if (particlePatternCode > 0) return "아";
                    else return "야";
                default:
                    return string.Empty;
            }
        }

        private string GetLastString(string str)
        {
            if (string.IsNullOrEmpty(str))
                return string.Empty;

            int startIndex = str.Length - 1;

            if (startIndex == 0)
                return str;

            return str.Substring(startIndex, 1);
        }

        private int GetParticlePatternCode(string lastStr)
        {
            byte[] unicodeBytes = Encoding.Unicode.GetBytes(lastStr.ToCharArray());

            if (unicodeBytes.Length != 2)
                return -1;

            if (MessageHelper.IsDigitWordByUnicode(unicodeBytes))
            {
                if (int.TryParse(lastStr, out int digit))
                    return GetParticlePatternCodeByDigit(digit);

                // Log that was supposedly commented out, concatenation result is ignored otherwise
                //MessageHelper.EmitLog("Can not parse int : " + lastStr, LogType.Error);

                return -1;
            }
            else
            {
                // Gets the tail consonant of the hangul character
                int charCode = unicodeBytes[0] + (256 * unicodeBytes[1]);
                return (charCode - 44032) % 28;
            }
        }

        private int GetParticlePatternCodeByDigit(int count)
        {
            int trimmedCount = count % 10;

            if (trimmedCount >= MessageDataConstants.NUM_PATCHIM_CODE_ARRAY.Length)
            {
                // Log that was supposedly commented out, string.Format result is ignored otherwise
                //MessageHelper.EmitLog(string.Format("Patchim Digit : OnesPlace {0}", trimmedCount), LogType.Error);
                return 0;
            }

            return MessageDataConstants.NUM_PATCHIM_CODE_ARRAY[trimmedCount];
        }

        private enum PatchumId : int
        {
            None = 0,
            Ha = 1,
            Wo = 2,
            Ga = 3,
            To = 4,
            Ni = 5,
            Ya = 6,
            San = 7,
        }
    }
}