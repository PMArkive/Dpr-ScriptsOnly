namespace Dpr.Battle.Logic
{
	public sealed class Section_WazaExec_CheckFail_2nd : Section
	{
		public Section_WazaExec_CheckFail_2nd(in CommonParam commonParam) : base(commonParam) { }

        // TODO
        public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private WazaFailCause checkWazaFail(BTL_POKEPARAM attacker, WazaParam wazaParam, PokeSet targets) { return default; }
		
		// TODO
		private void wazaExecFailed(BTL_POKEPARAM attacker, WazaParam wazaParam, WazaFailCause failCause) { }

		public class Description
		{
			public BTL_POKEPARAM attacker;
			public WazaParam wazaParam;
			public PokeSet targets;
		}

		public class Result
		{
			public bool isFailed;
		}
	}
}