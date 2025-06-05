using Pml.WazaData;

namespace Dpr.Battle.Logic
{
	public sealed class Section_AddSick : Section
	{
		public Section_AddSick(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result result, in Description description) { }
		
		// TODO
		private bool checkFail(BTL_POKEPARAM attacker, BTL_POKEPARAM target, WazaSick sick, BTL_SICKCONT sickCont, SickCause sickCause, uint wazaSerial, SickOverWriteMode overWriteMode, bool isFailResultDisplay) { return default; }
		
		// TODO
		private void addSick(BTL_POKEPARAM attacker, BTL_POKEPARAM target, WazaSick sick, BTL_SICKCONT sickCont, bool isEffectDisplay, bool isDefaultMessageDisplay, in StrParam specialMessage, bool isItemReactionDisable) { }

		public class Description
		{
			public byte pokeID;
			public byte targetPokeID;
			public WazaSick sickID;
			public BTL_SICKCONT sickCont;
			public SickCause sickCause;
			public SickOverWriteMode overWriteMode;
			public bool isDisplayTokuseiWindow;
			public bool isFailResultDisplay;
			public bool isEffectDisplay;
			public bool isStandardMessageDisable;
			public bool isItemReactionDisable;
			public bool isEffectiveToDeadPoke;
			public StrParam specialMessage = new StrParam();
			
			public Description()
			{
				pokeID = PokeID.INVALID;
				targetPokeID = PokeID.INVALID;
				sickID = WazaSick.WAZASICK_NONE;
				sickCont = default;
				isEffectDisplay = true;
				isStandardMessageDisable = false;
				isItemReactionDisable = false;
				isEffectiveToDeadPoke = false;
			}
		}

		public class Result
		{
			public bool isSuccessed;
		}
	}
}