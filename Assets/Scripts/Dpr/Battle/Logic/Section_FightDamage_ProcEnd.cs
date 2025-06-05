namespace Dpr.Battle.Logic
{
	public sealed class Section_FightDamage_ProcEnd : Section
	{
		public Section_FightDamage_ProcEnd(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private void cureKori(WazaParam wazaParam, BTL_POKEPARAM attacker, PokeSet targets) { }
		
		// TODO
		private void cureSick_KOORI(BTL_POKEPARAM poke) { }
		
		// TODO
		private void friendPinchAction(PokeSet targets) { }
		
		// TODO
		private bool IsPinch(uint now_value, uint max_value) { return default; }
		
		// TODO
		private void checkItemReaction_ForTargets(PokeSet targets) { }
		
		// TODO
		private void checkItemReaction(BTL_POKEPARAM poke) { }

		public class Description
		{
			public ActionDesc actionDesc;
			public WazaParam wazaParam;
			public BTL_POKEPARAM attacker;
			public PokeSet targets;
			public bool byDelayAttack;
			
			public Description()
			{
				actionDesc = null;
				wazaParam = null;
				targets = null;
				byDelayAttack = false;
			}
		}

		public class Result { }
	}
}