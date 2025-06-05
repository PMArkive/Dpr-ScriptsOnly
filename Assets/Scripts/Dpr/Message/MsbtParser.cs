using Nintendo.MessageStudio.Lib;
using System.Collections.Generic;
using System.Text;
using TMPro;

namespace Dpr.Message
{
    public class MsbtParser
    {
        private const char NEW_LINE_CHAR = '\xd';
        private List<WordData> wordDataList = new List<WordData>();
        private LabelParseProcessor parseProcessor = new LabelParseProcessor();
        private MessageEnumData.MsgLangId msgLangID = MessageEnumData.MsgLangId.Num;
        private TMP_FontAsset fontAsset;
        private float fontSize;
        private MessageEnumData.MsgLangId fontTagLangID = MessageEnumData.MsgLangId.JPN;
        private int sizeTagScale = 100;

        public void Initialize()
        {
            parseProcessor.Initialize();
        }

        public LabelData[] ParseMsbtBinData(byte[] binDataArray, MessageEnumData.MsgLangId langID, int patchVersion)
        {
            fontSize = 0.0f;
            msgLangID = langID;
            return ConvertParseTextDataToFormatMsbtData(ParseMsbtFileData(binDataArray), patchVersion);
        }

        private MsbtFileData ParseMsbtFileData(byte[] msbtByteDataArray)
        {
            var binFile = new BinMsgFile();
            binFile.SetMSBTFileData(msbtByteDataArray);

            var msbtFile = new MsbtFileData();
            msbtFile.langID = MessageEnumData.MsgLangId.JPN;

            int maxIndex = binFile.GetTextNum();
            var labelDataModelArray = new LabelDataModel[maxIndex];
            for (int i=0; i<maxIndex; i++)
            {
                parseProcessor.Reset();
                parseProcessor.Process(binFile.GetText(i));

                var labelDataModel = new LabelDataModel();
                labelDataModel.labelIndex = i;
                labelDataModel.arrayIndex = binFile.GetIndexAttribute(i, 65);
                labelDataModel.styleIndex = binFile.GetStyle(i);
                labelDataModel.labelName = binFile.GetLabel(i);
                labelDataModel.parseDataModel = parseProcessor.CreateParseDataModel();
                labelDataModel.patchVersion = binFile.GetIndexAttribute(binFile.GetAttributes(i), 65);

                labelDataModelArray[i] = labelDataModel;
            }

            msbtFile.binMsgFile = binFile;
            msbtFile.langID = msgLangID;
            msbtFile.labelDataModelArray = labelDataModelArray;
            return msbtFile;
        }

        private LabelData[] ConvertParseTextDataToFormatMsbtData(MsbtFileData dataModel, int patchVersion)
        {
            var maxIndex = dataModel.GetMaxDataIndex();
            var labelDataModelArray = new LabelDataModel[maxIndex];

            for (int i=0; i<dataModel.labelDataModelArray.Length; i++)
            {
                int index = dataModel.GetIndexAttributeData(dataModel.labelDataModelArray[i].labelIndex);
                if (labelDataModelArray[index] == null)
                {
                    if (dataModel.labelDataModelArray[i].patchVersion <= patchVersion)
                    {
                        dataModel.labelDataModelArray[i].arrayIndex = index;
                        labelDataModelArray[index] = dataModel.labelDataModelArray[i];
                    }
                }
                else
                {
                    MessageHelper.EmitLog(string.Format("{0} : Index {1} is Already Setting Data Index!!!!", dataModel.labelDataModelArray[i].labelName, index), UnityEngine.LogType.Error);
                }
            }

            var labelDataArray = new LabelData[maxIndex];

            for (int i=0; i<labelDataArray.Length; i++)
            {
                var labelData = new LabelData();
                if (labelDataModelArray[i] != null)
                {
                    labelData.labelIndex = labelDataModelArray[i].labelIndex;
                    labelData.arrayIndex = labelDataModelArray[i].arrayIndex;
                    labelData.labelName = labelDataModelArray[i].labelName;

                    labelData.styleInfo = CreateStyleInfo(labelDataModelArray[i].styleIndex, dataModel.CheckControlID(labelDataModelArray[i].labelIndex));
                    labelData.attributeValueArray = CreateAttributeInfo(dataModel.GetAttributeDataModel(labelDataModelArray[i].labelIndex));
                    labelData.tagDataArray = CreateTagDataArray(labelDataModelArray[i]);
                    labelData.wordDataArray = CreateWordDataArray(labelDataModelArray[i].parseDataModel, out string _);
                }
                labelDataArray[i] = labelData;
            }

            return labelDataArray;
        }

