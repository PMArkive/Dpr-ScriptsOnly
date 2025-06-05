namespace Dpr.NetworkUtils
{
	public class NetUgJoinData : ANetData<UgJoinData>
	{
		public override byte GetDataID { get => 22; }
		public static byte DataID { get => 22; }
	}
}