namespace Dpr.Battle.Logic
{
	public sealed class Section_DamageDrain : Section
	{
		public Section_DamageDrain(in CommonParam commonParam) : base(commonParam) { }

        // TODO
        public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private uint calcRecoverVolume(WazaParam wazaParam, uint damage) { return default; }
		
		// TODO
		private bool drain(BTL_POKEPARAM attacker, BTL_POKEPARAM defender, uint damage) { return default; }

		public class Description
		{
			public WazaParam wazaParam;
			public BTL_POKEPARAM attacker;
			public BTL_POKEPARAM defender;
			public uint damage;
			
			public Description()
			{
				wazaParam = null;
				attacker = null;
				defender = null;
				damage = 0;
			}
		}

		public class Result { }
	}
}