using Pml.WazaData;

namespace Dpr.Battle.Logic
{
	public sealed class Section_FreeFall_Release : Section
	{
		public Section_FreeFall_Release(in CommonParam commonParam) : base(commonParam) { }

        // TODO
        public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private BTL_POKEPARAM getCapturedPoke(BTL_POKEPARAM attacker) { return default; }
		
		// TODO
		private void freeFallEnd_Captured(BTL_POKEPARAM capturedPoke, bool canAppear) { }
		
		// TODO
		private void cureSick(BTL_POKEPARAM poke, WazaSick sick) { }
		
		// TODO
		private void freeFallEnd_Attacker(BTL_POKEPARAM attacker, bool canAppear) { }

		public class Description
		{
			public BTL_POKEPARAM attacker;
			public bool canAppearSelf;
			public bool canAppearTarget;
			
			public Description()
			{
				attacker = null;
				canAppearSelf = false;
				canAppearTarget = false;
			}
		}

		public class Result { }
	}
}