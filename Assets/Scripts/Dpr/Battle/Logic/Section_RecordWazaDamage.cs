namespace Dpr.Battle.Logic
{
	public sealed class Section_RecordWazaDamage : Section
	{
		public Section_RecordWazaDamage(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private void addWazaDamageRecord(BtlPokePos attackerPos, BTL_POKEPARAM attacker, BTL_POKEPARAM defender, WazaParam wazaParam, ushort damage) { }

		public class Description
		{
			public BTL_POKEPARAM attacker;
			public BtlPokePos attackerPos;
			public WazaParam wazaParam;
			public byte damageTargetNum;
			public DamageProcParams damageProcParams;
			public PokeSet damagedPokeSet;
			
			public Description()
			{
				attacker = null;
				attackerPos = BtlPokePos.POS_NULL;
				wazaParam = null;
				damageTargetNum = 0;
				damageProcParams = null;
				damagedPokeSet = null;
			}
		}

		public class Result { }
	}
}