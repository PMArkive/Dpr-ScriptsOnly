namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_Shrink : Section
	{
		public Section_FromEvent_Shrink(in CommonParam commonParam) : base(commonParam) { }

        // TODO
        public void Execute(Result result, in Description description) { }
		
		// TODO
		private bool shrink(byte pokeID, byte percentage) { return default; }

		public class Description
		{
			public byte pokeID;
			public byte percentage;
			
			public Description()
			{
				pokeID = PokeID.INVALID;
				percentage = 0;
			}
		}

		public class Result
		{
			public bool isSucceeded;
		}
	}
}