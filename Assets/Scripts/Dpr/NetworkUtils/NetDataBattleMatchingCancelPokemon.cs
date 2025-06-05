namespace Dpr.NetworkUtils
{
	public class NetDataBattleMatchingCancelPokemon : ANetData<BattleMatchingBaseData>
	{
		public override byte GetDataID { get => 57; }
		public static byte DataID { get => 57; }
	}
}