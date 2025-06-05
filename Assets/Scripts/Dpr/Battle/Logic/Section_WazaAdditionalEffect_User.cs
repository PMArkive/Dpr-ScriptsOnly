namespace Dpr.Battle.Logic
{
	public sealed class Section_WazaAdditionalEffect_User : Section
	{
		public Section_WazaAdditionalEffect_User(in CommonParam commonParam) : base(commonParam) { }

        // TODO
        public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private void addRankEffect(BTL_POKEPARAM attacker, WazaParam wazaParam, ActionDesc actionDesc) { }

		public class Description
		{
			public ActionDesc actionDesc;
			public WazaParam wazaParam;
			public BTL_POKEPARAM attacker;
		}

		public class Result { }
	}
}