namespace Dpr.Battle.Logic
{
	public sealed class Section_FieldEffect_End : Section
	{
		public Section_FieldEffect_End(in CommonParam commonParam) : base(commonParam) { }

        // TODO
        public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private bool remove(EffectType effect, BTL_POKEPARAM pDependPoke) { return default; }
		
		// TODO
		private void putRemovedMessage(EffectType effect) { }
		
		// TODO
		private void checkItemReaction_All() { }
		
		// TODO
		private void getFrontPokeSetByAgilityOrder(PokeSet targets) { }
		
		// TODO
		private void checkItemReaction(BTL_POKEPARAM poke) { }
		
		// TODO
		private void resetGround() { }
		
		// TODO
		private void resetKagakuhenkaGas() { }

		public class Description
		{
			public EffectType effect;
			public BTL_POKEPARAM pDependPoke;
			
			public Description()
			{
				pDependPoke = null;
				effect = EffectType.EFF_NULL;
			}
		}

		public class Result
		{
			public bool isRemoved;
		}
	}
}