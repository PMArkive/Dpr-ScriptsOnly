using Pml;

namespace Dpr.Battle.Logic
{
	public sealed class Section_UseItem : Section
	{
		public Section_UseItem(in CommonParam commonParam) : base(commonParam) { }

        // TODO
        public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private void useItemCore(out TrainerItemResult pUseResult, out bool pIsConsumed, out bool pIsUsedBall, BTL_POKEPARAM poke, ushort itemID, byte actParam, byte targetPokeID, POKE_CAPTURED_CONTEXT capContext)
		{
			pUseResult = default;
			pIsConsumed = default;
			pIsUsedBall = default;
		}
		
		// TODO
		private bool expGetByCaptured(byte userClientID, BtlPokePos capturedPos) { return default; }
		
		// TODO
		private void putFurimukiCommand(byte playerClientID) { }
		
		// TODO
		private bool getExp(BTL_PARTY pParty, ExpCalculator.CalcExpContainer pExpContainer) { return default; }
		
		// TODO
		private void putCapturedCommand(in POKE_CAPTURED_CONTEXT context) { }
		
		// TODO
		private void updateZukanData(in POKE_CAPTURED_CONTEXT context) { }
		
		// TODO
		private bool escape(BTL_POKEPARAM escapePoke) { return default; }

		public class Description
		{
			public BTL_POKEPARAM poke;
			public ushort itemID;
			public byte actParam;
			public byte targetPokeID;
			
			public Description()
			{
				poke = null;
				itemID = (ushort)ItemNo.DUMMY_DATA;
				actParam = 0;
				targetPokeID = PokeID.INVALID;
			}
		}

		public class Result
		{
			public bool isExpGet;
		}
	}
}