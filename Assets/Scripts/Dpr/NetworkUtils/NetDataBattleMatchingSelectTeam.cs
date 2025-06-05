namespace Dpr.NetworkUtils
{
	public class NetDataBattleMatchingSelectTeam : ANetData<StationIndexData>
	{
		public override byte GetDataID { get => 52; }
		public static byte DataID { get => 52; }
	}
}