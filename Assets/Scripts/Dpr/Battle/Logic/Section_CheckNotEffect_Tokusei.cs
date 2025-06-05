namespace Dpr.Battle.Logic
{
	public sealed class Section_CheckNotEffect_Tokusei : Section
	{
		public Section_CheckNotEffect_Tokusei(in CommonParam commonParam) : base(commonParam) { }

        // TODO
        public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private void checkNoEffect_Tokusei(BTL_POKEPARAM attacker, WazaParam wazaParam, DmgAffRec affinityRecorder, PokeSet targets) { }

		public class Description
		{
			public BTL_POKEPARAM attacker;
			public WazaParam wazaParam;
			public DmgAffRec affinityRecorder;
			public PokeSet targets;
			public ActionRecorder actionRecorder;
			
			public Description()
			{
				attacker = null;
				wazaParam = null;
				affinityRecorder = null;
				targets = null;
				actionRecorder = null;
			}
		}

		public class Result { }
	}
}