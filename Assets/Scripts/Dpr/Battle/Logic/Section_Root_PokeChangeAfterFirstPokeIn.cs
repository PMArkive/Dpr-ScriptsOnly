namespace Dpr.Battle.Logic
{
	public sealed class Section_Root_PokeChangeAfterFirstPokeIn : Section
	{
		public Section_Root_PokeChangeAfterFirstPokeIn(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private void storePokeActions(PokeActionContainer pokeActionContainer, SVCL_ACTION pClientInstructions) { }
		
		// TODO
		private void processInterruptPokeChangeAction(PokeActionContainer pokeActionContainer) { }
		
		// TODO
		private void firstPokeInEnd() { }

		public class Description
		{
			public SVCL_ACTION pClientInstructions;
		}

		public class Result
		{
			public InterruptCode interrupt;
		}
	}
}