using Pml;

namespace Dpr.Battle.Logic
{
	public sealed class Section_RecoverHP : Section
	{
		public Section_RecoverHP(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result result, in Description description) { }
		
		// TODO
		private bool checkFailBase(BTL_POKEPARAM poke) { return default; }
		
		// TODO
		private bool checkFailSP(BTL_POKEPARAM poke, bool isFailMessageDisplay) { return default; }
		
		// TODO
		private void recover(BTL_POKEPARAM poke, ushort recoverHP, bool isEffectEnable) { }

		public class Description
		{
			public byte userPokeID;
			public byte targetPokeID;
			public ushort recoverHP;
			public ushort itemID;
			public bool isDisplayTokuseiWindow;
			public bool isDisplayFailMessage_HPFull;
			public bool isDisplayFailMessage_SP;
			public bool isDisplayRecoverEffect;
			public bool isSkipFailCheckSP;
			public StrParam successMessage = new StrParam();
			
			public Description()
			{
				userPokeID = PokeID.INVALID;
				targetPokeID = PokeID.INVALID;
				recoverHP = 0;
				itemID = (ushort)ItemNo.DUMMY_DATA;
				isDisplayTokuseiWindow = false;
				isDisplayFailMessage_HPFull = false;
				isDisplayFailMessage_SP = true;
				isDisplayRecoverEffect = true;
				isSkipFailCheckSP = false;
			}
		}

		public class Result
		{
			public bool isRecovered;
		}
	}
}