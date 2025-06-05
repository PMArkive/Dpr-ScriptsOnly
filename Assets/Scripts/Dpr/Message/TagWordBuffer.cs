using UnityEngine;

namespace Dpr.Message
{
    public class TagWordBuffer
    {
        private AWordParamBase[] wordParamArray = new AWordParamBase[MessageDataConstants.WORD_PARAM_ARRAY_SIZE];
        private MessageEnumData.MsgLangId languageId;
        private MessageManager msgManager;

        public AWordParamBase[] WordParamArray { get => wordParamArray; }

        public void Initialize(MessageManager msgManager, MessageEnumData.MsgLangId languageId)
        {
            this.msgManager = msgManager;
            this.languageId = languageId;
        }

        public void SetLanguageId(MessageEnumData.MsgLangId languageId)
        {
            this.languageId = languageId;
        }

        public void ClearWordParam()
        {
            for (int i=0; i<wordParamArray.Length; i++)
                wordParamArray[i] = null;
        }

        public void SetWordParams(AWordParamBase[] wordParams)
        {
            for (int i=0; i<wordParams.Length; i++)
                SetWordParam(i, wordParams[i]);
        }

        public void SetWordParam(int index, AWordParamBase wordParam)
        {
            if (index < wordParamArray.Length)
                wordParamArray[index] = wordParam;
            else
                MessageHelper.EmitLog(string.Format("Index {0} is over Size", index), UnityEngine.LogType.Error);
        }

        public bool IsSetTagWordParam(int index)
        {
            if (index < wordParamArray.Length)
                return false;
            else
                return wordParamArray[index] != null;
        }

        public void SetGlossaryWordParam(int index, MessageGlossaryParseDataModel dataModel)
        {
            SetWordParam(index, new GlossaryWordParam(dataModel, 1, languageId));
        }

        public void SetGlossaryWordParam(int index, MessageGlossaryParseDataModel dataModel, int count)
        {
            SetWordParam(index, new GlossaryWordParam(dataModel, count, languageId));
        }

        public void SetItemWordParam(int index, int itemNumber, int count)
        {
            SetWordParam(index, new ItemNameWordParam(itemNumber, count, languageId));
        }

        public void SetUserPokemonWordParam(int index, string nickName, int genderId, bool isEgg, MessageEnumData.MsgLangId languageid, int initialSound = 0)
        {
            var param = new UserPokemonWordParam();
            if (isEgg)
            {
                if (MessageHelper.IsEFIGS(languageid))
                {
                    var attribute = msgManager.GetAttributeInfo(MessageDataConstants.MONSNAME_FILE_NAME, MessageDataConstants.EGG_LABEL_NAME, languageid);
                    param.SetPokemonEggParam(nickName, attribute.gender, attribute.initialSound, languageid);
                }
                else
                {
                    param.SetPokemonEggParam(nickName, genderId, 0, languageid);
                }
                SetWordParam(index, param);
            }
            else
            {
                param.SetPokemonParam(nickName, genderId, languageid, initialSound);
                SetWordParam(index, param);
            }
        }

        public void SetUserNickNameWordParam(int index, string nickName, int genderId, MessageEnumData.MsgLangId languageid)
        {
            SetWordParam(index, new TrainerNickNameWordParam(nickName, genderId, languageid, MessageEnumData.AttriArticleID.NoArticle));
        }

        public void SetRivalNameWordParam(int index, string nickName, int genderId)
        {
            SetWordParam(index, new TrainerNickNameWordParam(nickName, genderId, languageId, MessageEnumData.AttriArticleID.NoArticle));
        }

        public void SetSupporterName(int index, string nickName, int genderId)
        {
            SetWordParam(index, new TrainerNickNameWordParam(nickName, genderId, languageId));
        }

        public void SetPlaceWordParam(int index, string labelName)
        {
            SetWordParam(index, new PlaceWordParam(labelName));
        }

        public void SetStrWordParam(int index, string str, float strWidth = -1.0f)
        {
            SetWordParam(index, new StringWordParam(str, languageId, strWidth));
        }

        public void SetStrWordParam(int index, string str, MessageEnumData.MsgLangId langId, float strWidth = -1.0f)
        {
            SetWordParam(index, new StringWordParam(str, langId, strWidth));
        }

