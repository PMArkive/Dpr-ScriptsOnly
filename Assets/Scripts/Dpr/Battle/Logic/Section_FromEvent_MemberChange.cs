namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_MemberChange : Section
	{
		public Section_FromEvent_MemberChange(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result result, in Description description) { }
		
		// TODO
		private bool canMemberChange(byte pokeID) { return default; }
		
		// TODO
		private bool memberOut(BTL_POKEPARAM outPoke, bool isInterruptDisable) { return default; }

		public class Description
		{
			public byte outPokeID;
			public bool isInterruptDisable;
			public bool isDisplayTokuseiWindow;
			public StrParam startMessage = new StrParam();
			public StrParam successMessage = new StrParam();
			
			public Description()
			{
				outPokeID = PokeID.INVALID;
				isInterruptDisable = false;
				isDisplayTokuseiWindow = false;
			}
		}

		public class Result
		{
			public bool isSucceeded;
		}
	}
}