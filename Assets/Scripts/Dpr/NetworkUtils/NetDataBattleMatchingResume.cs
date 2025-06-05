namespace Dpr.NetworkUtils
{
	public class NetDataBattleMatchingResume : ANetData<StationIndexData>
	{
		public override byte GetDataID { get => 64; }
		public static byte DataID { get => 64; }
	}
}