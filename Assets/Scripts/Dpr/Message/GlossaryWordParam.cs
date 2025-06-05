using System;

namespace Dpr.Message
{
    [Serializable]
    public class GlossaryWordParam : AWordParamBase
    {
        public GlossaryWordParam(MessageGlossaryParseDataModel dataModel, int count, MessageEnumData.MsgLangId languageId)
        {
            if (dataModel == null)
                return;

            strValue = dataModel.GetName();
            this.languageId = languageId;
            this.count = count;
            gender = dataModel.AttributeDataModel.gender;
            initialSound = dataModel.AttributeDataModel.initialSound;
            countablity = dataModel.AttributeDataModel.countability;
            articlePresence = dataModel.AttributeDataModel.articlePresence;
            strWidth = dataModel.StrWidth;
        }
    }
}