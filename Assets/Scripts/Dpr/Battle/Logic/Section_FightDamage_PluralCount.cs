using Pml.PokePara;

namespace Dpr.Battle.Logic
{
	public sealed class Section_FightDamage_PluralCount : Section
	{
		public Section_FightDamage_PluralCount(in CommonParam commonParam) : base(commonParam) { }

        // TODO
        public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private void calcDamage(DamageCalcResult dmgRec, BTL_POKEPARAM attacker, PokeSet targets, WazaParam wazaParam, DmgAffRec affRec, HITCHECK_PARAM hitCheckParam, uint hitCountIdx) { }
		
		// TODO
		private int getDamageRatio(in HITCHECK_PARAM hitCheckParam, uint hitCountIndex) { return default; }
		
		// TODO
		private uint damageSide(BTL_POKEPARAM attacker, ActionDesc actionDesc, WazaParam wazaParam, DamageCalcResult damageRecord, HITCHECK_PARAM hitCheckParam, PokeSet pDamagedPokeSet) { return default; }
		
		// TODO
		private SectionUtil.GWallUpdateResult updateGWallGauge(BTL_POKEPARAM pAttacker, PokeSet pDamagedPokeSet, WazaParam wazaParam) { return default; }
		
		// TODO
		private void checkItemReaction(BTL_POKEPARAM poke) { }
		
		// TODO
		public bool canContinueNextHit(BTL_POKEPARAM attacker, PokeSet targets, WazaParam wazaParam, HITCHECK_PARAM hitCheckParam, Sick attackerPrevSick, uint hitCountIdx) { return default; }
		
		// TODO
		private void checkBattleTalk(byte pokeID) { }
		
		// TODO
		private BTL_POKEPARAM getTarget(PokeSet pTargets, uint hitCountIdx) { return default; }
		
		// TODO
		private bool isTargetEnable(BTL_POKEPARAM pPoke) { return default; }

		public class Description
		{
			public BTL_POKEPARAM attacker;
			public ActionDesc actionDesc;
			public WazaParam wazaParam;
			public DmgAffRec affRec;
			public PokeSet targets;
			public PokeSet damagedPokeSet;
			public HITCHECK_PARAM hitCheckParam;
			
			public Description()
			{
				attacker = null;
				actionDesc = null;
				wazaParam = null;
				affRec = null;
				targets = null;
				damagedPokeSet = null;
				hitCheckParam = null;
			}
		}

		public class Result
		{
			public uint dmgSum;
			public SectionUtil.GWallUpdateResult gWallUpdateResult = new SectionUtil.GWallUpdateResult();
			public WazaEffectReservedPos wazaEffectReservePos = new WazaEffectReservedPos();
		}
	}
}