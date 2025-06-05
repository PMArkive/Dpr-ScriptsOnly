using Pml.WazaData;

namespace Dpr.Battle.Logic
{
	public sealed class Section_AddSickCheckFail : Section
	{
		public Section_AddSickCheckFail(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private AddSickFailCode checkFail(BTL_POKEPARAM attacker, BTL_POKEPARAM target, WazaSick sick, in BTL_SICKCONT sickCont, SickCause sickCause, SickOverWriteMode overWriteMode) { return default; }
		
		// TODO
		private AddSickFailCode checkFail_byOverwriteMode(BTL_POKEPARAM target, WazaSick sick, SickOverWriteMode overWriteMode) { return default; }
		
		// TODO
		private AddSickFailCode checkFail_byBasicRules(BTL_POKEPARAM target, WazaSick sick, in BTL_SICKCONT sickCont) { return default; }
		
		// TODO
		private bool isLoaclShineWeather(BTL_POKEPARAM poke) { return default; }
		
		// TODO
		private bool isFailMessageEnable(AddSickFailCode failCode, SickCause sickCause, bool isOtherEffectDisplayed) { return default; }
		
		// TODO
		private void putFailMessage(BTL_POKEPARAM target, AddSickFailCode failCode, WazaSick sick, SickCause sickCause) { }
		
		// TODO
		private void checkFail_Special(ref bool isFailed, ref bool canFailResultDisplay, BTL_POKEPARAM attacker, BTL_POKEPARAM target, WazaSick sick, SickCause sickCause) { }

		public class Description
		{
			public BTL_POKEPARAM attacker;
			public BTL_POKEPARAM target;
			public WazaSick sick;
			public BTL_SICKCONT sickCont;
			public SickCause sickCause;
			public uint wazaSerial;
			public SickOverWriteMode overWriteMode;
			public bool isFailResultDisplay_ByBasicRules;
			public bool isFailResultDisplay_BySpecialFactors;
			public bool isOtherEffectDisplayed;
			
			public Description()
			{
				attacker = null;
				target = null;
				sick = WazaSick.WAZASICK_NONE;
				sickCont = default;
				sickCause = SickCause.OTHER;
				wazaSerial = 0;
				overWriteMode = SickOverWriteMode.CANT;
				isFailResultDisplay_ByBasicRules = false;
				isFailResultDisplay_BySpecialFactors = false;
				isOtherEffectDisplayed = false;
			}
		}

		public class Result
		{
			public bool isFail;
		}
	}
}