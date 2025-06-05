using Pml;

namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_InterruptAction : Section
	{
		public Section_FromEvent_InterruptAction(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result result, in Description description) { }

		public class Description
		{
			public byte pokeID;
			public WazaNo wazano;
			public StrParam successMessage = new StrParam();
			
			public Description()
			{
				pokeID = PokeID.INVALID;
				wazano = WazaNo.NULL;
			}
		}

		public class Result
		{
			public bool isSucceeded;
		}
	}
}