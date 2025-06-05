namespace Dpr.NetworkUtils
{
	public class NetDataBattleTypeData : ANetData<BattleTypeData>
	{
		public override byte GetDataID { get => 9; }
		public static byte DataID { get => 9; }
	}
}