namespace Dpr.NetworkUtils
{
	public class NetDataTranerCardData : ANetData<TranerData>
	{
		public override byte GetDataID { get => 5; }
		public static byte DataID { get => 5; }
	}
}