using Pml.PokePara;
using Pml;
using XLSXContent;
using Dpr.Battle.Logic;
using UnityEngine;
using Pml.Personal;
using GameData;

namespace Dpr.Message
{
    public static class MessageWordSetHelper
    {
        public static MessageManager manager;

        public static void SetRivalNickNameWord(int tagIndex)
        {
            manager.TagWordBuffer.SetRivalNameWordParam(tagIndex, manager.GetRivalName(), (int)MessageEnumData.GenderID.Feminine);
        }

        public static void SetSupporterName(int tagIndex)
        {
            string supporterLabel = PlayerWork.playerSex ? MessageDataConstants.WOMAN_SUPPORTER_NAME_LABEL : MessageDataConstants.MAN_SUPPORTER_NAME_LABEL;
            manager.TagWordBuffer.SetGlossaryWordParam(tagIndex, GetWordDataModel(MessageDataConstants.CHARACTER_NAME_MSBT_FILE, supporterLabel));
        }

        public static void SetPlayerNickNameWord(int tagIndex)
        {
            manager.TagWordBuffer.SetUserNickNameWordParam(tagIndex, PlayerWork.userName, PlayerWork.playerSex ? 0 : 1, manager.UserLanguageID);
        }

        public static void SetPlayerNickNameWord(int tagIndex, PlayerNameData playerData)
        {
            manager.TagWordBuffer.SetUserNickNameWordParam(tagIndex, playerData.nickName, playerData.genderid, playerData.lanugageId);
        }

        public static void SetPlayerNickNameWord(int tagIndex, MyStatus status)
        {
            manager.TagWordBuffer.SetUserNickNameWordParam(tagIndex, status.name, status.sex ? 0 : 1, status.lang);
        }

        public static void SetSpeakersNameWord(int tagIndex, int speakerId)
        {
            manager.TagWordBuffer.SetGlossaryWordParam(tagIndex, GetWordDataModel(MessageDataConstants.SPEAKER_NAME_FILE_NAME, speakerId));
        }

        public static void SetPokemonNickNameWord(int tagIndex, CoreParam pp, bool isShowNickName = true)
        {
            bool isEgg = pp.IsEgg(EggCheckType.BOTH_EGG);
            int sex = (int)pp.GetSex();
            MessageEnumData.MsgLangId lang = (MessageEnumData.MsgLangId)pp.GetLangId();
            MonsNo monsNo = pp.GetMonsNo();

            if (monsNo > MonsNo.END)
                monsNo = MonsNo.NULL;

            int initialSound;

            if (isShowNickName)
            {
                if (pp.HaveNickName())
                    initialSound = 0;
                else
                    initialSound = GetWordDataModel(MessageDataConstants.MONSNAME_FILE_NAME, (int)monsNo).AttributeDataModel.initialSound;

                manager.TagWordBuffer.SetUserPokemonWordParam(tagIndex, pp.GetNickName(), sex, isEgg, lang, initialSound);
            }
            else
            {
                initialSound = GetWordDataModel(MessageDataConstants.MONSNAME_FILE_NAME, (int)monsNo).AttributeDataModel.initialSound;
                string name = PersonalSystem.GetMonsName(monsNo, lang);
                manager.TagWordBuffer.SetUserPokemonWordParam(tagIndex, name, sex, isEgg, lang, initialSound);
            }
        }

        public static void SetPokemonNickNameWord(int tagIndex, MonsNameData monsNameData)
        {
            manager.TagWordBuffer.SetUserPokemonWordParam(tagIndex, monsNameData.nickName, monsNameData.genderid, monsNameData.isEgg, monsNameData.languageId);
        }

        public static void SetMonsNameWord(int tagIndex, MonsNo monsNo)
        {
            SetMonsNameWord(tagIndex, (int)monsNo);
        }

        public static void SetMonsNameWord(int tagIndex, int monsNo)
        {
            manager.TagWordBuffer.SetGlossaryWordParam(tagIndex, GetWordDataModel(MessageDataConstants.MONSNAME_FILE_NAME, monsNo));
        }

