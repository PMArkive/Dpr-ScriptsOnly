namespace Dpr.Battle.Logic
{
	public sealed class Section_CheckNoEffect_SimpleEffect : Section
	{
		public Section_CheckNoEffect_SimpleEffect(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private void removeNoEffectTarget(ActionDesc actionDesc, WazaParam wazaParam, BTL_POKEPARAM attacker, PokeSet targets) { }
		
		// TODO
		private void checkEffective(out bool pIsEffective, out SimpleEffectFailManager.Result pFailResult, BTL_POKEPARAM attacker, BTL_POKEPARAM target, WazaParam wazaParam, uint actionSerialNo)
		{
			pIsEffective = default;
			pFailResult = default;
		}
		
		// TODO
		private void putFailMessage(BTL_POKEPARAM attacker, BTL_POKEPARAM target, WazaParam wazaParam, uint actionSerialNo, SimpleEffectFailManager.Result failResult) { }
		
		// TODO
		private void putFailMessage_Others(BTL_POKEPARAM attacker, BTL_POKEPARAM target, WazaParam wazaParam, uint actionSerialNo) { }

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