namespace Dpr.NetworkUtils
{
	public class NetTradePokeData : ANetData<TradePokeData>
	{
		public override byte GetDataID { get => 19; }
		public static byte DataID { get => 19; }
	}
}