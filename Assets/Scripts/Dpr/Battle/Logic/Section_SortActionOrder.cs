namespace Dpr.Battle.Logic
{
	public sealed class Section_SortActionOrder : Section
	{
		public Section_SortActionOrder(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private void setPriority(PokeActionContainer actionContainer) { }
		
		// TODO
		private uint calcActionPriority(PokeAction pokeAction) { return default; }
		
		// TODO
		private BtlSpecialPri getSpActPriority(PokeAction pokeAction) { return default; }
		
		// TODO
		private void sort(PokeActionContainer actionContainer) { }

		public class Description
		{
			public PokeActionContainer actionContainer;
			
			public Description()
			{
				actionContainer = null;
			}
		}

		public class Result { }
	}
}