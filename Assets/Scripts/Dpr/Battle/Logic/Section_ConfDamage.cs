namespace Dpr.Battle.Logic
{
	public sealed class Section_ConfDamage : Section
	{
		public Section_ConfDamage(in CommonParam commonParam) : base(commonParam) { }

        // TODO
        public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private ushort calcDamage(BTL_POKEPARAM poke) { return default; }
		
		// TODO
		private ushort fixDamage(BTL_POKEPARAM poke, ushort damage) { return default; }
		
		// TODO
		private void checkKoraeru(out KoraeruCause koraeCause, out ushort fixedDamage, BTL_POKEPARAM poke, ushort damage)
		{
			koraeCause = default;
			fixedDamage = default;
		}
		
		// TODO
		private void section_Koraeru(BTL_POKEPARAM poke, KoraeruCause cause) { }

		public class Description
		{
			public BTL_POKEPARAM attacker;
			
			public Description()
			{
				attacker = null;
			}
		}

		public class Result
		{
			public ushort damage;
		}
	}
}