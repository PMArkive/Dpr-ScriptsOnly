namespace Dpr.Battle.Logic
{
	public sealed class Section_CheckRealHitPoke : Section
	{
		public Section_CheckRealHitPoke(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private uint storeDamageRecords(DamageProcParams damageProcParams, DamageCalcResult rec) { return default; }
		
		// TODO
		private void storeDamageRecord(DamageProcParams param, uint paramIdx, DamageCalcResult rec, uint recIdx) { }

		public class Description
		{
			public DamageCalcResult damageRecord;
			public DamageProcParams damageProcParams;
			
			public Description()
			{
				damageRecord = null;
				damageProcParams = null;
			}
		}

		public class Result
		{
			public byte realHitPokeCount;
		}
	}
}