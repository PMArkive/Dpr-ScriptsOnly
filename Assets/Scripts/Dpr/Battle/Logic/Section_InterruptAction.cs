namespace Dpr.Battle.Logic
{
	public sealed class Section_InterruptAction : Section
	{
		public Section_InterruptAction(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result result, in Description description) { }
		
		// TODO
		private PokeAction getInterruptPokeAction(byte interruptPokeID) { return default; }
		
		// TODO
		private void processAction(PokeAction pokeAction) { }

		public class Description
		{
			public byte interruptPokeID;
			public byte targetPokeID;
			
			public Description()
			{
				interruptPokeID = PokeID.INVALID;
				targetPokeID = PokeID.INVALID;
            }
		}

		public class Result
		{
			public bool isInterrupted;
		}
	}
}