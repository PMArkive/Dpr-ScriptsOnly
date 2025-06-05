namespace Dpr.NetworkUtils
{
	public class NetDataAttachSealNetData : ANetData<BallDecoData>
	{
		public override byte GetDataID { get => 21; }
		public static byte DataID { get => 21; }
	}
}