namespace Dpr.NetworkUtils
{
	public class NetSecretBaseInfo : ANetData<PosZoneData>
	{
		public override byte GetDataID { get => 65; }
		public static byte DataID { get => 65; }
	}
}