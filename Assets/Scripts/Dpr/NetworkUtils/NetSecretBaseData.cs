using DPData;

namespace Dpr.NetworkUtils
{
	public class NetSecretBaseData : ANetData<UgSecretBase>
	{
		public override byte GetDataID { get => 24; }
		public static byte DataID { get => 24; }
	}
}