        private StyleInfo CreateStyleInfo(int styleIndex, MessageEnumData.MsgControlID controlID)
        {
            if (styleIndex < 0)
                return new StyleInfo();

            StyleInfo styleInfo = new StyleInfo();

            var formatData = MessageFontDataConstants.FONT_STYLE_DATA_TABLE[styleIndex];
            var styleModel = new MessageStyleDataModel(styleIndex, formatData);

            styleInfo.styleIndex = styleIndex;
            styleInfo.fontSize = styleModel.fontSize;
            styleInfo.colorIndex = formatData.fontColorIndex;
            styleInfo.maxWidth = styleModel.maxTextWidth;
            styleInfo.controlID = controlID;

            fontSize = styleModel.fontSize;
            return styleInfo;
        }

        private int[] CreateAttributeInfo(MessageAttributeDataModel attributeDataModel)
        {
            return new int[5]
            {
                attributeDataModel.gender,
                attributeDataModel.initialSound,
                attributeDataModel.countablity,
                attributeDataModel.displayPattern,
                attributeDataModel.articlePresence,
            };
        }

        private TagData[] CreateTagDataArray(LabelDataModel dataModel)
        {
            List<TagData> tagDataList = new List<TagData>();

            SetForceTagReference(dataModel.TagDataList);
            foreach (var tagData in dataModel.TagDataList)
            {
                if (tagData.IsWordTag)
                {
                    tagDataList.Add(new TagData()
                    {
                        tagIndex = tagData.index,
                        groupID = tagData.tagGroupID,
                        tagID = tagData.tagID,
                        tagPatternID = tagData.patternID,
                        tagParameter = tagData.tagParameter,
                        tagWordArray = tagData.tagWords,
                        forceArticle = tagData.forceArticle,
                        forceGrmID = tagData.forceGrmID,
                    });
                }
            }

            return tagDataList.ToArray();
        }

        private void SetForceTagReference(List<LabelTagDataModel> tagDataList)
        {
            if (tagDataList == null || tagDataList.Count < 1)
                return;

            for (int i=0; i<tagDataList.Count; i++)
            {
                switch (tagDataList[i].tagGroupID)
                {
                    case MessageEnumData.GroupTagID.Grm:
                        GrmTagReference(i, (MessageEnumData.GrmID)tagDataList[i].tagID, tagDataList);
                        break;

                    case MessageEnumData.GroupTagID.EN:
                        ENTagReference(i, tagDataList[i], tagDataList);
                        break;

                    case MessageEnumData.GroupTagID.FR:
                        FRTagReference(i, tagDataList[i], tagDataList);
                        break;

                    case MessageEnumData.GroupTagID.IT:
                        ITTagReference(i, tagDataList[i], tagDataList);
                        break;

                    case MessageEnumData.GroupTagID.DE:
                        DETagReference(i, tagDataList[i], tagDataList);
                        break;

                    case MessageEnumData.GroupTagID.ES:
                        ESTagReference(i, tagDataList[i], tagDataList);
                        break;
                }
            }
        }

        private void GrmTagReference(int listIndex, MessageEnumData.GrmID tagId, List<LabelTagDataModel> tagDataList)
        {
            if (tagId == MessageEnumData.GrmID.ForceMasculine)
                SetForceGrmId(listIndex, tagDataList, MessageEnumData.ForceGrmID.Masculine);
        }

        private void ENTagReference(int listIndex, LabelTagDataModel tagData, List<LabelTagDataModel> tagDataList)
        {
            switch ((MessageEnumData.ENID)tagData.tagID)
            {
                case MessageEnumData.ENID.ForceSingular:
                    SetForceGrmId(listIndex, tagDataList, MessageEnumData.ForceGrmID.Singular);
                    break;

                case MessageEnumData.ENID.ForcePlural:
                    SetForceGrmId(listIndex, tagDataList, MessageEnumData.ForceGrmID.Plural);
                    break;

                case MessageEnumData.ENID.ForceInitialCap:
                    SetForceGrmId(listIndex, tagDataList, MessageEnumData.ForceGrmID.InitialCap);
                    break;
            }
        }

