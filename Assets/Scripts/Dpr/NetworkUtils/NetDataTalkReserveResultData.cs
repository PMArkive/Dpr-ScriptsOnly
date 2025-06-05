namespace Dpr.NetworkUtils
{
	public class NetDataTalkReserveResultData : ANetData<TalkReserveResultData>
	{
		public override byte GetDataID { get => 100; }
		public static byte DataID { get => 100; }
	}
}