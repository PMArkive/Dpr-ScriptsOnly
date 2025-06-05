namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_TameHideCancel : Section
	{
		public Section_FromEvent_TameHideCancel(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result result, in Description description) { }
		
		// TODO
		private bool cancelHide(BTL_POKEPARAM poke, ContFlag flag) { return default; }

		public class Description
		{
			public byte targetPokeID;
			public ContFlag flag;
			public StrParam successMessage = new StrParam();
			
			public Description()
			{
				targetPokeID = PokeID.INVALID;
				flag = ContFlag.CONTFLG_NULL;
			}
		}

		public class Result
		{
			public bool isSucceeded;
		}
	}
}