        private void FRTagReference(int listIndex, LabelTagDataModel tagData, List<LabelTagDataModel> tagDataList)
        {
            switch ((MessageEnumData.FRID)tagData.tagID)
            {
                case MessageEnumData.FRID.ForceSingular:
                    SetForceGrmId(listIndex, tagDataList, MessageEnumData.ForceGrmID.Singular);
                    break;

                case MessageEnumData.FRID.ForcePlural:
                    SetForceGrmId(listIndex, tagDataList, MessageEnumData.ForceGrmID.Plural);
                    break;

                case MessageEnumData.FRID.ForceInitialCap:
                    SetForceGrmId(listIndex, tagDataList, MessageEnumData.ForceGrmID.InitialCap);
                    break;
            }
        }

        private void ITTagReference(int listIndex, LabelTagDataModel tagData, List<LabelTagDataModel> tagDataList)
        {
            switch ((MessageEnumData.ITID)tagData.tagID)
            {
                case MessageEnumData.ITID.ForceSingular:
                    SetForceGrmId(listIndex, tagDataList, MessageEnumData.ForceGrmID.Singular);
                    break;

                case MessageEnumData.ITID.ForcePlural:
                    SetForceGrmId(listIndex, tagDataList, MessageEnumData.ForceGrmID.Plural);
                    break;

                case MessageEnumData.ITID.ForceMasculine:
                    SetForceGrmId(listIndex, tagDataList, MessageEnumData.ForceGrmID.Masculine);
                    break;

                case MessageEnumData.ITID.ForceInitialCap:
                    SetForceGrmId(listIndex, tagDataList, MessageEnumData.ForceGrmID.InitialCap);
                    break;
            }
        }

        private void DETagReference(int listIndex, LabelTagDataModel tagData, List<LabelTagDataModel> tagDataList)
        {
            switch ((MessageEnumData.DEID)tagData.tagID)
            {
                case MessageEnumData.DEID.ForceSingular:
                    SetForceGrmId(listIndex, tagDataList, MessageEnumData.ForceGrmID.Singular);
                    break;

                case MessageEnumData.DEID.ForcePlural:
                    SetForceGrmId(listIndex, tagDataList, MessageEnumData.ForceGrmID.Plural);
                    break;

                case MessageEnumData.DEID.ForceInitialCap:
                    SetForceGrmId(listIndex, tagDataList, MessageEnumData.ForceGrmID.InitialCap);
                    break;
            }
        }

        private void ESTagReference(int listIndex, LabelTagDataModel tagData, List<LabelTagDataModel> tagDataList)
        {
            switch ((MessageEnumData.ESID)tagData.tagID)
            {
                case MessageEnumData.ESID.ForceSingular:
                    SetForceGrmId(listIndex, tagDataList, MessageEnumData.ForceGrmID.Singular);
                    break;

                case MessageEnumData.ESID.ForcePlural:
                    SetForceGrmId(listIndex, tagDataList, MessageEnumData.ForceGrmID.Plural);
                    break;

                case MessageEnumData.ESID.ForceInitialCap:
                    SetForceGrmId(listIndex, tagDataList, MessageEnumData.ForceGrmID.InitialCap);
                    break;
            }
        }

        private void SetForceGrmId(int listIndex, List<LabelTagDataModel> tagDataList, MessageEnumData.ForceGrmID forceGrmId)
        {
            for (int i=listIndex+1; i<tagDataList.Count; i++)
            {
                tagDataList[i].forceGrmID = forceGrmId;

                if (tagDataList[i].patternID == MessageEnumData.TagPatternID.Word)
                    break;
            }
        }

