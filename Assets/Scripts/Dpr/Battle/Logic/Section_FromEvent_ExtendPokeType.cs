namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_ExtendPokeType : Section
	{
		public Section_FromEvent_ExtendPokeType(in CommonParam commonParam) : base(commonParam) { }

        // TODO
        public void Execute(Result result, in Description description) { }

		public class Description
		{
			public byte pokeID;
			public byte exType;
			public BTL_POKEPARAM.ExTypeCause exTypeCause;
			
			public Description()
			{
				pokeID = PokeID.INVALID;
				exType = 0;
				exTypeCause = BTL_POKEPARAM.ExTypeCause.EXTYPE_CAUSE_NONE;
			}
		}

		public class Result
		{
			public bool isSuccessed;
		}
	}
}