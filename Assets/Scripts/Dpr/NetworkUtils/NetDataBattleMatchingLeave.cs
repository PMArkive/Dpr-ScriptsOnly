namespace Dpr.NetworkUtils
{
	public class NetDataBattleMatchingLeave : ANetData<BattleMatchingBaseData>
	{
		public override byte GetDataID { get => 49; }
		public static byte DataID { get => 49; }
	}
}