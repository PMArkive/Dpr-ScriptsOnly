using System;
using System.Runtime.InteropServices;
using SmartPoint.AssetAssistant;
using UnityEngine.Events;

namespace Dpr.Message
{
    public class MessageManager : SingletonMonoBehaviour<MessageManager>
    {
        public static UnityAction<bool> onChangeKanjiMode;
        private MsgDataFileLoader msbtLoader = new MsgDataFileLoader();
        private MessageDataModel dataModel = new MessageDataModel();
        private TagWordBuffer tagWordBuffer = new TagWordBuffer();
        private MessageWordDataPool wordDataPool = new MessageWordDataPool();

        public bool IsInitialize { get => CheckInitialized(); }
        public bool IsLoading { get => msbtLoader.IsLoading; }

        public void Initialize(MessageEnumData.MsgLangId languageId)
        {
            if (IsInitialize)
                return;

            Sequencer.onDestroy -= Destroy;
            Sequencer.onDestroy += Destroy;

            ConfigWork.onValueChanged -= OnChangedConfig;
            ConfigWork.onValueChanged += OnChangedConfig;

            MessageWordSetHelper.manager = this;
            dataModel.Initialize(languageId);
            msbtLoader.Initialize(OnCompleteLoadAssetBundle, OnCompleteLoadMsbtFile);
            tagWordBuffer.Initialize(this, languageId);

            wordDataPool.GeneratePool(MessageDataConstants.GENERATE_POOL_NUM);
            RegisitLoadingCommonMsbt();
            RegistLoadingLanguageMsbt();

            RequestLoadMessageAssetbundle(() =>
            {
                dataModel.CreateAllLabelTable();
                dataModel.InitializedManager();
                UnloadMSBTAssetBundle();
            });
        }

        private bool CheckInitialized()
        {
            return dataModel.Initialized;
        }

        private void Destroy()
        {
            onChangeKanjiMode = null;

            Sequencer.onDestroy -= Destroy;
            ConfigWork.onValueChanged -= OnChangedConfig;

            MessageWordSetHelper.manager = null;
            wordDataPool.Dispose();
            msbtLoader.Dispose();
            dataModel.Dispose();

            AssetManager.UnloadAssetBundle(MessageDataConstants.COMMON_ASSETNAME);
            UnloadMSBTAssetBundle();
        }

        public MessageEnumData.MsgLangId UserLanguageID { get => dataModel.UserSelectLanguageID; }
        public bool IsKanji { get => dataModel.IsKanji; }

        public void SetJPNKanjiFlag(bool flag)
        {
            if (dataModel.IsKanji == flag)
                return;

            dataModel.SetJPNKanjiFlag(flag);
            onChangeKanjiMode?.Invoke(flag);
        }

        public string[] Varitnas { get => dataModel.Variants; }

        public MessageMsgFile GetMsgFile(string fileName)
        {
            if (IsInitialize)
                return dataModel.GetMsgFile(fileName, UserLanguageID);

            return null;
        }

        public MessageMsgFile GetMsgFile(string fileName, MessageEnumData.MsgLangId languageId)
        {
            if (IsInitialize)
                return dataModel.GetMsgFile(fileName, languageId);

            return null;
        }

        private void UnloadMSBTAssetBundle()
        {
            UnloadCommonMSBTAssetBundle();
            AssetManager.UnloadAssetBundle(MessageDataConstants.ASSET_FOLDER_NAME_TABLE[(int)UserLanguageID]);
            if (UserLanguageID == MessageEnumData.MsgLangId.JPN)
                AssetManager.UnloadAssetBundle(MessageDataConstants.JPN_KANJI_ASSET_FOLDER_NAME);
        }

        private void UnloadCommonMSBTAssetBundle()
        {
            AssetManager.UnloadAssetBundle(MessageDataConstants.COMMON_ASSETNAME);
        }

        private void RegistLoadingLanguageMsbt()
        {
            RegistLoadingMsbtFile(UserLanguageID);
        }

        private void RegisitLoadingCommonMsbt()
        {
            msbtLoader.RegistLoadCommonAssetBundleTask(MessageDataConstants.COMMON_ASSETNAME);
        }

        private void RegistLoadingMsbtFile(MessageEnumData.MsgLangId languageId)
        {
            msbtLoader.RegistLoadAssetBundleTask(MessageDataConstants.ASSET_FOLDER_NAME_TABLE[(int)languageId]);
            if (languageId == MessageEnumData.MsgLangId.JPN)
                msbtLoader.RegistLoadAssetBundleTask(MessageDataConstants.JPN_KANJI_ASSET_FOLDER_NAME);
        }

