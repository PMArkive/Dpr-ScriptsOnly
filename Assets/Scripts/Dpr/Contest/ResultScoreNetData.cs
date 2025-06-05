using Dpr.NetworkUtils;

namespace Dpr.Contest
{
	public class ResultScoreNetData : ANetData<ResultScore>
	{
		public override byte GetDataID { get => (byte)SendDataType.ResultScore; }
	}
}