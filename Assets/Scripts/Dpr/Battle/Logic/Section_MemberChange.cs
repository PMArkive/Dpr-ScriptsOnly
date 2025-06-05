namespace Dpr.Battle.Logic
{
	public sealed class Section_MemberChange : Section
	{
		public Section_MemberChange(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private bool isPokeExist(in BTL_POKEPARAM poke) { return default; }
		
		// TODO
		private bool memberOut(BTL_POKEPARAM outPoke) { return default; }
		
		// TODO
		private byte memberIn(BTL_POKEPARAM outPoke, byte nextPokeIdx) { return default; }
		
		// TODO
		private void incMemberChangeCount(BTL_POKEPARAM outPoke) { }

		public class Description
		{
			public BTL_POKEPARAM outPoke;
			public byte nextPokeIdx;
			
			public Description()
			{
				outPoke = null;
				nextPokeIdx = 0;
			}
		}

		public class Result
		{
			public byte inPokeID;
		}
	}
}