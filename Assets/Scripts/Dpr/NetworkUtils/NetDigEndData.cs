namespace Dpr.NetworkUtils
{
	public class NetDigEndData : ANetData<DigEndData>
	{
		public override byte GetDataID { get => 40; }
		public static byte DataID { get => 40; }
	}
}