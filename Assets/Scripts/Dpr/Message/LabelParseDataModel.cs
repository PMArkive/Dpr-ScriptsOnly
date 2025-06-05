using System.Collections.Generic;

namespace Dpr.Message
{
    public class LabelParseDataModel
    {
        private List<LabelTagDataModel> tagDataList = new List<LabelTagDataModel>();
        private List<string> stringList = new List<string>();

        public List<LabelTagDataModel> TagDataList { get => tagDataList; }
        public List<string> StringList { get => stringList; }

        public void AddTagDataModel(LabelTagDataModel tagDataModel)
        {
            tagDataList.Add(tagDataModel);
        }

        public void AddStringData(string str)
        {
            stringList.Add(str);
        }
    }
}