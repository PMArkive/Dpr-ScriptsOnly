using Pml;

namespace Dpr.Battle.Logic
{
	public static class SectionUtil
	{
		// TODO
		public static bool CheckShowdown(MainModule mainModule, BattleEnv battleEnv) { return default; }
		
		// TODO
		private static bool checkShowdown_Raid(MainModule mainModule, BattleEnv battleEnv) { return default; }
		
		// TODO
		private static bool checkAllDeadSideExist(MainModule mainModule, BattleEnv battleEnv) { return default; }
		
		// TODO
		public static bool CheckAllDeadSide(MainModule mainModule, BattleEnv battleEnv, BtlSide checkSide) { return default; }
		
		// TODO
		private static bool checkAllDeadClient(BattleEnv pBattleEnv, BTL_CLIENT_ID clientID) { return default; }
		
		// TODO
		public static bool CheckSkipBattleAfterShowdown(MainModule mainModule) { return default; }
		
		// TODO
		public static bool CheckTurnEnd(InterruptCode interruptCode) { return default; }
		
		// TODO
		public static bool CheckPlayersClient(MainModule mainModule, BTL_CLIENT_ID clientID) { return default; }
		
		// TODO
		public static byte GetFriendship(MainModule mainModule, BTL_POKEPARAM poke) { return default; }
		
		// TODO
		public static bool CheckPlayersPoke(MainModule mainModule, BTL_POKEPARAM poke) { return default; }
		
		// TODO
		public static bool CheckPlayersFriendPoke(MainModule mainModule, BTL_POKEPARAM poke) { return default; }
		
		// TODO
		public static bool CheckMustHit(MainModule mainModule, BTL_POKEPARAM attacker, BTL_POKEPARAM target, in PosPoke posPoke) { return default; }
		
		// TODO
		public static bool CheckSkyBattleFailWaza(MainModule mainModule, WazaNo waza) { return default; }
		
		// TODO
		public static WazaNo CheckEncoreWazaChange(PokeAction action) { return default; }

		public class GWallUpdateResult
		{
			public bool isBroken;
			public bool isBecameMax;
			
			public void CopyFrom(GWallUpdateResult src)
			{
				isBroken = src.isBroken;
				isBecameMax = src.isBecameMax;
			}
		}
	}
}