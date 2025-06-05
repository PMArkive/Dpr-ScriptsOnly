namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_RemovePosEffect : Section
	{
		public Section_FromEvent_RemovePosEffect(in CommonParam commonParam) : base(commonParam) { }

        // TODO
        public void Execute(Result result, in Description description) { }

		public class Description
		{
			public BtlPokePos pos;
			public BtlPosEffect effect;
			
			public Description()
			{
				pos = BtlPokePos.POS_NULL;
				effect = BtlPosEffect.BTL_POSEFF_NULL;
			}
		}

		public class Result { }
	}
}