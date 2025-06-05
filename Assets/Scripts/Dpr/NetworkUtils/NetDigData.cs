namespace Dpr.NetworkUtils
{
	public class NetDigData : ANetData<DigPosData>
	{
		public override byte GetDataID { get => 25; }
		public static byte DataID { get => 25; }
	}
}