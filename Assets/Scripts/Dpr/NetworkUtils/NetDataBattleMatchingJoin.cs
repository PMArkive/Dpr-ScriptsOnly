namespace Dpr.NetworkUtils
{
	public class NetDataBattleMatchingJoin : ANetData<JoinPlayerData>
	{
		public override byte GetDataID { get => 48; }
		public static byte DataID { get => 48; }
	}
}