namespace Dpr.Battle.Logic
{
	public sealed class Section_RaidBoss_ExtraAction_Add : Section
	{
		public Section_RaidBoss_ExtraAction_Add(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private uint calcActionPriority(PokeAction pokeAction) { return default; }

		public class Description { }

		public class Result { }
	}
}