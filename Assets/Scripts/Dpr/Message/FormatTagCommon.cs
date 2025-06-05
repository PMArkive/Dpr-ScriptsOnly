using System;
using System.Globalization;
using System.Text;

namespace Dpr.Message
{
    public class FormatTagCommon
    {
        private StringBuilder strBuilder = new StringBuilder();
        private char charComma;
        private char charPreriod;
        private char charHarfSpace;
        private char charQuaterSpace;

        public void Initialize()
        {
            charComma = Convert.ToChar(MessageDataConstants.COMMA_CODE);
            charPreriod = Convert.ToChar(MessageDataConstants.PERIOD_CODE);
            charHarfSpace = Convert.ToChar(MessageDataConstants.HALF_SPACE_CODE);
            charQuaterSpace = Convert.ToChar(MessageDataConstants.QUATER_SPACE_CODE);
        }

        public string FormatNameTag(MessageTagDataModel tagDataModel, MessageEnumData.MsgLangId languageId)
        {
            switch ((MessageEnumData.NameID)tagDataModel.tagId)
            {
                case MessageEnumData.NameID.TrainerNameField:
                case MessageEnumData.NameID.TrainerNameUpperCase:
                case MessageEnumData.NameID.PokemonNicknameUpperCase:
                    return GetNameUpperCase(tagDataModel, languageId);

                default:
                    return tagDataModel.GetStrValue();
            }
        }

        private string GetNameUpperCase(MessageTagDataModel tagDataModel, MessageEnumData.MsgLangId languageId)
        {
            switch (languageId)
            {
                case MessageEnumData.MsgLangId.USA:
                case MessageEnumData.MsgLangId.FRA:
                case MessageEnumData.MsgLangId.ITA:
                case MessageEnumData.MsgLangId.DEU:
                case MessageEnumData.MsgLangId.ESP:
                    return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(tagDataModel.GetStrValue());

                default:
                    return tagDataModel.GetStrValue();
            }
        }

        public string FormatDigitTag(MessageEnumData.DigitID digitTagId, int tagParameter, int count, string strValue, MessageEnumData.MsgLangId languageId)
        {
            if (!string.IsNullOrEmpty(strValue))
                return strValue;

            if (count < 1)
                return "0";

            switch (digitTagId)
            {
                case MessageEnumData.DigitID.OneDigit:
                case MessageEnumData.DigitID.TwoDigits:
                case MessageEnumData.DigitID.ThreeDigits:
                    return ConvertValueToString(count);

                case MessageEnumData.DigitID.FourDigits:
                case MessageEnumData.DigitID.FiveDigits:
                case MessageEnumData.DigitID.SixDigits:
                case MessageEnumData.DigitID.SevenDigits:
                case MessageEnumData.DigitID.EightDigits:
                case MessageEnumData.DigitID.NineDigits:
                case MessageEnumData.DigitID.TenDigits:
                    return ConvertValueToDigitGroupingStr(tagParameter, count, languageId);

                default:
                    // Log that was supposedly commented out, string.Format result is ignored otherwise
                    //MessageHelper.EmitLog(string.Format("TagId {0} : Not Found : {1} : LanguageId {2}", digitTagId, strValue, languageId), LogType.Warning);
                    return string.Empty;
            }
        }

        private string ConvertValueToString(int count)
        {
            return count.ToString();
        }

        private string ConvertValueToDigitGroupingStr(int tagParameter, int value, MessageEnumData.MsgLangId languageId)
        {
            switch ((MessageEnumData.DigitTagParamID)tagParameter)
            {
                case MessageEnumData.DigitTagParamID.None:
                    return ConvertValueToString(value);

                case MessageEnumData.DigitTagParamID.Default:
                    return ConvertValueToStrByLanguage(value, languageId);

                case MessageEnumData.DigitTagParamID.Comma:
                    return GetNumStrGroupingByChar(charComma, value, languageId);

                case MessageEnumData.DigitTagParamID.Period:
                    return GetNumStrGroupingByChar(charPreriod, value, languageId);

                case MessageEnumData.DigitTagParamID.HalfSpace:
                    return GetNumStrGroupingByChar(charHarfSpace, value, languageId);

                case MessageEnumData.DigitTagParamID.QuaterSpace:
                    return GetNumStrGroupingByChar(charQuaterSpace, value, languageId);

                default:
                    return string.Empty;
            }
        }

