namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_SetWeight : Section
	{
		public Section_FromEvent_SetWeight(in CommonParam commonParam) : base(commonParam) { }

        // TODO
        public void Execute(Result result, in Description description) { }

		public class Description
		{
			public byte pokeID;
			public ushort weight;
			public StrParam successMessage = new StrParam();
			
			public Description()
			{
				pokeID = PokeID.INVALID;
				weight = 0;
			}
		}

		public class Result { }
	}
}