        public static void SetMonsNameWord(int tagIndex, CoreParam pp)
        {
            SetMonsNameWord(tagIndex, pp.GetMonsNo());
        }

        public static void SetParentNameWord(int tagIndex, CoreParam pp)
        {
            manager.TagWordBuffer.SetUserNickNameWordParam(tagIndex, pp.GetParentName(), (int)pp.GetParentSex(), (MessageEnumData.MsgLangId)pp.GetLangId());
        }

        public static void SetContestDescriptionWord(int contestWazaIndex)
        {
            SetContestDescriptionWord(DataManager.ContestWazaInfo[contestWazaIndex]);
        }

        public static void SetContestDescriptionWord(ContestWazaInfo.SheetContestWazaData wazaData)
        {
            if (wazaData.wazaType != 1 && wazaData.wazaType != 7)
            {
                MessageManager.Instance.ClearTagWordParams();
                SetDigitWord(0, wazaData.value1);
            }
        }

        public static void SetWazaNameWord(int tagIndex, WazaNo wazaNo)
        {
            manager.TagWordBuffer.SetGlossaryWordParam(tagIndex, GetWordDataModel(MessageDataConstants.WAZA_FILE_NAME, (int)wazaNo));
        }

        public static void SetWazaTypeWord(int tagIndex, PokeType pokeTypeNo)
        {
            manager.TagWordBuffer.SetGlossaryWordParam(tagIndex, GetWordDataModel(MessageDataConstants.POKETYPE_FILE_NAME, (int)pokeTypeNo));
        }

        public static void SetItemWord(int tagIndex, ItemNo itemNo, int itemCount)
        {
            SetItemWord(tagIndex, (int)itemNo, itemCount);
        }

        public static void SetItemWord(int tagIndex, int itemNo, int itemCount)
        {
            manager.TagWordBuffer.SetItemWordParam(tagIndex, itemNo, itemCount);
        }

        public static void SetPocketNameWord(int tagIndex, ItemNo itemNo)
        {
            SetPocketNameWord(tagIndex, (int)ItemWork.GetItemInfo((int)itemNo).Category);
        }

        public static void SetPocketNameWord(int tagIndex, int wordIndex)
        {
            string pocketName = GetWordStr(MessageDataConstants.BAG_POCKET_FILE_NAME, MessageDataConstants.POCKET_NAME_LABEL_TABLE[wordIndex]);
            string pocketIcon = MessageHelper.ConvertUnicodeToChar(MessageDataConstants.POCKET_ICON_CODE_TABLE[wordIndex]).ToString();

            manager.TagWordBuffer.SetStrWordParam(tagIndex, pocketIcon + pocketName);
        }

        public static void SetSealNameWord(int tagIndex, SealID sealID)
        {
            SetSealNameWord(tagIndex, sealID, 1);
        }

        public static void SetSealNameWord(int tagIndex, SealID sealID, int itemCount)
        {
            manager.TagWordBuffer.SetItemWordParam(tagIndex, (int)sealID, itemCount);
        }

        public static void SetUgItemNameWord(int tagIndex, int ugItemId)
        {
            SetUgItemNameWord(tagIndex, ugItemId, 1);
        }

        public static void SetUgItemNameWord(int tagIndex, int ugItemId, int itemCount)
        {
            manager.TagWordBuffer.SetItemWordParam(tagIndex, ugItemId, itemCount);
        }

        public static void SetParkItemNameWord(int tagIndex, int parkItemId)
        {
            SetParkItemNameWord(tagIndex, parkItemId, 1);
        }

        public static void SetParkItemNameWord(int tagIndex, int parkItemId, int itemCount)
        {
            manager.TagWordBuffer.SetItemWordParam(tagIndex, parkItemId, itemCount);
        }

