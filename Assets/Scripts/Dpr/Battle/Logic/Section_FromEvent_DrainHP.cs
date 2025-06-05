namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_DrainHP : Section
	{
		public Section_FromEvent_DrainHP(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result result, in Description description) { }
		
		// TODO
		private bool drain(BTL_POKEPARAM attacker, BTL_POKEPARAM target, ushort drainHP, bool skipSpFailCheck) { return default; }

		public class Description
		{
			public ushort recoverHP;
			public byte recoverPokeID;
			public byte damagedPokeID;
			public bool isSkipFailCheckSP;
			public StrParam successMessage = new StrParam();
			
			public Description()
			{
				recoverHP = 0;
				recoverPokeID = PokeID.INVALID;
				damagedPokeID = PokeID.INVALID;
				isSkipFailCheckSP = false;
			}
		}

		public class Result
		{
			public bool isSuccessed;
		}
	}
}