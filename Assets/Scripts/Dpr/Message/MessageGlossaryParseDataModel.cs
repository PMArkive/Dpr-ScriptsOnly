using System.Collections.Generic;
using System.Text;

namespace Dpr.Message
{
    public class MessageGlossaryParseDataModel
    {
        private List<MessageTagDataModel> tagDataList = new List<MessageTagDataModel>();
        private SetupTagReference setupTagRef = new SetupTagReference();
        private MessageFormatter msgFormatter = new MessageFormatter();
        private LabelData labelData;
        private MessageEnumData.MsgLangId langID;
        private StringBuilder textSb = new StringBuilder(MessageDataConstants.TEXT_CAPACITY_SIZE);
        private AttributeInfo attributeInfo;
        private float strWidth;
        private float fontSize;

        public void Dispose()
        {
            msgFormatter.Dispose();
        }

        public void SetLabelData(LabelData labelData, MessageEnumData.MsgLangId langID)
        {
            this.labelData = labelData;
            this.langID = langID;

            if (labelData == null)
                return;

            if (string.IsNullOrEmpty(labelData.labelName))
            {
                var log = string.Format("{0} : LabelName not found!!", labelData.labelIndex);
                // Commented out Logging
                //MessageHelper.EmitLog(log, UnityEngine.LogType.Error);
            }

            attributeInfo = new AttributeInfo(labelData.attributeValueArray);
            fontSize = labelData.styleInfo.fontSize;

            for (int i=0; i<labelData.wordDataArray.Length; i++)
            {
                if (labelData.wordDataArray[i].strWidth < 0.0f)
                {
                    strWidth = -1.0f;
                    break;
                }

                strWidth += labelData.wordDataArray[i].strWidth;
            }

            msgFormatter.Initialize();

            for (int i=0; i<labelData.tagDataArray.Length; i++)
            {
                var tag = new MessageTagDataModel();
                tag.SetTagData(labelData.tagDataArray[i]);
                tagDataList.Add(tag);
            }
        }

        public List<MessageTagDataModel> TagDataList { get => tagDataList; }
        public AttributeInfo AttributeDataModel { get => attributeInfo; }
        public WordData[] WordDataArray { get => labelData?.wordDataArray; }
        public float FontSize { get => fontSize; }
        public float StrWidth { get => strWidth; }

        public void SetTagWord(int setTargetIndex, string word, float strWidth)
        {
            if (setTargetIndex < tagDataList.Count)
            {
                tagDataList[setTargetIndex].strValue = word;
                tagDataList[setTargetIndex].strWidth = strWidth;
            }
        }

        public string GetName()
        {
            if (textSb.Length > 0)
                return textSb.ToString();

            setupTagRef.SetTagReference(tagDataList);
            textSb.Append(msgFormatter.FormatGlossary(this, langID));
            msgFormatter.Dispose();

            return textSb.ToString();
        }
    }
}
