namespace Dpr.NetworkUtils
{
	public class NetDataStandbyWaitData : ANetData<StandbyData>
	{
		public override byte GetDataID { get => 89; }
		public static byte DataID { get => 89; }
	}
}