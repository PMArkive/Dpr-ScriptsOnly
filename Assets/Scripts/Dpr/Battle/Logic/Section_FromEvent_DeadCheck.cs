namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_DeadCheck : Section
	{
		public Section_FromEvent_DeadCheck(in CommonParam commonParam) : base(commonParam) { }

        // TODO
        public void Execute(Result result, in Description description) { }
		
		// TODO
		private void checkPokeDead(BTL_POKEPARAM poke) { }

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
			public bool isChecked;
		}
	}
}