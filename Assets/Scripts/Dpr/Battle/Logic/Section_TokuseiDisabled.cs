namespace Dpr.Battle.Logic
{
	public sealed class Section_TokuseiDisabled : Section
	{
		public Section_TokuseiDisabled(in CommonParam commonParam) : base(commonParam) { }

        // TODO
        public void Execute(Result result, in Description description) { }
		
		// TODO
		private void onKintyoukanMoved(BTL_POKEPARAM poke) { }

		public class Description
		{
			public BTL_POKEPARAM target;
			
			public Description()
			{
				target = null;
			}
		}

		public class Result { }
	}
}