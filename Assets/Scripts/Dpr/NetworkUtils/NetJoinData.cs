namespace Dpr.NetworkUtils
{
	public class NetJoinData : ANetData<JoinData>
	{
		public override byte GetDataID { get => 1; }
		public static byte DataID { get => 1; }
	}
}