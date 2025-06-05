namespace Dpr.Battle.Logic
{
	public sealed class Section_RankFlat_Recover : Section
	{
		public Section_RankFlat_Recover(in CommonParam commonParam) : base(commonParam) { }

        // TODO
        public void Execute(Result result, in Description description) { }

		public class Description
		{
			public byte pokeID;
			
			public Description()
			{
				pokeID = PokeID.INVALID;
			}
		}

		public class Result
		{
			public bool isSuccessed;
		}
	}
}