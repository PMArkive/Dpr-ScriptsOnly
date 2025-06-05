using Pml;

namespace Dpr.Battle.Logic
{
	public sealed class Section_WazaExecEnd : Section
	{
		public Section_WazaExecEnd(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private void tameLockClear(BTL_POKEPARAM poke) { }
		
		// TODO
		private void freefallRelease(BTL_POKEPARAM poke) { }
		
		// TODO
		private void event_EndWazaSeq(ActionDesc actionDesc, BTL_POKEPARAM attacker, WazaNo waza, bool isWazaEffective) { }

		public class Description
		{
			public ActionDesc actionDesc;
			public BTL_POKEPARAM attacker;
			public WazaParam wazaParam;
			public bool isPPUsed;
			public bool isWazaEffective;
			public bool isWazaLocked;
			public bool isWazaHide;
			public WazaNo orgWaza;
			public BtlPokePos actTargetPos;
		}

		public class Result { }
	}
}