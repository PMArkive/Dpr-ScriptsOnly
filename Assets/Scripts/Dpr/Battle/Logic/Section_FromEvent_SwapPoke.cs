namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_SwapPoke : Section
	{
		public Section_FromEvent_SwapPoke(in CommonParam commonParam) : base(commonParam) { }

        // TODO
        public void Execute(Result result, in Description description) { }
		
		// TODO
		private void afterMoveEvent(BTL_POKEPARAM poke) { }

		public class Description
		{
			public byte pokeID1;
			public byte pokeID2;
			public StrParam successMessage = new StrParam();
			
			public Description()
			{
				pokeID1 = PokeID.INVALID;
				pokeID2 = PokeID.INVALID;
			}
		}

		public class Result
		{
			public bool isSwapped;
		}
	}
}