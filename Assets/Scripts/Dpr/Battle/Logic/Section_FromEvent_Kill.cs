using Pml;

namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_Kill : Section
	{
		public Section_FromEvent_Kill(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result result, in Description description) { }
		
		// TODO
		private void kill(BTL_POKEPARAM target, byte attackerID, DamageCause deadCause, PGLRecord.RecParam pPglParam, bool doDeadProcess) { }

		public class Description
		{
			public byte userPokeID;
			public byte targetPokeID;
			public bool isDeadPokeEnable;
			public bool isDisableDeadProcess;
			public WazaNo recordWazaID;
			public DamageCause deadCause;
			public StrParam message = new StrParam();
			
			public Description()
			{
				userPokeID = PokeID.INVALID;
				targetPokeID = PokeID.INVALID;
				isDeadPokeEnable = false;
				isDisableDeadProcess = false;
				recordWazaID = WazaNo.NULL;
				deadCause = DamageCause.OTHER;
			}
		}

		public class Result
		{
			public bool isKilled;
		}
	}
}