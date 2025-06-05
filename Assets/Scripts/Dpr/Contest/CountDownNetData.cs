using Dpr.NetworkUtils;

namespace Dpr.Contest
{
	public class CountDownNetData : ANetData<CountDownData>
	{
		public override byte GetDataID { get => (byte)SendDataType.CountDown; }
	}
}