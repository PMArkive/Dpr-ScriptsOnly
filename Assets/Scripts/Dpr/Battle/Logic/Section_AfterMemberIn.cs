namespace Dpr.Battle.Logic
{
	public sealed class Section_AfterMemberIn : Section
	{
		public Section_AfterMemberIn(in CommonParam commonParam) : base(commonParam) { }

        // TODO
        public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private void getTargets(PokeSet pokeSet, PokeIDRegister targetPokemons) { }
		
		// TODO
		private void sortByAgility(PokeSet pokeSet) { }
		
		// TODO
		private void event_DefaultPowerUp(PokeSet targets) { }
		
		// TODO
		private void event_BattonTouch(PokeSet targets) { }
		
		// TODO
		private void event_MemberIn(PokeSet targets) { }

		public class Description
		{
			public PokeIDRegister targets;

			public Description()
			{
				targets = null;
			}
		}

		public class Result { }
	}
}