        public static void SetKinomiNameWord(int tagIndex, int kinomiNo)
        {
            SetKinomiNameWord(tagIndex, kinomiNo, 1);
        }

        public static void SetKinomiNameWord(int tagIndex, int kinomiNo, int itemCount)
        {
            manager.TagWordBuffer.SetGlossaryWordParam(tagIndex, GetWordDataModel(MessageDataConstants.KINOMI_FILE_NAME, kinomiNo), itemCount);
        }

        public static void SetRibbonNameWord(int tagIndex, int ribbonNo)
        {
            SetRibbonNameWord(tagIndex, ribbonNo, 1);
        }

        public static void SetRibbonNameWord(int tagIndex, int ribbonNo, int itemCount)
        {
            manager.TagWordBuffer.SetGlossaryWordParam(tagIndex, GetWordDataModel(MessageDataConstants.RIBBON_NAME_FILE_NAME, ribbonNo), itemCount);
        }

        public static void SetDressupItemNameWord(int tagIndex, string label)
        {
            manager.TagWordBuffer.SetGlossaryWordParam(tagIndex, GetWordDataModel(MessageDataConstants.STYLE_NAME_MSBT_FILE, label));
        }

        public static void SetPoffinNameWord(int tagIndex, string poffinLabelName)
        {
            SetPoffinNameWord(tagIndex, poffinLabelName, 1);
        }

        public static void SetPoffinNameWord(int tagIndex, string poffinLabelName, int itemCount)
        {
            SetPoffinNameWord(tagIndex, GetLabelIndexByLabelName(MessageDataConstants.POFFIN_NAME_MSBT_FILE, poffinLabelName), itemCount);
        }

        public static void SetPoffinNameWord(int tagIndex, int labelIndex)
        {
            SetPoffinNameWord(tagIndex, labelIndex, 1);
        }

        public static void SetPoffinNameWord(int tagIndex, int labelIndex, int itemCount)
        {
            manager.TagWordBuffer.SetItemWordParam(tagIndex, labelIndex, itemCount);
        }

        public static void SetTokuseiWord(int tagIndex, TokuseiNo tokuseiNo)
        {
            manager.TagWordBuffer.SetGlossaryWordParam(tagIndex, GetWordDataModel(MessageDataConstants.TOKUSEI_FILE_NAME, (int)tokuseiNo));
        }

        public static void SetSeikakuWord(int tagIndex, Seikaku seikakuNo)
        {
            manager.TagWordBuffer.SetGlossaryWordParam(tagIndex, GetWordDataModel(MessageDataConstants.SEIKAKU_FILE_NAME, (int)seikakuNo));
        }

        public static void SetTrainerNameWord(int tagIndex, string labelName)
        {
            manager.TagWordBuffer.SetGlossaryWordParam(tagIndex, GetWordDataModel(MessageDataConstants.TRAINER_NAME_FILE_NAME, labelName));
        }

        public static void SetTrainerTypeWord(int tagIndex, string labelName)
        {
            manager.TagWordBuffer.SetGlossaryWordParam(tagIndex, GetWordDataModel(MessageDataConstants.TRAINER_TYPE_FILE_NAME, labelName));
        }

        public static void SetAreanameWord(int tagIndex, string labelName)
        {
            SetGlossaryWord(tagIndex, MessageDataConstants.AREANAME_FILE_NAME, labelName);
        }

        public static void SetAreanameWord(int tagIndex, int labelIndex)
        {
            SetGlossaryWord(tagIndex, MessageDataConstants.AREANAME_FILE_NAME, labelIndex);
        }

        public static void SetAreanameIndirectWord(int tagIndex, string labelName)
        {
            SetGlossaryWord(tagIndex, MessageDataConstants.AREANAME_INDIRECT_FILE_NAME, labelName);
        }

        public static void SetAreanameIndirectWord(int tagIndex, int labelIndex)
        {
            if (!CheckEnableIndex(MessageDataConstants.AREANAME_INDIRECT_FILE_NAME, labelIndex))
                return;

            SetGlossaryWord(tagIndex, MessageDataConstants.AREANAME_INDIRECT_FILE_NAME, labelIndex);
        }

