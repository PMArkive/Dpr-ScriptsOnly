using Dpr.NetworkUtils;

namespace Dpr.Contest
{
	public class ContestInfoNetData : ANetData<ContestInfoData>
	{
		public override byte GetDataID { get => (byte)SendDataType.ContestInfoData; }
	}
}