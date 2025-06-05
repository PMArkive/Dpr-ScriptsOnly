namespace Dpr.Battle.Logic
{
	public sealed class Section_SortByAgility : Section
	{
		public Section_SortByAgility(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }

		public class Description
		{
			public PokeSet targets;
		}

		public class Result { }
	}
}