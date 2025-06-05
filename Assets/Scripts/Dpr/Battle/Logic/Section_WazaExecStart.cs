using Pml;
using Pml.WazaData;

namespace Dpr.Battle.Logic
{
	public sealed class Section_WazaExecStart : Section
	{
		public Section_WazaExecStart(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private void event_StartWazaSeq(BTL_POKEPARAM attacker, WazaNo waza) { }
		
		// TODO
		private bool checkWazaFail_1st(BTL_POKEPARAM attacker, WazaParam wazaParam, ActionDesc actionDesc, bool isWazaLock, bool isTameLock) { return default; }
		
		// TODO
		private void registerWazaTargets(BTL_POKEPARAM pAttacker, WazaParam pWazaParam, BtlPokePos targetPos, byte aimTargetID, PokeSet pTargets) { }
		
		// TODO
		private bool decrementPP(BTL_POKEPARAM attacker, WazaNo orgWaza, WazaNo actWaza, PokeSet targets) { return default; }
		
		// TODO
		private void onFailed(BTL_POKEPARAM attacker, WazaNo waza, WazaFailCause failCause) { }
		
		// TODO
		private BtlPokePos correctReqWazaTargetPos(WazaNo orgWaza, BtlPokePos defaultTargetPos) { return default; }
		
		// TODO
		private WazaFailCause checkReqWazaFail(BTL_POKEPARAM attacker, WazaParam wazaParam) { return default; }
		
		// TODO
		private void event_WazaCallDecide(BTL_POKEPARAM attacker, WazaParam wazaParamOrg, WazaParam wazaParamAct) { }
		
		// TODO
		private void putWazaMessage(BTL_POKEPARAM pAttacker, WazaNo orgWazaID, WazaNo actWazaID, BtlPokePos actTargetPos) { }
		
		// TODO
		private bool checkWazaMsgCustom(BTL_POKEPARAM pAttacker, WazaNo orgWazaID, WazaNo actWazaID, StrParam pStrParam) { return default; }
		
		// TODO
		private bool checkWazaFail_2nd(BTL_POKEPARAM attacker, WazaParam wazaParam, PokeSet targets) { return default; }
		
		// TODO
		private bool checkWazaFail_Funjin(BTL_POKEPARAM attacker, WazaParam wazaParam) { return default; }
		
		// TODO
		private bool checkWazaFail_3rd(BTL_POKEPARAM attacker, WazaParam wazaParam, PokeSet targets) { return default; }
		
		// TODO
		private void cureSick(BTL_POKEPARAM poke, WazaSick sick) { }
		
		// TODO
		private bool setDelayWazaReady(ref bool pIsWazaEnable, BTL_POKEPARAM attacker, WazaParam wazaParam, BtlPokePos targetPos) { return default; }
		
		// TODO
		private bool setCombiWazaReady(BTL_POKEPARAM attacker, WazaNo waza, BtlPokePos targetPos) { return default; }
		
		// TODO
		private void event_WazaExecDecide(BTL_POKEPARAM attacker, WazaParam wazaParam) { }
		
		// TODO
		private bool checkWazaRob(BTL_POKEPARAM attacker, WazaNo waza, PokeSet targets, WazaRobParam robParam) { return default; }
		
		// TODO
		public void checkBattleTalk(byte pokeID, WazaNo waza) { }

		public enum ResultCode : int
		{
			FAILED = 0,
			SUCCESSED = 1,
			DELAY_WAZA_SET = 2,
			COMBI_WAZA_READY = 3,
			ROBBED = 4,
		}

		public class Description
		{
			public PokeAction pPokemonAction;
			
			public Description()
			{
				pPokemonAction = null;
			}
		}

		public class Result
		{
			public ResultCode resultCode;
			public bool isWazaEffective;
			public bool isPPUsed;
			public WazaParam wazaParam = new WazaParam();
			public BtlPokePos targetPos;
			public PokeSet targets = new PokeSet();
			public WazaRobParam robParam = new WazaRobParam();
		}
	}
}