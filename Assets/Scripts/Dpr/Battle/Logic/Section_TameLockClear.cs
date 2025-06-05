using Pml.WazaData;

namespace Dpr.Battle.Logic
{
	public sealed class Section_TameLockClear : Section
	{
		public Section_TameLockClear(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private void clearTameLock(BTL_POKEPARAM poke) { }
		
		// TODO
		private void cureSick(BTL_POKEPARAM poke, WazaSick sick) { }
		
		// TODO
		private void clearHide(BTL_POKEPARAM poke) { }

		public class Description
		{
			public BTL_POKEPARAM poke;
			
			public Description()
			{
				poke = null;
			}
		}

		public class Result { }
	}
}