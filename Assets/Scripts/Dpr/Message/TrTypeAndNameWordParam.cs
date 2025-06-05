using System.Text;

namespace Dpr.Message
{
    public class TrTypeAndNameWordParam : AWordParamBase
    {
        private const int INIT_CAPACITY = 20;
        private StringBuilder sb = new StringBuilder(INIT_CAPACITY);

        public void SetFRSingleWordParam(TrTypeAndNameData typeAndNameData, MessageEnumData.MsgLangId languageId)
        {
            this.languageId = languageId;
            SetFRSingleWordParam(typeAndNameData);
        }

        public void SetFRPairWordParam(TrTypeAndNameData typeAndNameData, MessageEnumData.MsgLangId languageId)
        {
            this.languageId = languageId;
            SetFRSingleWordParam(typeAndNameData);
        }

        private void SetFRSingleWordParam(TrTypeAndNameData typeAndNameData)
        {
            count = 1;

            sb.Clear();
            AppendFRDisplayPattern(typeAndNameData.displayPattern, typeAndNameData);
            strValue = sb.ToString();
        }

        private void AppendFRDisplayPattern(int displayPattern, TrTypeAndNameData typeAndNameData)
        {
            var formatTagGrammar = new FormatTagGrammar();

            countablity = typeAndNameData.nameParam.countability;
            gender = typeAndNameData.nameParam.gender;
            initialSound = typeAndNameData.nameParam.initialSound;
            articlePresence = typeAndNameData.nameParam.articlePresence;

            sb.Append(typeAndNameData.nameParam.name + " ");

            var tagDataModel = new MessageTagDataModel();
            tagDataModel.SetWordParam(typeAndNameData.typeParam.name, 1, typeAndNameData.typeParam.gender, typeAndNameData.typeParam.initialSound,
                typeAndNameData.typeParam.articlePresence, typeAndNameData.typeParam.countability, typeAndNameData.typeParam.strWidth, false);

            switch (displayPattern)
            {
                case 0:
                    sb.Append(formatTagGrammar.FormatFRTag(MessageEnumData.FRID.DefArt, tagDataModel));
                    break;

                case 1:
                    sb.Append(formatTagGrammar.FormatFRTag(MessageEnumData.FRID.De_DefArt, tagDataModel));
                    break;

                case 2:
                    sb.Append(formatTagGrammar.FormatFRTag(MessageEnumData.FRID.De, tagDataModel));
                    break;
            }

            sb.Append(typeAndNameData.typeParam.name);
        }

        public void SetDESingleWordParam(TrTypeAndNameData typeAndNameData, MessageEnumData.MsgLangId languageId)
        {
            this.languageId = languageId;
            SetDESingleWordParam(typeAndNameData);
        }

        public void SetDEPairWordParam(TrTypeAndNameData typeAndNameData, MessageEnumData.MsgLangId languageId)
        {
            this.languageId = languageId;
            SetDESingleWordParam(typeAndNameData);
        }

        private void SetDESingleWordParam(TrTypeAndNameData typeAndNameData)
        {
            count = 1;

            sb.Clear();
            AppendDEDisplayPattern(typeAndNameData.displayPattern, typeAndNameData);
            strValue = sb.ToString();
        }

        private void AppendDEDisplayPattern(int displayPattern, TrTypeAndNameData typeAndNameData)
        {
            switch (displayPattern)
            {
                case 0:
                    countablity = typeAndNameData.typeParam.countability;
                    gender = typeAndNameData.typeParam.gender;
                    initialSound = typeAndNameData.typeParam.initialSound;
                    articlePresence = typeAndNameData.typeParam.articlePresence;
                    sb.Append(typeAndNameData.typeParam.name + " " + typeAndNameData.nameParam.name);
                    break;

                case 1:
                    countablity = typeAndNameData.nameParam.countability;
                    gender = typeAndNameData.nameParam.gender;
                    initialSound = typeAndNameData.nameParam.initialSound;
                    articlePresence = typeAndNameData.nameParam.articlePresence;
                    sb.Append(typeAndNameData.nameParam.name + " von den " + typeAndNameData.typeParam.name);
                    break;

                case 2:
                    countablity = typeAndNameData.nameParam.countability;
                    gender = typeAndNameData.nameParam.gender;
                    initialSound = typeAndNameData.nameParam.initialSound;
                    articlePresence = typeAndNameData.nameParam.articlePresence;
                    sb.Append(typeAndNameData.nameParam.name + " von " + typeAndNameData.typeParam.name);
                    break;
            }
        }

        public void SetESSingleWordParam(TrTypeAndNameData typeAndNameData, MessageEnumData.MsgLangId languageId)
        {
            this.languageId = languageId;
            SetESTrTypeAndNameWordParam(typeAndNameData);
        }

        public void SetESPairWordParam(TrTypeAndNameData typeAndNameData, MessageEnumData.MsgLangId languageId)
        {
            this.languageId = languageId;
            SetESTrTypeAndNameWordParam(typeAndNameData);
        }

        private void SetESTrTypeAndNameWordParam(TrTypeAndNameData typeAndNameData)
        {
            count = 1;

            sb.Clear();
            AppendESDisplayPattern(typeAndNameData.displayPattern, typeAndNameData);
            strValue = sb.ToString();
        }

        private void AppendESDisplayPattern(int displayPattern, TrTypeAndNameData typeAndNameData)
        {
            switch (displayPattern)
            {
                case 0:
                    countablity = typeAndNameData.typeParam.countability;
                    gender = typeAndNameData.typeParam.gender;
                    initialSound = typeAndNameData.typeParam.initialSound;
                    articlePresence = typeAndNameData.typeParam.articlePresence;
                    sb.Append(typeAndNameData.typeParam.name + " " + typeAndNameData.nameParam.name);
                    break;

                case 1:
                    var formatTagGrammar = new FormatTagGrammar();
                    var tagDataModel = new MessageTagDataModel();

                    tagDataModel.SetWordParam(typeAndNameData.typeParam.name, 1, typeAndNameData.typeParam.gender, typeAndNameData.typeParam.initialSound,
                        typeAndNameData.typeParam.articlePresence, typeAndNameData.typeParam.countability, typeAndNameData.typeParam.strWidth, false);

                    countablity = typeAndNameData.nameParam.countability;
                    gender = typeAndNameData.nameParam.gender;
                    initialSound = typeAndNameData.nameParam.initialSound;
                    articlePresence = typeAndNameData.nameParam.articlePresence;

                    sb.Append(typeAndNameData.nameParam.name + " " + formatTagGrammar.FormatESTag(MessageEnumData.ESID.De_DefArt, tagDataModel) + typeAndNameData.typeParam.name);
                    break;

                case 2:
                    countablity = typeAndNameData.nameParam.countability;
                    gender = typeAndNameData.nameParam.gender;
                    initialSound = typeAndNameData.nameParam.initialSound;
                    articlePresence = typeAndNameData.nameParam.articlePresence;
                    sb.Append(typeAndNameData.nameParam.name + " de " + typeAndNameData.typeParam.name);
                    break;
            }
        }
    }
}