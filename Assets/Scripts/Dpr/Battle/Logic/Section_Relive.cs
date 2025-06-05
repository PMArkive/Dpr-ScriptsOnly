namespace Dpr.Battle.Logic
{
	public sealed class Section_Relive : Section
	{
		public Section_Relive(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result result, in Description description) { }
		
		// TODO
		private byte memberIn(byte clientID, byte posIdx, byte nextPokeIdx) { return default; }
		
		// TODO
		private void afterMemberIn(byte inPokeID) { }

		public class Description
		{
			public byte pokeID;
			public ushort recoverHP;
			public StrParam reliveMessage = new StrParam();
			
			public Description()
			{
				pokeID = PokeID.INVALID;
				recoverHP = 0;
			}
		}

		public class Result { }
	}
}