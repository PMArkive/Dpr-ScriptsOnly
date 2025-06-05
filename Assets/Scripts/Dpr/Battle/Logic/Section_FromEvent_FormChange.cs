namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_FormChange : Section
	{
		public Section_FromEvent_FormChange(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result result, in Description description) { }
		
		// TODO
		private void formChange(in Description description) { }

		public class Description
		{
			public byte pokeID;
			public byte formNo;
			public bool isDontResetFormByOut;
			public bool isEnableInCaseOfDead;
			public bool isDisplayTokuseiWindow;
			public bool isDisplayChangeEffect;
			public StrParam successMessage = new StrParam();
			
			public Description()
			{
				pokeID = PokeID.INVALID;
				formNo = 0;
				isDontResetFormByOut = false;
				isEnableInCaseOfDead = false;
				isDisplayTokuseiWindow = false;
				isDisplayChangeEffect = true;
			}
		}

		public class Result
		{
			public bool isChanged;
		}
	}
}