using System.Collections.Generic;

namespace Dpr.Message
{
    public class MsbtDataModel
    {
        public MessageEnumData.MsgLangId langID;
        public string fileName;
        public int hash;
        private Dictionary<int, int> labelIndexTable;
        private LabelData[] labelDataArray;
        private bool bIsResident;
        private bool bIsCreate;
        private int currentIndex;

        public bool IsCreate { get => bIsCreate; }
        public bool IsResident { get => bIsResident; }

        public MsbtDataModel(LabelData[] labelDataArray, MessageEnumData.MsgLangId langID, int hash, string fileName, bool isResident)
        {
            this.bIsCreate = false;
            this.langID = langID;
            this.hash = hash;
            this.fileName = fileName.ToLower();
            this.labelDataArray = labelDataArray;
            this.bIsResident = isResident;
        }

        public void ClearData()
        {
            labelDataArray = null;
            labelIndexTable.Clear();
        }

        public void CreateLabelTable()
        {
            if (labelIndexTable == null)
                labelIndexTable = new Dictionary<int, int>();

            for (int i=currentIndex; i<labelDataArray.Length; i++, currentIndex = i)
            {
                if (!string.IsNullOrEmpty(labelDataArray[i].labelName))
                {
                    if (!labelIndexTable.ContainsKey(labelDataArray[i].labelName.GetHashCode()))
                        labelIndexTable.Add(labelDataArray[i].labelName.GetHashCode(), labelDataArray[i].arrayIndex);
                }
            }

            bIsCreate = true;
        }

        public LabelData[] LabelDataArray { get => labelDataArray; }

        public int GetTextNum()
        {
            return labelDataArray.Length;
        }

        public LabelData GetLabelDataByName(string labelName)
        {
            if (labelIndexTable.ContainsKey(labelName.GetHashCode()))
                return labelDataArray[labelIndexTable[labelName.GetHashCode()]];

            MessageHelper.EmitLog("[" + labelName + "] Label Not Found in ", UnityEngine.LogType.Error);
            return null;
        }

        public LabelData GetLabelDataByIndex(int labelIndex)
        {
            if (labelIndex > -1 && labelIndex < labelDataArray.Length)
                return labelDataArray[labelIndex];

            MessageHelper.EmitLog(string.Format("[{0}] Array Index Outof {1} : Total Num {2}", labelIndex, labelDataArray.Length), UnityEngine.LogType.Error);
            return null;
        }
    }
}
