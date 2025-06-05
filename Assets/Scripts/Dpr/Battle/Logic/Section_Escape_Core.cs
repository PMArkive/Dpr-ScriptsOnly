namespace Dpr.Battle.Logic
{
	public sealed class Section_Escape_Core : Section
	{
		public Section_Escape_Core(in CommonParam commonParam) : base(commonParam) { }

        // TODO
        public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private bool checkEscapeForbid(BTL_POKEPARAM escapePoke) { return default; }
		
		// TODO
		private bool putSpEscapeMessage(BTL_POKEPARAM escapePoke) { return default; }
		
		// TODO
		private void putDefaultEscapeMessage(BTL_POKEPARAM escapePoke) { }

		public class Description
		{
			public BTL_POKEPARAM escapePoke;
			public bool isForceSuccess;
			public bool isSpMessageCheckEnable;
			
			public Description()
			{
				escapePoke = null;
				isForceSuccess = false;
				isSpMessageCheckEnable = false;
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