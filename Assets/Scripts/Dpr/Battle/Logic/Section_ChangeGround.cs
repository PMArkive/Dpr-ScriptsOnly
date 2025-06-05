namespace Dpr.Battle.Logic
{
	public sealed class Section_ChangeGround : Section
	{
		public Section_ChangeGround(in CommonParam commonParam) : base(commonParam) { }

        // TODO
        public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private bool needEffect(ChangeGroundCause cause) { return default; }

		public class Description
		{
			public byte pokeID;
			public BtlGround ground;
			public BTL_SICKCONT contParam;
			public ChangeGroundCause cause;
			
			public Description()
			{
				pokeID = PokeID.INVALID;
				ground = BtlGround.BTL_GROUND_NONE;
				contParam = default;
				cause = ChangeGroundCause.OTHERS;
			}
		}

		public class Result
		{
			public bool isChanged;
		}
	}
}