        public static void SetAreanameDisplayWord(int tagIndex, int labelIndex)
        {
            if (!CheckEnableIndex(MessageDataConstants.AREANAME_DISPLAY_FILE_NAME, labelIndex))
                return;

            SetGlossaryWord(tagIndex, MessageDataConstants.AREANAME_DISPLAY_FILE_NAME, labelIndex);
        }

        public static void SetAreanameDisplayWord(int tagIndex, string labelName)
        {
            SetGlossaryWord(tagIndex, MessageDataConstants.AREANAME_DISPLAY_FILE_NAME, labelName);
        }

        public static void SetAreanameTownmapWord(int tagIndex, string labelName)
        {
            SetGlossaryWord(tagIndex, MessageDataConstants.AREANAME_TOWNMAP_FILE_NAME, labelName);
        }

        public static void SetAreanameTownmapWord(int tagIndex, int labelIndex)
        {
            SetGlossaryWord(tagIndex, MessageDataConstants.AREANAME_TOWNMAP_FILE_NAME, labelIndex);
        }

        public static void SetPlaceNameWord(int tagIndex, int placeID)
        {
            manager.TagWordBuffer.SetPlaceWordParam(tagIndex, GetLabelNameByIndex(MessageDataConstants.AREANAME_FILE_NAME, placeID));
        }

        public static void SetPlaceNameWord(int tagIndex, string labelName)
        {
            manager.TagWordBuffer.SetPlaceWordParam(tagIndex, labelName);
        }

        public static void SetStatusNameWord(int tagIndex, PowerID powerId, uint totalValue)
        {
            if (MessageDataConstants.POKE_POWER_NAME_LABEL_ARRAY.ContainsKey((int)powerId))
                SetGlossaryWord(tagIndex, MessageDataConstants.BAG_FILE_NAME, MessageDataConstants.POKE_POWER_NAME_LABEL_ARRAY[(int)powerId], (int)totalValue);
            else
                MessageHelper.EmitLog(string.Format("Not found ID in POKE_POWER_NAME_LABEL_ARRAY: {0}", powerId), LogType.Error);
        }

        public static void SetDigitWord(int tagIndex, int number)
        {
            manager.TagWordBuffer.SetDigitWordParam(tagIndex, number);
        }

        public static void SetDigitWord(int tagIndex, string numberStr)
        {
            manager.TagWordBuffer.SetDigitStrWordParam(tagIndex, numberStr);
        }

        public static void SetCentiSizeUnitWord(float centimeterSize, int integerTagIndex, int decimalTagIndex)
        {
            int integerValue = 0;
            int decimalValue = 0;
            var forceGrm = MessageHelper.CreateNotationValue(centimeterSize, ref integerValue, ref decimalValue);

            manager.TagWordBuffer.SetDigitWordParam(integerTagIndex, integerValue, forceGrm);
            manager.TagWordBuffer.SetDigitWordParam(decimalTagIndex, decimalValue, forceGrm);
        }

        public static void SetStringWord(int tagIndex, string str)
        {
            manager.TagWordBuffer.SetStrWordParam(tagIndex, str);
        }

        public static void SetStringWord(int tagIndex, string str, MessageEnumData.MsgLangId langId)
        {
            manager.TagWordBuffer.SetStrWordParam(tagIndex, str, langId);
        }

        public static void SetRivalTypeAndNameWord(int tagIndex, string typeLabel)
        {
            manager.TagWordBuffer.SetSingleTrTypeAndNameWordParam(tagIndex, CreateRivalTrTypeAndNameData(typeLabel));
        }

        public static void SetSingleTrainerTypeAndNameWord(int tagIndex, string typeLabel, string nameLabel)
        {
            manager.TagWordBuffer.SetSingleTrTypeAndNameWordParam(tagIndex, CreateTrTypeAndNameDataFromLabelName(typeLabel, nameLabel));
        }

