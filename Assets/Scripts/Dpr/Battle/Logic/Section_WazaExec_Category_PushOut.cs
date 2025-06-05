using Pml;

namespace Dpr.Battle.Logic
{
	public sealed class Section_WazaExec_Category_PushOut : Section
	{
		public Section_WazaExec_Category_PushOut(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private void pushOut(out bool isSuccessed, out bool isFailMsgDisplayed, BTL_POKEPARAM attacker, BTL_POKEPARAM target, ushort effectNo)
		{
			isSuccessed = default;
			isFailMsgDisplayed = default;
		}

		public class Description
		{
			public WazaNo waza;
			public BTL_POKEPARAM attacker;
			public PokeSet targets;
			
			public Description()
			{
				waza = WazaNo.NULL;
				attacker = null;
				targets = null;
			}
		}

		public class Result { }
	}
}