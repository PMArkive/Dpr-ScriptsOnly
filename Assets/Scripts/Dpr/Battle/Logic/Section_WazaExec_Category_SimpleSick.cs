using Pml.WazaData;

namespace Dpr.Battle.Logic
{
	public sealed class Section_WazaExec_Category_SimpleSick : Section
	{
		public Section_WazaExec_Category_SimpleSick(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private bool sectionWazaSickCore(BTL_POKEPARAM attacker, BTL_POKEPARAM target, WazaSick sick, in BTL_SICKCONT sickCont) { return default; }

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