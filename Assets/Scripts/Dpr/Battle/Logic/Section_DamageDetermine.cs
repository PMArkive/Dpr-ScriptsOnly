namespace Dpr.Battle.Logic
{
	public sealed class Section_DamageDetermine : Section
	{
		public Section_DamageDetermine(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private void damageDetermineEvent(DamageCalcResult damageRec, BTL_POKEPARAM attacker, WazaParam wazaParam) { }
		
		// TODO
		private void udpateCriticalCount(BTL_POKEPARAM pAttacker, DamageCalcResult pDamageRec) { }
		
		// TODO
		private void updateTotalDamageRecieved(DamageCalcResult pDamageRec) { }

		public class Description
		{
			public BTL_POKEPARAM pAttacker;
			public HITCHECK_PARAM pHitCheckParam;
			public DamageCalcResult pDamageRecord;
			public WazaParam pWazaParam;
			
			public Description()
			{
				pAttacker = null;
				pHitCheckParam = null;
				pDamageRecord = null;
				pWazaParam = null;
			}
		}

		public class Result { }
	}
}