        public static void SetSingleTrainerTypeAndNameWord(int tagIndex, int typeLabelIndex, int nameLabelIndex)
        {
            manager.TagWordBuffer.SetSingleTrTypeAndNameWordParam(tagIndex, CreateTrTypeAndNameDataFromLabelIndex(typeLabelIndex, nameLabelIndex));
        }

        public static void SetRivalTagTrainerTypeAndNameWord(int rivalTagIndex, string rivalTypeLabel, int pairTagIndex, string pairTagTypeLabel, string pairTagNameLabel)
        {
            var data1 = CreateRivalTrTypeAndNameData(rivalTypeLabel);
            var data2 = CreateTrTypeAndNameDataFromLabelName(pairTagTypeLabel, pairTagNameLabel);
            manager.TagWordBuffer.SetSameTypePairTrTypeAndNameWordParam(rivalTagIndex, data1, pairTagIndex, data2);
        }

        public static void SetRivalTagTrainerTypeAndNameWord(int rivalTagIndex, string rivalTypeLabel, int pairTagIndex, int pairTagTypeLabelIndex, int pairTagNameLabelIndex)
        {
            var data1 = CreateRivalTrTypeAndNameData(rivalTypeLabel);
            var data2 = CreateTrTypeAndNameDataFromLabelIndex(pairTagTypeLabelIndex, pairTagNameLabelIndex);
            manager.TagWordBuffer.SetSameTypePairTrTypeAndNameWordParam(rivalTagIndex, data1, pairTagIndex, data2);
        }

        public static void SetSameTagTrainerTypeAndNameWord(int tagIndex1, string typeLabel, string nameLabel1, int tagIndex2, string nameLabel2)
        {
            var data1 = CreateTrTypeAndNameDataFromLabelName(typeLabel, nameLabel1);
            var data2 = CreateTrTypeAndNameDataFromLabelName(typeLabel, nameLabel2);
            manager.TagWordBuffer.SetSameTypePairTrTypeAndNameWordParam(tagIndex1, data1, tagIndex2, data2);
        }

        public static void SetSameTagTrainerTypeAndNameWord(int tagIndex1, int typeLabelIndex, int nameLabelIndex1, int tagIndex2, int nameLabelIndex2)
        {
            var data1 = CreateTrTypeAndNameDataFromLabelIndex(typeLabelIndex, nameLabelIndex1);
            var data2 = CreateTrTypeAndNameDataFromLabelIndex(typeLabelIndex, nameLabelIndex2);
            manager.TagWordBuffer.SetSameTypePairTrTypeAndNameWordParam(tagIndex1, data1, tagIndex2, data2);
        }

        public static void SetDiffTagTrainerTypeAndNameWord(int tagIndex1, string typeLabel1, string nameLabel1, int tagIndex2, string typeLabel2, string nameLabel2)
        {
            var data1 = CreateTrTypeAndNameDataFromLabelName(typeLabel1, nameLabel1);
            var data2 = CreateTrTypeAndNameDataFromLabelName(typeLabel2, nameLabel2);
            manager.TagWordBuffer.SetSameTypePairTrTypeAndNameWordParam(tagIndex1, data1, tagIndex2, data2);
        }

        public static void SetDiffTagTrainerTypeAndNameWord(int tagIndex1, int typeLabelIndex1, int nameLabelIndex1, int tagIndex2, int typeLabelIndex2, int nameLabelIndex2)
        {
            var data1 = CreateTrTypeAndNameDataFromLabelIndex(typeLabelIndex1, nameLabelIndex1);
            var data2 = CreateTrTypeAndNameDataFromLabelIndex(typeLabelIndex2, nameLabelIndex2);
            manager.TagWordBuffer.SetSameTypePairTrTypeAndNameWordParam(tagIndex1, data1, tagIndex2, data2);
        }

