namespace Dpr.Battle.Logic
{
	public sealed class Section_ProcessInterruptPokeChangeAction : Section
	{
		public Section_ProcessInterruptPokeChangeAction(in CommonParam commonParam) : base(commonParam) { }

        // TODO
        public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private void processAction_OnlyPokeChange(PokeIDRegister inPokeIDRegister, PokeActionContainer pokeActionContainer) { }
		
		// TODO
		private byte section_MemberChange(byte clientID, byte outPosIndex, byte inPokeIndex) { return default; }
		
		// TODO
		private void afterMemberIn(PokeIDRegister targets) { }
		
		// TODO
		private bool checkExpGet() { return default; }

		public class Description
		{
			public PokeActionContainer pokeActionContainer;
			
			public Description()
			{
				pokeActionContainer = null;
			}
		}

		public class Result { }
	}
}