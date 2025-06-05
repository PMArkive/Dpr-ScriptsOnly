namespace Dpr.NetworkUtils
{
	public class NetZoneData : ANetData<PosZoneData>
	{
		public override byte GetDataID { get => 23; }
		public static byte DataID { get => 23; }
	}
}