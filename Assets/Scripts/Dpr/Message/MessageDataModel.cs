using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Dpr.Message
{
    public class MessageDataModel
    {
        private const int LOAD_PROCESS_NUM = 20;
        private const string UNDER_BAR = "_";
        private Dictionary<int, MsbtDataModel> msbtDataTable = new Dictionary<int, MsbtDataModel>(0x200);
        private MessageEnumData.MsgLangId userLanguageId = MessageEnumData.MsgLangId.JPN;
        private LoadMsbtOperation loadMsbtOp = new LoadMsbtOperation();
        private StringBuilder fileNameCapSb = new StringBuilder();
        private string[] languageVariants;
        private bool bIsKanji;
        private bool bInit;
        private bool bInitialized;

        public bool Initialized { get => bInitialized; }
        public bool IsCalledInitialize { get => bInit; }
        public LoadMsbtOperation LoadMsbtOperation { get => loadMsbtOp; }
        public bool IsAlreadySetLoadOpData { get => loadMsbtOp.IsReady; }

        public void Initialize(MessageEnumData.MsgLangId languageId)
        {
            bIsKanji = false;
            msbtDataTable.Clear();
            SetUserSelectLanguageID(languageId);
            bInit = true;
        }

        public void InitializedManager()
        {
            bInitialized = true;
        }

        public void Dispose()
        {
            loadMsbtOp = null;
            msbtDataTable.Clear();
        }

        public MessageEnumData.MsgLangId UserSelectLanguageID { get => userLanguageId; }

        public void SetUserSelectLanguageID(MessageEnumData.MsgLangId languageId)
        {
            userLanguageId = languageId;
            fileNameCapSb.Clear();
            fileNameCapSb.Append(GetAssetFolderNameByLanguageId(languageId) + UNDER_BAR);

            languageVariants = new string[1]
            {
                MessageDataConstants.ROOT_FOLDER_NAME_TABLE[(int)userLanguageId].ToLower()
            };
        }

        public bool IsKanji { get => bIsKanji; }

        public void SetJPNKanjiFlag(bool flag)
        {
            bIsKanji = flag;
            SetUserSelectLanguageID(userLanguageId);
        }

        public string GetFileNameCapStr(MessageEnumData.MsgLangId languageId)
        {
            return GetAssetFolderNameByLanguageId(languageId) + UNDER_BAR;
        }

        public string GetJPNKanjiFileNameCapStr()
        {
            return GetJPNKanjiAssetBundleName() + UNDER_BAR;
        }

        public string ConvertMSBTFileKey(string fileName, MessageEnumData.MsgLangId languageId)
        {
            return ConvertMSBTFileKey(fileName, languageId, bIsKanji);
        }

        public string ConvertMSBTFileKey(string fileName, MessageEnumData.MsgLangId languageId, bool kanji)
        {
            string bundleName = "";
            if (languageId == MessageEnumData.MsgLangId.JPN && kanji)
            {
                bundleName = GetJPNKanjiAssetBundleName() + UNDER_BAR;
            }
            else if (userLanguageId == languageId)
            {
                bundleName = fileNameCapSb.ToString();
            }
            else
            {
                bundleName = GetAssetFolderNameByLanguageId(languageId) + UNDER_BAR;
            }

            return (bundleName + fileName).Replace(".msbt", "");
        }

        public string GetAssetBundleName(MessageEnumData.MsgLangId languageId)
        {
            return MessageDataConstants.ASSET_FOLDER_NAME_TABLE[(int)languageId];
        }

        public string GetJPNKanjiAssetBundleName()
        {
            return MessageDataConstants.JPN_KANJI_ASSET_FOLDER_NAME;
        }

        private string GetAssetFolderNameByLanguageId(MessageEnumData.MsgLangId languageId)
        {
            if (MessageDataConstants.ASSET_FOLDER_NAME_TABLE.ContainsKey((int)languageId))
                return GetAssetBundleName(languageId);

            string log = string.Format("LanguageID Not Found Table : {0}", languageId);
            // This is presumed to be commented out
            //Debug.Log(log);

            return string.Empty;
        }

        public string[] Variants { get => languageVariants; }

        public bool IsAlreadyLoadFile(string fileKey)
        {
            return msbtDataTable.ContainsKey(fileKey.GetHashCode());
        }

        public MessageMsgFile GetMsgFile(string fileName, MessageEnumData.MsgLangId languageId)
        {
            string key = ConvertMSBTFileKey(fileName, languageId, bIsKanji);

            if (IsAlreadyLoadFile(key))
            {
                return new MessageMsgFile(msbtDataTable[key.GetHashCode()]);
            }
            else
            {
                string log = "[" + key + "] File Not Loaded";
                // This is presumed to be commented out
                //Debug.Log(log);

                return null;
            }
        }

        public void AddMsgDataFile(string fileName, MsbtData msbtData)
        {
            if (msbtData == null)
                return;

            if (IsAlreadyLoadFile(fileName))
                return;

            msbtDataTable.Add(fileName.GetHashCode(), new MsbtDataModel(msbtData.labelDataArray, msbtData.langID, msbtData.hash, fileName, msbtData.isResident));
        }

        public void CreateAllLabelTable()
        {
            foreach (var key in msbtDataTable.Keys)
                msbtDataTable[key].CreateLabelTable();
        }

        public void SetLoadOperationData()
        {
            var array = new MsbtDataModel[msbtDataTable.Count];

            int i = 0;
            foreach (var key in msbtDataTable.Keys)
            {
                array[i] = msbtDataTable[key];
                i++;
            }

            loadMsbtOp.SetData(array, LOAD_PROCESS_NUM);
        }

        public void AddBinMsbtFileData(LoadMsbtFileTask loadTask)
        {
            // Empty
        }

        public void UnloadMSBTFileByLanguageId(MessageEnumData.MsgLangId langId)
        {
            var unloadList = new List<int>();
            foreach (var key in msbtDataTable.Keys)
            {
                if (!msbtDataTable[key].IsResident && msbtDataTable[key].langID == langId)
                    unloadList.Add(key);
            }

            foreach (var key in unloadList)
            {
                msbtDataTable[key].ClearData();
                msbtDataTable.Remove(key.GetHashCode());
            }
        }

        public AttributeInfo GetAttributeInfo(string fileName, string label, MessageEnumData.MsgLangId languageId)
        {
            return new AttributeInfo(GetLabelData(fileName, label, languageId).attributeValueArray);
        }

        public MessageGlossaryParseDataModel GetGloosaryParseData(string fileName, string label, MessageEnumData.MsgLangId languageId)
        {
            var labelData = GetLabelData(fileName, label, languageId);
            if (labelData == null)
                return null;

            var model = new MessageGlossaryParseDataModel();
            model.SetLabelData(labelData, languageId);
            return model;
        }

        public MessageGlossaryParseDataModel GetGloosaryParseData(string fileName, int labelIndex, MessageEnumData.MsgLangId languageId)
        {
            var labelData = GetLabelData(fileName, labelIndex, languageId);
            if (labelData == null)
                return null;

            var model = new MessageGlossaryParseDataModel();
            model.SetLabelData(labelData, languageId);
            return model;
        }

        public MessageTextParseDataModel GetTextParseData(string fileName, string label, MessageEnumData.MsgLangId languageId)
        {
            var labelData = GetLabelData(fileName, label, languageId);
            if (labelData == null)
                return null;

            var model = new MessageTextParseDataModel();
            model.SetLabelData(labelData, languageId);
            return model;
        }

        public MessageTextParseDataModel GetTextParseData(string fileName, int labelIndex, MessageEnumData.MsgLangId languageId)
        {
            var labelData = GetLabelData(fileName, labelIndex, languageId);
            if (labelData == null)
                return null;

            var model = new MessageTextParseDataModel();
            model.SetLabelData(labelData, languageId);
            return model;
        }

        private LabelData GetLabelData(string fileName, string labelName, MessageEnumData.MsgLangId languageId)
        {
            var key = ConvertMSBTFileKey(fileName, languageId, bIsKanji);
            if (!msbtDataTable.ContainsKey(key.GetHashCode()))
            {
                // Presumed logging that was commented out (string.Format result is ignored otherwise)
                //MessageHelper.EmitLog("[" + key + "] File Not Loaded", LogType.Error);
                return null;
            }

            return msbtDataTable[key.GetHashCode()].GetLabelDataByName(labelName);
        }

        private LabelData GetLabelData(string fileName, int labelIndex, MessageEnumData.MsgLangId languageId)
        {
            var key = ConvertMSBTFileKey(fileName, languageId, bIsKanji);
            if (!msbtDataTable.ContainsKey(key.GetHashCode()))
            {
                // Presumed logging that was commented out (string.Format result is ignored otherwise)
                //MessageHelper.EmitLog("[" + key + "] File Not Loaded", LogType.Error);
                return null;
            }

            return msbtDataTable[key.GetHashCode()].GetLabelDataByIndex(labelIndex);
        }

        public enum LoadResult : int
        {
            Success = 0,
            IsLoaded = 1,
            Failed = 2,
            IsRunning = 3,
        }
    }
}