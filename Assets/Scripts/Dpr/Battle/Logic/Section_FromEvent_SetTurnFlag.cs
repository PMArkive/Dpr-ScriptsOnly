namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_SetTurnFlag : Section
	{
		public Section_FromEvent_SetTurnFlag(in CommonParam commonParam) : base(commonParam) { }

        // TODO
        public void Execute(Result result, in Description description) { }

		public class Description
		{
			public byte pokeID;
			public BTL_POKEPARAM.TurnFlag flag;
			
			public Description()
			{
				pokeID = PokeID.INVALID;
				flag = BTL_POKEPARAM.TurnFlag.TURNFLG_MAX;
			}
		}

		public class Result
		{
			public bool isSuccessed;
		}
	}
}