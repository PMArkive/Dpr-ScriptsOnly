namespace Dpr.Battle.Logic
{
	public sealed class Section_CheckAttackerDead : Section
	{
		public Section_CheckAttackerDead(in CommonParam commonParam) : base(commonParam) { }

        // TODO
        public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private void checkPokeDead(BTL_POKEPARAM poke) { }

		public class Description
		{
			public BTL_POKEPARAM attacker;
			public WazaParam wazaParam;
			
			public Description()
			{
				attacker = null;
				wazaParam = null;
			}
		}

		public class Result { }
	}
}