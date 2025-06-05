namespace Dpr.Battle.Logic
{
	public sealed class Section_PushOut : Section
	{
		public Section_PushOut(in CommonParam commonParam) : base(commonParam) { }

        // TODO
        public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private PushOutEffect getPushOutEffect(BTL_POKEPARAM attacker, bool isForceChange) { return default; }
		
		// TODO
		private BtlPokePos getTargetPos(BTL_POKEPARAM target) { return default; }
		
		// TODO
		private bool checkFail(ref bool isFailMessageDisplayed, BTL_POKEPARAM attacker, BTL_POKEPARAM target) { return default; }
		
		// TODO
		private bool pushOutEffect_Change(BTL_POKEPARAM target, ushort effectNo, StrParam succeedMessage) { return default; }
		
		// TODO
		private bool pushOutEffect_Escape(BTL_POKEPARAM attacker, BTL_POKEPARAM target, ushort effectNo, bool isIgnoreLevel) { return default; }
		
		// TODO
		private int getNextInPokeIndex(byte clientID) { return default; }
		
		// TODO
		private void memberOut(BTL_POKEPARAM target, ushort effectNo) { }
		
		// TODO
		private byte memberIn(byte clientID, byte posIdx, byte nextPokeIdx) { return default; }
		
		// TODO
		private void afterMemberIn(byte inPokeID) { }

		public class Description
		{
			public byte attackerID;
			public byte targetID;
			public bool isForceChange;
			public bool isIgnoreLevel;
			public ushort effectNo;
			public StrParam succeedMessage;
			
			public Description()
			{
				succeedMessage = null;
				attackerID = PokeID.INVALID;
				targetID = PokeID.INVALID;
				isForceChange = false;
				isIgnoreLevel = false;
				effectNo = 0;
			}
		}

		public class Result
		{
			public bool isSuccessed;
			public bool isFailMessageDisplayed;
		}
	}
}