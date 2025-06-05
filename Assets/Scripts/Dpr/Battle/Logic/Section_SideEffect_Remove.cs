namespace Dpr.Battle.Logic
{
	public sealed class Section_SideEffect_Remove : Section
	{
		public Section_SideEffect_Remove(in CommonParam commonParam) : base(commonParam) { }

        // TODO
        public void Execute(Result result, in Description description) { }
		
		// TODO
		private bool removeSideEffects(RemoveResult pResult, BtlSide side, byte[] sideEffectBitFlag) { return default; }
		
		// TODO
		private bool removeSideEffect(BtlSide side, BtlSideEffect effect) { return default; }

		public class Description
		{
			public byte pokeID;
			public BtlSide side;
			public byte[] flags;
			public bool isTokuseiWindowDisplay;
			
			// TODO
			public Description()
			{
				pokeID = PokeID.INVALID;
				side = BtlSide.BTL_SIDE_NULL;
				isTokuseiWindowDisplay = false;
				flags = new byte[(int)BtlSideEffect.BTL_SIDEEFF_BITFLG_BYTES];
			}
		}

		public class Result
		{
			public bool isSuccessed;
		}

		private class RemoveResult
		{
			public bool[][] isRemoved = RectangularArrays.RectangularDefaultArray<bool>((int)BtlSide.BTL_SIDE_NUM, (int)BtlSideEffect.BTL_SIDEEFF_MAX);
			
			public RemoveResult()
			{
				for (var i = BtlSide.BTL_SIDE_1ST; i != BtlSide.BTL_SIDE_2ND; i++)
				{
					isRemoved[(int)i][(int)BtlSideEffect.BTL_SIDEEFF_REFLECTOR] = false;
					isRemoved[(int)i][(int)BtlSideEffect.BTL_SIDEEFF_HIKARINOKABE] = false;
					isRemoved[(int)i][(int)BtlSideEffect.BTL_SIDEEFF_SINPINOMAMORI] = false;
					isRemoved[(int)i][(int)BtlSideEffect.BTL_SIDEEFF_SIROIKIRI] = false;
					isRemoved[(int)i][(int)BtlSideEffect.BTL_SIDEEFF_OIKAZE] = false;
					isRemoved[(int)i][(int)BtlSideEffect.BTL_SIDEEFF_OMAJINAI] = false;
					isRemoved[(int)i][(int)BtlSideEffect.BTL_SIDEEFF_MAKIBISI] = false;
					isRemoved[(int)i][(int)BtlSideEffect.BTL_SIDEEFF_DOKUBISI] = false;
					isRemoved[(int)i][(int)BtlSideEffect.BTL_SIDEEFF_STEALTHROCK] = false;
					isRemoved[(int)i][(int)BtlSideEffect.BTL_SIDEEFF_WIDEGUARD] = false;
					isRemoved[(int)i][(int)BtlSideEffect.BTL_SIDEEFF_FASTGUARD] = false;
					isRemoved[(int)i][(int)BtlSideEffect.BTL_SIDEEFF_RAINBOW] = false;
					isRemoved[(int)i][(int)BtlSideEffect.BTL_SIDEEFF_BURNING] = false;
					isRemoved[(int)i][(int)BtlSideEffect.BTL_SIDEEFF_MOOR] = false;
					isRemoved[(int)i][(int)BtlSideEffect.BTL_SIDEEFF_NEBANEBANET] = false;
					isRemoved[(int)i][(int)BtlSideEffect.BTL_SIDEEFF_TATAMIGAESHI] = false;
					isRemoved[(int)i][(int)BtlSideEffect.BTL_SIDEEFF_TRICKGUARD] = false;
					isRemoved[(int)i][(int)BtlSideEffect.BTL_SIDEEFF_AURORAVEIL] = false;
					isRemoved[(int)i][(int)BtlSideEffect.BTL_SIDEEFF_SPOTLIGHT] = false;
					isRemoved[(int)i][(int)BtlSideEffect.BTL_SIDEEFF_STEALTHROCK_HAGANE] = false;
					isRemoved[(int)i][(int)BtlSideEffect.BTL_SIDEEFF_GSHOCK_HONOO] = false;
					isRemoved[(int)i][(int)BtlSideEffect.BTL_SIDEEFF_GSHOCK_IWA] = false;
				}
			}
			
			// TODO
			public bool isRemovedAny() { return default; }
		}
	}
}