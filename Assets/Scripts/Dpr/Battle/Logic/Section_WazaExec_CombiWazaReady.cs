using Pml;

namespace Dpr.Battle.Logic
{
	public sealed class Section_WazaExec_CombiWazaReady : Section
	{
		private const uint MAX_COMBI_POKE_NUM = 4;

		private static readonly WazaNo[] COMBI_WAZA_TABLE = new WazaNo[]
		{
            WazaNo.HONOONOTIKAI, WazaNo.MIZUNOTIKAI, WazaNo.KUSANOTIKAI,
        };
		
		public Section_WazaExec_CombiWazaReady(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private bool isCombiWaza(WazaNo waza) { return default; }
		
		// TODO
		private void getCombiPossibleActions(PokeAction[] ppActionBuffer, ref uint pActionNum, byte attackerID, WazaNo waza, BtlPokePos targetPos) { }
		
		// TODO
		private PokeAction getCombiPartnerAction(PokeAction[] pActions, uint actionNum) { return default; }

		public class Description
		{
			public BTL_POKEPARAM attacker;
			public WazaNo waza;
			public BtlPokePos targetPos;
		}

		public class Result
		{
			public bool isReadied;
		}
	}
}