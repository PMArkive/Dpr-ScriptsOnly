namespace Dpr.Battle.Logic
{
	public sealed class Section_MemberIn : Section
	{
		public Section_MemberIn(in CommonParam commonParam) : base(commonParam) { }

        // TODO
        public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private byte memberIn(byte clientID, byte posIdx, byte nextPokeIdx) { return default; }
		
		// TODO
		private void checkBattleTalk(byte pokeID) { }

		public class Description
		{
			public byte clientID;
			public byte posIdx;
			public byte nextPokeIdx;
			public bool isPutMessage;
			
			public Description()
			{
				clientID = (byte)BTL_CLIENT_ID.BTL_CLIENT_NULL;
				posIdx = 0;
				nextPokeIdx = 0;
				isPutMessage = false;
			}
		}

		public class Result
		{
			public byte inPokeID;
		}
	}
}