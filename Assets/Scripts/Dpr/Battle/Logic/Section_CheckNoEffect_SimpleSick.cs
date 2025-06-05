using Pml;
using Pml.WazaData;

namespace Dpr.Battle.Logic
{
	public sealed class Section_CheckNoEffect_SimpleSick : Section
    {
		public Section_CheckNoEffect_SimpleSick(in CommonParam commonParam): base(commonParam) { }

        // TODO
        public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private bool checkNoEffect(WazaParam wazaParam, BTL_POKEPARAM attacker, PokeSet targets) { return default; }
		
		// TODO
		private bool isNoEffect(BTL_POKEPARAM attacker, BTL_POKEPARAM target, WazaNo waza) { return default; }
		
		// TODO
		private bool addSickCheckFail(BTL_POKEPARAM target, BTL_POKEPARAM attacker, WazaSick sick, in BTL_SICKCONT sickCont) { return default; }

		public class Description
		{
			public WazaParam wazaParam;
			public BTL_POKEPARAM attacker;
			public PokeSet targets;
			
			public Description()
			{
				wazaParam = null;
				attacker = null;
				targets = null;
			}
		}

		public class Result { }
	}
}