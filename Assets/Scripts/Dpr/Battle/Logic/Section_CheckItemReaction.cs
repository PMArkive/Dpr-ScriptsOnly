namespace Dpr.Battle.Logic
{
	public sealed class Section_CheckItemReaction : Section
	{
		public Section_CheckItemReaction(in CommonParam commonParam) : base(commonParam) { }

        // TODO
        public void Execute(Result pResult, in Description desc) { }

		public class Description
		{
			public byte pokeID = PokeID.INVALID;
			public byte reactionType;
		}

		public class Result { }
	}
}