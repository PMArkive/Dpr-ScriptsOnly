using System.Collections.Generic;
using System.Text;
using static Dpr.Message.MessageDataConstants;

namespace Dpr.Message
{
    public class MessageFormatter
    {
        private const int INIT_LIST_CAPACITY = 16;
        private List<MessageTextLineDataModel> lineMessageDataList;
        private StringBuilder strBuilder = new StringBuilder(TEXT_CAPACITY_SIZE);
        private FormatTagCommon commonFormatter = new FormatTagCommon();
        private FormatTagGrammar grammarFormatter = new FormatTagGrammar();

        public void Initialize()
        {
            commonFormatter.Initialize();
        }

        public void Dispose()
        {
            strBuilder.Clear();
            if (lineMessageDataList != null)
            {
                foreach (var msgData in lineMessageDataList)
                    msgData.Dispose();

                lineMessageDataList.Clear();
                lineMessageDataList = null;
            }
        }

        public string FormatGlossary(MessageGlossaryParseDataModel parseDataModel, MessageEnumData.MsgLangId languageId)
        {
            strBuilder.Clear();

            for (int i=0; i<parseDataModel.WordDataArray.Length; i++)
            {
                var word = parseDataModel.WordDataArray[i];
                switch (word.patternID)
                {
                    case MessageEnumData.WordDataPatternID.Str:
                        strBuilder.Append(word.str);
                        break;

                    case MessageEnumData.WordDataPatternID.WordTag:
                        strBuilder.Append(GetTagNameDataStr(parseDataModel.TagDataList[word.tagIndex], languageId));
                        break;

                    case MessageEnumData.WordDataPatternID.Event:
                        strBuilder.Append(word.str);
                        if (word.eventID == MessageEnumData.MsgEventID.NewLine)
                            strBuilder.Append("\n");
                        break;
                }
            }

            return strBuilder.ToString();
        }

        public string FormatSimple(MessageTextParseDataModel parseDataModel)
        {
            strBuilder.Clear();

            for (int i=0; i<parseDataModel.WordDataArray.Length; i++)
            {
                var word = parseDataModel.WordDataArray[i];
                switch (word.patternID)
                {
                    case MessageEnumData.WordDataPatternID.Str:
                    case MessageEnumData.WordDataPatternID.SpriteFont:
                        strBuilder.Append(word.str);
                        break;

                    case MessageEnumData.WordDataPatternID.Event:
                        switch (word.eventID)
                        {
                            case MessageEnumData.MsgEventID.NewLine:
                            case MessageEnumData.MsgEventID.ScrollPage:
                            case MessageEnumData.MsgEventID.ScrollLine:
                                strBuilder.Append(word.str);
                                strBuilder.Append("\n");
                                break;

                            case MessageEnumData.MsgEventID.End:
                                strBuilder.Append(word.str);
                                break;
                        }
                        break;
                }
            }

            return strBuilder.ToString();
        }

        public MessageTextLineDataModel[] Format(MessageTextParseDataModel parseDataModel, MessageEnumData.MsgLangId languageId)
        {
            ApplyGlossaryName(parseDataModel);
            FormatMessage(parseDataModel, languageId);
            return lineMessageDataList.ToArray();
        }