        public void SetDigitWordParam(int index, int count)
        {
            SetWordParam(index, new DigitWordParam(count));
        }

        public void SetDigitWordParam(int index, int count, MessageEnumData.ForceGrmID forceGrmID)
        {
            SetWordParam(index, new DigitWordParam(count, forceGrmID));
        }

        public void SetDigitStrWordParam(int index, string countStr)
        {
            SetWordParam(index, new DigitWordParam(countStr));
        }

        public void SetSingleTrTypeAndNameWordParam(int index, TrTypeAndNameData typeAndNameData)
        {
            var param = new TrTypeAndNameWordParam();

            switch (MessageHelper.ConvertMsgId(languageId))
            {
                case MessageEnumData.MsgLangId.FRA:
                    param.SetFRSingleWordParam(typeAndNameData, languageId);
                    break;

                case MessageEnumData.MsgLangId.DEU:
                    param.SetDESingleWordParam(typeAndNameData, languageId);
                    break;

                case MessageEnumData.MsgLangId.ESP:
                    param.SetESSingleWordParam(typeAndNameData, languageId);
                    break;

                default:
                    MessageHelper.EmitLog("TrTypeAndName Tag Used Except FR,DE and Spanish " + MessageHelper.ConvertMsgId(languageId), LogType.Error);
                    break;
            }

            SetWordParam(index, param);
        }

        public void SetSameTypePairTrTypeAndNameWordParam(int index1, TrTypeAndNameData typeAndNameData1, int index2, TrTypeAndNameData typeAndNameData2)
        {
            var param = new TrTypeAndNameWordParam();

            switch (MessageHelper.ConvertMsgId(languageId))
            {
                case MessageEnumData.MsgLangId.FRA:
                    SetWordParam(index2, new StringWordParam(typeAndNameData2.nameParam.name, languageId, typeAndNameData2.nameParam.strWidth));
                    param.SetFRSingleWordParam(typeAndNameData1, languageId);
                    break;

                case MessageEnumData.MsgLangId.DEU:
                    SetWordParam(index2, new StringWordParam(typeAndNameData2.nameParam.name, languageId, typeAndNameData2.nameParam.strWidth));
                    param.SetDESingleWordParam(typeAndNameData1, languageId);
                    break;

                case MessageEnumData.MsgLangId.ESP:
                    SetWordParam(index2, new StringWordParam(typeAndNameData2.nameParam.name, languageId, typeAndNameData2.nameParam.strWidth));
                    param.SetESSingleWordParam(typeAndNameData1, languageId);
                    break;

                default:
                    MessageHelper.EmitLog("TrTypeAndName Tag Used Except FR,DE and Spanish " + MessageHelper.ConvertMsgId(languageId), LogType.Error);
                    return;
            }

            SetWordParam(index1, param);
        }

        public void SetDiffTypePairTrTypeAndNameWordParam(int index1, TrTypeAndNameData typeAndNameData1, int index2, TrTypeAndNameData typeAndNameData2)
        {
            var param1 = new TrTypeAndNameWordParam();
            var param2 = new TrTypeAndNameWordParam();

            switch (MessageHelper.ConvertMsgId(languageId))
            {
                case MessageEnumData.MsgLangId.FRA:
                    param1.SetFRSingleWordParam(typeAndNameData1, languageId);
                    param1.SetFRSingleWordParam(typeAndNameData2, languageId);
                    break;

                case MessageEnumData.MsgLangId.DEU:
                    param1.SetDESingleWordParam(typeAndNameData1, languageId);
                    param1.SetDESingleWordParam(typeAndNameData2, languageId);
                    break;

                case MessageEnumData.MsgLangId.ESP:
                    param1.SetESSingleWordParam(typeAndNameData1, languageId);
                    param1.SetESSingleWordParam(typeAndNameData2, languageId);
                    break;

                default:
                    MessageHelper.EmitLog("TrTypeAndName Tag Used Except FR,DE and Spanish " + MessageHelper.ConvertMsgId(languageId), LogType.Error);
                    return;
            }

            SetWordParam(index1, param1);
            SetWordParam(index2, param2);
        }
    }
}