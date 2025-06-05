namespace Dpr.NetworkUtils
{
	public class NetPlayerNameData : ANetData<NetPlayerName>
	{
		public override byte GetDataID { get => 66; }
		public static byte DataID { get => 66; }
	}
}