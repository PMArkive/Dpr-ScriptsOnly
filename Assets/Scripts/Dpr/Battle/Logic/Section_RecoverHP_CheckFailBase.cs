namespace Dpr.Battle.Logic
{
	public sealed class Section_RecoverHP_CheckFailBase : Section
	{
		public Section_RecoverHP_CheckFailBase(in CommonParam commonParam) : base(commonParam) { }

        // TODO
        public void Execute(Result pResult, in Description description) { }

		public class Description
		{
			public BTL_POKEPARAM poke;
			
			public Description()
			{
				poke = null;
			}
		}

		public class Result
		{
			public bool isFailed;
		}
	}
}