        private void ApplyGlossaryName(MessageTextParseDataModel parseDataModel)
        {
            for (int i=0; i<parseDataModel.TagDataList.Count; i++)
            {
                var tag = parseDataModel.TagDataList[i];
                if (tag.patternId != MessageEnumData.TagPatternID.Word)
                    continue;

                switch (tag.tagGroupId)
                {
                    case MessageEnumData.GroupTagID.Name:
                        switch ((MessageEnumData.NameID)tag.tagId)
                        {
                            case MessageEnumData.NameID.Place:
                                if (tag.isPlaceWord)
                                    tag.SetGlossaryData(GetGlossaryDataModel(AREANAME_FILE_NAME, tag.strValue));
                                break;

                            case MessageEnumData.NameID.Item:
                                tag.SetGlossaryData(GetParseDataModelByCount(tag.intValue, tag.GetQtyId(), ITEM_FILE_NAME, ITEM_PLURAL_FILE_NAME));
                                break;

                            case MessageEnumData.NameID.ItemClassified:
                                tag.SetGlossaryData(GetParseDataModelByCount(tag.intValue, tag.GetQtyId(), ITEM_CLASSIFIED_FILE_NAME, ITEM_CLASSIFIED_PLURAL_FILE_NAME));
                                break;

                            case MessageEnumData.NameID.ItemAcc:
                                tag.SetGlossaryData(GetParseDataModelByCount(tag.intValue, tag.GetQtyId(), ITEM_ACC_FILE_NAME, ITEM_PLURAL_FILE_NAME));
                                break;

                            case MessageEnumData.NameID.Poffin:
                                tag.SetGlossaryData(GetParseDataModelByCount(tag.intValue, tag.GetQtyId(), POFFIN_NAME_MSBT_FILE, POFFIN_NAME_PLURAL_MSBT_FILE));
                                break;

                            case MessageEnumData.NameID.ItemAccClassified:
                                tag.SetGlossaryData(GetParseDataModelByCount(tag.intValue, tag.GetQtyId(), ITEM_ACC_CLASSIFIED_FILE_NAME, ITEM_CLASSIFIED_PLURAL_FILE_NAME));
                                break;

                            case MessageEnumData.NameID.UgItem:
                                tag.SetGlossaryData(GetParseDataModelByCount(tag.intValue, tag.GetQtyId(), UG_ITEM_FILE_NAME, UG_ITEM_PLURAL_FILE_NAME));
                                break;

                            case MessageEnumData.NameID.PlaceIndirect:
                                tag.SetGlossaryData(GetGlossaryDataModel(AREANAME_INDIRECT_FILE_NAME, tag.strValue));
                                break;

                            case MessageEnumData.NameID.Sticker:
                                tag.SetGlossaryData(GetParseDataModelByCount(tag.intValue, tag.GetQtyId(), STICKER_FILE_NAME, STICKER_PLURAL_FILE_NAME));
                                break;

                            case MessageEnumData.NameID.ParkItem:
                                tag.SetGlossaryData(GetParseDataModelByCount(tag.intValue, tag.GetQtyId(), PARK_ITEM_FILE_NAME, PARK_ITEM_PLURAL_FILE_NAME));
                                break;

                            case MessageEnumData.NameID.UgItemAcc:
                                tag.SetGlossaryData(GetParseDataModelByCount(tag.intValue, tag.GetQtyId(), UG_ITEM_ACC_FILE_NAME, UG_ITEM_PLURAL_FILE_NAME));
                                break;

                            case MessageEnumData.NameID.UgItemClassified:
                                tag.SetGlossaryData(GetParseDataModelByCount(tag.intValue, tag.GetQtyId(), UG_ITEM_CLASSIFIED_FILE_NAME, UG_ITEM_CLASSIFIED_PLURAL_FILE_NAME));
                                break;

                            case MessageEnumData.NameID.UgItemAccClassified:
                                tag.SetGlossaryData(GetParseDataModelByCount(tag.intValue, tag.GetQtyId(), UG_ITEM_ACC_CLASSIFIED_FILE_NAME, UG_ITEM_CLASSIFIED_PLURAL_FILE_NAME));
                                break;

                            case MessageEnumData.NameID.PoffinAcc:
                                tag.SetGlossaryData(GetParseDataModelByCount(tag.intValue, tag.GetQtyId(), POFFIN_NAME_ACC_MSBT_FILE, POFFIN_NAME_PLURAL_MSBT_FILE));
                                break;
                        }
                        break;

                    case MessageEnumData.GroupTagID.DE:
                        switch ((MessageEnumData.DEID)tag.tagId)
                        {
                            case MessageEnumData.DEID.ItemAcc:
                                tag.SetGlossaryData(GetParseDataModelByCount(tag.intValue, tag.GetQtyId(), ITEM_ACC_FILE_NAME, ITEM_PLURAL_FILE_NAME));
                                break;

                            case MessageEnumData.DEID.ItemAccClassified:
                                tag.SetGlossaryData(GetParseDataModelByCount(tag.intValue, tag.GetQtyId(), ITEM_ACC_CLASSIFIED_FILE_NAME, ITEM_CLASSIFIED_PLURAL_FILE_NAME));
                                break;
                        }
                        break;
                }
            }
        }

