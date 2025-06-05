namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_FriendshipEffect : Section
	{
		public Section_FromEvent_FriendshipEffect(in CommonParam commonParam) : base(commonParam) { }

        // TODO
        public void Execute(Result result, in Description description) { }

		public class Description
		{
			public byte pokeID;
			public FriendshipEffect effectType;
			public StrParam message = new StrParam();
			
			public Description()
			{
				pokeID = PokeID.INVALID;
				effectType = FriendshipEffect.FREFF_HEART;
			}
		}

		public class Result { }
	}
}