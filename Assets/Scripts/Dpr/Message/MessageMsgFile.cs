namespace Dpr.Message
{
    public class MessageMsgFile
    {
        private MsbtDataModel msbtDataModel;

        public MessageMsgFile(MsbtDataModel msbtDataModel)
        {
            this.msbtDataModel = msbtDataModel;
        }

        public MessageEnumData.MsgLangId LanguageID { get => msbtDataModel.langID; }

        public void ReplaceMsbtDataModel(MsbtDataModel msbtDataModel)
        {
            this.msbtDataModel = msbtDataModel;
        }

        public bool IsValidData()
        {
            return msbtDataModel?.LabelDataArray != null;
        }

        public LabelData[] GetAllLabelDataArray()
        {
            return msbtDataModel.LabelDataArray;
        }

        public int GetLabelIndex(string label)
        {
            return msbtDataModel.GetLabelDataByName(label)?.labelIndex ?? -1;
        }

        public string GetLabel(int index)
        {
            return msbtDataModel.GetLabelDataByIndex(index)?.labelName ?? string.Empty;
        }

        public string FileName { get => msbtDataModel.fileName; }

        public int GetTotalTextNum()
        {
            return msbtDataModel.GetTextNum();
        }

        public bool HasLabelByIndex(int labelIndex)
        {
            return !string.IsNullOrEmpty(msbtDataModel.GetLabelDataByIndex(labelIndex).labelName);
        }

        public string GetNameStr(string label)
        {
            return GetNameDataModel(label).GetName();
        }

        public string GetNameStr(int labelIndex)
        {
            return GetNameDataModelByIndex(labelIndex).GetName();
        }

        public MessageGlossaryParseDataModel GetNameDataModelByIndex(int labelIndex)
        {
            var labelData = msbtDataModel.GetLabelDataByIndex(labelIndex);
            var glossary = new MessageGlossaryParseDataModel();
            glossary.SetLabelData(labelData, msbtDataModel.langID);
            return glossary;
        }

        public MessageGlossaryParseDataModel GetNameDataModel(string label)
        {
            var labelData = msbtDataModel.GetLabelDataByName(label);
            var glossary = new MessageGlossaryParseDataModel();
            glossary.SetLabelData(labelData, msbtDataModel.langID);
            return glossary;
        }

        public string GetSimpleMessage(string label)
        {
            return GetTextDataModel(label).CreateSimpleMessage();
        }

        public string GetSimpleMessage(int labelIndex)
        {
            return GetTextDataModelByIndex(labelIndex).CreateSimpleMessage();
        }

        public string GetFormattedMessage(string label)
        {
            var model = GetTextDataModel(label);
            model.ApplyFormat();
            return model.GetAllText();
        }

        public string GetFormattedMessage(int labelIndex)
        {
            var model = GetTextDataModelByIndex(labelIndex);
            model.ApplyFormat();
            return model.GetAllText();
        }

        public MessageTextParseDataModel GetTextDataModel(string label)
        {
            var model = new MessageTextParseDataModel();
            var labelData = msbtDataModel.GetLabelDataByName(label);
            if (labelData != null)
                model.SetLabelData(labelData, msbtDataModel.langID);

            return model;
        }

        public MessageTextParseDataModel GetTextDataModelByIndex(int index)
        {
            MessageTextParseDataModel model = null;
            var labelData = msbtDataModel.GetLabelDataByIndex(index);
            if (labelData != null)
            {
                model = new MessageTextParseDataModel();
                model.SetLabelData(labelData, msbtDataModel.langID);
            }

            return model;
        }

        public void ClearWordParam()
        {
            MessageManager.Instance.TagWordBuffer.ClearWordParam();
        }

        public bool IsSetWordParam(int index)
        {
            return MessageManager.Instance.TagWordBuffer.IsSetTagWordParam(index);
        }
    }
}
