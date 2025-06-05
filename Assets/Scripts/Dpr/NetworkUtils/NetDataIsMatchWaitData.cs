namespace Dpr.NetworkUtils
{
	public class NetDataIsMatchWaitData : ANetData<MatchWaitData>
	{
		public override byte GetDataID { get => 35; }
		public static byte DataID { get => 35; }
	}
}