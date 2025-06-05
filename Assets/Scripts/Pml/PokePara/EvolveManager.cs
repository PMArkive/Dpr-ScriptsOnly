using XLSXContent;

namespace Pml.PokePara
{
	public sealed class EvolveManager
	{
		public const ushort EVOLVE_FRIENDSHIP = 160;
		
		public EvolveManager()
		{
			// Empty, declared explicitly
		}
		
		// TODO
		public MonsNo GetEvolvedMonsNo_byLevelUp(CoreParam poke, PokeParty party, EvolveSituation situation, ref uint root_num) { return default; }
		
		// TODO
		public MonsNo GetEvolvedMonsNo_byEvent(CoreParam poke, PokeParty party, EvolveSituation situation, ref uint root_num) { return default; }
		
		// TODO
		public MonsNo GetEvolvedMonsNo_byItem(CoreParam poke, EvolveSituation situation, uint use_item, ref uint root_num) { return default; }
		
		// TODO
		public MonsNo GetEvolvedMonsNo_byTrade(CoreParam poke, CoreParam pair_poke, ref uint root_num) { return default; }
		
		// TODO
		public bool HaveEvolutionRoot(CoreParam poke) { return default; }
		
		// TODO
		protected bool CheckItem_KAWARAZUNOISHI(uint item) { return default; }
		
		// TODO
		private bool canEvolve(CoreParam poke) { return default; }
		
		// TODO
		private bool IsSatisfyEvolveConditionLevelUp(CoreParam poke, PokeParty party, EvolveSituation situation, EvolveTable.SheetEvolve evolveData, int evolveRouteIndex) { return default; }
		
		// TODO
		private bool IsSatisfyEvolveConditionEvent(CoreParam poke, PokeParty party, EvolveSituation situation, EvolveTable.SheetEvolve evolveData, int evolveRouteIndex) { return default; }
		
		// TODO
		private bool IsSatisfyEvolveConditionItem(CoreParam poke, EvolveSituation situation, uint use_item, EvolveTable.SheetEvolve evolveData, int evolveRouteIndex) { return default; }
		
		// TODO
		private bool IsSatisfyEvolveConditionTrade(CoreParam poke, CoreParam pair_poke, EvolveTable.SheetEvolve evolveData, int evolveRouteIndex) { return default; }
	}
}