namespace Dpr.NetworkUtils
{
	public class NetDataTalkCancelEndData : ANetData<CancelEndData>
	{
		public override byte GetDataID { get => 16; }
		public static byte DataID { get => 16; }
	}
}