        public void ReloadAllMsbtFile(MessageEnumData.MsgLangId newLanguageId, Action onCompleteLoad)
        {
            if (UserLanguageID == newLanguageId)
            {
                // This line is presumed to have been commented out, the result of string.Format is ignored otherwise
                //Debug.Log(string.Format("Message Data [{0}] is Already Loaded", newLanguageId));
                onCompleteLoad?.Invoke();
            }
            else
            {
                if (!msbtLoader.IsLoading)
                {
                    dataModel.UnloadMSBTFileByLanguageId(UserLanguageID);
                    dataModel.SetUserSelectLanguageID(newLanguageId);
                    tagWordBuffer.SetLanguageId(newLanguageId);
                    RegistLoadingMsbtFile(UserLanguageID);
                    RequestLoadMessageAssetbundle(() =>
                    {
                        dataModel.CreateAllLabelTable();
                        onCompleteLoad?.Invoke();
                        UnloadMSBTAssetBundle();
                    });
                }
                else
                {
                    onCompleteLoad?.Invoke();
                }
            }
        }

        public LoadMsbtOperation AsyncReloadAllMsbtFileAsync(MessageEnumData.MsgLangId newLanguageId)
        {
            if (!dataModel.IsAlreadySetLoadOpData)
            {
                dataModel.UnloadMSBTFileByLanguageId(UserLanguageID);
                dataModel.SetUserSelectLanguageID(newLanguageId);
                tagWordBuffer.SetLanguageId(newLanguageId);
                RegistLoadingMsbtFile(UserLanguageID);
                RequestLoadMessageAssetbundle(() =>
                {
                    dataModel.SetLoadOperationData();
                    UnloadMSBTAssetBundle();
                });
            }

            return dataModel.LoadMsbtOperation;
        }

        private void RequestLoadMessageAssetbundle([Optional] Action onFinishedLoadRequest)
        {
            FontManager.Instance.ReloadMaterialTable();
            msbtLoader.RequestLoadAssetBundle(() =>
            {
                onFinishedLoadRequest?.Invoke();
                OnFinishReloadMsbt();
            });
        }

        private void OnFinishReloadMsbt()
        {
            var msgFile = IsInitialize ? dataModel.GetMsgFile(MessageDataConstants.MONSNAME_FILE_NAME, UserLanguageID) : null;
            string eggName = msgFile.GetNameStr(0);
            MessageHelper.SetEggName(eggName);
        }

        public TagWordBuffer TagWordBuffer { get => tagWordBuffer; }

        public void ClearTagWordParams()
        {
            tagWordBuffer.ClearWordParam();
        }

        public void SetTagWordParam(int index, AWordParamBase wordParam)
        {
            tagWordBuffer.SetWordParam(index, wordParam);
        }

        public bool IsSetWordParam(int index)
        {
            return tagWordBuffer.IsSetTagWordParam(index);
        }

        public string GetRivalName()
        {
            if (!IsInitialize)
                return string.Empty;

            return PlayerWork.rivalName;
        }

        public string GetRivalMotherName()
        {
            if (!IsInitialize)
            {
                // Presumed logging that was commented out
                //MessageHelper.EmitLog("Datamodel not initialized", LogType.Error);
                return string.Empty;
            }

            var model = GetNameMessageDataModel(MessageDataConstants.SPEAKER_NAME_FILE_NAME, MessageDataConstants.RIVAL_MOTHER_LABEL_NAME, UserLanguageID);
            if (UserLanguageID == MessageEnumData.MsgLangId.FRA)
            {
                if (model.TagDataList.Count < 2)
                    return model.GetName();

                model.TagDataList[1].strValue = GetRivalName();
                model.TagDataList[1].strWidth = model.StrWidth;
            }
            else
            {
                if (model.TagDataList.Count < 1)
                    return model.GetName();

                model.TagDataList[0].strValue = GetRivalName();
                model.TagDataList[0].strWidth = model.StrWidth;
            }

            return model.GetName();
        }

        public string GetNameMessage(string fileName, int labelIndex)
        {
            return GetNameMessage(fileName, labelIndex, UserLanguageID);
        }

