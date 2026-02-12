namespace Dpr.Contest
{
	public sealed class ContestRewardDataModel : ContestRewardData
	{
		public bool IsBestPerformer { get => bIsBestPerformer; }
		
		public void ResetParam()
		{
			this.bIsMulti = 0;
			this[0] = 0;
			this.categoryID = 0;
			this.Length = 0;
			this.categoryRibbon = 0xff000000ff;
			this.itemNo = 0xff00000000;
		}
	}
}