        private WordData[] CreateWordDataArray(LabelParseDataModel parseDataModel, out string errorMsg)
        {
            errorMsg = string.Empty;
            fontTagLangID = msgLangID;
            sizeTagScale = 100;

            var sb = new StringBuilder();
            wordDataList.Clear();

            int tagCharCount = 0;
            int tagCount = 0;

            foreach (var str in parseDataModel.StringList)
            {
                if (str.Length != 1)
                {
                    sb.Append(str);
                    continue;
                }

                switch (str[0])
                {
                    case NEW_LINE_CHAR:
                        AddNewLineWordData(MessageEnumData.MsgEventID.NewLine, sb.ToString());
                        sb.Clear();
                        break;

                    case MessageDataConstants.TAG_CHAR:
                        var tag = parseDataModel.TagDataList[tagCharCount];
                        switch (tag.patternID)
                        {
                            case MessageEnumData.TagPatternID.Word:
                            case MessageEnumData.TagPatternID.Digit:
                            case MessageEnumData.TagPatternID.GrammarWord:
                                AddStrWordData(sb.ToString());
                                sb.Clear();
                                wordDataList.Add(new WordData
                                {
                                    patternID = MessageEnumData.WordDataPatternID.WordTag,
                                    eventID = MessageEnumData.MsgEventID.None,
                                    tagIndex = tagCount,
                                });
                                tagCount++;
                                break;

                            case MessageEnumData.TagPatternID.RichText:
                                AddStrWordData(sb.ToString());
                                sb.Clear();
                                switch (tag.tagGroupID)
                                {
                                    case MessageEnumData.GroupTagID.System:
                                        switch ((MessageEnumData.SystemID)tag.tagID)
                                        {
                                            case MessageEnumData.SystemID.Font:
                                                fontTagLangID = MessageDataConstants.CONVERT_LANG_ID_TABLE[(int)(tag.langID == 0 ? msgLangID : tag.langID)];
                                                wordDataList.Add(new WordData
                                                {
                                                    patternID = MessageEnumData.WordDataPatternID.FontTag,
                                                    str = tag.strValue,
                                                    eventID = MessageEnumData.MsgEventID.None,
                                                });
                                                break;

                                            case MessageEnumData.SystemID.Size:
                                                sizeTagScale = tag.tagParameter != 0 ? tag.tagParameter : 100;
                                                wordDataList.Add(new WordData
                                                {
                                                    patternID = MessageEnumData.WordDataPatternID.SizeTag,
                                                    str = tag.strValue,
                                                    eventID = MessageEnumData.MsgEventID.None,
                                                });
                                                break;

                                            case MessageEnumData.SystemID.Color:
                                                wordDataList.Add(new WordData
                                                {
                                                    patternID = MessageEnumData.WordDataPatternID.ColorTag,
                                                    str = tag.strValue,
                                                    eventID = MessageEnumData.MsgEventID.None,
                                                });
                                                break;

                                            default:
                                                wordDataList.Add(new WordData
                                                {
                                                    str = tag.strValue,
                                                    eventID = MessageEnumData.MsgEventID.None,
                                                });
                                                break;
                                        }
                                        break;

                                    case MessageEnumData.GroupTagID.Ctrl1:
                                        switch ((MessageEnumData.Ctrl1ID)tag.tagID)
                                        {
                                            case MessageEnumData.Ctrl1ID.xright:
                                            case MessageEnumData.Ctrl1ID.xadd:
                                            case MessageEnumData.Ctrl1ID.xset:
                                                wordDataList.Add(new WordData
                                                {
                                                    patternID = MessageEnumData.WordDataPatternID.CtrlTag,
                                                    str = tag.strValue,
                                                    eventID = MessageEnumData.MsgEventID.None,
                                                });
                                                break;

                                            default:
                                                wordDataList.Add(new WordData
                                                {
                                                    str = tag.strValue,
                                                    eventID = MessageEnumData.MsgEventID.None,
                                                });
                                                break;
                                        }
                                        break;
                                }
                                break;

                            case MessageEnumData.TagPatternID.ControlMessage:
                                var ctrl2Data = CreateEventDataByCtrl2ID((MessageEnumData.Ctrl2ID)tag.tagID, tag.tagParameter);
                                switch (ctrl2Data.endEventId)
                                {
                                    case MessageEnumData.MsgEventID.Wait:
                                    case MessageEnumData.MsgEventID.CallBack:
                                    case MessageEnumData.MsgEventID.GuidIcon:
                                        wordDataList.Add(new WordData
                                        {
                                            patternID = MessageEnumData.WordDataPatternID.Event,
                                            tagValue = ctrl2Data.tagParameter,
                                            eventID = ctrl2Data.endEventId,
                                            str = sb.ToString(),
                                        });
                                        sb.Clear();
                                        break;

                                    case MessageEnumData.MsgEventID.NewLine:
                                    case MessageEnumData.MsgEventID.ScrollPage:
                                    case MessageEnumData.MsgEventID.ScrollLine:
                                        AddNewLineWordData(ctrl2Data.endEventId, sb.ToString());
                                        sb.Clear();
                                        break;
                                }
                                break;

                            case MessageEnumData.TagPatternID.SpriteFont:
                                AddStrWordData(sb.ToString());
                                sb.Clear();
                                wordDataList.Add(new WordData
                                {
                                    patternID = MessageEnumData.WordDataPatternID.SpriteFont,
                                    eventID = MessageEnumData.MsgEventID.None,
                                    tagIndex = tagCount,
                                });
                                tagCount++;
                                break;
                        }
                        tagCharCount++;
                        break;

                    case MessageDataConstants.PAGE_CHANGE_CHAR:
                        AddNewLineWordData(MessageEnumData.MsgEventID.ScrollPage, sb.ToString());
                        sb.Clear();
                        break;

                    case MessageDataConstants.PAGE_SCROLL_CHAR:
                        AddNewLineWordData(MessageEnumData.MsgEventID.ScrollLine, sb.ToString());
                        sb.Clear();
                        break;

                    default:
                        sb.Append(str[0]);
                        break;
                }
            }

            if (sb.Length > 0)
                AddStrWordData(sb.ToString());

            if (wordDataList.Count < 1)
            {
                wordDataList.Add(new WordData
                {
                    patternID = MessageEnumData.WordDataPatternID.Event,
                    eventID = MessageEnumData.MsgEventID.End,
                });
            }
            else
            {
                var item = wordDataList[wordDataList.Count - 1];
                switch (item.eventID)
                {
                    case MessageEnumData.MsgEventID.NewLine:
                        if (string.IsNullOrEmpty(item.str))
                        {
                            errorMsg = "改行タグの直後に改行コードが利用されています";
                            if (wordDataList.Count > 1)
                            {
                                wordDataList[wordDataList.Count - 2].eventID = MessageEnumData.MsgEventID.End;
                                wordDataList.RemoveAt(wordDataList.Count - 1);
                                break;
                            }
                        }
                        item.eventID = MessageEnumData.MsgEventID.End;
                        break;

                    case MessageEnumData.MsgEventID.Wait:
                    case MessageEnumData.MsgEventID.CallBack:
                        wordDataList.Add(new WordData
                        {
                            patternID = MessageEnumData.WordDataPatternID.Event,
                            eventID = MessageEnumData.MsgEventID.End,
                        });
                        break;

                    case MessageEnumData.MsgEventID.End:
                        break;

                    default:
                        item.eventID = MessageEnumData.MsgEventID.End;
                        break;
                }
            }

            return wordDataList.ToArray();
        }

