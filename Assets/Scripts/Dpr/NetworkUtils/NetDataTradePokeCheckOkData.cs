namespace Dpr.NetworkUtils
{
	public class NetDataTradePokeCheckOkData : ANetData<TradePokeCheckOkData>
	{
		public override byte GetDataID { get => 70; }
		public static byte DataID { get => 70; }
	}
}