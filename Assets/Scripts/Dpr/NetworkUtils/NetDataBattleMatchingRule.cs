namespace Dpr.NetworkUtils
{
	public class NetDataBattleMatchingRule : ANetData<BattleMatchingRuleData>
	{
		public override byte GetDataID { get => 55; }
		public static byte DataID { get => 55; }
	}
}