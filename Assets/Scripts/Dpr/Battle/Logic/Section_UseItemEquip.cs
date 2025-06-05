namespace Dpr.Battle.Logic
{
	public sealed class Section_UseItemEquip : Section
	{
		public Section_UseItemEquip(in CommonParam commonParam) : base(commonParam) { }

        // TODO
        public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private void section_ChangeItem(BTL_POKEPARAM pPoke) { }
		
		// TODO
		private void section_AfterItemEquip(BTL_POKEPARAM pPoke, ushort itemID) { }

		public class Description
		{
			public byte userPokeID = PokeID.INVALID;
			public bool isSkipHPFull;
			public bool isUseDead;
		}

		public class Result
		{
			public bool isUsed;
		}
	}
}