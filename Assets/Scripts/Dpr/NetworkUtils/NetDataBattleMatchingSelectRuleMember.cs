namespace Dpr.NetworkUtils
{
	public class NetDataBattleMatchingSelectRuleMember : ANetData<BattleMatchingBaseData>
	{
		public override byte GetDataID { get => 53; }
		public static byte DataID { get => 53; }
	}
}