namespace Dpr.Battle.Logic
{
	public sealed class Section_CheckNotEffect_Guard : Section
	{
		public Section_CheckNotEffect_Guard(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private void check_Field(BTL_POKEPARAM attacker, WazaParam wazaParam, DmgAffRec affinityRecorder, PokeSet targets) { }
		
		// TODO
		private void check_Side(BTL_POKEPARAM attacker, WazaParam wazaParam, DmgAffRec affinityRecorder, PokeSet targets) { }
		
		// TODO
		private void check_Mamoru(BTL_POKEPARAM attacker, WazaParam wazaParam, DmgAffRec affinityRecorder, PokeSet targets) { }
		
		// TODO
		private bool isNoEffectByMamoru(BTL_POKEPARAM attacker, BTL_POKEPARAM target, WazaParam wazaParam, DmgAffRec affinityRecorder) { return default; }
		
		// TODO
		private bool isNoEffectByMamoru_Others(BTL_POKEPARAM attacker, BTL_POKEPARAM target, WazaParam wazaParam, DmgAffRec affinityRecorder) { return default; }
		
		// TODO
		private void onMamoruSuccess(BTL_POKEPARAM attacker, BTL_POKEPARAM target, WazaParam wazaParam) { }
		
		// TODO
		private void check_Others(BTL_POKEPARAM attacker, WazaParam wazaParam, DmgAffRec affinityRecorder, PokeSet targets) { }

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