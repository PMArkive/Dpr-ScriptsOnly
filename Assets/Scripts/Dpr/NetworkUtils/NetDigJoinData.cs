namespace Dpr.NetworkUtils
{
	public class NetDigJoinData : ANetData<DigJoinData>
	{
		public override byte GetDataID { get => 38; }
		public static byte DataID { get => 38; }
	}
}