        private MsgEventData CreateEventDataByCtrl2ID(MessageEnumData.Ctrl2ID tagId, float tagParameter)
        {
            var msgData = new MsgEventData();

            switch (tagId)
            {
                case MessageEnumData.Ctrl2ID.LineFeed:
                    msgData.endEventId = MessageEnumData.MsgEventID.ScrollLine;
                    return msgData;

                case MessageEnumData.Ctrl2ID.PageClear:
                    msgData.endEventId = MessageEnumData.MsgEventID.ScrollPage;
                    msgData.tagParameter = tagParameter;
                    return msgData;

                case MessageEnumData.Ctrl2ID.CallBackOne:
                    msgData.endEventId = MessageEnumData.MsgEventID.CallBack;
                    msgData.tagParameter = tagParameter;
                    return msgData;

                case MessageEnumData.Ctrl2ID.GuidIcon:
                    msgData.endEventId = MessageEnumData.MsgEventID.GuidIcon;
                    return msgData;

                default:
                    msgData.endEventId = MessageEnumData.MsgEventID.End;
                    MessageHelper.EmitLog(string.Format("Not Found Ctrl2Tag : {0}", tagId), UnityEngine.LogType.Warning);
                    return msgData;
            }
        }

        private void AddStrWordData(string str)
        {
            if (string.IsNullOrEmpty(str))
                return;

            var wordData = new WordData
            {
                patternID = MessageEnumData.WordDataPatternID.Str,
                eventID = MessageEnumData.MsgEventID.None,
                str = str,
                strWidth = CalcStrWidth(str)
            };
            wordDataList.Add(wordData);
        }

        private void AddNewLineWordData(MessageEnumData.MsgEventID eventID, string str)
        {
            if (string.IsNullOrEmpty(str) && wordDataList.Count > 0)
            {
                switch (wordDataList[wordDataList.Count-1].eventID)
                {
                    case MessageEnumData.MsgEventID.NewLine:
                    case MessageEnumData.MsgEventID.ScrollPage:
                    case MessageEnumData.MsgEventID.ScrollLine:
                    case MessageEnumData.MsgEventID.End:
                        return;
                }
            }

            var wordData = new WordData
            {
                patternID = MessageEnumData.WordDataPatternID.Event,
                eventID = eventID,
                str = str,
                strWidth = CalcStrWidth(str)
            };
            wordDataList.Add(wordData);
        }

