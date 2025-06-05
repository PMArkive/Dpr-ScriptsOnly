namespace Dpr.Battle.Logic
{
	public sealed class Section_TurnCheck : Section
	{
		public Section_TurnCheck(in CommonParam commonParam) : base(commonParam) { }

        // TODO
        public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private TurnCheckResult turnCheck() { return default; }
		
		// TODO
		private void storeFrontPokeByAgilityOrder(PokeSet pPokeSet) { }
		
		// TODO
		private bool turnCheck_Weather() { return default; }
		
		// TODO
		private void turnCheck_FriendshipCure() { }
		
		// TODO
		private bool turnCheck_Event(EventID eventID) { return default; }
		
		// TODO
		private bool turnCheck_Sick() { return default; }
		
		// TODO
		private void turnCheck_SideEffect() { }
		
		// TODO
		private void turnCheck_Field() { }

		public class Description { }

		public class Result { }

		private enum TurnCheckResult : int
		{
			DONE = 0,
			LEVELUP = 1,
			POKECHANGE = 2,
			QUIT = 3,
		}

		private enum SeqturnCheck : int
		{
			SEQ_START = 0,
			SEQ_WEATHER = 1,
			SEQ_WEATHER_TERMINATE = 2,
			SEQ_WEATHER_POKECHANGE = 3,
			SEQ_KAWAIGARI_EFFECT = 4,
			SEQ_EVENT_BEGIN = 5,
			SEQ_EVENT_BEGIN_TERMINATE = 6,
			SEQ_EVENT_BEGIN_POKECHANGE = 7,
			SEQ_SICK = 8,
			SEQ_SICK_TERMINATE = 9,
			SEQ_SICK_POKECHANGE = 10,
			SEQ_SIDE = 11,
			SEQ_FIELD = 12,
			SEQ_EVENT_END = 13,
			SEQ_EVENT_END_TERMINATE = 14,
			SEQ_EVENT_END_POKECHANGE = 15,
			SEQ_EVENT_DONE = 16,
			SEQ_END = 17,
		}
	}
}