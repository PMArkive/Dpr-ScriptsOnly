using Dpr.Item;
using Dpr.Message;
using GameData;
using XLSXContent;

namespace Dpr.UI
{
	public class KinomiInfo
	{
		private const float ParameterMaxValue = 50.0f;
		private const float RaderChartMinValue = 0.1f;
		private const float RaderChartMaxValue = 1.0f;

		private const string IconAssetNameFormat = "img_berry_{0:000}";
		private const string DescriptionMessageFileName = "dp_berries_info";

		private static readonly string[] HardnessTextLabels = new string[]
		{
            null,                 "DP_poffin_main_012", "DP_poffin_main_013",
			"DP_poffin_main_014", "DP_poffin_main_015", "DP_poffin_main_016",
        };
		
		public int Id { get => data.TagNo; }
		public int ItemId { get; set; }
		public int Index { get; set; }

        private KinomiData.SheetData data;

        public string DescriptionText { get => MessageManager.Instance.GetSimpleMessage(DescriptionMessageFileName, Index); }
		public string HardnessTextLabel { get => HardnessTextLabels[data.Firmness]; }
		
		public KinomiInfo(ItemInfo info)
		{
			Index = info.GroupId;
			ItemId = info.Id;
			data = DataManager.KinomiData.Data[Index];
		}
		
		// TODO
		public string GetIconAssetName() { return default; }
		
		public float GetSize { get => data.Size; }
		
		// TODO
		public float[] GetRaderChartValues()
		{
			// TODO
			float GetValue(int param) { return default; }

            return default;
		}
	}
}