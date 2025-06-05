using Pml;

namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_Hensin : Section
	{
		public Section_FromEvent_Hensin(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result result, in Description description) { }
		
		// TODO
		private void afterTokuseiChanged_Event(BTL_POKEPARAM poke) { }
		
		// TODO
		private void afterTokuseiChanged_Item(BTL_POKEPARAM poke, TokuseiNo prevTokusei, TokuseiNo nextTokusei) { }

		public class Description
		{
			public byte userPokeID;
			public byte targetPokeID;
			public bool isDisplayTokuseiWindow;
			public StrParam successMessage = new StrParam();
			
			public Description()
			{
				userPokeID = PokeID.INVALID;
				targetPokeID = PokeID.INVALID;
				isDisplayTokuseiWindow = false;
			}
		}

		public class Result
		{
			public bool isSucceeded;
		}
	}
}