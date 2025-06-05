namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_SwapItem : Section
	{
		public Section_FromEvent_SwapItem(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result result, in Description description) { }
		
		// TODO
		private void changeItem(BTL_POKEPARAM poke, ushort nextItemID) { }
		
		// TODO
		private void checkItemReaction(BTL_POKEPARAM poke) { }
		
		// TODO
		private void incRecord_StealItemFromWildPoke(byte targetPokeID, ushort targetItem) { }

		public class Description
		{
			public byte userPokeID;
			public byte targetPokeID;
			public bool isIncRecordCount_StealItemFromWildPoke;
			public bool isDisplayTokuseiWindow;
			public StrParam successMessage1 = new StrParam();
			public StrParam successMessage2 = new StrParam();
			public StrParam successMessage3 = new StrParam();
			
			public Description()
			{
				userPokeID = PokeID.INVALID;
				targetPokeID = PokeID.INVALID;
				isIncRecordCount_StealItemFromWildPoke = false;
				isDisplayTokuseiWindow = false;
			}
		}

		public class Result
		{
			public bool isSucceeded;
		}
	}
}