        private string ConvertValueToStrByLanguage(int value, MessageEnumData.MsgLangId languageId)
        {
            switch (languageId)
            {
                case MessageEnumData.MsgLangId.JPN:
                case MessageEnumData.MsgLangId.USA:
                case MessageEnumData.MsgLangId.KOR:
                case MessageEnumData.MsgLangId.SCH:
                case MessageEnumData.MsgLangId.TCH:
                    return GetNumStrGroupingByChar(charComma, value, languageId);

                case MessageEnumData.MsgLangId.FRA:
                    return GetNumStrGroupingByChar(charHarfSpace, value, languageId);

                case MessageEnumData.MsgLangId.ITA:
                    return GetNumStrGroupingByChar(charPreriod, value, languageId);

                case MessageEnumData.MsgLangId.DEU:
                case MessageEnumData.MsgLangId.ESP:
                    return GetNumStrGroupingByChar(charQuaterSpace, value, languageId);

                default:
                    return string.Empty;
            }
        }

        private string GetNumStrGroupingByChar(char c, int value, MessageEnumData.MsgLangId languageId)
        {
            strBuilder.Clear();

            if (CheckIsFourDigitInESP(value, languageId))
            {
                strBuilder.Append(value);
                return strBuilder.ToString();
            }

            if (value > 0)
            {
                int i = 0;
                while (true)
                {
                    i++;
                    strBuilder.Insert(0, value % 10);
                    if (value < 10)
                        break;

                    value /= 10;
                    if (i > 0 && i % 3 == 0)
                        strBuilder.Insert(0, c);
                }
            }

            return strBuilder.ToString();
        }

        private bool CheckIsFourDigitInESP(int value, MessageEnumData.MsgLangId languageId)
        {
            if (languageId == MessageEnumData.MsgLangId.ESP && value < MessageDataConstants.CHECK_FOUR_DIGIT_VALUE)
                return true;

            return false;
        }

        public string GetGenderStr(int refValue, MessageTagDataModel refTagData, string[] words)
        {
            MessageEnumData.GenderID gender;

            if (refValue == MessageDataConstants.REF_USER_GENDER_VALUE)
                gender = PlayerWork.playerSex ? MessageEnumData.GenderID.Masculine : MessageEnumData.GenderID.Feminine;
            else if (refValue == MessageDataConstants.REF_TV_GENDER_VALUE)
                gender = TvWork.CurrentStrDataGenderId;
            else if (refTagData == null)
                gender = MessageEnumData.GenderID.Masculine;
            else
                gender = refTagData.GetGenderId();

            if ((int)gender >= words.Length)
                return string.Empty;

            switch (gender)
            {
                case MessageEnumData.GenderID.Masculine:
                    return words[0];

                case MessageEnumData.GenderID.Feminine:
                    return words[1];

                case MessageEnumData.GenderID.Neuter:
                    return words[2];

                default:
                    // Log that was supposedly commented out, string.Format result is ignored otherwise
                    //MessageHelper.EmitLog(string.Format("Gender ID {0} : Not Found", gender), LogType.Warning);
                    return string.Empty;
            }
        }

        public string GetQtyStr(MessageTagDataModel refTagData, string[] words, MessageEnumData.MsgLangId langID)
        {
            MessageEnumData.QtyID qty;

            if (refTagData == null)
            {
                var partyCount = PlayerWork.playerParty.GetMemberCount();
                if (partyCount == 0)
                    qty = langID == MessageEnumData.MsgLangId.FRA ? MessageEnumData.QtyID.Singular : MessageEnumData.QtyID.Plural;
                else if (partyCount == 1)
                    qty = MessageEnumData.QtyID.Singular;
                else
                    qty = MessageEnumData.QtyID.Plural;
            }
            else
            {
                qty = refTagData.GetQtyId();
            }

            if ((int)qty >= words.Length)
                return string.Empty;

            switch (qty)
            {
                case MessageEnumData.QtyID.Singular:
                    return words[0];

                case MessageEnumData.QtyID.Plural:
                    return words[1];

                default:
                    // Log that was supposedly commented out, string.Format result is ignored otherwise
                    //MessageHelper.EmitLog(string.Format("GetQtyStr - QtyId : {0}", qty), LogType.Warning);
                    return string.Empty;
            }
        }

