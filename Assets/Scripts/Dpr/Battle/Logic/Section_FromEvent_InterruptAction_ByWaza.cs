using Pml;

namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_InterruptAction_ByWaza : Section
	{
		public Section_FromEvent_InterruptAction_ByWaza(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result result, in Description description) { }

		public class Description
		{
			public WazaNo waza;
			
			public Description()
			{
				waza = WazaNo.NULL;
			}
		}

		public class Result
		{
			public bool isSucceeded;
		}
	}
}