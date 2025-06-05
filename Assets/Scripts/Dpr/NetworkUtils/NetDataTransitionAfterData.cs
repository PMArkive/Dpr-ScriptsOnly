namespace Dpr.NetworkUtils
{
	public class NetDataTransitionAfterData : ANetData<TransitionAfterData>
	{
		public override byte GetDataID { get => 32; }
		public static byte DataID { get => 32; }
	}
}