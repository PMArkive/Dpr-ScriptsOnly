namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_DecrementPP : Section
	{
		public Section_FromEvent_DecrementPP(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result result, in Description description) { }
		
		// TODO
		private bool decrementPP(BTL_POKEPARAM poke, byte wazaIndex, byte volume) { return default; }
		
		// TODO
		private void useItem(BTL_POKEPARAM poke) { }

		public class Description
		{
			public byte pokeID;
			public byte wazaIdx;
			public byte volume;
			public bool isSurfacePP;
			public bool isDeadPokeEnable;
			public StrParam successMessage = new StrParam();
			
			public Description()
			{
				pokeID = PokeID.INVALID;
				wazaIdx = 0;
				volume = 0;
				isSurfacePP = false;
				isDeadPokeEnable = false;
			}
		}

		public class Result
		{
			public bool isSuccessed;
		}
	}
}