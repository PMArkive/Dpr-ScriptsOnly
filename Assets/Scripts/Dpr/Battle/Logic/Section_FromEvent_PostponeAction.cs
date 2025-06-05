namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_PostponeAction : Section
	{
		public Section_FromEvent_PostponeAction(in CommonParam commonParam) : base(commonParam) { }

        // TODO
        public void Execute(Result result, in Description description) { }

		public class Description
		{
			public byte pokeID;
			public StrParam successMessage = new StrParam();
			
			public Description()
			{
				pokeID = PokeID.INVALID;
			}
		}

		public class Result
		{
			public bool isSucceeded;
		}
	}
}