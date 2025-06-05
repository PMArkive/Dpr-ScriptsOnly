using Pml;
using Pml.Personal;
using Pml.PokePara;

namespace Dpr.Battle.Logic
{
	public static class ExpCalculator
	{
		private static readonly calcEffortExp_PokeTableElem[] RelationTbl = new calcEffortExp_PokeTableElem[]
		{
			new calcEffortExp_PokeTableElem(ParamID.PAINS_HP,    PowerID.HP,    (ushort)ItemNo.PAWAAUEITO),
			new calcEffortExp_PokeTableElem(ParamID.PAINS_ATK,   PowerID.ATK,   (ushort)ItemNo.PAWAARISUTO),
			new calcEffortExp_PokeTableElem(ParamID.PAINS_DEF,   PowerID.DEF,   (ushort)ItemNo.PAWAABERUTO),
            new calcEffortExp_PokeTableElem(ParamID.PAINS_AGI,   PowerID.AGI,   (ushort)ItemNo.PAWAAANKURU),
            new calcEffortExp_PokeTableElem(ParamID.PAINS_SPATK, PowerID.SPATK, (ushort)ItemNo.PAWAARENZU),
			new calcEffortExp_PokeTableElem(ParamID.PAINS_SPDEF, PowerID.SPDEF, (ushort)ItemNo.PAWAABANDO),
		};
		private static readonly ParamID[] PERSONAL_PARAM_TABLE = new ParamID[]
		{
            ParamID.PAINS_HP,  ParamID.PAINS_ATK,   ParamID.PAINS_DEF,
            ParamID.PAINS_AGI, ParamID.PAINS_SPATK, ParamID.PAINS_SPDEF,
        };
		
		// TODO
		public static bool CalcExp(CalcExpContainer result, in CalcParam param) { return default; }
		
		// TODO
		private static void calcExp_Party(CalcExpContainer result, MyStatus myStatus, in MainModule mainModule, in BTL_PARTY party, in BTL_POKEPARAM deadPoke) { }
		
		// TODO
		private static void calcExp_Poke(CalcExpWork result, MyStatus myStatus, in MainModule mainModule, in BTL_POKEPARAM bpp, in BTL_POKEPARAM deadPoke) { }
		
		// TODO
		private static uint getPokeGiveExp(in BTL_POKEPARAM bpp) { return default; }
		
		// TODO
		private static bool isEvoCanceledPoke(in BTL_POKEPARAM bpp) { return default; }
		
		// TODO
		private static void calcEffortExp_Party(CalcExpContainer result, in BTL_PARTY party, in BTL_POKEPARAM deadPoke) { }
		
		// TODO
		private static void calcEffortExp_Poke(CalcExpWork result, in BTL_POKEPARAM bpp, in BTL_POKEPARAM deadPoke) { }
		
		// TODO
		private static void calcGEffort_Party(CalcExpContainer result, in BTL_PARTY party, in BTL_POKEPARAM deadPoke) { }
		
		// TODO
		private static void calcGEffort_Poke(CalcExpWork result, in BTL_POKEPARAM bpp, in BTL_POKEPARAM deadPoke) { }

		public class CalcExpWork
		{
			public uint exp;
			public byte hp;
			public byte pow;
			public byte def;
			public byte agi;
			public byte sp_pow;
			public byte sp_def;
			public byte g;
			public bool fBonus;
			public bool bGakusyuSouti;
			public bool bGakusyuSoutiOnly;
			
			public void Clear()
			{
				pow = 0;
				def = 0;
				agi = 0;
				sp_pow = 0;
				sp_def = 0;
				g = 0;
				fBonus = false;
				bGakusyuSouti = false;
				exp = 0;
				hp = 0;
				pow = 0;
				def = 0;
				agi = 0;
				bGakusyuSoutiOnly = true;
			}
			
			// TODO
			public void Marge(in CalcExpWork rhs) { }
		}

		public class CalcExpContainer
		{
			public CalcExpWork[] work = Arrays.InitializeWithDefaultInstances<CalcExpWork>((int)BTL_CLIENT_ID.BTL_CLIENT_NUM);
			
			public CalcExpContainer()
			{
				Clear();
			}
			
			public void Clear()
			{
				for (int i=0; i<work.Length; i++)
					work[i].Clear();
			}
			
			// TODO
			public bool IsExpExist() { return default; }
			
			// TODO
			public void Marge(in CalcExpContainer rhs) { }
		}

		public class CalcParam
		{
			public MyStatus myStatus;
			public MainModule mainModule;
			public BTL_PARTY party;
			public BTL_POKEPARAM deadPoke;
			public bool canGainEffortValue;
			public bool canGainGEffort;
		}

		private enum kStatusIndex : int
		{
			_HP = 0,
			_POW = 1,
			_DEF = 2,
			_AGI = 3,
			_SPOW = 4,
			_SDEF = 5,
			_PARAM_MAX = 6,
		}

		private struct calcEffortExp_PokeTableElem
		{
			public ParamID personalParamID;
			public PowerID pokeParamID;
			public ushort boostItemID;
			
			public calcEffortExp_PokeTableElem(ParamID personalParamID, PowerID pokeParamID, ushort boostItemID)
			{
				this.personalParamID = personalParamID;
				this.pokeParamID = pokeParamID;
				this.boostItemID = boostItemID;
			}
		}
	}
}