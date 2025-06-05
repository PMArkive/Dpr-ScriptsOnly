namespace Dpr.Battle.Logic
{
	public sealed class Section_Root_Cover : Section
	{
		public Section_Root_Cover(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private void storePokeActions(SVCL_ACTION pClientInstructions) { }
		
		// TODO
		private void sortPokeActionOrder() { }
		
		// TODO
		private void processCoverAction() { }
		
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