namespace Dpr.NetworkUtils
{
	public class NetDataTransitionData : ANetData<TransitionData>
	{
		public override byte GetDataID { get => 7; }
		public static byte DataID { get => 7; }
	}
}