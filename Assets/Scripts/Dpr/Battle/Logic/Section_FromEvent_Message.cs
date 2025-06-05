namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_Message : Section
	{
		public Section_FromEvent_Message(in CommonParam commonParam) : base(commonParam) { }

        // TODO
        public void Execute(Result result, in Description description) { }

		public class Description
		{
			public byte pokeID;
			public bool isDisplayTokuseiWindow;
			public StrParam message = new StrParam();
			
			public Description()
			{
				pokeID = PokeID.INVALID;
				isDisplayTokuseiWindow = false;
			}
		}

		public class Result { }
	}
}