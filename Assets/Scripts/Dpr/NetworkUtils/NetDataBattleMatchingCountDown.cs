namespace Dpr.NetworkUtils
{
	public class NetDataBattleMatchingCountDown : ANetData<BattleMatchingCountDownData>
	{
		public override byte GetDataID { get => 82; }
		public static byte DataID { get => 82; }
	}
}