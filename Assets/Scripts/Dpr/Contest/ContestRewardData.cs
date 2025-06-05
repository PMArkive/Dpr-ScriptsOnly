using Pml;

namespace Dpr.Contest
{
	public class ContestRewardData
	{
		public CategoryID categoryID;
		public RankID rankID;
		public bool bIsBestPerformer;
		public ResultID resultID;
		public int multiResult;
		public bool bIsMulti;
		public uint categoryRibbon = (uint)RibbonNo.NULL;
        public uint contestStarRibbon = (uint)RibbonNo.NULL;
        public int itemNo;
		public uint twinkleStarRibbon = (uint)RibbonNo.NULL;
	}
}