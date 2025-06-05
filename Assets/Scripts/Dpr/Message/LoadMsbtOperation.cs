using UnityEngine;

namespace Dpr.Message
{
    public class LoadMsbtOperation : CustomYieldInstruction
    {
        private bool bIsReady;
        private MsbtDataModel[] dataModelArray;
        private int arrayNum;
        private int currentIndex;
        private int processingFileNum;

        public bool IsReady { get => bIsReady; }

        public void SetData(MsbtDataModel[] dataModelArray, int processingFileNum)
        {
            currentIndex = 0;
            this.dataModelArray = dataModelArray;
            arrayNum = dataModelArray.Length;
            this.processingFileNum = processingFileNum;
            bIsReady = true;
        }

        public override bool keepWaiting
        {
            get
            {
                if (!bIsReady)
                    return true;

                for (int i=0; currentIndex<arrayNum; i++, currentIndex++)
                {
                    var item = dataModelArray[i];
                    if (!item.IsCreate)
                        item.CreateLabelTable();

                    if (processingFileNum <= i+1)
                        return true;
                }

                bIsReady = false;
                return false;
            }
        }
    }
}