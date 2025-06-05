using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Dpr.Message
{
    public class MessageTextParseDataModel
    {
        private List<MessageTagDataModel> tagDataList = new List<MessageTagDataModel>();
        private SetupTagReference setupTagRef = new SetupTagReference();
        private MessageFormatter msgFormatter = new MessageFormatter();
        private MessageTextLineDataModel[] lineMessageDataArray;
        private LabelData labelData;
        private MessageEnumData.MsgLangId langID;
        private StringBuilder textSb = new StringBuilder(MessageDataConstants.TEXT_CAPACITY_SIZE);

        public void Dispose()
        {
            msgFormatter.Dispose();
        }

        public void SetLabelData(LabelData labelData, MessageEnumData.MsgLangId langID)
        {
            this.labelData = labelData;
            this.langID = langID;

            if (!string.IsNullOrEmpty(labelData.labelName))
            {
                msgFormatter.Initialize();

                for (int i=0; i<labelData.tagDataArray.Length; i++)
                {
                    var tag = labelData.tagDataArray[i];
                    var messageTag = new MessageTagDataModel();
                    messageTag.SetTagData(tag);
                    tagDataList.Add(messageTag);
                }
            }
            else
            {
                MessageHelper.EmitLog(string.Format("{0} : LabelName not found!!", labelData.labelIndex), LogType.Error);
            }
        }

        public int LabelIndex { get => labelData.labelIndex; }
        public string LabelName { get => labelData.labelName; }
        public bool IsLabelNull { get => labelData == null; }
        public int StyleIndex { get => labelData.styleInfo.styleIndex; }
        public float FontSize { get => StyleInfo?.fontSize ?? 0.0f; }
        public int TextWidth { get => labelData.styleInfo.maxWidth; }

        public Color GetFontColor()
        {
            if (labelData.styleInfo.colorIndex > -1)
                return MessageFontDataConstants.FONT_COLOR_ARRAY[labelData.styleInfo.colorIndex].GetColor();

            return MessageFontDataConstants.DEFAULT_FONT_COLOR;
        }

        public bool IsUnknownMessage { get => labelData.styleInfo.controlID == MessageEnumData.MsgControlID.UnknownMessage; }
        private StyleInfo StyleInfo { get => labelData?.styleInfo; }

        [Obsolete]
        public bool HasAssignmentTag()
        {
            foreach (var item in tagDataList)
            {
                if (item.IsAssignmentTag)
                    return true;
            }

            return false;
        }

        public List<MessageTagDataModel> TagDataList { get => tagDataList; }
        public TagData[] TagDataArray { get => labelData.tagDataArray; }

        public TagData GetTagDataByIndex(int index)
        {
            return TagDataArray[index];
        }

        public WordData[] WordDataArray { get => labelData.wordDataArray; }

        public string CreateSimpleMessage()
        {
            var msg = msgFormatter.FormatSimple(this);
            msgFormatter.Dispose();
            return msg;
        }

        public void ApplyFormat()
        {
            SetTagWords(MessageManager.Instance.TagWordBuffer.WordParamArray);
            setupTagRef.SetTagReference(tagDataList);
            lineMessageDataArray = msgFormatter.Format(this, langID);
        }

        public void ApplyFormat(bool reparse)
        {
            if (reparse)
                textSb.Clear();

            ApplyFormat();
        }

        private void SetTagWords(AWordParamBase[] wordParamArray)
        {
            if (wordParamArray == null)
                return;

            if (wordParamArray.Length < 1)
                return;

            if (tagDataList.Count < 1)
                return;

            for (int i=0; i<tagDataList.Count; i++)
            {
                var tag = tagDataList[i];
                if ((tag.patternId == MessageEnumData.TagPatternID.Word || tag.patternId == MessageEnumData.TagPatternID.Digit) && tag.index < wordParamArray.Length)
                {
                    if (wordParamArray[tag.index] == null)
                        MessageHelper.EmitLog(string.Format("[{0}] : Tag Index [{1}] is Null : Group {2} - {3}", labelData.labelName, tag.index, tag.tagGroupId, tag.tagId));
                    else
                        wordParamArray[tag.index].SetWordParam(tag);
                }
            }
        }

        public bool HasOverWidthLineData(float textFontScale, int viewWidth, out float fontScale)
        {
            fontScale = 1.0f;

            if (lineMessageDataArray.Length < 1)
                return false;

            bool overWidth = false;
            for (int i=0; i<lineMessageDataArray.Length; i++)
            {
                int lineWidth = lineMessageDataArray[i].CalcLineWidth(textFontScale);
                if (viewWidth < lineWidth)
                {
                    MessageHelper.EmitLog(string.Format("超過しました : View Width {0} : Line Width {1}", viewWidth, lineWidth), LogType.Warning);
                    if ((float)viewWidth / lineWidth < fontScale)
                        fontScale = (float)viewWidth / lineWidth;

                    overWidth = true;
                }
            }

            return overWidth;
        }

        public string GetAllText()
        {
            if (textSb.Length < 1)
            {
                for (int i=0; i<lineMessageDataArray.Length; i++)
                {
                    var message = lineMessageDataArray[i];
                    textSb.Append(message.GetText());
                    if (message.LineWordDataList[message.LineWordDataList.Count - 1].IsNewLineEvent)
                        textSb.Append("\n");
                }
            }

            return textSb.ToString();
        }

        public MessageTextLineDataModel[] GetLineMessageDataArray()
        {
            return lineMessageDataArray;
        }

        public bool IsOneLineTagMessage()
        {
            return labelData.styleInfo.controlID == MessageEnumData.MsgControlID.BattleOneline;
        }

        public MessageTextLineDataModel[] CreateOneLineMessageDataArray(float textFontScale, float viewWidth)
        {
            MessageHelper.EmitLog("Begine BattleOneline Process", LogType.Log);

            var resultList = new List<MessageTextLineDataModel>();
            float spaceWidth = GetSpaceStrWidth(textFontScale);

            bool overflowingLine = false;

            for (int i=0; i<lineMessageDataArray.Length; i++)
            {
                var line = lineMessageDataArray[i];

                switch (line.GetLineEndEventId())
                {
                    case MessageEnumData.MsgEventID.ScrollPage:
                    case MessageEnumData.MsgEventID.End:
                        overflowingLine = false;
                        resultList.Add(line);
                        continue;
                }

                if (i + 1 < lineMessageDataArray.Length)
                {
                    resultList.Add(line);
                    break;
                }

                float totalLineWidth = line.CalcLineWidth(textFontScale);
                MessageHelper.EmitLog(string.Format("Line[{0}] - TotalWidth[{1}] - ViewWidth[{2}]", i, totalLineWidth, viewWidth), LogType.Log);

                if (totalLineWidth <= viewWidth)
                {
                    for (int j=i; j+1<lineMessageDataArray.Length; j++)
                    {
                        var nextLine = lineMessageDataArray[j+1];
                        float nextLineWidth = nextLine.CalcLineWidth(textFontScale);
                        totalLineWidth = spaceWidth + totalLineWidth + nextLineWidth;

                        MessageHelper.EmitLog(string.Format("NextWidth[{0}] - SpaceWidth[{1}] - Total [{2}]", nextLineWidth, spaceWidth, totalLineWidth), LogType.Log);

                        if (viewWidth < totalLineWidth)
                        {
                            var prevLine = lineMessageDataArray[j];
                            var eventId = overflowingLine ? prevLine.GetLineEndEventId() : MessageEnumData.MsgEventID.NewLine;
                            var totalLine = ConcateLineDatas(i, j, eventId, totalLineWidth - nextLineWidth - spaceWidth);
                            resultList.Add(totalLine);
                            overflowingLine = true;
                            i = j;
                            break;
                        }

                        switch (nextLine.GetLineEndEventId())
                        {
                            case MessageEnumData.MsgEventID.ScrollPage:
                            case MessageEnumData.MsgEventID.End:
                                var totalLine = ConcateLineDatas(i, j+1, nextLine.GetLineEndEventId(), totalLineWidth - nextLineWidth - spaceWidth);
                                resultList.Add(totalLine);
                                MessageHelper.EmitLog(string.Format("Apply BattleOneLine : Line[{0}] - [{1}]", i, j), LogType.Log);
                                overflowingLine = false;
                                i = j + 2;
                                break;
                        }
                    }
                }
                else
                {
                    resultList.Add(line);
                }
            }

            MessageHelper.EmitLog("Finish BattleOneline Process", LogType.Log);
            return resultList.ToArray();
        }

        private float GetSpaceStrWidth(float textFontScale)
        {
            char space;
            if (MessageHelper.IsEFIGS(langID))
            {
                space = MessageHelper.ConvertUnicodeToChar(MessageDataConstants.HALF_SPACE_CODE);
            }
            else
            {
                if (langID != MessageEnumData.MsgLangId.JPN)
                {
                    MessageHelper.EmitLog(string.Format("Can not use battle_oneline tag - language : {0}", langID));
                    return 0.0f;
                }
                space = MessageHelper.ConvertUnicodeToChar(MessageDataConstants.SPACE_CODE);
            }

            return MessageHelper.CalcMessageWidth(langID, space.ToString(), textFontScale);
        }

        private MessageTextLineDataModel ConcateLineDatas(int startIndex, int lastIndex, MessageEnumData.MsgEventID lineEndEventID, float totalLineWidth)
        {
            var newLineData = new MessageTextLineDataModel();
            setWordDataToNewLineData(startIndex);

            var linesSB = new StringBuilder(MessageDataConstants.TEXT_CAPACITY_SIZE);
            for (int i=startIndex+1; i<lastIndex; i++)
            {
                if (MessageHelper.IsEFIGS(langID))
                {
                    linesSB.Append(MessageHelper.ConvertUnicodeToChar(MessageDataConstants.HALF_SPACE_CODE));
                }
                else
                {
                    if (langID == MessageEnumData.MsgLangId.JPN)
                        linesSB.Append(MessageHelper.ConvertUnicodeToChar(MessageDataConstants.SPACE_CODE));
                    else
                        MessageHelper.EmitLog(string.Format("Can not use battle_oneline tag - language : {0}", langID));
                }

                if (linesSB.Length > 0)
                {
                    var item = MessageManager.GetWordDataFromPool();
                    item.endEventId = MessageEnumData.MsgEventID.None;
                    item.languageId = MessageManager.Instance.UserLanguageID;
                    item.tagValue = 0.0f;
                    item.strWidth = 0.0f;
                    item.AppendStr(linesSB.ToString());
                    newLineData.LineWordDataList.Add(item);
                    linesSB.Clear();
                }
                setWordDataToNewLineData(i);
            }

            newLineData.FinishLineMessageData(string.Empty, lineEndEventID, MessageManager.Instance.UserLanguageID, totalLineWidth);
            return newLineData;

            void setWordDataToNewLineData(int listIndex)
            {
                foreach (var word in lineMessageDataArray[listIndex].LineWordDataList)
                {
                    switch (word.endEventId)
                    {
                        case MessageEnumData.MsgEventID.NewLine:
                        case MessageEnumData.MsgEventID.ScrollPage:
                        case MessageEnumData.MsgEventID.ScrollLine:
                            word.strWidth = 0.0f;
                            word.endEventId = MessageEnumData.MsgEventID.None;
                            newLineData.LineWordDataList.Add(word);
                            break;

                        case MessageEnumData.MsgEventID.End:
                            if (word.StrLength > 0)
                            {
                                word.strWidth = 0.0f;
                                word.endEventId = MessageEnumData.MsgEventID.None;
                                newLineData.LineWordDataList.Add(word);
                            }
                            break;

                        default:
                            word.strWidth = 0.0f;
                            newLineData.LineWordDataList.Add(word);
                            break;
                    }
                }
            }
        }
    }
}