namespace Dpr.Battle.Logic
{
	public class PokeResult
	{
		public ushort totalTurnCount;
		public ushort criticalCount;
		public ushort totalDamageRecieved;
		public ushort deadCount;
		
		public void Clear()
		{
			totalTurnCount = 0;
			criticalCount = 0;
			totalDamageRecieved = 0;
			deadCount = 0;
		}
	}
}