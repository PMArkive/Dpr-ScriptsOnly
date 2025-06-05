using System;
using UnityEngine;

namespace Dpr.Message
{
    [Serializable]
    public class DigitWordParam : AWordParamBase
    {
        private MessageEnumData.ForceGrmID forceGrmId;

        public DigitWordParam(int count)
        {
            this.count = count;
            languageId = MessageManager.Instance.UserLanguageID;
        }

        public DigitWordParam(string countStr)
        {
            strValue = countStr;
            languageId = MessageManager.Instance.UserLanguageID;

            if (int.TryParse(countStr, out int parsedInt))
                count = parsedInt;
            else
                MessageHelper.EmitLog(countStr + " is can't parse to int", LogType.Error);
        }

        public DigitWordParam(int count, MessageEnumData.ForceGrmID forceGrmId)
        {
            this.count = count;
            this.forceGrmId = forceGrmId;
            languageId = MessageManager.Instance.UserLanguageID;
        }

        public override void SetWordParam(MessageTagDataModel tagDataModel)
        {
            tagDataModel.languageId = languageId;
            tagDataModel.SetWordParam(strValue, count, gender, initialSound, articlePresence, countablity, strWidth, forceGrmId);
        }
    }
}
