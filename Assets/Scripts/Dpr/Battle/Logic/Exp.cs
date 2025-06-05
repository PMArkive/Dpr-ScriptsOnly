namespace Dpr.Battle.Logic
{
	public static class Exp
	{
		// TODO
		public static void CalcExp(in CalcParam calcParam, CalcResult pResult) { }
		
		// TODO
		private static uint CalcBaseExp(uint deadPokeExp, uint deadPokeLevel, uint pokeLevel) { return default; }
		
		// TODO
		private static uint CalcGakusyusoutiExp(uint baseExp) { return default; }
		
		// TODO
		private static uint getexp_calc_adjust_level(uint base_exp, ushort getpoke_lv, ushort deadpoke_lv) { return default; }
		
		// TODO
		private static float calc_adjust_level_sub(float fValue) { return default; }
		
		// TODO
		private static uint ApplyBonus_Received(uint exp, uint playerLangId, uint pokeLangId) { return default; }
		
		// TODO
		private static uint ApplyBonus_Siawasetamago(uint exp) { return default; }
		
		// TODO
		private static uint ApplyBonus_EvoCanceled(uint exp) { return default; }
		
		// TODO
		private static uint ApplyBonus_Friendship(uint exp) { return default; }

		public class CalcParam
		{
			public BtlCompetitor competitor;
			public uint playerLanguageId;
			public uint levelCap;
			public uint deadPokeExp;
			public uint deadPokeLevel;
			public uint getPokeLevel;
			public uint getPokeFriendship;
			public uint getPokeLanguageId;
			public bool isMatch;
			public bool isGakusyusoutiOn;
			public bool haveSiawasetamago;
			public bool isEvoCanceledPoke;
			public bool isMyPoke;
		}

		public class CalcResult
		{
			public uint exp;
			public bool byGakusyusouti;
			public bool isContainBonus;
		}
	}
}