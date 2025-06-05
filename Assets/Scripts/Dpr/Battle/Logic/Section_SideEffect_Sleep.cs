namespace Dpr.Battle.Logic
{
	public sealed class Section_SideEffect_Sleep : Section
	{
		public Section_SideEffect_Sleep(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result result, in Description description) { }
		
		// TODO
		private bool sleepSideEffects(BtlSide side, byte[] sideEffectBitFlag, bool wakeUpFlag) { return default; }
		
		// TODO
		private bool sleepSideEffect(BtlSide side, BtlSideEffect effect, bool wakeUpFlag) { return default; }

		public class Description
		{
			public BtlSide side;
			public byte[] flags;
			public bool wakeUpFlag;
			
			public Description()
			{
				side = BtlSide.BTL_SIDE_NULL;
				wakeUpFlag = false;
				flags = new byte[(int)BtlSideEffect.BTL_SIDEEFF_BITFLG_BYTES];
			}
		}

		public class Result
		{
			public bool isSuccessed;
		}
	}
}