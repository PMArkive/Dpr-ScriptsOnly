using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Dpr.Message
{
    public class MessageTextLineDataModel
    {
        private const int INIT_LIST_CAPACITY = 16;
        private List<WordDataModel> lineWordDataList = new List<WordDataModel>(INIT_LIST_CAPACITY);
        private StringBuilder lineStringBuilder = new StringBuilder(MessageDataConstants.TEXT_CAPACITY_SIZE);
        private MessageEnumData.MsgEventID currentEventId;
        private WordDataModel lastShowMsgObjData;
        private int totalStrLength;
        private int wordDataIndex;
        private int charIndex;
        private int nowStrIndex;
        private int tempCharIndex;
        private bool bIsCenter;

        ~MessageTextLineDataModel()
        {
            Dispose();
        }

        public void Dispose()
        {
            if (lineWordDataList != null)
            {
                foreach (var word in lineWordDataList)
                    word.Clear();

                lineWordDataList = null;
            }
        }

        public bool HasMessageData { get => lineWordDataList.Count > 0; }
        public List<WordDataModel> LineWordDataList { get => lineWordDataList; }
        public bool IsCenterMessage { get => bIsCenter; }
        public int TotalStringLength { get => totalStrLength; }

        public MessageEnumData.MsgEventID GetLineEndEventId()
        {
            return lineWordDataList[lineWordDataList.Count - 1].endEventId;
        }

        public MessageEnumData.MsgEventID NowEventId { get => currentEventId; }
        public bool IsViewComplete { get => lineWordDataList.Count <= wordDataIndex; }

        public float GetNowMessageDataValue()
        {
            return lastShowMsgObjData?.tagValue ?? 0.0f;
        }

        public int CalcLineWidth(float textFontScale)
        {
            bool richText = false;
            var currentLang = MessageEnumData.MsgLangId.JPN;
            var fontAssetInfo = FontManager.Instance.GetFontAssetInfoByLangId(currentLang);
            float totalLength = 0.0f;

            foreach (var word in lineWordDataList)
            {
                if (word.bIsRichTextTag)
                {
                    if (word.languageId != 0 && !richText)
                    {
                        richText = true;
                        fontAssetInfo = FontManager.Instance.GetFontAssetInfoByLangId(word.languageId);
                    }
                    else
                    {
                        richText = false;
                    }
                }
                else
                {
                    if (!richText && word.languageId != currentLang)
                    {
                        fontAssetInfo = FontManager.Instance.GetFontAssetInfoByLangId(word.languageId);
                        currentLang = word.languageId;
                    }

                    if (fontAssetInfo != null)
                    {
                        if (word.strWidth < 0.0f)
                            totalLength += MessageHelper.CheckMessageWidth(fontAssetInfo, word.GetMessage(), textFontScale);
                        else
                            totalLength += word.strWidth;
                    }
                }
            }

            return Mathf.FloorToInt(totalLength);
        }

        public void ResetMessageData()
        {
            lastShowMsgObjData = null;
            lineStringBuilder.Clear();
            currentEventId = MessageEnumData.MsgEventID.None;
            wordDataIndex = 0;
            charIndex = 0;
            nowStrIndex = 0;
            tempCharIndex = 0;
        }

        public string GetText()
        {
            if (lineStringBuilder.Length < 1)
            {
                foreach (var word in lineWordDataList)
                    lineStringBuilder.Append(word.sb);
            }

            nowStrIndex = totalStrLength;
            return lineStringBuilder.ToString();
        }

        public string GetTextUntilIndex(int index)
        {
            if (totalStrLength < 1)
            {
                if (lineWordDataList.Count < 1)
                {
                    MessageHelper.EmitLog("MessageLineDataList Count is 0!!!!", LogType.Error);
                    currentEventId = MessageEnumData.MsgEventID.End;
                }
                else
                {
                    currentEventId = GetLineEndEventId();
                }
            }
            else if (index > -1)
            {
                if (nowStrIndex < totalStrLength)
                {
                    if (nowStrIndex < index)
                    {
                        for (int i=1000; nowStrIndex<index; i--)
                        {
                            // Result ignored
                            GetNextTextStr();
                            if (currentEventId != MessageEnumData.MsgEventID.None)
                                break;

                            if (i == 1)
                            {
                                MessageHelper.EmitLog(string.Format("[{0}][{1}] : LoopCnt over 1000!!!!!!", index, totalStrLength), LogType.Error);
                                currentEventId = MessageEnumData.MsgEventID.End;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    wordDataIndex++;
                    lastShowMsgObjData = lineWordDataList[wordDataIndex];
                    currentEventId = lastShowMsgObjData.endEventId;
                }

                return lineStringBuilder.ToString();
            }

            return string.Empty;
        }

        public string GetNextTextStr()
        {
            currentEventId = MessageEnumData.MsgEventID.None;

            if (wordDataIndex < lineWordDataList.Count)
            {
                for (int i=wordDataIndex; i<lineWordDataList.Count; i++)
                {
                    var word = lineWordDataList[i];
                    if (word.bIsRichTextTag)
                    {
                        charIndex += word.StrLength;
                        lineStringBuilder.Append(word.GetMessage());
                    }
                    else
                    {
                        int nextLength = tempCharIndex + word.StrLength;
                        if (charIndex < nextLength)
                        {
                            lineStringBuilder.Append(word.GetMessageSubstring(charIndex - tempCharIndex));
                            charIndex++;
                            nowStrIndex++;

                            if (charIndex >= nextLength)
                            {
                                lastShowMsgObjData = word;
                                currentEventId = word.endEventId;
                            }

                            break;
                        }

                        if (word.endEventId != MessageEnumData.MsgEventID.None)
                        {
                            lastShowMsgObjData = word;
                            currentEventId = word.endEventId;
                            wordDataIndex++;
                            charIndex = 0;
                            tempCharIndex = 0;
                            break;
                        }

                        charIndex++;
                    }

                    tempCharIndex = charIndex;
                    wordDataIndex++;
                }
            }

            return lineStringBuilder.ToString();
        }

        public bool HasShowMessageData()
        {
            if (lineWordDataList.Count < 1)
                return false;

            return !lineWordDataList[lineWordDataList.Count - 1].IsNewLineEvent;
        }

        public void AddTextData(string str, MessageEnumData.MsgLangId languageID, float strWidth, float tagValue, MessageEnumData.MsgEventID endEventId)
        {
            var word = MessageManager.GetWordDataFromPool();
            word.endEventId = endEventId;
            word.languageId = languageID;
            word.tagValue = tagValue;
            word.strWidth = strWidth;
            word.AppendStr(str);
            AddLineWordData(word);
        }

        public void AddNameTextData(string str, MessageEnumData.MsgLangId languageID, float strWidth, bool isNameWord)
        {
            if (languageID == MessageManager.Instance.UserLanguageID || !isNameWord)
            {
                AddNickNameStrData(str, languageID, strWidth);
            }
            else
            {
                CreateFontTagObj(MessageDataConstants.START_FONT_TAG_STR + MessageHelper.GetFontFileName(languageID) + ">", languageID);
                AddNickNameStrData(str, languageID, strWidth);
                AddLineWordData(CreateFontTagObj(MessageDataConstants.END_FONT_TAG_STR, languageID));
            }
        }

        private void AddNickNameStrData(string str, MessageEnumData.MsgLangId languageID, float strWidth)
        {
            var word = MessageManager.GetWordDataFromPool();
            word.languageId = languageID;
            word.strWidth = (strWidth != 0.0f) ? strWidth : -1.0f;
            word.AppendStr(str);
            AddLineWordData(word);
        }

        public void AddFontTagData(WordData wordData, MessageEnumData.MsgLangId languageId)
        {
            AddLineWordData(CreateFontTagObj(wordData.str, languageId));
            if (wordData.patternID == MessageEnumData.WordDataPatternID.SizeTag && !bIsCenter)
                bIsCenter = true;
        }

        public void AddLineWordData(WordDataModel wordDataModel)
        {
            lineWordDataList.Add(wordDataModel);
        }

        public void FinishLineMessageData(string str, MessageEnumData.MsgEventID endEventId, MessageEnumData.MsgLangId languageID, float strWidth)
        {
            var word = MessageManager.GetWordDataFromPool();
            word.endEventId = endEventId;
            word.languageId = languageID;
            word.strWidth = (strWidth != 0.0f) ? strWidth : -1.0f;
            word.AppendStr(str);
            AddLineWordData(word);
            SettingLineStringDataInfo();
            ResetMessageData();
        }

        private void SettingLineStringDataInfo()
        {
            int capacity = 0;
            int length = 0;
            foreach (var word in lineWordDataList)
            {
                capacity += word.StrLength;
                length += word.Length;
            }

            lineStringBuilder.Capacity = capacity;
            totalStrLength = length;
        }

        private WordDataModel CreateFontTagObj(string str, MessageEnumData.MsgLangId languageID)
        {
            var word = MessageManager.GetWordDataFromPool();
            word.languageId = languageID;
            word.bIsRichTextTag = true;
            word.AppendStr(str);
            return word;
        }
    }
}