namespace Dpr.Battle.Logic
{
	public sealed class Section_AfterTokuseiChanged_Event : Section
	{
		public Section_AfterTokuseiChanged_Event(in CommonParam commonParam) : base(commonParam) { }

        // TODO
        public void Execute(Result pResult, in Description desc) { }

		public class Description
		{
			public BTL_POKEPARAM poke;
		}

		public class Result { }
	}
}