        public void SetFontAsset(MessageEnumData.MsgLangId langID)
        {
            if (msgLangID != MessageEnumData.MsgLangId.Num &&
                MessageDataConstants.CONVERT_LANG_ID_TABLE[(int)msgLangID] == MessageDataConstants.CONVERT_LANG_ID_TABLE[(int)langID])
                return;

            int index = MessageFontDataConstants.FONT_FILE_TABLE[(int)MessageDataConstants.CONVERT_LANG_ID_TABLE[(int)langID]];

            _ = MessageFontDataConstants.FONT_FILE_NAME_ARRAY[index];
        }

        private float CalcStrWidth(string str)
        {
            if (fontAsset != null && fontSize > 0.0f && !string.IsNullOrEmpty(str))
            {
                TMP_FontAsset fontToUse = null;
                if (msgLangID == fontTagLangID)
                    fontToUse = fontAsset;

                return MessageHelper.CheckMessageWidth(fontToUse, str, sizeTagScale / 100.0f);
            }

            return 0.0f;
        }

        private class MsbtFileData
        {
	        public MessageEnumData.MsgLangId langID;
            public LabelDataModel[] labelDataModelArray;
            public BinMsgFile binMsgFile;

            public int LabelNum { get => labelDataModelArray.Length; }

            public MsbtFileData()
            {
                langID = MessageEnumData.MsgLangId.JPN;
            }

            public MessageAttributeDataModel GetAttributeDataModel(int labelIndex)
            {
                var labelName = labelDataModelArray[labelIndex].labelName;
                var model = new MessageAttributeDataModel();

                switch (MessageDataConstants.CONVERT_LANG_ID_TABLE[(int)langID])
                {
                    case MessageEnumData.MsgLangId.USA:
                        model.ApplyENAttributeData(binMsgFile, labelName);
                        break;

                    case MessageEnumData.MsgLangId.FRA:
                        model.ApplyFRAttributeData(binMsgFile, labelName);
                        break;

                    case MessageEnumData.MsgLangId.ITA:
                        model.ApplyITAttributeData(binMsgFile, labelName);
                        break;

                    case MessageEnumData.MsgLangId.DEU:
                        model.ApplyDEAttributeData(binMsgFile, labelName);
                        break;

                    case MessageEnumData.MsgLangId.ESP:
                        model.ApplyESAttributeData(binMsgFile, labelName);
                        break;
                }

                return model;
            }

            public MessageEnumData.MsgControlID CheckControlID(int labelIndex)
            {
                foreach (var model in labelDataModelArray[labelIndex].TagDataList)
                {
                    if (model.tagGroupID == MessageEnumData.GroupTagID.Ctrl1)
                    {
                        switch ((MessageEnumData.Ctrl1ID)model.tagID)
                        {
                            case MessageEnumData.Ctrl1ID.battle_oneline:
                                return MessageEnumData.MsgControlID.BattleOneline;

                            case MessageEnumData.Ctrl1ID.unknown_message:
                                return MessageEnumData.MsgControlID.UnknownMessage;
                        }
                    }
                }

                return MessageEnumData.MsgControlID.None;
            }

            public int GetMaxDataIndex()
            {
                int max = 0;

                for (int i=0; i<labelDataModelArray.Length; i++)
                {
                    if (labelDataModelArray[i] != null)
                    {
                        int tempMax = GetIndexAttributeData(labelDataModelArray[i].labelIndex);

                        if (max < tempMax)
                            max = tempMax;
                    }
                }

                return max + 1;
            }

            public int GetIndexAttributeData(int labelIndex)
            {
                return binMsgFile.GetIndexAttribute(binMsgFile.GetAttributes(labelDataModelArray[labelIndex].labelName), 65);
            }
        }

        private class LabelDataModel
        {
	        public LabelParseDataModel parseDataModel;
            public string labelName;
            public int labelIndex;
            public int arrayIndex;
            public int styleIndex;
            public int patchVersion;

            public List<LabelTagDataModel> TagDataList { get => parseDataModel.TagDataList; }
        }

        private class MsgEventData
        {
            public MessageEnumData.MsgEventID endEventId;
            public float tagParameter;
        }
    }
}
