namespace Dpr.NetworkUtils
{
	public class NetDataTalkReserveData : ANetData<TalkReserveData>
	{
		public override byte GetDataID { get => 99; }
		public static byte DataID { get => 99; }
	}
}