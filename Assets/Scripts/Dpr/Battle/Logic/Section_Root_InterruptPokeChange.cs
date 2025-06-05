namespace Dpr.Battle.Logic
{
	public sealed class Section_Root_InterruptPokeChange : Section
	{
		public Section_Root_InterruptPokeChange(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private void storePokeActions(PokeActionContainer pokeActionContainer, SVCL_ACTION pClientInstructions) { }
		
		// TODO
		private void processInterruptPokeChangeAction(PokeActionContainer pokeActionContainer) { }
		
		// TODO
		private void processUnfinishedAction() { }
		
		// TODO
		private void turnCheck() { }
		
		// TODO
		private void coverCheck() { }
		
		// TODO
		private void onTurnEnd() { }

		public class Description
		{
			public SVCL_ACTION pClientInstructions;
			
			public Description()
			{
				pClientInstructions = null;
			}
		}

		public class Result
		{
			public InterruptCode interrupt;
		}
	}
}