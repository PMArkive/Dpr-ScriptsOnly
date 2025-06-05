using Pml.WazaData;

namespace Dpr.Battle.Logic
{
	public sealed class Section_WazaSick : Section
	{
		public Section_WazaSick(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private bool addSickCheckFail(BTL_POKEPARAM attacker, BTL_POKEPARAM target, WazaSick sick, BTL_SICKCONTOBJ sickCont, SickCause cause, uint actionSerialNo, bool isFailResultDisplay_ByBasicRules, bool isFailResultDisplay_BySpecialFactors, bool isOtherEffectDisplayed) { return default; }
		
		// TODO
		private void addSick(BTL_POKEPARAM attacker, BTL_POKEPARAM target, WazaSick sick, BTL_SICKCONTOBJ sickCont, StrParam specialMessage) { }

		public class Description
		{
			public BTL_POKEPARAM attacker;
			public BTL_POKEPARAM target;
			public WazaSick sick;
			public BTL_SICKCONT sickCont;
			public SickCause cause;
			public uint actionSerialNo;
			public bool isFailResultDisplay_ByBasicRules;
			public bool isFailResultDisplay_BySpecialFactors;
			public bool isOtherEffectDisplayed;
			
			public Description()
			{
				attacker = null;
				target = null;
				sick = WazaSick.WAZASICK_NONE;
				sickCont = default;
				cause = SickCause.OTHER;
				actionSerialNo = 0;
				isFailResultDisplay_ByBasicRules = false;
				isFailResultDisplay_BySpecialFactors = false;
				isOtherEffectDisplayed = false;
			}
		}

		public class Result
		{
			public bool isSuccess;
		}
	}
}