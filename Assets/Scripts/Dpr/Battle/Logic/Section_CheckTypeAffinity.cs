using Pml.Battle;

namespace Dpr.Battle.Logic
{
	public sealed class Section_CheckTypeAffinity : Section
	{
		public Section_CheckTypeAffinity(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }
		
		// TODO
		public void checkTypeAffinity(out TypeAffinity.AffinityID pTypeAffinity, out bool pIsNoEffectByFloatingStatus, BTL_POKEPARAM attacker, BTL_POKEPARAM defender, WazaParam wazaParam)
		{
			pTypeAffinity = default;
			pIsNoEffectByFloatingStatus = default;
		}

		public class Description
		{
			public WazaParam wazaParam;
			public BTL_POKEPARAM attacker;
			public PokeSet targets;
			public DmgAffRec affinityRecorder;
			
			public Description()
			{
				wazaParam = null;
				attacker = null;
				targets = null;
				affinityRecorder = null;
			}
		}

		public class Result { }
	}
}