namespace Dpr.NetworkUtils
{
	public class NetDataStandbyWaitListData : ANetData<StanbyListData>
	{
		public override byte GetDataID { get => 34; }
		public static byte DataID { get => 34; }
	}
}