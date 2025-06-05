using System;

namespace Dpr.Message
{
    [Serializable]
    public class ItemNameWordParam : AWordParamBase
    {
        private int itemNumber;

        public ItemNameWordParam(int itemNumber, int count, MessageEnumData.MsgLangId languageId)
        {
            this.itemNumber = itemNumber;
            this.languageId = languageId;
            this.count = count;
        }

        public override void SetWordParam(MessageTagDataModel tagDataModel)
        {
            base.SetWordParam(tagDataModel);
            tagDataModel.intValue = itemNumber;
        }
    }
}