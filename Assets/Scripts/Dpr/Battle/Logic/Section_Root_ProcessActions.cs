namespace Dpr.Battle.Logic
{
	public sealed class Section_Root_ProcessActions : Section
	{
		public Section_Root_ProcessActions(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private void onTurnStart() { }
		
		// TODO
		private void storePokeActions(SVCL_ACTION pClientInstructions) { }
		
		// TODO
		private void sortPokeActionOrder() { }
		
		// TODO
		private void setSpActPriority() { }
		
		// TODO
		private void processUnfinishedAction() { }
		
		// TODO
		private void turnCheck() { }
		
		// TODO
		private void coverCheck() { }
		
		// TODO
		private void turnEnd() { }

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