namespace Dpr.NetworkUtils
{
	public class NetDataCurrentFlowCancelData : ANetData<CancelData>
	{
		public override byte GetDataID { get => 37; }
		public static byte DataID { get => 37; }
	}
}