namespace Dpr.NetworkUtils
{
	public class NetPosData : ANetData<PosListData>
	{
		public override byte GetDataID { get => 2; }
		public static byte DataID { get => 2; }
	}
}