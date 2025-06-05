namespace Dpr.NetworkUtils
{
	public class NetDataBattleMatchingReady : ANetData<BattleMatchingBaseData>
	{
		public override byte GetDataID { get => 50; }
		public static byte DataID { get => 50; }
	}
}