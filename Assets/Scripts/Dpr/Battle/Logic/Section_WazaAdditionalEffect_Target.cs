namespace Dpr.Battle.Logic
{
	public sealed class Section_WazaAdditionalEffect_Target : Section
	{
		public Section_WazaAdditionalEffect_Target(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private void addRankEffect(ActionDesc actionDesc, WazaParam wazaParam, BTL_POKEPARAM attacker, BTL_POKEPARAM target) { }
		
		// TODO
		private void addSick(WazaParam wazaParam, BTL_POKEPARAM attacker, BTL_POKEPARAM target) { }

		public class Description
		{
			public ActionDesc actionDesc;
			public WazaParam wazaParam;
			public BTL_POKEPARAM attacker;
			public BTL_POKEPARAM defender;
			public uint damage;
			public bool fMigawriHit;
		}

		public class Result { }
	}
}