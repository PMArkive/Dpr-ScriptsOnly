namespace Dpr.NetworkUtils
{
	public class NetDigGroupIdData : ANetData<UgStationID_to_DigFossilIDList>
	{
		public override byte GetDataID { get => 41; }
		public static byte DataID { get => 41; }
	}
}