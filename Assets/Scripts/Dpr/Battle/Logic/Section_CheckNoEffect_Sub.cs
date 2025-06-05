namespace Dpr.Battle.Logic
{
	public sealed class Section_CheckNoEffect_Sub : Section
	{
		public Section_CheckNoEffect_Sub(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private bool checkNoEffect(WazaParam wazaParam, BTL_POKEPARAM attacker, BTL_POKEPARAM target, DmgAffRec affinityRecorder, EventID eventID, bool fEnableMessage) { return default; }

		public class Description
		{
			public WazaParam wazaParam;
			public BTL_POKEPARAM attacker;
			public PokeSet targets;
			public DmgAffRec affinityRecorder;
			public EventID eventID;
			public bool isMustHitEnable;
			
			public Description()
			{
				wazaParam = null;
				attacker = null;
				targets = null;
				affinityRecorder = null;
				eventID = EventID.INVALID;
				isMustHitEnable = false;
			}
		}

		public class Result { }
	}
}