namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_GetWeight : Section
	{
		public Section_FromEvent_GetWeight(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result result, in Description description) { }

		public class Description
		{
			public byte pokeID;
			
			public Description()
			{
				pokeID = PokeID.INVALID;
			}
		}

		public class Result
		{
			public uint weight;
		}
	}
}