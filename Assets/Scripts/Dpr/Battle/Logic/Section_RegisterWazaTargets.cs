namespace Dpr.Battle.Logic
{
	public sealed class Section_RegisterWazaTargets : Section
	{
		public Section_RegisterWazaTargets(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private bool canAimTarget(BTL_POKEPARAM attacker, WazaParam wazaParam, byte aimTargetID) { return default; }
		
		// TODO
		private bool checkTemptEnable(BTL_POKEPARAM attacker, bool enable) { return default; }
		
		// TODO
		private BTL_POKEPARAM checkTemptPokemon(BTL_POKEPARAM target, BTL_POKEPARAM attacker, WazaParam wazaParam, ref bool isInterrupted) { return default; }
		
		// TODO
		private byte checkTemptPokeID(BTL_POKEPARAM attacker, WazaParam wazaParam, byte targetPokeID, ref bool isInterrupted) { return default; }
		
		// TODO
		private void increaseTarget(BTL_POKEPARAM attacker, PokeSet targets) { }
		
		// TODO
		private bool correctTargetDead(BtlRule rule, BTL_POKEPARAM attacker, WazaParam wazaParam, BtlPokePos targetPos, PokeSet rec) { return default; }
		
		// TODO
		private BTL_POKEPARAM correctTargetDeadSub_decideTarget(BTL_POKEPARAM attacker, BtlPokePos defaultTargetPos, byte targetListCount, BTL_POKEPARAM[] targets) { return default; }
		
		// TODO
		private byte correctTargetDeadSub_storeNextTargets(BTL_POKEPARAM[] dstNextTarget, BTL_POKEPARAM attacker, WazaParam wazaParam) { return default; }
		
		// TODO
		private void selectWazaTargets(MainModule mainModule, BattleEnv battleEnv, BTL_POKEPARAM attacker, BtlPokePos targetPos, WazaParam wazaParam, byte intrPokeID, PokeSet rec, ref bool isTargetTemptEnable) { }
		
		// TODO
		private void selectWazaTargets_Single(MainModule mainModule, BattleEnv battleEnv, BTL_POKEPARAM attacker, BtlPokePos targetPos, WazaParam wazaParam, byte intrPokeID, PokeSet rec) { }
		
		// TODO
		private void selectWazaTargets_Double(MainModule mainModule, BattleEnv battleEnv, BTL_POKEPARAM attacker, BtlPokePos targetPos, WazaParam wazaParam, byte intrPokeID, PokeSet rec, ref bool isTargetTemptEnable) { }
		
		// TODO
		private void selectWazaTargets_Raid(MainModule mainModule, BattleEnv battleEnv, BTL_POKEPARAM attacker, BtlPokePos targetPos, WazaParam wazaParam, byte intrPokeID, PokeSet rec, ref bool isTargetTemptEnable) { }
		
		// TODO
		private BTL_POKEPARAM getOpponentPokemon(MainModule mainModule, POKECON pokecon, BtlPokePos myPoso, byte opponentPokeIndex) { return default; }
		
		// TODO
		private BTL_POKEPARAM getNextPokemon(MainModule mainModule, POKECON pokecon, BtlPokePos myPoso) { return default; }
		
		// TODO
		private BtlPokePos correctNoroiTarget(MainModule mainModule, POKECON pokecon, WazaParam wazaParam, BTL_POKEPARAM attacker, BtlPokePos targetPos) { return default; }
		
		// TODO
		private void removeNotExistTargets(PokeSet targets) { }

		public class Description
		{
			public BTL_POKEPARAM pAttacker;
			public WazaParam pWazaParam;
			public BtlPokePos targetPos = BtlPokePos.POS_NULL;
			public byte aimTargetID = PokeID.INVALID;
			public PokeSet pPokeSet;
		}

		public class Result { }
	}
}