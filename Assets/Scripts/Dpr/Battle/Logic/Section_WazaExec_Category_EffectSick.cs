namespace Dpr.Battle.Logic
{
	public sealed class Section_WazaExec_Category_EffectSick : Section
	{
		public Section_WazaExec_Category_EffectSick(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private bool addRankEffect(ActionDesc actionDesc, WazaParam wazaParam, BTL_POKEPARAM attacker, BTL_POKEPARAM target) { return default; }
		
		// TODO
		private bool addSick(ActionDesc actionDesc, WazaParam wazaParam, BTL_POKEPARAM attacker, BTL_POKEPARAM target, bool isRankEffectEffective) { return default; }

		public class Description
		{
			public ActionDesc actionDesc;
			public WazaParam wazaParam;
			public BTL_POKEPARAM attacker;
			public PokeSet targets;
			
			public Description()
			{
				actionDesc = null;
				wazaParam = null;
				attacker = null;
				targets = null;
			}
		}

		public class Result { }
	}
}