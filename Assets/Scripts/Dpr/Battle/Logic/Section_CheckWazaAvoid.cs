using Pml;

namespace Dpr.Battle.Logic
{
	public sealed class Section_CheckWazaAvoid : Section
	{
		public Section_CheckWazaAvoid(in CommonParam commonParam) : base(commonParam) { }

        // TODO
        public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private void checkHit(out bool pIsHit, out bool pIsFriendshipActive, BTL_POKEPARAM attacker, BTL_POKEPARAM target, WazaParam wazaParam)
		{
			pIsHit = default;
			pIsFriendshipActive = default;
		}
		
		// TODO
		private void putAvoidMessage(BTL_POKEPARAM avoidPoke, WazaNo waza, bool byFriendship) { }
		
		// TODO
		private void wazaAvoid(BTL_POKEPARAM attacker, bool fDelayAttack) { }

		public class Description
		{
			public BTL_POKEPARAM attacker;
			public WazaParam wazaParam;
			public PokeSet targets;
			public ActionRecorder actionRecorder;
			public bool isDelayAttack;
			
			public Description()
			{
				attacker = null;
				wazaParam = null;
				targets = null;
				actionRecorder = null;
				isDelayAttack = false;
			}
		}

		public class Result { }
	}
}