        public string GetNameMessage(string fileName, int labelIndex, MessageEnumData.MsgLangId languageId)
        {
            if (!IsInitialize)
            {
                // Presumed logging that was commented out
                //MessageHelper.EmitLog("Datamodel not initialized", LogType.Error);
                return string.Empty;
            }

            return GetNameMessageDataModel(fileName, labelIndex, languageId).GetName();
        }

        public string GetNameMessage(string fileName, string label)
        {
            return GetNameMessage(fileName, label, UserLanguageID);
        }

        public string GetNameMessage(string fileName, string label, MessageEnumData.MsgLangId languageId)
        {
            if (!IsInitialize)
            {
                // Presumed logging that was commented out
                //MessageHelper.EmitLog("Datamodel not initialized", LogType.Error);
                return string.Empty;
            }

            return GetNameMessageDataModel(fileName, label, languageId).GetName();
        }

        public MessageGlossaryParseDataModel GetNameMessageDataModel(string fileName, int labelIndex)
        {
            return GetNameMessageDataModel(fileName, labelIndex, UserLanguageID);
        }

        public MessageGlossaryParseDataModel GetNameMessageDataModel(string fileName, int labelIndex, MessageEnumData.MsgLangId languageId)
        {
            if (!IsInitialize)
            {
                // Presumed logging that was commented out
                //MessageHelper.EmitLog("Datamodel not initialized", LogType.Error);
                return null;
            }

            return dataModel.GetGloosaryParseData(fileName, labelIndex, languageId);
        }

        public MessageGlossaryParseDataModel GetNameMessageDataModel(string fileName, string label)
        {
            return GetNameMessageDataModel(fileName, label, UserLanguageID);
        }

        public MessageGlossaryParseDataModel GetNameMessageDataModel(string fileName, string label, MessageEnumData.MsgLangId languageId)
        {
            if (!IsInitialize)
            {
                // Presumed logging that was commented out
                //MessageHelper.EmitLog("Datamodel not initialized", LogType.Error);
                return null;
            }

            return dataModel.GetGloosaryParseData(fileName, label, languageId);
        }

        public AttributeInfo GetAttributeInfo(string fileName, string label, MessageEnumData.MsgLangId languageId)
        {
            return dataModel.GetAttributeInfo(fileName, label, languageId);
        }

        public string GetSimpleMessage(string fileName, string label)
        {
            return GetSimpleMessage(fileName, label, UserLanguageID);
        }

        public string GetSimpleMessage(string fileName, string label, MessageEnumData.MsgLangId languageId)
        {
            if (!IsInitialize)
            {
                // Presumed logging that was commented out
                //MessageHelper.EmitLog("Datamodel not initialized", LogType.Error);
                return string.Empty;
            }

            var msbtData = dataModel.GetTextParseData(fileName, label, languageId);
            return msbtData != null ? msbtData.CreateSimpleMessage() : string.Empty;
        }

        public string GetSimpleMessage(string fileName, int labelIndex)
        {
            return GetSimpleMessage(fileName, labelIndex, UserLanguageID);
        }

        public string GetSimpleMessage(string fileName, int labelIndex, MessageEnumData.MsgLangId languageId)
        {
            if (!IsInitialize)
            {
                // Presumed logging that was commented out
                //MessageHelper.EmitLog("Datamodel not initialized", LogType.Error);
                return string.Empty;
            }

            var msbtData = dataModel.GetTextParseData(fileName, labelIndex, languageId);
            return msbtData != null ? msbtData.CreateSimpleMessage() : string.Empty;
        }

        private void OnCompleteLoadAssetBundle(LoadAssetBundleTask loadTask)
        {
            dataModel.AddMsgDataFile(loadTask.fileName, loadTask.msbtData);
        }

        private void OnCompleteLoadMsbtFile(LoadMsbtFileTask loadTask)
        {
            // Empty
        }

        private void OnChangedConfig(ConfigID configID, int value)
        {
            if (configID != ConfigID.LangJpnMode)
                return;

            if (value == 0)
            {
                if (IsKanji)
                {
                    dataModel.SetJPNKanjiFlag(false);
                    onChangeKanjiMode?.Invoke(false);
                }
            }
            else
            {
                if (!IsKanji)
                {
                    dataModel.SetJPNKanjiFlag(true);
                    onChangeKanjiMode?.Invoke(true);
                }
            }
        }

        public static WordDataModel GetWordDataFromPool()
        {
            var model = Instance.wordDataPool.Get();
            model.Init();
            return model;
        }

        public bool InsertSDCard { get => false; }
    }
}
