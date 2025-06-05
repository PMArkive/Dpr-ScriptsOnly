using System;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore;

namespace Dpr.Message
{
    public static class MessageHelper
    {
        private static int eggNameHash;

        public static string ExtractionLangNameByName(string fileName)
        {
            string langStr = fileName.Substring(0, fileName.IndexOf('_') - 1);

            if (langStr != MessageDataConstants.ASSET_FOLDER_NAME_TABLE[1])
                return langStr;

            if (fileName.Substring(0, MessageDataConstants.JPN_KANJI_ASSET_FOLDER_NAME.Length) == MessageDataConstants.JPN_KANJI_ASSET_FOLDER_NAME)
                return MessageDataConstants.ASSET_FOLDER_NAME_TABLE[1];

            return langStr;
        }

        public static bool IsEFIGS(MessageEnumData.MsgLangId languageId)
        {
            switch (languageId)
            {
                case MessageEnumData.MsgLangId.USA:
                case MessageEnumData.MsgLangId.FRA:
                case MessageEnumData.MsgLangId.ITA:
                case MessageEnumData.MsgLangId.DEU:
                case MessageEnumData.MsgLangId.ESP:
                    return true;

                default:
                    return false;
            }
        }

        public static string SurroundFontTag(string word, uint languageId)
        {
            return SurroundFontTag(word, (MessageEnumData.MsgLangId)languageId);
        }

        public static string SurroundFontTag(string word, MessageEnumData.MsgLangId languageId)
        {
            if (MessageManager.Instance.UserLanguageID == languageId)
                return word;

            StringBuilder sb = new StringBuilder();
            sb.Append(MessageDataConstants.START_FONT_TAG_STR);
            sb.Append(GetFontFileName(languageId));
            sb.Append(">");
            sb.Append(word);
            sb.Append(MessageDataConstants.END_FONT_TAG_STR);

            return sb.ToString();
        }

        public static string GetFontFileName(MessageEnumData.MsgLangId languageId)
        {
            if (MessageFontDataConstants.FONT_FILE_TABLE.ContainsKey((int)languageId))
                return MessageFontDataConstants.FONT_FILE_NAME_ARRAY[MessageFontDataConstants.FONT_FILE_TABLE[(int)languageId]];

            // This line is presumed to have been commented out, the result of the concatenation is ignored otherwise
            //EmitLog("LanguageId Not Found : " + languageId, LogType.Error);

            return MessageFontDataConstants.FONT_FILE_NAME_ARRAY[MessageFontDataConstants.FONT_FILE_TABLE[(int)MessageEnumData.MsgLangId.JPN]];
        }

        public static string[] GetLocalizeVariants()
        {
            if (!MessageManager.isInstantiated)
                return null;

            return MessageManager.Instance.Varitnas;
        }

        public static string GetLanguageVariant()
        {
            if (!MessageManager.isInstantiated)
                return string.Empty;

            return GetLanguageVariant(MessageManager.Instance.UserLanguageID);
        }

        public static string GetLanguageVariant(MessageEnumData.MsgLangId langID)
        {
            return MessageDataConstants.ROOT_FOLDER_NAME_TABLE[(int)langID].ToLower();
        }

        public static string AddVariantNameToPath(string path)
        {
            return path + "." + GetLanguageVariant();
        }

        public static string AddVariantNameToPath(string path, string langVariant)
        {
            return path + "." + langVariant;
        }

        public static bool CheckExcludeCode(char c)
        {
            uint code = Convert.ToUInt32(c);
            for (int i=0; i<MessageDataConstants.EXCLUDE_CODES.Length; i++)
            {
                if (MessageDataConstants.EXCLUDE_CODES[i] == code)
                    return true;
            }

            return false;
        }

        public static bool CheckNewLineCharCode(char c)
        {
            return ContainParam(c, MessageDataConstants.NEWLINE_CHAR_CODES);
        }

        public static char ConvertUnicodeToChar(int unicode)
        {
            return Convert.ToChar(unicode);
        }

        public static MessageEnumData.GenderQtyID GetGenderQtyId(MessageEnumData.GenderID genderId, MessageEnumData.QtyID qtyId)
        {
            if (genderId == MessageEnumData.GenderID.Feminine)
            {
                if (qtyId == MessageEnumData.QtyID.Singular)
                    return MessageEnumData.GenderQtyID.FeminineSingular;

                if (qtyId == MessageEnumData.QtyID.Plural)
                    return MessageEnumData.GenderQtyID.FemininePlural;
            }
            else if (genderId == MessageEnumData.GenderID.Masculine)
            {
                if (qtyId == MessageEnumData.QtyID.Singular)
                    return MessageEnumData.GenderQtyID.MasculineSingular;

                if (qtyId == MessageEnumData.QtyID.Plural)
                    return MessageEnumData.GenderQtyID.MasculinePlural;
            }

            // This line is presumed to have been commented out, the result of the concatenation is ignored otherwise
            //EmitLog(string.Format("GenderID : {0} - QtyId {1} is Unexpected Pattern", genderId, qtyId), LogType.Error);

            return MessageEnumData.GenderQtyID.MasculineSingular;
        }