        private MessageGlossaryParseDataModel GetParseDataModelByCount(int labelIndex, MessageEnumData.QtyID qtyId, string singleMsbtName, string pluralMsbtName)
        {
            switch (qtyId)
            {
                case MessageEnumData.QtyID.Plural:
                    return GetGlossaryDataModel(pluralMsbtName, labelIndex);

                default:
                    return GetGlossaryDataModel(singleMsbtName, labelIndex);
            }
        }

        private MessageGlossaryParseDataModel GetGlossaryDataModel(string msbtName, int itemNumber)
        {
            return MessageManager.Instance.GetNameMessageDataModel(msbtName, itemNumber, MessageManager.Instance.UserLanguageID);
        }

        private MessageGlossaryParseDataModel GetGlossaryDataModel(string msbtName, string labelName)
        {
            return MessageManager.Instance.GetNameMessageDataModel(msbtName, labelName, MessageManager.Instance.UserLanguageID);
        }

        private void FormatMessage(MessageTextParseDataModel parseDataModel, MessageEnumData.MsgLangId languageId)
        {
            var fontAsset = FontManager.Instance.GetFontAssetByLangId(languageId);
            float fontSize = parseDataModel.FontSize;
            int ptSize = fontAsset.creationSettings.pointSize;

            strBuilder.Clear();
            var model = new MessageTextLineDataModel();
            lineMessageDataList = new List<MessageTextLineDataModel>(INIT_LIST_CAPACITY);

            fontSize /= ptSize;
            float strWidth = -1.0f;
            for (int i=0; i<parseDataModel.WordDataArray.Length; i++)
            {
                var word = parseDataModel.WordDataArray[i];
                switch (word.patternID)
                {
                    case MessageEnumData.WordDataPatternID.Str:
                    case MessageEnumData.WordDataPatternID.SpriteFont:
                        strBuilder.Append(word.str);
                        strWidth += fontSize * word.strWidth;
                        break;

                    case MessageEnumData.WordDataPatternID.FontTag:
                    case MessageEnumData.WordDataPatternID.ColorTag:
                    case MessageEnumData.WordDataPatternID.SizeTag:
                    case MessageEnumData.WordDataPatternID.CtrlTag:
                        AddStrData(model, languageId, strWidth, word.tagValue, word.eventID);
                        strBuilder.Clear();
                        model.AddFontTagData(word, languageId);
                        strWidth = 0.0f;
                        break;

                    case MessageEnumData.WordDataPatternID.WordTag:
                        if (strBuilder.Length > 0)
                            model.AddTextData(strBuilder.ToString(), languageId, strWidth, 0.0f, MessageEnumData.MsgEventID.None);
                        strBuilder.Clear();

                        var tagData = parseDataModel.TagDataList[word.tagIndex];

                        if (!tagData.IsUserInputWordTag())
                        {
                            model.AddNameTextData(GetTagNameDataStr(tagData, languageId), languageId, fontSize * tagData.strWidth, false);
                        }
                        else
                        {
                            if (tagData.languageId == languageId && MessageHelper.ExistMissingChara(fontAsset, tagData.GetStrValue()))
                                model.AddNameTextData(string.Empty, tagData.languageId, -1.0f, tagData.IsNameWord());
                            else
                                model.AddNameTextData(tagData.GetStrValue().GetInvalidRichText(), tagData.languageId, -1.0f, tagData.IsNameWord());
                        }

                        strWidth = 0.0f;
                        break;

                    case MessageEnumData.WordDataPatternID.Event:
                        switch (word.eventID)
                        {
                            case MessageEnumData.MsgEventID.NewLine:
                            case MessageEnumData.MsgEventID.ScrollPage:
                            case MessageEnumData.MsgEventID.ScrollLine:
                                strBuilder.Append(word.str);
                                AddLineDataModel(word.eventID, model, languageId, strWidth + fontSize * word.strWidth);
                                strBuilder.Clear();
                                model = new MessageTextLineDataModel();
                                strWidth = 0.0f;
                                break;

                            case MessageEnumData.MsgEventID.End:
                                strBuilder.Append(word.str);
                                model.FinishLineMessageData(strBuilder.ToString(), MessageEnumData.MsgEventID.End, languageId, strWidth + fontSize * word.strWidth);
                                strBuilder.Clear();
                                AddLineMessageDataList(model);
                                model = new MessageTextLineDataModel();
                                strWidth = 0.0f;
                                break;

                            default:
                                strBuilder.Append(word.str);
                                AddStrData(model, languageId, strWidth + fontSize * word.strWidth, word.tagValue, word.eventID);
                                strBuilder.Clear();
                                strWidth = 0.0f;
                                break;
                        }
                        break;

                    default:
                        break;
                }
            }

            if (strBuilder.Length > 0)
            {
                model.AddTextData(strBuilder.ToString(), languageId, strWidth, 0.0f, MessageEnumData.MsgEventID.None);
                strBuilder.Clear();
                strWidth = 0.0f;
            }

            if (model.HasMessageData)
            {
                AddLineDataModel(MessageEnumData.MsgEventID.End, model, languageId, strWidth);
                strBuilder.Clear();
            }
        }

