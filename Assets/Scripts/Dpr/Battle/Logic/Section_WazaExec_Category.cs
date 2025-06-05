using Pml.WazaData;

namespace Dpr.Battle.Logic
{
	public sealed class Section_WazaExec_Category : Section
	{
		public Section_WazaExec_Category(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private void damageWaza(BTL_POKEPARAM attacker, ActionDesc actionDesc, WazaParam wazaParam, DmgAffRec affinityRecorder, PokeSet targets) { }
		
		// TODO
		private void simpleEffect(ActionDesc actionDesc, BTL_POKEPARAM attacker, WazaParam wazaParam, PokeSet targets) { }
		
		// TODO
		private void simpleSick(BTL_POKEPARAM attacker, WazaParam wazaParam, PokeSet targets) { }
		
		// TODO
		private void simpleRecover(BTL_POKEPARAM attacker, WazaParam wazaParam, PokeSet targets) { }
		
		// TODO
		private void effectSick(ActionDesc actionDesc, BTL_POKEPARAM attacker, WazaParam wazaParam, PokeSet targets) { }
		
		// TODO
		private void pushOut(BTL_POKEPARAM attacker, WazaParam wazaParam, PokeSet targets) { }
		
		// TODO
		private void fieldEffect(BTL_POKEPARAM attacker, WazaParam wazaParam) { }
		
		// TODO
		private void uncategory(BTL_POKEPARAM attacker, WazaParam wazaParam, PokeSet targets) { }
		
		// TODO
		private void event_UnDamageProcEnd(BTL_POKEPARAM attacker, WazaParam wazaParam) { }

		public class Description
		{
			public BTL_POKEPARAM attacker;
			public ActionDesc actionDesc;
			public WazaParam wazaParam;
			public bool isDamageWaza;
			public WazaCategory wazaCategory;
			public DmgAffRec affinityRecorder;
			public PokeSet targets;
		}

		public class Result { }
	}
}