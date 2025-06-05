namespace Dpr.Battle.Logic
{
	public sealed class Section_AppearFreeFallTarget : Section
	{
		public Section_AppearFreeFallTarget(in CommonParam commonParam) : base(commonParam) { }

        // TODO
        public void Execute(Result pResult, in Description description) { }

		public class Description
		{
			public byte targetPokeID;
			
			public Description()
			{
				targetPokeID = PokeID.INVALID;
			}
		}

		public class Result { }
	}
}