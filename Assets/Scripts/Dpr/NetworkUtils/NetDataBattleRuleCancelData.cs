namespace Dpr.NetworkUtils
{
	public class NetDataBattleRuleCancelData : ANetData<BattleCancelData>
	{
		public override byte GetDataID { get => 17; }
		public static byte DataID { get => 17; }
	}
}