namespace Dpr.Battle.Logic
{
	public sealed class Section_CheckDeadAfterWazaDamage : Section
	{
		public Section_CheckDeadAfterWazaDamage(in CommonParam commonParam) : base(commonParam) { }

        // TODO
        public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private void checkTargetDead(HITCHECK_PARAM hitCheckParam, BTL_POKEPARAM attacker, WazaParam wazaParam, BTL_POKEPARAM target) { }
		
		// TODO
		private void checkAttackerDead_Before(BTL_POKEPARAM poke, WazaParam wazaParam) { }
		
		// TODO
		private void checkAttackerDead_After(BTL_POKEPARAM poke) { }

		public class Description
		{
			public DamageProcParams damageParams;
			public WazaParam wazaParam;
			public HITCHECK_PARAM hitCheckParam;
			public BTL_POKEPARAM attacker;
			public byte hitPokeCount;
			
			public Description()
			{
				damageParams = null;
				wazaParam = null;
				hitCheckParam = null;
				attacker = null;
				hitPokeCount = 0;
			}
		}

		public class Result { }
	}
}