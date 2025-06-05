namespace Dpr.NetworkUtils
{
	public class NetDataReturnSelectData : ANetData<ReturnSelectData>
	{
		public override byte GetDataID { get => 69; }
		public static byte DataID { get => 69; }
	}
}