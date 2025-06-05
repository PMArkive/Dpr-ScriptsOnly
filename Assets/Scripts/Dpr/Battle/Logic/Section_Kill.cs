namespace Dpr.Battle.Logic
{
	public sealed class Section_Kill : Section
	{
		public Section_Kill(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private void deadProcess(BTL_POKEPARAM target, PGLRecord.RecParam pPglParam) { }

		public class Description
		{
			public BTL_POKEPARAM target;
			public byte attackerID;
			public DamageCause deadCause;
			public PGLRecord.RecParam pPglParam;
			public bool doDeadProcess;
			
			public Description()
			{
				target = null;
				pPglParam = null;
				attackerID = PokeID.INVALID;
				deadCause = DamageCause.OTHER;
				doDeadProcess = false;
			}
		}

		public class Result { }
	}
}