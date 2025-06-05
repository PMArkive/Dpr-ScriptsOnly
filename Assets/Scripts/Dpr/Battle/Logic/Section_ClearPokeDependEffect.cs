namespace Dpr.Battle.Logic
{
	public sealed class Section_ClearPokeDependEffect : Section
	{
		public Section_ClearPokeDependEffect(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private void releaseFreeFall(BTL_POKEPARAM poke) { }
		
		// TODO
		private void removeHandlers(BTL_POKEPARAM poke) { }
		
		// TODO
		private void cureDependPokeSick(BTL_POKEPARAM causePoke) { }
		
		// TODO
		private void removeDependPokeField(BTL_POKEPARAM causePoke) { }
		
		// TODO
		private void onKintyoukanMoved(BTL_POKEPARAM poke) { }

		public class Description
		{
			public BTL_POKEPARAM poke;
			
			public Description()
			{
				poke = null;
			}
		}

		public class Result { }
	}
}