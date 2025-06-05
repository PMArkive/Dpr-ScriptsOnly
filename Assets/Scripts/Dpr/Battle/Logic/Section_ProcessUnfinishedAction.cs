namespace Dpr.Battle.Logic
{
	public sealed class Section_ProcessUnfinishedAction : Section
	{
		public Section_ProcessUnfinishedAction(in CommonParam commonParam) : base(commonParam) { }

        // TODO
        public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private void sortActionOrder(PokeActionContainer actionContainer) { }
		
		// TODO
		private void processAction(PokeAction pokeAction) { }
		
		// TODO
		private void onAllActionDone() { }
		
		// TODO
		private bool raidboss_checkAngryWazaEnable() { return default; }
		
		// TODO
		private void raidboss_addAngryWazaAction() { }

		public class Description
		{
			public PokeActionContainer pokeActionContainer;
			
			public Description()
			{
				pokeActionContainer = null;
			}
		}

		public class Result { }
	}
}