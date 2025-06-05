namespace Dpr.NetworkUtils
{
	public class NetDigJoinMemberCount : ANetData<IntData>
	{
		public override byte GetDataID { get => 81; }
		public static byte DataID { get => 81; }
	}
}