        public static MessageEnumData.QtyID CheckQtyIdByCount(int count, MessageEnumData.MsgLangId langID)
        {
            if (count == 0)
            {
                if (langID == MessageEnumData.MsgLangId.FRA)
                    return MessageEnumData.QtyID.Singular;
                else
                    return MessageEnumData.QtyID.Plural;
            }
            else if (count == 1)
            {
                return MessageEnumData.QtyID.Singular;
            }
            else
            {
                return MessageEnumData.QtyID.Plural;
            }
        }

        public static bool IsVowel(char initial)
        {
            return ContainParam(initial, MessageDataConstants.VOWEL_TABLE);
        }

        public static bool IsFRVowel(char initial)
        {
            return IsVowel(initial) || ContainParam(initial, MessageDataConstants.VOWEL_FR_TABLE);
        }

        public static bool IsITVowelE(char initial)
        {
            return ContainParam(initial, MessageDataConstants.VOWEL_E_IT_TABLE);
        }

        private static bool ContainParam(char target, in char[] paramArray)
        {
            for (int i=0; i<paramArray.Length; i++)
            {
                if (paramArray[i] == target)
                    return true;
            }

            return false;
        }

        public static bool IsDigitWordByUnicode(byte[] unicodes)
        {
            if (unicodes[1] != 0)
                return false;

            if (MessageDataConstants.DIGIT_UNICODE_RANGE.x <= unicodes[0] && unicodes[0] <= MessageDataConstants.DIGIT_UNICODE_RANGE.y)
                return true;

            return false;
        }

        public static void SetEggName(string eggName)
        {
            eggNameHash = eggName.GetHashCode();
        }

        public static bool IsEggName(string nickName)
        {
            return eggNameHash == nickName.GetHashCode();
        }

        public static int GetEggNameGender(MessageEnumData.MsgLangId langID, int genderID)
        {
            switch (langID)
            {
                case MessageEnumData.MsgLangId.FRA:
                case MessageEnumData.MsgLangId.ITA:
                case MessageEnumData.MsgLangId.ESP:
                    return (int)MessageEnumData.GenderID.Masculine;

                case MessageEnumData.MsgLangId.DEU:
                    return (int)MessageEnumData.GenderID.Neuter;

                default:
                    return genderID;
            }
        }

        public static int GetEggNameInitialSound(MessageEnumData.MsgLangId langID, int initialSound)
        {
            switch (langID)
            {
                case MessageEnumData.MsgLangId.FRA:
                    return (int)MessageEnumData.FRInitialSoundID.YesElision;

                case MessageEnumData.MsgLangId.ITA:
                    return (int)MessageEnumData.ITInitialSoundID.Vowel;

                case MessageEnumData.MsgLangId.ESP:
                    return (int)MessageEnumData.ESInitialSoundID.Consonant;

                default:
                    return initialSound;
            }
        }

        public static float CalcMessageWidth(MessageEnumData.MsgLangId langID, string str, float textFontScale)
        {
            return CheckMessageWidth(FontManager.Instance.GetFontAssetInfoByLangId(langID), str, textFontScale);
        }

        public static float CheckMessageWidth(FontAssetInfo fontAssetInfo, string str, float textFontScale)
        {
            fontAssetInfo.AddCharacters(str);
            return CheckMessageWidth(fontAssetInfo.fontAsset, str, textFontScale);
        }

