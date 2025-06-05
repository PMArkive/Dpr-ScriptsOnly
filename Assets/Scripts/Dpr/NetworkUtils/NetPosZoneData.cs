namespace Dpr.NetworkUtils
{
	public class NetPosZoneData : ANetData<PosZoneData>
	{
		public override byte GetDataID { get => 67; }
		public static byte DataID { get => 67; }
	}
}