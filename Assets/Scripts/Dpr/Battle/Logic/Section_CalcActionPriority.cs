namespace Dpr.Battle.Logic
{
	public sealed class Section_CalcActionPriority : Section
	{
		public Section_CalcActionPriority(in CommonParam commonParam) : base(commonParam) { }

        // TODO
        public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private OperationPriority calcOperationPriority(PokeAction pAction) { return default; }
		
		// TODO
		private ushort calcAgility(BTL_POKEPARAM poke) { return default; }
		
		// TODO
		private byte calcWazaPriority(in PokeAction pokeAction) { return default; }

		public class Description
		{
			public PokeAction pokeAction;
			public DominantPriority dominantPriority;
			public BtlSpecialPri specialPriority;
			
			public Description()
			{
				pokeAction = null;
				dominantPriority = DominantPriority.DEFAULT;
				specialPriority = BtlSpecialPri.BTL_SPPRI_DEFAULT;
			}
		}

		public class Result
		{
			public uint priority;
		}
	}
}