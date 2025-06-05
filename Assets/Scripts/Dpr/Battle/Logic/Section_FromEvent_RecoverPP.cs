namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_RecoverPP : Section
	{
		public Section_FromEvent_RecoverPP(in CommonParam commonParam) : base(commonParam) { }

        // TODO
        public void Execute(Result result, in Description description) { }

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