namespace Dpr.Message
{
    public class PlaceWordParam : AWordParamBase
    {
        public PlaceWordParam(string labelName)
        {
            strValue = labelName;
        }

        public override void SetWordParam(MessageTagDataModel tagDataModel)
        {
            tagDataModel.strValue = strValue;
            tagDataModel.isPlaceWord = true;
            tagDataModel.count = count;
            tagDataModel.attriCountability = countablity;
            tagDataModel.attriInitialSound = initialSound;
            tagDataModel.attriGender = gender;
            tagDataModel.attriArticle = articlePresence;
            tagDataModel.strWidth = strWidth;
        }
    }
}
