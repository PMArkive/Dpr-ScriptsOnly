using Pml.Battle;

namespace Dpr.Battle.Logic
{
	public sealed class Section_FightDamageSide_MigawariDamage : Section
	{
		public Section_FightDamageSide_MigawariDamage(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private uint storeMigawariHitInfo(DamageProcParams damageProcParams, DamageCalcResult damageRecord) { return default; }
		
		// TODO
		public ushort addDamageToMigawari(ActionDesc actionDesc, WazaParam wazaParam, BTL_POKEPARAM attacker, BTL_POKEPARAM target, ushort damage, TypeAffinity.AffinityID affinity, CriticalType criticalType) { return default; }

		public class Description
		{
			public DamageCalcResult damageRecord;
			public ActionDesc actionDesc;
			public WazaParam wazaParam;
			public BTL_POKEPARAM attacker;
			public PokeSet pDamagedPokeSet;
			
			public Description()
			{
				damageRecord = null;
				actionDesc = null;
				wazaParam = null;
				attacker = null;
				pDamagedPokeSet = null;
			}
		}

		public class Result { }
	}
}