namespace Dpr.Battle.Logic
{
	public sealed class Section_CheckNoEffect_TypeAffinity : Section
	{
		public Section_CheckNoEffect_TypeAffinity(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private void putNoEffectMessage(BTL_POKEPARAM target, in DmgAffRec affinityRecorder) { }
		
		// TODO
		private void putNoEffectMessageByFlying(BTL_POKEPARAM defender) { }
		
		// TODO
		private void incNoEffectCount(BTL_POKEPARAM attacker, BTL_POKEPARAM target) { }
		
		// TODO
		private void checkBattleTalk(byte pokeID) { }

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