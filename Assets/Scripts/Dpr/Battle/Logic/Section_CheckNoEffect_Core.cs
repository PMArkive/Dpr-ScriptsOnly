namespace Dpr.Battle.Logic
{
	public sealed class Section_CheckNoEffect_Core : Section
	{
		public Section_CheckNoEffect_Core(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private void displayMessage(byte pokeID, bool isTokuseiWindowDisplay, in StrParam strParam) { }

		public class Description
		{
			public WazaParam wazaParam;
			public BTL_POKEPARAM attacker;
			public BTL_POKEPARAM target;
			public DmgAffRec affinityRecorder;
			public EventID eventID;
			public bool fEnableMessage;
			
			public Description()
			{
				wazaParam = null;
				attacker = null;
				target = null;
				affinityRecorder = null;
				eventID = EventID.INVALID;
				fEnableMessage = true;
			}
		}

		public class Result
		{
			public bool isNoEffect;
		}
	}
}