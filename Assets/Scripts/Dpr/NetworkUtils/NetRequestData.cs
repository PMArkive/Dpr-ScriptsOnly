namespace Dpr.NetworkUtils
{
	public class NetRequestData : ANetData<RequestData>
	{
		public override byte GetDataID { get => 18; }
		public static byte DataID { get => 18; }
	}
}