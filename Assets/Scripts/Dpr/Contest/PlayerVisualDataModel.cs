namespace Dpr.Contest
{
	public class PlayerVisualDataModel : PlayerVisualData
	{
		// TODO
		public void SetScore(int stickerScore, int itemScore, int conditionScore, int checkLargetHeartCount) { }
		
		public bool IsEmitHeart { get => emitNormalHeartNum > 0 || emitLargeHeartNum > 0; }
		public int TotalHeartNum { get => emitLargeHeartNum + emitNormalHeartNum; }
		
		// TODO
		private int CalcHeartNum() { return default; }
	}
}