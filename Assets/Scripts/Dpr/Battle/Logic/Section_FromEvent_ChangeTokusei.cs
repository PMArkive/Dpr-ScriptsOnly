using Pml;

namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_ChangeTokusei : Section
	{
		public Section_FromEvent_ChangeTokusei(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result result, in Description description) { }
		
		// TODO
		private void afterTokuseiChanged_Item(BTL_POKEPARAM poke, TokuseiNo prevTokusei, TokuseiNo nextTokusei) { }

		public class Description
		{
			public byte userPokeID;
			public byte targetPokeID;
			public TokuseiNo tokuseiID;
			public TokuseiChangeCause cause;
			public bool isEffectiveToSameTokusei;
			public bool isSkipMemberInEvent;
			public bool isDisplayTokuseiWindow;
			public StrParam successMessage = new StrParam();
			
			public Description()
			{
				userPokeID = PokeID.INVALID;
				targetPokeID = PokeID.INVALID;
				tokuseiID = TokuseiNo.NULL;
				cause = TokuseiChangeCause.TOKUSEI_CHANGE_CAUSE_OTHER;
				isEffectiveToSameTokusei = false;
				isSkipMemberInEvent = false;
				isDisplayTokuseiWindow = false;
			}
		}

		public class Result
		{
			public bool isChanged;
		}
	}
}