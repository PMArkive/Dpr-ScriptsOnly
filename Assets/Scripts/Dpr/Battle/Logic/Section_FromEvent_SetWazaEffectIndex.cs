namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_SetWazaEffectIndex : Section
	{
		public Section_FromEvent_SetWazaEffectIndex(in CommonParam commonParam) : base(commonParam) { }

        // TODO
        public void Execute(Result result, in Description description) { }

		public class Description
		{
			public byte effectIndex;
			
			public Description()
			{
				effectIndex = 0;
			}
		}

		public class Result { }
	}
}