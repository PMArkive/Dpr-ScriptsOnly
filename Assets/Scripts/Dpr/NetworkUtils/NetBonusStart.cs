namespace Dpr.NetworkUtils
{
	public class NetBonusStart : ANetData<Dummy>
	{
		public override byte GetDataID { get => 72; }
		public static byte DataID { get => 72; }
	}
}