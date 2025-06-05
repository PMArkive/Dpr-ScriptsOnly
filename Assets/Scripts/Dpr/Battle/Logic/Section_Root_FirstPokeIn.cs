namespace Dpr.Battle.Logic
{
	public sealed class Section_Root_FirstPokeIn : Section
	{
		public Section_Root_FirstPokeIn(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private void changeWeather() { }
		
		// TODO
		private void changeGround() { }
		
		// TODO
		private void memberInAll() { }
		
		// TODO
		private void memberInAll(PokeIDRegister inPokeIDRegister, byte clientID) { }
		
		// TODO
		private void memberIn(PokeIDRegister inPokeIDRegister, byte clientID, byte posIdx, byte nextPokeIdx) { }
		
		// TODO
		private void afterMemberIn(PokeIDRegister inPokeIDRegister) { }
		
		// TODO
		private void firstPokeInEnd() { }

		public class Description { }

		public class Result
		{
			public InterruptCode interrupt;
		}
	}
}