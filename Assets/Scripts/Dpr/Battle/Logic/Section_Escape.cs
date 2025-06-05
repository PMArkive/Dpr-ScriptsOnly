namespace Dpr.Battle.Logic
{
	public sealed class Section_Escape : Section
	{
		public Section_Escape(in CommonParam commonParam) : base(commonParam) { }

        // TODO
        public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private bool escape(BTL_POKEPARAM poke) { return default; }
		
		// TODO
		private void onEscapeFailed(BTL_POKEPARAM poke) { }

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
			public bool isSucceeded;
		}
	}
}