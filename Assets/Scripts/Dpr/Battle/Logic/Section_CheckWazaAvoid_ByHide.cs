namespace Dpr.Battle.Logic
{
	public sealed class Section_CheckWazaAvoid_ByHide : Section
	{
		public Section_CheckWazaAvoid_ByHide(in CommonParam commonParam) : base(commonParam) { }

        // TODO
        public void Execute(Result pResult, in Description description) { }

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