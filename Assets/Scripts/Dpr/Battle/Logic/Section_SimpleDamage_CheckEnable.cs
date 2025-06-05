namespace Dpr.Battle.Logic
{
	public sealed class Section_SimpleDamage_CheckEnable : Section
	{
		public Section_SimpleDamage_CheckEnable(in CommonParam commonParam) : base(commonParam) { }

        // TODO
        public void Execute(Result pResult, in Description description) { }

		public class Description
		{
			public BTL_POKEPARAM poke;
			public uint damage;
			public DamageCause damageCause;
			
			public Description()
			{
				poke = null;
				damage = 0;
				damageCause = DamageCause.OTHER;
			}
		}

		public class Result
		{
			public bool isEnable;
		}
	}
}