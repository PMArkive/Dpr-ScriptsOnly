namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_PosEffect_Add : Section
	{
		public Section_FromEvent_PosEffect_Add(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result result, in Description description) { }
		
		// TODO
		private void getEventFactorParam(int[] factorParam, ref byte factorParamNum, byte userPokeID, BtlPokePos pos, BtlPosEffect effect, in PosEffect.EffectParam effectParam, bool isSkipHpRecoverSpFailCheck) { }

		public class Description
		{
			public byte userPokeID;
			public BtlPokePos pos;
			public BtlPosEffect effect;
			public PosEffect.EffectParam effectParam;
			public bool isSkipHpRecoverSpFailCheck;
			
			public Description()
			{
				userPokeID = PokeID.INVALID;
				pos = BtlPokePos.POS_NULL;
				effect = BtlPosEffect.BTL_POSEFF_NULL;
				effectParam = default;
				isSkipHpRecoverSpFailCheck = false;
			}
		}

		public class Result
		{
			public bool isAdded;
		}
	}
}