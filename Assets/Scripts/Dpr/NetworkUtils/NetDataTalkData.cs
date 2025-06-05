namespace Dpr.NetworkUtils
{
	public class NetDataTalkData : ANetData<TalkData>
	{
		public override byte GetDataID { get => 6; }
		public static byte DataID { get => 6; }
	}
}