        private void AddStrData(MessageTextLineDataModel lineMessageData, MessageEnumData.MsgLangId languageId, float strWidth, float tagValue = 0.0f, MessageEnumData.MsgEventID endEventId = MessageEnumData.MsgEventID.None)
        {
            if (endEventId == MessageEnumData.MsgEventID.None && strBuilder.Length < 1)
                return;

            lineMessageData.AddTextData(strBuilder.ToString(), languageId, strWidth, tagValue, endEventId);
        }

        private void AddLineDataModel(MessageEnumData.MsgEventID endEventId, MessageTextLineDataModel lineMessageData, MessageEnumData.MsgLangId languageId, float strWidth)
        {
            if (strBuilder.Length < 1 && !lineMessageData.HasShowMessageData())
                return;

            lineMessageData.FinishLineMessageData(strBuilder.ToString(), endEventId, languageId, strWidth);
            AddLineMessageDataList(lineMessageData);
        }

        private void AddLineMessageDataList(MessageTextLineDataModel addData)
        {
            lineMessageDataList.Add(addData);
        }

        private string GetTagNameDataStr(MessageTagDataModel tagDataModel, MessageEnumData.MsgLangId languageId)
        {
            if (tagDataModel == null)
                return string.Empty;

            switch (tagDataModel.tagGroupId)
            {
                case MessageEnumData.GroupTagID.Name:
                    return FormatNameTagProcess(tagDataModel, languageId);

                case MessageEnumData.GroupTagID.Digit:
                    return FormatDigitTagProcess(tagDataModel, languageId);

                case MessageEnumData.GroupTagID.EN:
                    return FormatENTagProcess(tagDataModel, languageId);

                case MessageEnumData.GroupTagID.FR:
                    return FormatFRTagProcess(tagDataModel, languageId);

                case MessageEnumData.GroupTagID.IT:
                    return FormatITTagProcess(tagDataModel, languageId);

                case MessageEnumData.GroupTagID.DE:
                    return FormatDETagProcess(tagDataModel, languageId);

                case MessageEnumData.GroupTagID.ES:
                    return FormatESTagProcess(tagDataModel, languageId);

                case MessageEnumData.GroupTagID.Kor:
                    return FormatKorTagProcess(tagDataModel, languageId);

                case MessageEnumData.GroupTagID.SC:
                    return FormatSCTagProcess(tagDataModel);

                default:
                    // Presumed logging that was commented out
                    //MessageHelper.EmitLog("Formatter : Used Tag Group {0} !!!!!!!", UnityEngine.LogType.Error);
                    return string.Empty;
            }
        }