        public string GetGenderQty(MessageTagDataModel refTagData, string[] words)
        {
            if (refTagData == null)
            {
                // Log that was supposedly commented out
                //MessageHelper.EmitLog("GetGenderQty : refTagData is null", LogType.Warning);
                return string.Empty;
            }

            var gender = refTagData.GetGenderId();
            var qty = refTagData.GetQtyId();

            switch (MessageHelper.GetGenderQtyId(gender, qty))
            {
                case MessageEnumData.GenderQtyID.MasculineSingular:
                    return words[0];

                case MessageEnumData.GenderQtyID.FeminineSingular:
                    return words[1];

                case MessageEnumData.GenderQtyID.MasculinePlural:
                    return words[2];

                case MessageEnumData.GenderQtyID.FemininePlural:
                    return words[3];

                default:
                    // Log that was supposedly commented out
                    //MessageHelper.EmitLog(string.Format("GenderID : {0} - QtyId {1} is Unexpected Pattern", gender, qty), LogType.Warning);
                    return string.Empty;
            }
        }

        public string GetDEGenderQty(MessageTagDataModel refTagData, string[] words)
        {
            if (refTagData == null)
            {
                // Log that was supposedly commented out
                //MessageHelper.EmitLog("GetDEGenderQty : refTagData is null", LogType.Warning);
                return string.Empty;
            }

            var DEGender = GetDEGenderQtyId(refTagData.GetGenderId(), refTagData.GetQtyId());
            if ((int)DEGender >= words.Length)
                return string.Empty;

            switch (DEGender)
            {
                case MessageEnumData.DEGenderQtyID.MasculineSingular:
                    return words[0];

                case MessageEnumData.DEGenderQtyID.FeminineSingular:
                    return words[1];

                case MessageEnumData.DEGenderQtyID.NeuterSingular:
                    return words[2];

                case MessageEnumData.DEGenderQtyID.Plural:
                    return words[3];

                default:
                    return string.Empty;
            }
        }

        private MessageEnumData.DEGenderQtyID GetDEGenderQtyId(MessageEnumData.GenderID genderId, MessageEnumData.QtyID qtyId)
        {
            switch (qtyId)
            {
                case MessageEnumData.QtyID.Singular:
                    switch (genderId)
                    {
                        case MessageEnumData.GenderID.Masculine:
                            return MessageEnumData.DEGenderQtyID.MasculineSingular;

                        case MessageEnumData.GenderID.Feminine:
                            return MessageEnumData.DEGenderQtyID.FeminineSingular;

                        default:
                            return MessageEnumData.DEGenderQtyID.NeuterSingular;
                    }

                case MessageEnumData.QtyID.Plural:
                    return MessageEnumData.DEGenderQtyID.Plural;

                default:
                    return MessageEnumData.DEGenderQtyID.MasculineSingular;
            }
        }

        public string GetQtyZeroStr(MessageTagDataModel refTagData, string[] words)
        {
            if (refTagData == null)
            {
                // Log that was supposedly commented out
                //MessageHelper.EmitLog("GetQtyZeroStr : refTagData is null", LogType.Warning);
                return string.Empty;
            }

            var qty = refTagData.GetQtyId();
            if ((int)qty >= words.Length)
                return string.Empty;

            switch (qty)
            {
                case MessageEnumData.QtyID.Singular:
                    return words[0];

                case MessageEnumData.QtyID.Plural:
                    return words[1];

                case MessageEnumData.QtyID.Zero:
                    return words[2];

                default:
                    return string.Empty;
            }
        }
    }
}