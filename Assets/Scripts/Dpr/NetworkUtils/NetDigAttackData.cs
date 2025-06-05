namespace Dpr.NetworkUtils
{
	public class NetDigAttackData : ANetData<DigAttackData>
	{
		public override byte GetDataID { get => 39; }
		public static byte DataID { get => 39; }
	}
}