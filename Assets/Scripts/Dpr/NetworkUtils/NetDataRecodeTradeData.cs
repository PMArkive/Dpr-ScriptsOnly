namespace Dpr.NetworkUtils
{
	public class NetDataRecodeTradeData : ANetData<RecodeTradeData>
	{
		public override byte GetDataID { get => 96; }
		public static byte DataID { get => 96; }
	}
}