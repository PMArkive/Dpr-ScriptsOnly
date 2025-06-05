namespace Dpr.NetworkUtils
{
	public class NetDataBattleMatchingDecideTeam : ANetData<BattleMatchingBaseData>
	{
		public override byte GetDataID { get => 98; }
		public static byte DataID { get => 98; }
	}
}