        private static TrTypeAndNameData CreateTrTypeAndNameDataFromLabelName(string typeLabel, string nameLabel)
        {
            var typeData = manager.GetNameMessageDataModel(MessageDataConstants.TRAINER_TYPE_FILE_NAME, typeLabel);
            var nameData = manager.GetNameMessageDataModel(MessageDataConstants.TRAINER_NAME_FILE_NAME, nameLabel);
            return CreateTrTypeAndNameData(typeData, nameData);
        }

        private static TrTypeAndNameData CreateTrTypeAndNameDataFromLabelIndex(int typeLabelIndex, int nameLabelIndex)
        {
            var typeData = manager.GetNameMessageDataModel(MessageDataConstants.TRAINER_TYPE_FILE_NAME, typeLabelIndex);
            var nameData = manager.GetNameMessageDataModel(MessageDataConstants.TRAINER_NAME_FILE_NAME, nameLabelIndex);
            return CreateTrTypeAndNameData(typeData, nameData);
        }

        private static TrTypeAndNameData CreateTrTypeAndNameData(MessageGlossaryParseDataModel typeDataModel, MessageGlossaryParseDataModel nameDataModel)
        {
            var trainerData = new TrTypeAndNameData();
            trainerData.displayPattern = typeDataModel.AttributeDataModel.displayPattern;

            trainerData.typeParam = new WordParameter
            {
                name = typeDataModel.GetName(),
                gender = typeDataModel.AttributeDataModel.gender,
                initialSound = typeDataModel.AttributeDataModel.initialSound,
                articlePresence = typeDataModel.AttributeDataModel.articlePresence,
                countability = typeDataModel.AttributeDataModel.countability,
                strWidth = typeDataModel.StrWidth
            };

            trainerData.nameParam = new WordParameter
            {
                name = nameDataModel.GetName(),
                gender = nameDataModel.AttributeDataModel.gender,
                initialSound = nameDataModel.AttributeDataModel.initialSound,
                articlePresence = nameDataModel.AttributeDataModel.articlePresence,
                countability = nameDataModel.AttributeDataModel.countability,
                strWidth = nameDataModel.StrWidth
            };

            return trainerData;
        }

        private static TrTypeAndNameData CreateRivalTrTypeAndNameData(string typeLabel)
        {
            var typeData = manager.GetNameMessageDataModel(MessageDataConstants.TRAINER_TYPE_FILE_NAME, typeLabel);

            var trainerData = new TrTypeAndNameData();
            trainerData.displayPattern = typeData.AttributeDataModel.displayPattern;

            trainerData.typeParam = new WordParameter
            {
                name = typeData.GetName(),
                gender = typeData.AttributeDataModel.gender,
                initialSound = typeData.AttributeDataModel.initialSound,
                articlePresence = typeData.AttributeDataModel.articlePresence,
                countability = typeData.AttributeDataModel.countability,
                strWidth = typeData.StrWidth
            };

            trainerData.nameParam = new WordParameter
            {
                name = manager.GetRivalName(),
                gender = (int)MessageEnumData.GenderID.Masculine,
                articlePresence = (int)MessageEnumData.AttriArticleID.NoArticle,
                strWidth = -1.0f
            };

            return trainerData;
        }

        public static void SetPocketchWord(int tagIndex, int labelIndex)
        {
            manager.TagWordBuffer.SetGlossaryWordParam(tagIndex, manager.GetNameMessageDataModel(MessageDataConstants.POKETCH_FILE_NAME, labelIndex));
        }

        public static void SetPocketchNameWord(int tagIndex, int appId)
        {
            SetPocketchWord(tagIndex, appId + 20);
        }

        public static void SetGlossaryWord(int index, string msbtName, string labelName)
        {
            SetGlossaryWord(index, msbtName, labelName, 1);
        }

