namespace Dpr.Battle.Logic
{
	public sealed class Section_WazaAdditionalEffect : Section
	{
		public Section_WazaAdditionalEffect(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private void shrink(WazaParam wazaParam, BTL_POKEPARAM attacker, BTL_POKEPARAM defender) { }
		
		// TODO
		private void drain(WazaParam wazaParam, BTL_POKEPARAM attacker, BTL_POKEPARAM defender, ushort damage) { }
		
		// TODO
		private void additionalEffect(ActionDesc actionDesc, WazaParam wazaParam, BTL_POKEPARAM attacker, BTL_POKEPARAM defender, ushort damage) { }
		
		// TODO
		private void additionalEffect_User(ActionDesc actionDesc, WazaParam wazaParam, BTL_POKEPARAM attacker) { }

		public class Description
		{
			public DamageProcParams pParams;
			public ActionDesc actionDesc;
			public WazaParam pWazaParam;
			public BTL_POKEPARAM pAttacker;
			public byte pokeCnt;
		}

		public class Result { }
	}
}