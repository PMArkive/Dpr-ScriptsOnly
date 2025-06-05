using Pml;

namespace Dpr.Battle.Logic
{
	public class RaidRewardItemData
	{
		public ItemNo itemno;
		public uint amount;
		
		public RaidRewardItemData()
		{
			itemno = ItemNo.DUMMY_DATA;
			amount = 0;
		}
		
		public void CopyFrom(RaidRewardItemData src)
		{
			itemno = src.itemno;
			amount = src.amount;
		}
	}
}