namespace Dpr.NetworkUtils
{
	public class NetDataTradeTranerData : ANetData<TradeTranerData>
	{
		public override byte GetDataID { get => 36; }
		public static byte DataID { get => 36; }
	}
}