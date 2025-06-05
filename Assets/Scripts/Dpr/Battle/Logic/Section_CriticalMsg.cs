namespace Dpr.Battle.Logic
{
	public sealed class Section_CriticalMsg : Section
	{
		public Section_CriticalMsg(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private void putMessage(BTL_POKEPARAM attacker, BTL_POKEPARAM target, CriticalType criticalType, bool isPluralHitWaza) { }
		
		// TODO
		private void checkBattleTalk(byte pokeID) { }

		public class Description
		{
			public BTL_POKEPARAM attacker;
			public WazaParam wazaParam;
			public uint targetNum;
			public BTL_POKEPARAM[] targets;
			public CriticalType[] criticalTypes;
			public bool isPluralHitWaza;
			
			public Description()
			{
				attacker = null;
				wazaParam = null;
				targetNum = 0;
				targets = null;
				criticalTypes = null;
				isPluralHitWaza = false;
			}
		}

		public class Result { }
	}
}