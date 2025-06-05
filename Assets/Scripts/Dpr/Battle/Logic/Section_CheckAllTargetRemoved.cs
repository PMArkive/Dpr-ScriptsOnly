namespace Dpr.Battle.Logic
{
	public sealed class Section_CheckAllTargetRemoved : Section
	{
		public Section_CheckAllTargetRemoved(in CommonParam commonParam) : base(commonParam) { }

        // TODO
        public void Execute(Result pResult, in Description description) { }

		public class Description
		{
			public BTL_POKEPARAM attacker;
			public WazaParam wazaParam;
			public PokeSet targets;
			
			public Description()
			{
				attacker = null;
				wazaParam = null;
				targets = null;
			}
		}

		public class Result
		{
			public bool isFailed;
		}
	}
}