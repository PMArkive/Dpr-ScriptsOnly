namespace Dpr.NetworkUtils
{
	public class NetDataBattleMatchingDecideRuleMember : ANetData<BattleMatchingBaseData>
	{
		public override byte GetDataID { get => 54; }
		public static byte DataID { get => 54; }
	}
}