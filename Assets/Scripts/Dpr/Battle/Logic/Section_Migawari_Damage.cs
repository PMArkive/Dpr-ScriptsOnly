using Pml.Battle;

namespace Dpr.Battle.Logic
{
	public sealed class Section_Migawari_Damage : Section
	{
		public Section_Migawari_Damage(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }
		
		// TODO
		public void putDamageEffect(BTL_POKEPARAM attacker, BTL_POKEPARAM target, in WazaParam wazaParam, ushort damage, TypeAffinity.AffinityID affinity, CriticalType criticalType) { }
		
		// TODO
		private void putCricicalMessage(BTL_POKEPARAM attacker, BTL_POKEPARAM target, WazaParam wazaParam, in CriticalType criticalType) { }
		
		// TODO
		private ushort addDamage(BTL_POKEPARAM target, ushort damage) { return default; }
		
		// TODO
		private void deleteMigawari(BTL_POKEPARAM poke) { }
		
		// TODO
		private void drainHP(BTL_POKEPARAM attacker, BTL_POKEPARAM target, WazaParam wazaParam, ushort damage) { }
		
		// TODO
		private void additionalEffect(BTL_POKEPARAM attacker, BTL_POKEPARAM target, WazaParam wazaParam, ActionDesc actionDesc, ushort damage) { }
		
		// TODO
		private void additionalEffect_User(BTL_POKEPARAM attacker, WazaParam wazaParam, ActionDesc actionDesc) { }
		
		// TODO
		public void damageReaction(BTL_POKEPARAM attacker, BTL_POKEPARAM target, WazaParam wazaParam, TypeAffinity.AffinityID affinity, ushort damage, CriticalType criticalType) { }

		public class Description
		{
			public BTL_POKEPARAM attacker;
			public BTL_POKEPARAM target;
			public ushort damage;
			public TypeAffinity.AffinityID affinity;
			public CriticalType criticalType;
			public ActionDesc actionDesc;
			public WazaParam wazaParam;
			
			public Description()
			{
				attacker = null;
				target = null;
				damage = 0;
				affinity = TypeAffinity.AffinityID.TYPEAFF_1;
				criticalType = CriticalType.CRITICAL_NONE;
				actionDesc = null;
				wazaParam = null;
			}
		}

		public class Result
		{
			public ushort damage;
		}
	}
}