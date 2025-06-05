namespace Dpr.NetworkUtils
{
	public class NetDataTradeReadyOkData : ANetData<ReadyOkData>
	{
		public override byte GetDataID { get => 33; }
		public static byte DataID { get => 33; }
	}
}