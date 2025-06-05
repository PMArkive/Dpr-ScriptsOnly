using Pml.Battle;

namespace Dpr.Battle.Logic
{
	public sealed class Section_CheckWazaDamageAffinity : Section
	{
		public Section_CheckWazaDamageAffinity(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }
		
		// TODO
		public TypeAffinity.AffinityID rewiteWazaAffinityByFloatingStatus(ref bool isNoEffectByFloatingStatus, BTL_POKEPARAM attacker, BTL_POKEPARAM defender, byte wazaType, TypeAffinity.AffinityID affinity) { return default; }
		
		// TODO
		private bool checkFloating(BTL_POKEPARAM pPoke, bool isIncludeHikouType) { return default; }
		
		// TODO
		public TypeAffinity.AffinityID rewiteWazaAffinityByTarSick(BTL_POKEPARAM defender, byte wazaType, TypeAffinity.AffinityID affinity) { return default; }

		public class Description
		{
			public BTL_POKEPARAM attacker;
			public BTL_POKEPARAM defender;
			public WazaParam wazaParam;
			public bool checkOnlyAttacker;
			
			public Description()
			{
				attacker = null;
				defender = null;
				wazaParam = null;
				checkOnlyAttacker = false;
			}
		}

		public class Result
		{
			public TypeAffinity.AffinityID typeAffinity;
			public bool isNoEffectByFloatingStatus;
		}
	}
}