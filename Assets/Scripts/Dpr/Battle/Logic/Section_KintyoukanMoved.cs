namespace Dpr.Battle.Logic
{
	public sealed class Section_KintyoukanMoved : Section
	{
		public Section_KintyoukanMoved(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private void checkItemReaction(BTL_POKEPARAM poke) { }

		public class Description
		{
			public BTL_POKEPARAM movedPoke;
			
			public Description()
			{
				movedPoke = null;
			}
		}

		public class Result { }
	}
}