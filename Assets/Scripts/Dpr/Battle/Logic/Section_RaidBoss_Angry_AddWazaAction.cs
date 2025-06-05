using Pml;

namespace Dpr.Battle.Logic
{
	public sealed class Section_RaidBoss_Angry_AddWazaAction : Section
	{
		public Section_RaidBoss_Angry_AddWazaAction(in CommonParam commonParam) : base(commonParam) { }

        // TODO
        public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private BtlPokePos calcTargetPos(BTL_POKEPARAM boss, WazaNo wazano) { return default; }
		
		// TODO
		private uint calcActionPriority(PokeAction pokeAction, DominantPriority dominantPriority) { return default; }

		public class Description
		{
			public DominantPriority dominantPriority;
			
			public Description()
			{
				dominantPriority = DominantPriority.DEFAULT;
			}
		}

		public class Result { }
	}
}