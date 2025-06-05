namespace Dpr.Battle.Logic
{
	public sealed class Section_Escape_Sub : Section
	{
		public Section_Escape_Sub(in CommonParam commonParam) : base(commonParam) { }

        // TODO
        public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private void checkForceSucceed(ref bool pIsForceSuccess, ref bool pIsSkipAgiCheck, in Description description) { }
		
		// TODO
		private bool section_Escape_CheckForceSucceed(BTL_POKEPARAM pPoke) { return default; }
		
		// TODO
		private bool checkEscapeEnableByAgi(BTL_POKEPARAM escapePoke, byte tryCount) { return default; }
		
		// TODO
		private bool section_Escape_Core(BTL_POKEPARAM pPoke, bool isForceSuccess) { return default; }

		public class Description
		{
			public BTL_POKEPARAM escapePoke;
			public bool isSkipAgiCheck;
			public bool isForceSuccess;
			
			public Description()
			{
				escapePoke = null;
				isSkipAgiCheck = false;
				isForceSuccess = false;
			}
		}

		public class Result
		{
			public bool isSucceeded;
			
			public Result()
			{
				isSucceeded = false;
			}
		}
	}
}