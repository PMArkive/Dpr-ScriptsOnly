using Pml;

namespace Dpr.Battle.Logic
{
	public static class BTL_ACTION
	{
		// TODO
		public static void SetFightParam(ref BTL_ACTION_PARAM p, byte pokeID, WazaNo waza, BtlPokePos targetPos, bool forbidGWaza = false, bool forceGWaza = false) { }
		
		// TODO
		public static void ChangeFightTargetPos(ref BTL_ACTION_PARAM p, BtlPokePos nextTargetPos) { }
		
		// TODO
		public static void FightParamToWazaInfoMode(ref BTL_ACTION_PARAM p) { }
		
		// TODO
		public static bool IsWazaInfoMode(ref BTL_ACTION_PARAM p) { return default; }
		
		// TODO
		public static bool IsFight(ref BTL_ACTION_PARAM p) { return default; }
		
		// TODO
		public static bool IsFightWithG(ref BTL_ACTION_PARAM p) { return default; }
		
		// TODO
		public static bool IsGStart(ref BTL_ACTION_PARAM p) { return default; }
		
		// TODO
		public static bool IsItem(ref BTL_ACTION_PARAM p) { return default; }
		
		// TODO
		public static bool IsCheer(ref BTL_ACTION_PARAM p) { return default; }
		
		// TODO
		public static WazaNo GetWazaID(ref BTL_ACTION_PARAM act) { return default; }
		
		// TODO
		public static BtlPokePos GetWazaTargetPos(ref BTL_ACTION_PARAM act) { return default; }
		
		// TODO
		public static WazaNo GetOriginalWazaID(ref BTL_ACTION_PARAM act) { return default; }
		
		// TODO
		public static void SetItemParam(ref BTL_ACTION_PARAM p, byte pokeID, ushort itemNumber, byte targetID, byte wazaIdx) { }
		
		// TODO
		public static void SetChangeParam(ref BTL_ACTION_PARAM p, byte posIdx, byte memberIdx) { }
		
		// TODO
		public static void SetChangeDepleteParam(ref BTL_ACTION_PARAM p) { }
		
		// TODO
		public static bool IsDeplete(in BTL_ACTION_PARAM p) { return default; }
		
		// TODO
		public static void SetEscapeParam(ref BTL_ACTION_PARAM p, byte pokeID) { }
		
		// TODO
		public static void SetCheer(ref BTL_ACTION_PARAM p) { }
		
		// TODO
		public static void SetSafariBall(ref BTL_ACTION_PARAM p, byte pokeID) { }
		
		// TODO
		public static void SetSafariEsa(ref BTL_ACTION_PARAM p, byte pokeID) { }
		
		// TODO
		public static void SetSafariDoro(ref BTL_ACTION_PARAM p, byte pokeID) { }
		
		// TODO
		public static void SetSafariYousumi(ref BTL_ACTION_PARAM p, byte pokeID) { }
		
		// TODO
		public static void SetNULL(ref BTL_ACTION_PARAM p) { }
		
		// TODO
		public static void SetSkip(ref BTL_ACTION_PARAM p, byte pokeID) { }
		
		// TODO
		public static BtlAction GetAction(in BTL_ACTION_PARAM p) { return default; }
		
		// TODO
		public static void SetRecPlayOver(ref BTL_ACTION_PARAM act) { }
		
		// TODO
		public static void SetRecPlayError(ref BTL_ACTION_PARAM act) { }
	}
}