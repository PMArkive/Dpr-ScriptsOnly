using Pml.WazaData;

namespace Dpr.Battle.Logic
{
	public sealed class Section_AddSick_Core : Section
	{
		public Section_AddSick_Core(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private void putEffect(BTL_POKEPARAM target, WazaSick sick) { }
		
		// TODO
		private void putMessage(BTL_POKEPARAM target, WazaSick sick, in BTL_SICKCONT sickCont, bool isDefaultMessageDisplay, StrParam specialMessage) { }
		
		// TODO
		private void makeDefaultMessage(StrParam str, BTL_POKEPARAM target, WazaSick sick, in BTL_SICKCONT sickCont) { }
		
		// TODO
		private int getDefaultSickStrID(WazaSick sick, in BTL_SICKCONT sickCont) { return default; }
		
		// TODO
		private void changeSheimiForm(WazaSick sick, BTL_POKEPARAM target) { }
		
		// TODO
		private void sickFixedEvent(BTL_POKEPARAM attacker, BTL_POKEPARAM target, WazaSick sick, in BTL_SICKCONT sickCont) { }
		
		// TODO
		private void onIekiFixed(BTL_POKEPARAM target) { }
		
		// TODO
		private void checkItemReaction(BTL_POKEPARAM target) { }

		public class Description
		{
			public BTL_POKEPARAM attacker;
			public BTL_POKEPARAM target;
			public WazaSick sick;
			public BTL_SICKCONT sickCont;
			public bool isEffectDisplay;
			public bool isDefaultMessageDisplay;
			public StrParam specialMessage;
			public bool isItemReactionDisable;
			
			public Description()
			{
				attacker = null;
				target = null;
				specialMessage = null;
				sick = WazaSick.WAZASICK_NONE;
				sickCont = default;
				isEffectDisplay = true;
				isDefaultMessageDisplay = false;
				isItemReactionDisable = false;
			}
		}

		public class Result { }
	}
}