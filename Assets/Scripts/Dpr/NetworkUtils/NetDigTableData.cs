namespace Dpr.NetworkUtils
{
	public class NetDigTableData : ANetData<UgStationID_to_DigFossilIDList>
	{
		public override byte GetDataID { get => 97; }
		public static byte DataID { get => 97; }
	}
}