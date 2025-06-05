namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_ConsumeItem : Section
	{
		public Section_FromEvent_ConsumeItem(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result result, in Description description) { }
		
		// TODO
		private void removeItem(BTL_POKEPARAM poke) { }
		
		// TODO
		private void afterItemEquip(BTL_POKEPARAM poke, ushort itemID, bool isKinomiCheckEnable) { }

		public class Description
		{
			public byte userPokeID;
			public bool isUseActionDisable;
			public bool isKinomiCheckDisable;
			public bool isConsumeMessageEnable;
			public StrParam successMessage = new StrParam();
			
			public Description()
			{
				userPokeID = PokeID.INVALID;
				isUseActionDisable = false;
				isKinomiCheckDisable = false;
				isConsumeMessageEnable = false;
			}
		}

		public class Result { }
	}
}