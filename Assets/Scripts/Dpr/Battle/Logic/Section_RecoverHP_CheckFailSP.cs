namespace Dpr.Battle.Logic
{
	public sealed class Section_RecoverHP_CheckFailSP : Section
	{
		public Section_RecoverHP_CheckFailSP(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }

		public class Description
		{
			public BTL_POKEPARAM poke;
			public bool isFailMsgEnable;
			
			public Description()
			{
				poke = null;
				isFailMsgEnable = false;
			}
		}

		public class Result
		{
			public bool isFailed;
		}
	}
}