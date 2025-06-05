namespace Dpr.Battle.Logic
{
	public sealed class Section_CheckExpGet : Section
	{
		public Section_CheckExpGet(in CommonParam commonParam) : base(commonParam) { }

        // TODO
        public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private void calcExp(ExpCalculator.CalcExpContainer pExpContainer) { }
		
		// TODO
		private bool isExpProvidePoke(byte deadPokeID) { return default; }
		
		// TODO
		private bool canPlayWinWildBGM() { return default; }
		
		// TODO
		private void playWinWildBGM() { }
		
		// TODO
		private bool isPlayerSideAlive() { return default; }
		
		// TODO
		private bool getExp(ExpCalculator.CalcExpContainer pExpContainer) { return default; }

		public class Description { }

		public class Result
		{
			public bool isExpGet;
		}
	}
}