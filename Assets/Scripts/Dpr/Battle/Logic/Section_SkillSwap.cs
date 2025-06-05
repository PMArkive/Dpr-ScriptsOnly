using Pml;

namespace Dpr.Battle.Logic
{
	public sealed class Section_SkillSwap : Section
	{
		public Section_SkillSwap(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description desc) { }
		
		// TODO
		private bool checkFail(BTL_POKEPARAM pAttacker, BTL_POKEPARAM pTarget, TokuseiChangeCause cause) { return default; }
		
		// TODO
		private void afterTokuseiChanged_Event(BTL_POKEPARAM poke) { }
		
		// TODO
		private void afterTokuseiChanged_Item(BTL_POKEPARAM poke, TokuseiNo prevTokusei, TokuseiNo nextTokusei) { }

		public class Description
		{
			public BTL_POKEPARAM attacker;
			public PokeSet targets;
			public bool needFailMessageDisplay = true;
			public TokuseiChangeCause cause;
		}

		public class Result { }
	}
}