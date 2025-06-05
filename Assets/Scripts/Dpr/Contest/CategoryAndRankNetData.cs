using Dpr.NetworkUtils;

namespace Dpr.Contest
{
	public class CategoryAndRankNetData : ANetData<CategoryAndRankData>
	{
		public override byte GetDataID { get => (byte)SendDataType.CategoryAndRank; }
	}
}