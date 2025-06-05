using Pml;

namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_SetItem : Section
	{
		// TODO
		public Section_FromEvent_SetItem(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result result, in Description description) { }
		
		// TODO
		private void changeItem(BTL_POKEPARAM poke, ushort nextItemID, bool isConsume) { }
		
		// TODO
		private void checkItemReaction(BTL_POKEPARAM poke) { }

		public class Description
		{
			public byte userPokeID;
			public byte targetPokeID;
			public ushort itemID;
			public bool isClearConsume;
			public bool isClearConsumeOtherPoke;
			public byte clearConsumePokeID;
			public bool isCallConsumedEvent;
			public bool isDisplayTokuseiWindow;
			public bool isConsumeItem;
			public StrParam successMessage = new StrParam();
			
			public Description()
			{
				userPokeID = PokeID.INVALID;
				targetPokeID = PokeID.INVALID;
				itemID = (ushort)ItemNo.DUMMY_DATA;
				isClearConsume = false;
				isClearConsumeOtherPoke = false;
				clearConsumePokeID = PokeID.INVALID;
				isCallConsumedEvent = false;
				isDisplayTokuseiWindow = false;
				isConsumeItem = false;
			}
		}

		public class Result
		{
			public bool isSucceeded;
		}
	}
}