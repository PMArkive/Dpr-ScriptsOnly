namespace Dpr.NetworkUtils
{
	public class NetDataSelectData : ANetData<SelectData>
	{
		public override byte GetDataID { get => 8; }
		public static byte DataID { get => 8; }
	}
}