        private string FormatNameTagProcess(MessageTagDataModel tagDataModel, MessageEnumData.MsgLangId languageId)
        {
            switch ((MessageEnumData.NameID)tagDataModel.tagId)
            {
                case MessageEnumData.NameID.PokeLevel:
                    if (tagDataModel.count > 0)
                        return tagDataModel.count.ToString();
                    else
                        return string.Empty;

                default:
                    return commonFormatter.FormatNameTag(tagDataModel, languageId);
            }
        }

        private string FormatDigitTagProcess(MessageTagDataModel tagDataModel, MessageEnumData.MsgLangId languageId)
        {
            return commonFormatter.FormatDigitTag((MessageEnumData.DigitID)tagDataModel.tagId, tagDataModel.tagParameter, tagDataModel.count, tagDataModel.strValue, languageId);
        }

        private string FormatENTagProcess(MessageTagDataModel tagDataModel, MessageEnumData.MsgLangId langID)
        {
            switch ((MessageEnumData.ENID)tagDataModel.tagId)
            {
                case MessageEnumData.ENID.Gen:
                    return commonFormatter.GetGenderStr(tagDataModel.tagParameter, tagDataModel.refTagData, tagDataModel.tagWords);

                case MessageEnumData.ENID.Qty:
                    return commonFormatter.GetQtyStr(tagDataModel.refTagData, tagDataModel.tagWords, langID);

                case MessageEnumData.ENID.GenQty:
                    return commonFormatter.GetGenderQty(tagDataModel.refTagData, tagDataModel.tagWords);

                case MessageEnumData.ENID.QtyZero:
                    return commonFormatter.GetQtyZeroStr(tagDataModel.refTagData, tagDataModel.tagWords);

                default:
                    return grammarFormatter.FormatENTag((MessageEnumData.ENID)tagDataModel.tagId, tagDataModel);
            }
        }

        private string FormatFRTagProcess(MessageTagDataModel tagDataModel, MessageEnumData.MsgLangId langID)
        {
            switch ((MessageEnumData.FRID)tagDataModel.tagId)
            {
                case MessageEnumData.FRID.Gen:
                    return commonFormatter.GetGenderStr(tagDataModel.tagParameter, tagDataModel.refTagData, tagDataModel.tagWords);

                case MessageEnumData.FRID.Qty:
                    return commonFormatter.GetQtyStr(tagDataModel.refTagData, tagDataModel.tagWords, langID);

                case MessageEnumData.FRID.GenQty:
                    return commonFormatter.GetGenderQty(tagDataModel.refTagData, tagDataModel.tagWords);

                case MessageEnumData.FRID.Elision:
                    return grammarFormatter.GetElisionStr(tagDataModel.refTagData, tagDataModel.tagWords);

                case MessageEnumData.FRID.QtyZero:
                    return commonFormatter.GetQtyZeroStr(tagDataModel.refTagData, tagDataModel.tagWords);

                default:
                    return grammarFormatter.FormatFRTag((MessageEnumData.FRID)tagDataModel.tagId, tagDataModel);
            }
        }

        private string FormatITTagProcess(MessageTagDataModel tagDataModel, MessageEnumData.MsgLangId langID)
        {
            switch ((MessageEnumData.ITID)tagDataModel.tagId)
            {
                case MessageEnumData.ITID.Gen:
                    return commonFormatter.GetGenderStr(tagDataModel.tagParameter, tagDataModel.refTagData, tagDataModel.tagWords);

                case MessageEnumData.ITID.Qty:
                    return commonFormatter.GetQtyStr(tagDataModel.refTagData, tagDataModel.tagWords, langID);

                case MessageEnumData.ITID.GenQty:
                    return commonFormatter.GetGenderQty(tagDataModel.refTagData, tagDataModel.tagWords);

                case MessageEnumData.ITID.QtyZero:
                    return commonFormatter.GetQtyZeroStr(tagDataModel.refTagData, tagDataModel.tagWords);

                case MessageEnumData.ITID.DateIT:
                    return grammarFormatter.GetDateITStr(tagDataModel.refTagData, tagDataModel.tagWords);

                default:
                    return grammarFormatter.FormatITTag((MessageEnumData.ITID)tagDataModel.tagId, tagDataModel);
            }
        }

