namespace Dpr.Battle.Logic
{
	public sealed class Section_MemberOut : Section
	{
		public Section_MemberOut(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private void memberOut(BTL_POKEPARAM outPoke) { }

		public class Description
		{
			public BTL_POKEPARAM outPoke;
			public bool isInterruptDisable;
			
			public Description()
			{
				outPoke = null;
				isInterruptDisable = false;
			}
		}

		public class Result
		{
			public bool isOutSuccessed;
		}
	}
}