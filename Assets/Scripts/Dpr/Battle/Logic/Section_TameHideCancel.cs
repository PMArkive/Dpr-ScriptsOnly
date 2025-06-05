using Pml.WazaData;

namespace Dpr.Battle.Logic
{
	public sealed class Section_TameHideCancel : Section
	{
		public Section_TameHideCancel(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private void cureSick(BTL_POKEPARAM poke, WazaSick sick) { }

		public class Description
		{
			public BTL_POKEPARAM poke;
			public ContFlag hideContFlag;
			public bool isOmitCancelAction;
			
			public Description()
			{
				poke = null;
				hideContFlag = ContFlag.CONTFLG_NULL;
				isOmitCancelAction = false;
			}
		}

		public class Result
		{
			public bool isCanceled;
		}
	}
}