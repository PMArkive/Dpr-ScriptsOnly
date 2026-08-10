using Pml;

namespace Dpr.Battle.Logic
{
	public sealed class Section_WazaExec_CheckFail_3rd : Section
	{
		public Section_WazaExec_CheckFail_3rd(in CommonParam commonParam) : base(commonParam) { }
		
		public void Execute(Result pResult, in Description description)
		{
            pResult.isFailed = false;

            if (description.wazaParam.wazaID == WazaNo.WARUAGAKI)
                return;

            var failCause = checkWazaFail(description.attacker, description.wazaParam, description.targets);

            if (failCause != WazaFailCause.NONE)
            {
                wazaExecFailed(description.attacker, description.wazaParam, failCause);
                pResult.isFailed = true;
            }
        }
		
		private WazaFailCause checkWazaFail(BTL_POKEPARAM attacker, WazaParam wazaParam, PokeSet targets)
		{
            return GetEventLauncher().Event_CheckWazaExecute(attacker, wazaParam.wazaID, EventID.WAZA_EXECUTE_CHECK_3RD, wazaParam, targets);
        }
		
		private void wazaExecFailed(BTL_POKEPARAM attacker, WazaParam wazaParam, WazaFailCause failCause)
		{
            var desc = new Section_WazaExec_Failed.Description()
            {
                pAttacker = attacker,
                waza = wazaParam.wazaID,
                failCause = failCause,
            };

            var result = new Section_WazaExec_Failed.Result();

            GetSectionContainer().GetSection_WazaExec_Failed().Execute(result, desc);
        }

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