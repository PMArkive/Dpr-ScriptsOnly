namespace Dpr.NetworkUtils
{
	public class NetKousekiCount : ANetData<IntData>
	{
		public override byte GetDataID { get => 80; }
		public static byte DataID { get => 80; }
	}
}