using Dpr.NetworkUtils;

namespace Dpr.Contest
{
	public class NoticeNetData : ANetData<ReadyData>
	{
		public override byte GetDataID { get => (byte)SendDataType.Notice; }
	}
}