        private string FormatDETagProcess(MessageTagDataModel tagDataModel, MessageEnumData.MsgLangId langID)
        {
            switch ((MessageEnumData.DEID)tagDataModel.tagId)
            {
                case MessageEnumData.DEID.Gen:
                    return commonFormatter.GetGenderStr(tagDataModel.tagParameter, tagDataModel.refTagData, tagDataModel.tagWords);

                case MessageEnumData.DEID.Qty:
                    return commonFormatter.GetQtyStr(tagDataModel.refTagData, tagDataModel.tagWords, langID);

                case MessageEnumData.DEID.GenQty:
                    return commonFormatter.GetDEGenderQty(tagDataModel.refTagData, tagDataModel.tagWords);

                case MessageEnumData.DEID.QtyZero:
                    return commonFormatter.GetQtyZeroStr(tagDataModel.refTagData, tagDataModel.tagWords);

                case MessageEnumData.DEID.ItemAcc:
                case MessageEnumData.DEID.ItemAccClassified:
                    return tagDataModel.GetStrValue();

                default:
                    return grammarFormatter.FormatDETag((MessageEnumData.DEID)tagDataModel.tagId, tagDataModel);
            }
        }

        private string FormatESTagProcess(MessageTagDataModel tagDataModel, MessageEnumData.MsgLangId langID)
        {
            switch ((MessageEnumData.ESID)tagDataModel.tagId)
            {
                case MessageEnumData.ESID.Gen:
                    return commonFormatter.GetGenderStr(tagDataModel.tagParameter, tagDataModel.refTagData, tagDataModel.tagWords);

                case MessageEnumData.ESID.Qty:
                    return commonFormatter.GetQtyStr(tagDataModel.refTagData, tagDataModel.tagWords, langID);

                case MessageEnumData.ESID.GenQty:
                    return commonFormatter.GetGenderQty(tagDataModel.refTagData, tagDataModel.tagWords);

                case MessageEnumData.ESID.QtyZero:
                    return commonFormatter.GetQtyZeroStr(tagDataModel.refTagData, tagDataModel.tagWords);

                default:
                    return grammarFormatter.FormatESTag((MessageEnumData.ESID)tagDataModel.tagId, tagDataModel);
            }
        }

        private string FormatKorTagProcess(MessageTagDataModel tagDataModel, MessageEnumData.MsgLangId langID)
        {
            switch ((MessageEnumData.KorID)tagDataModel.tagId)
            {
                case MessageEnumData.KorID.Gen:
                    return commonFormatter.GetGenderStr(tagDataModel.tagParameter, tagDataModel.refTagData, tagDataModel.tagWords);

                case MessageEnumData.KorID.Qty:
                    return commonFormatter.GetQtyStr(tagDataModel.refTagData, tagDataModel.tagWords, langID);

                case MessageEnumData.KorID.GenQty:
                    return commonFormatter.GetGenderQty(tagDataModel.refTagData, tagDataModel.tagWords);

                case MessageEnumData.KorID.QtyZero:
                    return commonFormatter.GetQtyZeroStr(tagDataModel.refTagData, tagDataModel.tagWords);

                default:
                    return grammarFormatter.FormatKorTag((MessageEnumData.KorID)tagDataModel.tagId, tagDataModel);
            }
        }

        private string FormatSCTagProcess(MessageTagDataModel tagDataModel)
        {
            switch ((MessageEnumData.SCID)tagDataModel.tagId)
            {
                case MessageEnumData.SCID.Gen:
                    return commonFormatter.GetGenderStr(tagDataModel.tagParameter, tagDataModel.refTagData, tagDataModel.tagWords);

                default:
                    return string.Empty;
            }
        }
    }
}