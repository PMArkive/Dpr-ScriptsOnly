namespace Dpr.NetworkUtils
{
	public class NetDataBattleMatchingSelectPokemon : ANetData<BattleMatchingPokeData>
	{
		public override byte GetDataID { get => 56; }
		public static byte DataID { get => 56; }
	}
}