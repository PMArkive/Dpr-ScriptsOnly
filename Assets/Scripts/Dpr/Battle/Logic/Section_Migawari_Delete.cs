namespace Dpr.Battle.Logic
{
	public sealed class Section_Migawari_Delete : Section
	{
		public Section_Migawari_Delete(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }

		public class Description
		{
			public BTL_POKEPARAM poke;
			public bool canPutDefaultMessage = true;
		}

		public class Result { }
	}
}