        public static void SetGlossaryWord(int index, string msbtName, string labelName, int count)
        {
            var dataModel = manager.GetNameMessageDataModel(msbtName, labelName);

            if (dataModel == null)
                return;

            manager.TagWordBuffer.SetGlossaryWordParam(index, dataModel, count);
        }

        public static void SetGlossaryWord(int index, string msbtName, int labelIndex)
        {
            SetGlossaryWord(index, msbtName, labelIndex, 1);
        }

        public static void SetGlossaryWord(int index, string msbtName, int labelIndex, int count)
        {
            var dataModel = manager.GetNameMessageDataModel(msbtName, labelIndex);

            if (dataModel == null)
                return;

            manager.TagWordBuffer.SetGlossaryWordParam(index, dataModel, count);
        }

        public static void SetGlossaryWordFromMsgFile(int index, MessageMsgFile msgFile, string label)
        {
            if (msgFile != null)
                manager.TagWordBuffer.SetGlossaryWordParam(index, msgFile.GetNameDataModel(label));
            else
                MessageHelper.EmitLog(string.Format("SetGlossaryWordFromMsgFile : MessageMsgFile is null!!! TagIndex {0} Label {1}", index, label), LogType.Error);
        }

        public static void SetGlossaryWordFromMsgFile(int index, MessageMsgFile msgFile, int labelIndex)
        {
            if (msgFile != null)
                manager.TagWordBuffer.SetGlossaryWordParam(index, msgFile.GetNameDataModelByIndex(labelIndex));
            else
                MessageHelper.EmitLog(string.Format("SetGlossaryWordFromMsgFile : MessageMsgFile is null!!! TagIndex {0} LabelIndex {1}", index, labelIndex), LogType.Error);
        }

        public static void SetStringWordFromMsgFile(int index, MessageMsgFile msgFile, string label)
        {
            if (msgFile != null)
                manager.TagWordBuffer.SetStrWordParam(index, msgFile.GetNameStr(label));
            else
                MessageHelper.EmitLog(string.Format("SetStringWordFromMsgFile : MsgFile is null!!! TagIndex {0} Label {1}", index, label), LogType.Error);
        }

        public static void SetStringWordFromMsgFile(int index, MessageMsgFile msgFile, int labelIndex)
        {
            if (msgFile != null)
                manager.TagWordBuffer.SetStrWordParam(index, msgFile.GetNameStr(labelIndex));
            else
                MessageHelper.EmitLog(string.Format("SetStringWordFromMsgFile : MsgFile is null!!! TagIndex {0} LabelIndex {1}", index, labelIndex), LogType.Error);
        }

        private static string GetWordStr(string msbtName, int labelIndex)
        {
            return manager.GetNameMessage(msbtName, labelIndex);
        }

        private static string GetWordStr(string msbtName, string labelName)
        {
            return manager.GetNameMessage(msbtName, labelName);
        }

        private static MessageGlossaryParseDataModel GetWordDataModel(string msbtName, int labelIndex)
        {
            return manager.GetNameMessageDataModel(msbtName, labelIndex);
        }

        private static MessageGlossaryParseDataModel GetWordDataModel(string msbtName, string labelName)
        {
            return manager.GetNameMessageDataModel(msbtName, labelName);
        }

        private static int GetLabelIndexByLabelName(string msbtName, string labelName)
        {
            return manager.GetMsgFile(msbtName)?.GetLabelIndex(labelName) ?? -1;
        }

        private static string GetLabelNameByIndex(string msbtName, int labelIndex)
        {
            return manager.GetMsgFile(msbtName)?.GetLabel(labelIndex) ?? string.Empty;
        }

        private static bool CheckEnableIndex(string msbtName, int labelIndex)
        {
            var file = manager.GetMsgFile(msbtName);
            if (file == null)
                return false;

            if (labelIndex < file.GetTotalTextNum())
                return true;

            MessageHelper.EmitLog(string.Format("{0} : Index over text num - Total Text Array Num : {1}", labelIndex, file.GetTotalTextNum()), LogType.Warning);
            return false;
        }
    }
}