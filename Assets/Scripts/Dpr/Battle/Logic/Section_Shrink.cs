namespace Dpr.Battle.Logic
{
	public sealed class Section_Shrink : Section
	{
		public Section_Shrink(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }

		public class Description
		{
			public BTL_POKEPARAM target;
			public uint percentage;
			
			public Description()
			{
				target = null;
				percentage = 0;
			}
		}

		public class Result
		{
			public bool isSuccess;
		}
	}
}