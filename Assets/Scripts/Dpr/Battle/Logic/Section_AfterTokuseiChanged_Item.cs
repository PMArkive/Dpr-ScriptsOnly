using Pml;

namespace Dpr.Battle.Logic
{
	public sealed class Section_AfterTokuseiChanged_Item : Section
	{
		public Section_AfterTokuseiChanged_Item(in CommonParam commonParam) : base(commonParam) { }

        // TODO
        public void Execute(Result pResult, in Description desc) { }
		
		// TODO
		private void checkItemReaction(BTL_POKEPARAM poke) { }
		
		// TODO
		private void onKintyoukanMoved(BTL_POKEPARAM poke) { }

		public class Description
		{
			public BTL_POKEPARAM poke;
			public TokuseiNo prevTokusei;
			public TokuseiNo nextTokusei;
		}

		public class Result { }
	}
}