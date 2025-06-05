using Dpr.NetworkUtils;

namespace Dpr.Contest
{
	public class ContestEntryNPCNetData : ANetData<ContestEntryNPCData>
	{
		public override byte GetDataID { get => (byte)SendDataType.EntryNPCData; }
	}
}