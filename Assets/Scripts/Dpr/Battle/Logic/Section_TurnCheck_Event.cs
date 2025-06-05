namespace Dpr.Battle.Logic
{
	public sealed class Section_TurnCheck_Event : Section
	{
		public Section_TurnCheck_Event(in CommonParam commonParam) : base(commonParam) { }

        // TODO
        public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private void storeFrontPokeByAgilityOrder(PokeSet pokeSet) { }
		
		// TODO
		private void checkPokeDead(BTL_POKEPARAM poke) { }
		
		// TODO
		private bool checkExpGet() { return default; }

		public class Description
		{
			public EventID eventID;
			
			public Description()
			{
				eventID = EventID.INVALID;
			}
		}

		public class Result
		{
			public bool isExpGet;
		}
	}
}