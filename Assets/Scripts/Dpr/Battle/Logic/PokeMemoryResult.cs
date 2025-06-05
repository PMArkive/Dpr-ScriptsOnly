namespace Dpr.Battle.Logic
{
	public class PokeMemoryResult
	{
		public int allDeadCausedClientID;
		public int allDeadCausedPokeIdx;
		
		public void Clear()
		{
			allDeadCausedClientID = -1;
			allDeadCausedPokeIdx = -1;
		}
	}
}