namespace Dpr.Battle.Logic
{
	public sealed class Section_DecrementPP : Section
	{
		public Section_DecrementPP(in CommonParam commonParam) : base(commonParam) { }

        // TODO
        public void Execute(Result pResult, in Description description) { }

		public class Description
		{
			public BTL_POKEPARAM poke;
			public byte wazaIndex;
			public byte volume;
			
			public Description()
			{
				poke = null;
				wazaIndex = 0;
				volume = 0;
			}
		}

		public class Result
		{
			public bool isDecrement;
			
			public Result()
			{
				isDecrement = false;
			}
		}
	}
}