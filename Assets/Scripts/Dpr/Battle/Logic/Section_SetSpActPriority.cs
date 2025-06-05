namespace Dpr.Battle.Logic
{
	public sealed class Section_SetSpActPriority : Section
	{
		public Section_SetSpActPriority(in CommonParam commonParam) : base(commonParam) { }

        // TODO
        public void Execute(Result pResult, in Description description) { }

		public class Description
		{
			public PokeActionContainer actionContainer;
			
			public Description()
			{
				actionContainer = null;
			}
		}

		public class Result { }
	}
}