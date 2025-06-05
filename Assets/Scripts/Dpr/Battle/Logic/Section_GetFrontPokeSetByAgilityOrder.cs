namespace Dpr.Battle.Logic
{
	public sealed class Section_GetFrontPokeSetByAgilityOrder : Section
	{
		public Section_GetFrontPokeSetByAgilityOrder(in CommonParam commonParam) : base(commonParam) { }

        // TODO
        public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private void storeFrontPoke(PokeSet pPokeSet) { }
		
		// TODO
		private void sortByAgility(PokeSet pPokeSet) { }

		public class Description
		{
			public PokeSet pPokeSet;
		}

		public class Result { }
	}
}