using Pml;

namespace Dpr.Battle.Logic
{
	public sealed class Section_WazaExec_CheckFail_1st : Section
	{
		public Section_WazaExec_CheckFail_1st(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private WazaFailCause checkFail(BTL_POKEPARAM attacker, WazaParam wazaParam, bool isWazaLock, ActionDesc actionDesc) { return default; }
		
		// TODO
		private void cureNemuriCheck(BTL_POKEPARAM attacker) { }
		
		// TODO
		private bool cureKooriCheck(BTL_POKEPARAM attacker, WazaNo waza) { return default; }
		
		// TODO
		private bool isWazaFailByKodawariLock(BTL_POKEPARAM attacker, WazaNo waza) { return default; }
		
		// TODO
		private SabotageType checkSabotageType(BTL_POKEPARAM poke) { return default; }
		
		// TODO
		private bool isSabotageEnable(BTL_POKEPARAM poke) { return default; }
		
		// TODO
		private SabotageType checkSabotageType_ByLevel(BTL_POKEPARAM poke) { return default; }
		
		// TODO
		private bool konranCheck(BTL_POKEPARAM attacker, SabotageType sabotageType) { return default; }
		
		// TODO
		private void cureSick_KONRAN(BTL_POKEPARAM poke) { }
		
		// TODO
		private void cureSick_NEMURI(BTL_POKEPARAM poke) { }
		
		// TODO
		private void cureSick_KOORI(BTL_POKEPARAM poke) { }
		
		// TODO
		private void cureSick_KOORI_ByWaza(BTL_POKEPARAM poke, WazaNo wazano) { }
		
		// TODO
		private bool meromeroCheck(BTL_POKEPARAM attacker) { return default; }
		
		// TODO
		private void wazaExecFailed(BTL_POKEPARAM attacker, WazaParam wazaParam, WazaFailCause failCause) { }
		
		// TODO
		private void wazaExecSucceeded(BTL_POKEPARAM attacker, WazaParam wazaParam) { }

		public class Description
		{
			public BTL_POKEPARAM attacker;
			public WazaParam wazaParam;
			public bool isWazaLock;
			public ActionDesc actionDesc;
			
			public Description()
			{
				attacker = null;
				wazaParam = null;
				actionDesc = null;
				isWazaLock = false;
			}
		}

		public class Result
		{
			public bool isFailed;
		}
	}
}