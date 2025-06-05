namespace Dpr.NetworkUtils
{
	public class NetRemainBonusTime : ANetData<IntData>
	{
		public override byte GetDataID { get => 73; }
		public static byte DataID { get => 73; }
	}
}