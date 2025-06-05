namespace Dpr.Battle.Logic
{
	public sealed class Section_Root_Escape : Section
	{
		public Section_Root_Escape(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private bool escape() { return default; }
		
		// TODO
		private void onTurnEnd() { }

		public class Description { }

		public class Result
		{
			public bool isSuccessed;
		}
	}
}