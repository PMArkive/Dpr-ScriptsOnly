using DPData;

namespace Dpr.NetworkUtils
{
	public class NetSecretBaseUpdate : ANetData<UgSecretBase>
	{
		public override byte GetDataID { get => 84; }
		public static byte DataID { get => 84; }
		public static byte NoticeID { get => 255; }
	}
}