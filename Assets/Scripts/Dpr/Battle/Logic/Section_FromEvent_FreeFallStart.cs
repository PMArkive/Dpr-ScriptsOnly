namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_FreeFallStart : Section
	{
		public Section_FromEvent_FreeFallStart(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result result, in Description description) { }
		
		// TODO
		private uint getWeight(BTL_POKEPARAM poke) { return default; }
		
		// TODO
		private void onMamoruSuccess(BTL_POKEPARAM attacker, BTL_POKEPARAM target, WazaParam wazaParam) { }
		
		// TODO
		private bool checkGuard(BTL_POKEPARAM attacker, BTL_POKEPARAM target, WazaParam wazaParam) { return default; }
		
		// TODO
		private void setFreeFallSick(BTL_POKEPARAM attacker, BTL_POKEPARAM target) { }

		public class Description
		{
			public byte attackerID;
			public byte targetID;
			public WazaParam wazaParam;
			
			public Description()
			{
				wazaParam = null;
				attackerID = PokeID.INVALID;
				targetID = PokeID.INVALID;
			}
		}

		public class Result
		{
			public bool isSucceeded;
			public bool isFailMessageDisplayed;
		}
	}
}