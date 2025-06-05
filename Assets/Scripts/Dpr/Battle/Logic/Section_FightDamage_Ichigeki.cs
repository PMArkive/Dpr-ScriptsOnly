using Pml.Battle;

namespace Dpr.Battle.Logic
{
	public sealed class Section_FightDamage_Ichigeki : Section
	{
		public Section_FightDamage_Ichigeki(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }
		
		// TODO
		public ushort addDamage(BTL_POKEPARAM pAttacker, BTL_POKEPARAM pTarget, WazaParam pWazaParam, PokeSet pTargetPokeSet, PokeSet pDamagedPokeSet, TypeAffinity.AffinityID affinity, bool isMigawariHit) { return default; }
		
		// TODO
		private bool checkMigawariHit(BTL_POKEPARAM attacker, BTL_POKEPARAM defender, WazaParam wazaParam) { return default; }
		
		// TODO
		public ushort damageWithMigawari(BTL_POKEPARAM target, WazaParam wazaParam, TypeAffinity.AboutAffinityID affinityAbout) { return default; }
		
		// TODO
		private void deleteMigawari(BTL_POKEPARAM poke) { }
		
		// TODO
		private bool checkGuardEnable(BTL_POKEPARAM attacker, BTL_POKEPARAM defender, WazaParam wazaParam) { return default; }
		
		// TODO
		private KoraeruCause checkKoraeruEnable(ref ushort pDamage, BTL_POKEPARAM attacker, BTL_POKEPARAM defender) { return default; }
		
		// TODO
		public void onSucceeded(BTL_POKEPARAM target, BTL_POKEPARAM attacker, WazaParam wazaParam, TypeAffinity.AboutAffinityID affAbout) { }
		
		// TODO
		public void onKoraeru(BTL_POKEPARAM target, BTL_POKEPARAM attacker, WazaParam wazaParam, TypeAffinity.AboutAffinityID affAbout, KoraeruCause koraeruCause, ushort damage) { }
		
		// TODO
		private void section_Koraeru(BTL_POKEPARAM pPoke, KoraeruCause cause) { }
		
		// TODO
		private void addWazaDamageRecord(BtlPokePos attackerPos, BTL_POKEPARAM pAttacker, BTL_POKEPARAM pDefender, WazaParam pWazaParam, ushort damage) { }
		
		// TODO
		public void damageReaction(BTL_POKEPARAM attacker, BTL_POKEPARAM defender, WazaParam wazaParam, TypeAffinity.AffinityID affinity, uint damage, bool isHitMigawari) { }
		
		// TODO
		private void checkPokeDead(BTL_POKEPARAM pPoke, BTL_POKEPARAM attacker, WazaParam wazaParam) { }
		
		// TODO
		private SectionUtil.GWallUpdateResult updateGWallGauge(BTL_POKEPARAM pAttacker, PokeSet pDamagedPokeSet, WazaParam wazaParam) { return default; }

		public class Description
		{
			public DmgAffRec pAffinityRecorder;
			public WazaParam pWazaParam;
			public BTL_POKEPARAM pAttacker;
			public PokeSet pTargets;
			public PokeSet pDamagedPokeSet;
			
			public Description()
			{
				pAffinityRecorder = null;
				pWazaParam = null;
				pAttacker = null;
				pTargets = null;
				pDamagedPokeSet = null;
			}
		}

		public class Result
		{
			public SectionUtil.GWallUpdateResult gWallUpdateResult = new SectionUtil.GWallUpdateResult();
		}
	}
}