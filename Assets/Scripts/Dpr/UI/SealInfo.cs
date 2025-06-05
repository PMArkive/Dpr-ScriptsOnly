using Dpr.BallDeco;
using Dpr.Message;
using GameData;
using XLSXContent;

namespace Dpr.UI
{
    public class SealInfo
    {
        private const string InfoMessageFileName = "dp_stickers_info";
        private SealTable.SheetSealData sealData;

	    public int SealId { get; set; }
        public int CategoryId { get => sealData.Category; }
        public int SortNumber { get => sealData.SortNumber; }
        public string IconAssetName { get => sealData.IconAssetbundleName; }

        public static string GetIconAssetName(int sealId)
        {
            return GetData(sealId)?.IconAssetbundleName;
        }

        public static SealTable.SheetSealData GetData(int sealId)
        {
            return DataManager.GetSealData((SealID)sealId);
        }

        public SealInfo(int id)
        {
            SealId = id;
            sealData = DataManager.GetSealData((SealID)id);
        }

        public int GetCount()
        {
            return BallDecoWork.GetSealCount(SealId);
        }

        public string GetInfoText()
        {
            return MessageManager.Instance.GetSimpleMessage(InfoMessageFileName, SealId);
        }
    }
}