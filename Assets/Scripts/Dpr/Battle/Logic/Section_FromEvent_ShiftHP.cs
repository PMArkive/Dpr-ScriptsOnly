namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_ShiftHP : Section
	{
		public Section_FromEvent_ShiftHP(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result result, in Description description) { }
		
		// TODO
		private void checkItemReaction(BTL_POKEPARAM poke) { }

		public class Description
		{
			public byte pokeID;
			public bool isEffectDisable;
			public bool isItemReactionDisable;
			public byte targetPokeCount;
			public byte[] targetPokeID = new byte[DefineConstants.BTL_POSIDX_MAX];
			public int[] volume = new int[DefineConstants.BTL_POSIDX_MAX];
			public DamageCause damageCause;
			
			public Description()
			{
				pokeID = PokeID.INVALID;
				isEffectDisable = false;
				isItemReactionDisable = false;
				targetPokeCount = 0;
				damageCause = DamageCause.OTHER;
			}
		}

		public class Result
		{
			public bool isSuccessed;
		}
	}
}