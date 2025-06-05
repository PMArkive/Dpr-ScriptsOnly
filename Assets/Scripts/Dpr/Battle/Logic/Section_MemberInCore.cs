namespace Dpr.Battle.Logic
{
	public sealed class Section_MemberInCore : Section
	{
		public Section_MemberInCore(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private void checkBattleTalk(byte pokeID) { }

		public class Description
		{
			public byte clientID;
			public byte posIdx;
			public byte nextPokeIdx;
			
			public Description()
			{
				clientID = (byte)BTL_CLIENT_ID.BTL_CLIENT_NULL;
				posIdx = 0;
				nextPokeIdx = 0;
			}
		}

		public class Result
		{
			public byte inPokeID;
		}
	}
}