using System.Collections.Generic;
using System.Text;

namespace Dpr.Message
{
    public class MessageWordDataPool
    {
        private List<WordDataModel> dataPool = new List<WordDataModel>();

        ~MessageWordDataPool()
        {
            Dispose();
            dataPool = null;
        }

        public void GeneratePool(int generateNum)
        {
            for (int i=0; i<generateNum; i++)
                AddPoolData();
        }

        private WordDataModel AddPoolData()
        {
            WordDataModel data = new WordDataModel();
            data.sb = new StringBuilder(MessageDataConstants.TEXT_CAPACITY_SIZE);
            data.strWidth = -1.0f;
            dataPool.Add(data);

            return data;
        }

        public WordDataModel Get()
        {
            WordDataModel data = dataPool.Find(x => !x.isUse);

            if (data == null)
            {
                MessageHelper.EmitLog("Add WordDataModel", UnityEngine.LogType.Log);
                data = AddPoolData();
            }

            data.isUse = true;
            return data;
        }

        public void Dispose()
        {
            dataPool.Clear();
        }
    }
}