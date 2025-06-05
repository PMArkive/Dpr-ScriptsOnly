namespace Dpr.Battle.Logic
{
	public sealed class Section_MsgAfterWazaDamage : Section
	{
		public Section_MsgAfterWazaDamage(in CommonParam commonParam) : base(commonParam) { }

        // TODO
        public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private void putCriticalMessage(BTL_POKEPARAM attacker, WazaParam wazaParam, uint targetNum, BTL_POKEPARAM[] targets, CriticalType[] criticalTypes, bool isPluralHitWaza) { }
		
		// TODO
		private void checkBattleTalk(byte pokeID) { }

		public class Description
		{
			public DamageProcParams damageProcParam;
			public WazaParam wazaParam;
			public BTL_POKEPARAM attacker;
			public HITCHECK_PARAM hitCheckParam;
			public byte targetCount;
			public bool isPluralHitWaza;
			
			public Description()
			{
				damageProcParam = null;
				wazaParam = null;
				attacker = null;
				hitCheckParam = null;
				targetCount = 0;
				isPluralHitWaza = false;
			}
		}

		public class Result { }
	}
}