namespace Dpr.Battle.Logic
{
	public sealed class Section_WazaExec_Effect : Section
	{
		public Section_WazaExec_Effect(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private void putWazaEffectCommand(WazaEffectParams pWazaEffect, WazaParam wazaParam, WazaEffectReservedPos pQueReservePos) { }
		
		// TODO
		private void eventOnWazaEffective(BTL_POKEPARAM poke, WazaParam wazaParam, ActionDesc actionDesc) { }
		
		// TODO
		private void onNotEffective(BTL_POKEPARAM poke, WazaParam wazaParam, ActionDesc actionDesc) { }

		public class Description
		{
			public BTL_POKEPARAM pAttacker;
			public ActionDesc pActionDesc;
			public WazaParam pWazaParam;
			public WazaEffectReservedPos pQueReservePos;
			public bool isWazaValid;
			
			public Description()
			{
				pAttacker = null;
				pActionDesc = null;
				pWazaParam = null;
				pQueReservePos = null;
				isWazaValid = false;
			}
		}

		public class Result { }
	}
}