namespace Dpr.Battle.Logic
{
	public sealed class Section_SideEffect_Add : Section
	{
		public Section_SideEffect_Add(in CommonParam commonParam) : base(commonParam) { }

        // TODO
        public void Execute(Result result, in Description desc) { }
		
		// TODO
		private void onSuccess(in Description desc, BtlSide targetSide) { }

		public class Description
		{
			public byte pokeID;
			public BtlSideEffect effect;
			public BTL_SICKCONT cont;
			public BtlSide side;
			public ushort successEffectNo;
			public StrParam successMessage;
			public bool isReplaceSuccessMessageArgs0ByExpandSide;
			
			public Description()
			{
				pokeID = PokeID.INVALID;
				effect = BtlSideEffect.BTL_SIDEEFF_NULL;
				side = BtlSide.BTL_SIDE_NULL;
				cont = default;
				successEffectNo = (ushort)BtlEff.BTLEFF_MAX;
				successMessage = new StrParam();
				isReplaceSuccessMessageArgs0ByExpandSide = false;
			}
		}

		public class Result
		{
			public bool isSuccessed;
		}
	}
}