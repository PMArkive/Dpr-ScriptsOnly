namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_QuitBattle : Section
	{
		public Section_FromEvent_QuitBattle(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result result, in Description description) { }
		
		// TODO
		private bool escape(BTL_POKEPARAM poke, bool isForceSuccess) { return default; }

		public class Description
		{
			public byte userPokeID;
			public bool isForceSuccess;
			public bool isDisplayTokuseiWindow;
			
			public Description()
			{
				userPokeID = PokeID.INVALID;
				isForceSuccess = false;
				isDisplayTokuseiWindow = false;
			}
		}

		public class Result
		{
			public bool isSucceeded;
		}
	}
}