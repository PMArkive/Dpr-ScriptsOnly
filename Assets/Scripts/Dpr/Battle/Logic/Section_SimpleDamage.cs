namespace Dpr.Battle.Logic
{
	public sealed class Section_SimpleDamage : Section
	{
		public Section_SimpleDamage(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private void putSimpleHp(BTL_POKEPARAM bpp, uint damage, DamageCause damageCause, byte damageCausePokeID) { }
		
		// TODO
		private void checkItemReaction(BTL_POKEPARAM poke) { }
		
		// TODO
		private void checkPokeDead(BTL_POKEPARAM poke) { }

		public class Description
		{
			public BTL_POKEPARAM poke;
			public uint damage;
			public DamageCause damageCause;
			public byte damageCausePokeID;
			public StrParam message;
			public bool doDeadProcess;
			
			public Description()
			{
				poke = null;
				message = null;
				damage = 0;
				damageCause = DamageCause.OTHER;
				damageCausePokeID = PokeID.INVALID;
				doDeadProcess = false;
			}
		}

		public class Result
		{
			public bool isDamaged;
		}
	}
}