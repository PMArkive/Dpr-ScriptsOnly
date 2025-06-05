using Pml.WazaData;

namespace Dpr.Battle.Logic
{
	public sealed class Section_RaidBoss_ExtraAction : Section
	{
		public Section_RaidBoss_ExtraAction(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private bool canExtraAttack() { return default; }
		
		// TODO
		private void effectOnExtraAttack() { }
		
		// TODO
		private void rankUp() { }
		
		// TODO
		private void rankUp(WazaRankEffect effect) { }
		
		// TODO
		private void extraAttack() { }
		
		// TODO
		private void decideWazaParam(WazaParam pWazaParam) { }
		
		// TODO
		private BTL_POKEPARAM decideTarget(in WazaParam wazaParam) { return default; }
		
		// TODO
		private void wazaExec(BTL_POKEPARAM target, WazaParam wazaParam) { }
		
		// TODO
		private void initGWall() { }
		
		// TODO
		private void repairGWall() { }
		
		// TODO
		private BTL_POKEPARAM getBoss() { return default; }

		public class Description { }

		public class Result { }
	}
}