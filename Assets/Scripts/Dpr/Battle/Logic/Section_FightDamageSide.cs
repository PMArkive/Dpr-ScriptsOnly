using Pml.Battle;

namespace Dpr.Battle.Logic
{
	public sealed class Section_FightDamageSide : Section
	{
		public Section_FightDamageSide(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private void migawariDamage(PokeSet pDamagedPokeSet, BTL_POKEPARAM pAttacker, ActionDesc pActionDesc, WazaParam pWazaParam, DamageCalcResult pDamageRec) { }
		
		// TODO
		private void damageDetermine(HITCHECK_PARAM pHitCheckParam, BTL_POKEPARAM pAttacker, WazaParam pWazaParam, DamageCalcResult pDamageRec) { }
		
		// TODO
		private byte checkRealHitPoke(DamageProcParams pDamageProcParam, DamageCalcResult pDamageRec) { return default; }
		
		// TODO
		private void checkAttackerDead(BTL_POKEPARAM attacker, WazaParam wazaParam) { }
		
		// TODO
		private void putWazaDamageCommand(DamageProcParams pDamageProcParam, BTL_POKEPARAM pAttacker, WazaParam pWazaParam, byte hitPokeCount) { }
		
		// TODO
		private void msgAfterWazaDamage(DamageProcParams pDamageProcParam, BTL_POKEPARAM pAttacker, WazaParam pWazaParam, HITCHECK_PARAM pHitCheckParam, byte targetPokeCount, bool isPluralHitWaza) { }
		
		// TODO
		private void recordWazaDamage(DamageProcParams pDamageProcParam, BTL_POKEPARAM pAttacker, WazaParam pWazaParam, BtlPokePos attackerPos, byte targetPokeCount, PokeSet pDamagedPokeSet) { }
		
		// TODO
		private void koraeru(BTL_POKEPARAM pPoke, KoraeruCause cause) { }
		
		// TODO
		private void additionalEffect(DamageProcParams pDamageProcParam, ActionDesc pActionDesc, WazaParam pWazaParam, BTL_POKEPARAM pAttacker, byte targetPokeCount) { }
		
		// TODO
		private void gShockEffect(BTL_POKEPARAM pAttacker, BTL_POKEPARAM pDefender, ActionDesc pActionDesc, WazaParam pWazaParam) { }
		
		// TODO
		public void damageReaction(BTL_POKEPARAM attacker, BTL_POKEPARAM defender, WazaParam wazaParam, TypeAffinity.AffinityID affinity, uint damage, CriticalType criticalType) { }
		
		// TODO
		private void checkDeadAfterWazaDamage(DamageProcParams pDamageProcParam, HITCHECK_PARAM pHitCheckParam, WazaParam pWazaParam, BTL_POKEPARAM pAttacker, byte targetPokeCount) { }

		public class Description
		{
			public BTL_POKEPARAM pAttacker;
			public ActionDesc pActionDesc;
			public DamageCalcResult pDmgRec;
			public WazaParam pWazaParam;
			public HITCHECK_PARAM pHitCheckParam;
			public bool isPluralHitWaza;
			public PokeSet pDamagedPokeSet;
		}

		public class Result
		{
			public uint dmgSum;
		}
	}
}