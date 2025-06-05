namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_BattonTouch : Section
	{
		public Section_FromEvent_BattonTouch(in CommonParam commonParam) : base(commonParam) { }

        // TODO
        public void Execute(Result result, in Description description) { }

		public class Description
		{
			public byte userPokeID;
			public byte targetPokeID;
			
			public Description()
			{
                userPokeID = PokeID.INVALID;
				targetPokeID = PokeID.INVALID;
			}
		}

		public class Result { }
	}
}