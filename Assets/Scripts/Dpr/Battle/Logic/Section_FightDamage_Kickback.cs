namespace Dpr.Battle.Logic
{
	public sealed class Section_FightDamage_Kickback : Section
	{
		// TODO
		public Section_FightDamage_Kickback(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private uint calcKickBackDamage(BTL_POKEPARAM attacker, WazaParam wazaParam, uint wazaDamage, out bool pIsMustEnable)
		{
			pIsMustEnable = default;
			return default;
		}
		
		// TODO
		private bool isKickbackDamageEnable(BTL_POKEPARAM attacker, uint damage) { return default; }
		
		// TODO
		private void addDamage(BTL_POKEPARAM poke, uint damage) { }

		public class Description
		{
			public BTL_POKEPARAM pAttacker;
			public WazaParam pWazaParam;
			public uint damageSum;
			
			public Description()
			{
				pAttacker = null;
				pWazaParam = null;
				damageSum = 0;
			}
		}

		public class Result { }
	}
}