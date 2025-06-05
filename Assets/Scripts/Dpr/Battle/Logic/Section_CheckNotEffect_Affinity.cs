namespace Dpr.Battle.Logic
{
	public sealed class Section_CheckNotEffect_Affinity : Section
	{
		public Section_CheckNotEffect_Affinity(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private void checkNoEffect_Lv1(BTL_POKEPARAM attacker, WazaParam wazaParam, DmgAffRec affinityRecorder, PokeSet targets) { }
		
		// TODO
		private void checkNoEffect_Lv2(BTL_POKEPARAM attacker, WazaParam wazaParam, DmgAffRec affinityRecorder, PokeSet targets) { }
		
		// TODO
		private void checkNoEffect_Type(BTL_POKEPARAM attacker, WazaParam wazaParam, PokeSet targets) { }
		
		// TODO
		private bool isNoEffectByType(BTL_POKEPARAM attacker, BTL_POKEPARAM target, WazaParam wazaParam) { return default; }

		public class Description
		{
			public BTL_POKEPARAM attacker;
			public WazaParam wazaParam;
			public DmgAffRec affinityRecorder;
			public PokeSet targets;
			
			public Description()
			{
				attacker = null;
				wazaParam = null;
				affinityRecorder = null;
				targets = null;
			}
		}

		public class Result { }
	}
}