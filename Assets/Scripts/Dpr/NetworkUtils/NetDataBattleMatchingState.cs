namespace Dpr.NetworkUtils
{
	public class NetDataBattleMatchingState : ANetData<StationIndexData>
	{
		public override byte GetDataID { get => 51; }
		public static byte DataID { get => 51; }
	}
}