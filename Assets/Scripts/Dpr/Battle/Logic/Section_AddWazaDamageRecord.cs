namespace Dpr.Battle.Logic
{
	public sealed class Section_AddWazaDamageRecord : Section
	{
		public Section_AddWazaDamageRecord(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }

		public class Description
		{
			public BTL_POKEPARAM defender;
			public BTL_POKEPARAM attacker;
			public BtlPokePos attackerPos;
			public WazaParam wazaParam;
			public ushort damage;
			
			public Description()
			{
				defender = null;
				attacker = null;
				wazaParam = null;
				attackerPos = BtlPokePos.POS_NULL;
				damage = 0;
			}
		}

		public class Result { }
	}
}