namespace Dpr.Battle.Logic
{
	public sealed class Section_RaidBoss_UpdateGWall : Section
	{
		public Section_RaidBoss_UpdateGWall(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private bool decGWallGauge(BTL_POKEPARAM attacker, BTL_POKEPARAM boss, WazaParam wazaParam) { return default; }
		
		// TODO
		private byte getGWallSubValue(BTL_POKEPARAM attacker, WazaParam wazaParam) { return default; }
		
		// TODO
		private bool isIchigekiWaza(WazaParam wazaParam) { return default; }

		public class Description
		{
			public BTL_POKEPARAM attacker;
			public PokeSet damagedPokeSet;
			public WazaParam wazaParam;
		}

		public class Result
		{
			public SectionUtil.GWallUpdateResult gWallUpdateResult = new SectionUtil.GWallUpdateResult();
		}
	}
}