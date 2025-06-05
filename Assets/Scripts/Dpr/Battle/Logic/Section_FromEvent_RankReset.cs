namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_RankReset : Section
	{
		public Section_FromEvent_RankReset(in CommonParam commonParam) : base(commonParam) { }

        // TODO
        public void Execute(Result result, in Description description) { }

		public class Description
		{
			public byte pokeCount;
			public byte[] pokeID = new byte[DefineConstants.BTL_POSIDX_MAX];
			
			public Description()
			{
				pokeCount = 0;
			}
		}

		public class Result
		{
			public bool isSuccessed;
		}
	}
}