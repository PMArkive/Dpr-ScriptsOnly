namespace Dpr.Battle.Logic
{
	public sealed class Section_WazaExec_CheckFail_Funjin : Section
	{
		public Section_WazaExec_CheckFail_Funjin(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private bool doFunjinExplode(BTL_POKEPARAM attacker, WazaParam wazaParam) { return default; }
		
		// TODO
		private void putFunjinExplodeCommand(BTL_POKEPARAM attacker, WazaParam wazaParam) { }
		
		// TODO
		private bool isDamageEnable(BTL_POKEPARAM poke, uint damage) { return default; }
		
		// TODO
		private void addDamage(BTL_POKEPARAM damagePoke, uint damage) { }
		
		// TODO
		private void checkPokeDead(BTL_POKEPARAM poke) { }

		public class Description
		{
			public BTL_POKEPARAM attacker;
			public WazaParam wazaParam;
		}

		public class Result
		{
			public bool isFailed;
		}
	}
}