        public static float CheckMessageWidth(TMP_FontAsset fontAsset, string str, float textFontScale)
        {
            if (str.Length < 1)
                return 0.0f;

            char[] chars = str.ToCharArray();
            var charLookupTable = fontAsset.characterLookupTable;
            var glyphLookupTable = fontAsset.glyphLookupTable;

            float totalWidth = 0.0f;

            for (int i=0; i<chars.Length; i++)
            {
                uint currentChar = Convert.ToUInt32(chars[i]);

                if (currentChar == Convert.ToUInt32('\r') || currentChar == Convert.ToUInt32('\n') ||
                    currentChar == Convert.ToUInt32('{') || currentChar == Convert.ToUInt32('}'))
                {
                    // This line is presumed to have been commented out, the result of string.Format is ignored otherwise
                    //EmitLog(string.Format("Find Exclude Char Code : {0}", chars[i]), LogType.Warning);
                }

                if (charLookupTable.TryGetValue(currentChar, out TMP_Character character))
                {
                    if (glyphLookupTable.TryGetValue(character.glyphIndex, out Glyph glyph))
                    {
                        totalWidth += glyph.metrics.horizontalAdvance;
                    }
                }
                else
                {
                    bool found = false;
                    foreach (var fallbackFontAsset in fontAsset.fallbackFontAssetTable)
                    {
                        if (fallbackFontAsset.atlasPopulationMode == AtlasPopulationMode.Dynamic)
                            fallbackFontAsset.HasCharacter(chars[i], false, true); // Result ignored

                        var fallbackCharLookupTable = fontAsset.characterLookupTable;
                        var fallbackGlyphLookupTable = fontAsset.glyphLookupTable;
                        if (fallbackCharLookupTable.TryGetValue(currentChar, out TMP_Character fallbackCharacter))
                        {
                            found = true;
                            if (fallbackGlyphLookupTable.TryGetValue(fallbackCharacter.glyphIndex, out Glyph fallbackGlyph))
                            {
                                totalWidth += fallbackGlyph.metrics.horizontalAdvance;
                                found = true;
                            }
                        }
                    }

                    if (!found)
                    {
                        if (IsSpriteFontCode(currentChar))
                        {
                            totalWidth += MessageDataConstants.SPRITE_FONT_WIDTH;
                        }
                        else
                        {
                            // This line is presumed to have been commented out, the result of string.Format is ignored otherwise
                            //EmitLog(string.Format("Missing Char : {0} {1:X2}", chars[i], currentChar), LogType.Warning);
                        }
                    }
                }
            }

            // This line is presumed to have been commented out, the result of string.Format is ignored otherwise
            //EmitLog(string.Format("Check StringWidth[{0}] : Width [{1}] - Font [{2}]", str, totalWidth, fontAsset.name), LogType.Log);

            return totalWidth * textFontScale;
        }

        private static bool IsSpriteFontCode(uint unicode)
        {
            for (int i=0; i<MessageDataConstants.POCKET_ICON_CODE_TABLE.Count; i++)
            {
                if (unicode == MessageDataConstants.POCKET_ICON_CODE_TABLE[i])
                    return true;
            }

            if (unicode == MessageDataConstants.CHARACTER1_CODE_TABLE[23])
                return true;

            return false;
        }

        public static bool ExistMissingChara(MessageEnumData.MsgLangId langID, in string checkStr)
        {
            // This line is presumed to have been commented out, the result of string.Format is ignored otherwise
            //EmitLog(string.Format("Check Missing Chara : LangID [{0}]", langID), LogType.Log);

            return ExistMissingChara(FontManager.Instance.GetFontAssetByLangId(langID), checkStr);
        }

        public static bool ExistMissingChara(TMP_FontAsset fontAsset, in string checkStr)
        {
            for (int i=0; i<checkStr.Length; i++)
            {
                if (!fontAsset.HasCharacter(checkStr[i], true, true))
                {
                    // This line is presumed to have been commented out, the result of string.Format is ignored otherwise
                    //EmitLog(string.Format("Exist Missing Chara : [{0}]", checkStr[i]), LogType.Log);
                    return true;
                }
            }

            return false;
        }

        public static MessageEnumData.ForceGrmID CreateNotationValue(float centiSize, ref int integerValue, ref int decimalValue)
        {
            float integerValueF = 0.0f;
            float decimalValueF = 0.0f;

            switch (MessageManager.Instance.UserLanguageID)
            {
                case MessageEnumData.MsgLangId.USA:
                    float inches = (int)(centiSize / MessageDataConstants.CONVERT_FEET_COEFFICIENT);
                    SplitRealNumber(inches, ref integerValueF, ref decimalValueF);
                    integerValue = (int)integerValueF;
                    decimalValue = (int)decimalValueF;

                    return (integerValue == 1 && decimalValue == 0) ? MessageEnumData.ForceGrmID.None : MessageEnumData.ForceGrmID.Plural;

                default:
                    SplitRealNumber(centiSize, ref integerValueF, ref decimalValueF);
                    integerValue = (int)integerValueF;
                    decimalValue = (int)decimalValueF;

                    return MessageEnumData.ForceGrmID.None;
            }
        }

        private static void SplitRealNumber(float baseValue, ref float integerValue, ref float decimalValue)
        {
            integerValue = baseValue;
            double roundedValue = Math.Round(baseValue * 10.0f % 10.0f, MidpointRounding.AwayFromZero);
            decimalValue = (int)roundedValue;
            if ((int)roundedValue > 9)
            {
                integerValue++;
                decimalValue = 0;
            }
        }

        public static void EmitLog(string log, LogType logType = LogType.Log)
        {
            // Empty, This code or something similar is presumed to have been commented out
            /*switch (logType)
            {
                case LogType.Exception:
                    Debug.LogError(log);
                    break;
                case LogType.Log:
                    Debug.Log(log);
                    break;
                case LogType.Warning:
                    Debug.LogWarning(log);
                    break;
                case LogType.Assert:
                    Debug.LogAssertion(log);
                    break;
                case LogType.Error:
                    Debug.LogError(log);
                    break;
            }*/
        }

        public static MessageEnumData.MsgLangId ConvertMsgId(MessageEnumData.MsgLangId langId)
        {
            return langId;
        }
    }
}