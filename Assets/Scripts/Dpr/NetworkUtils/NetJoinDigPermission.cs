namespace Dpr.NetworkUtils
{
	public class NetJoinDigPermission : ANetData<JoinDigPermission>
	{
		public override byte GetDataID { get => 68; }
		public static byte DataID { get => 68; }
	}
}