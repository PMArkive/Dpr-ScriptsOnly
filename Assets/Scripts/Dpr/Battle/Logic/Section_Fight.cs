using Pml;

namespace Dpr.Battle.Logic
{
	public sealed class Section_Fight : Section
	{
		public Section_Fight(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private void beforeFirstFight() { }
		
		// TODO
		private void wazaExecStart(out Section_WazaExecStart.ResultCode pResultCode, out bool pIsWazaEffective, out bool pIsPPUsed, WazaParam pActWaza, out BtlPokePos pTargetPos, PokeSet pTargets, WazaRobParam pRobParam, PokeAction pokeAction)
		{
			pResultCode = default;
			pIsWazaEffective = default;
			pIsPPUsed = default;
			pTargetPos = default;
		}
		
		// TODO
		private bool wazaExec(BTL_POKEPARAM attacker, WazaParam wazaParam, ActionDesc actionDesc, PokeSet targets) { return default; }
		
		// TODO
		private void wazaRob(WazaRobParam robParam, BTL_POKEPARAM attacker, WazaNo waza) { }
		
		// TODO
		private void putWazaMessage(BTL_POKEPARAM pAttacker, WazaParam pWazaParam, BtlPokePos targetPos) { }
		
		// TODO
		private bool needWazaMessageDisplay(in WazaNo wazaID) { return default; }
		
		// TODO
		private void wazaExecEnd(ActionDesc actionDesc, BTL_POKEPARAM attacker, WazaNo orgWaza, WazaParam wazaParam, BtlPokePos targetPos, bool isWazaHide, bool isWazaLock, bool isPPUsed, bool isWazaEffective) { }
		
		// TODO
		private void magicCoat(WazaNo waza) { }
		
		// TODO
		private void setPokeMemories(BTL_POKEPARAM pAttacker, PokeSet pTargets, WazaNo wazano, bool isSuccessWazaExecStart, bool isWazaEffective) { }

		public class Description
		{
			public PokeAction pokeAction;
			
			public Description()
			{
				pokeAction = null;
			}
		}

		public class Result { }
	}
}