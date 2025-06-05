namespace Dpr.Battle.Logic
{
	public sealed class Section_ProcessAction : Section
	{
		public Section_ProcessAction(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private void processActionCore(PokeAction pokeAction) { }
		
		// TODO
		private bool checkExpGet() { return default; }
		
		// TODO
		private void raidboss_updateGwazaUseSchedule(PokeAction pokeAction) { }
		
		// TODO
		private void raidboss_angry() { }
		
		// TODO
		private bool raidboss_checkAngryWazaEnable(PokeAction pokeAction) { return default; }
		
		// TODO
		private void raidboss_addAngryWazaAction() { }

		public class Description
		{
			public PokeAction pokeAction;
			
			public Description()
			{
				pokeAction = null;
			}
		}

		public class Result { }
	}
}