namespace Dpr.Battle.Logic
{
	public sealed class Section_StoreActions : Section
	{
		public Section_StoreActions(in CommonParam commonParam) : base(commonParam) { }

        // TODO
        public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private void createPokeAction_FromClientInstruction(PokeActionContainer pokeActionContainer, SVCL_ACTION clientInstructions) { }
		
		// TODO
		private void createPokeAction_FromClientInstruction(PokeActionContainer actionContainer, SVCL_ACTION instructions, byte clientID) { }
		
		// TODO
		private bool setupPokeAction_FromClientInstruction(PokeAction pokeAction, in BTL_ACTION_PARAM clientInstruction, byte clientID) { return default; }
		
		// TODO
		private BTL_POKEPARAM getActionPoke(in BTL_ACTION_PARAM clientInstruction, byte clientID) { return default; }
		
		// TODO
		private void createPokeAction_G(PokeActionContainer pPokeActionContainer) { }
		
		// TODO
		private void setupPokeAction_G(PokeAction gAction, in PokeAction fightAction) { }

		public class Description
		{
			public PokeActionContainer pokeActionContainer;
			public SVCL_ACTION clientInstructions;
			
			public Description()
			{
				pokeActionContainer = null;
				clientInstructions = null;
			}
		}

		public class Result { }
	}
}