namespace Dpr.Battle.Logic
{
	public sealed class Section_WazaExec_Category_Uncategory : Section
	{
		public Section_WazaExec_Category_Uncategory(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private void skillSwap(BTL_POKEPARAM attacker, PokeSet targets) { }
		
		// TODO
		private bool createMigawari(BTL_POKEPARAM attacker) { return default; }

		public class Description
		{
			public WazaParam wazaParam;
			public BTL_POKEPARAM attacker;
			public PokeSet targets;
			
			public Description()
			{
				wazaParam = null;
				attacker = null;
				targets = null;
			}
		}

		public class Result { }
	}
}