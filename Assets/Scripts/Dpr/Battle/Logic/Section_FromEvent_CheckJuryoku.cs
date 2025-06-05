using Pml.WazaData;

namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_CheckJuryoku : Section
	{
		public Section_FromEvent_CheckJuryoku(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result result, in Description description) { }
		
		// TODO
		private void getAllFrontPokeID(byte[] pokeIDArray, out uint pokeCount, byte basePokeID)
		{
			pokeCount = default;
		}
		
		// TODO
		private void cancelSoraWoTobu(BTL_POKEPARAM poke) { }
		
		// TODO
		private void freefallRelease(BTL_POKEPARAM poke) { }
		
		// TODO
		private void cureSick(BTL_POKEPARAM poke, WazaSick sick) { }

		public class Description
		{
			public byte userPokeID;
			
			public Description()
			{
				userPokeID = PokeID.INVALID;
			}
		}

		public class Result { }
	}
}