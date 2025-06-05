namespace Dpr.NetworkUtils
{
	public class NetEmotionData : ANetData<EmotionData>
	{
		public override byte GetDataID { get => 3; }
		public static byte DataID { get => 3; }
	}
}