namespace NexPlugin
{
	public class Ranking2CategorySetting
	{
		internal uint minScore;
		internal uint maxScore;
		internal ushort lowestRank;
		internal byte maxSeasonsToGoBack;
		internal byte resetMode;
		internal byte resetHour;
		internal byte resetDay;
		internal ushort resetMonth;
		internal bool scoreOrder;
		
		public Ranking2CategorySetting()
		{
			// Empty, declared explicitly
		}
		
		// TODO
		public uint GetMinScore() { return default; }
		
		// TODO
		public uint GetMaxScore() { return default; }
		
		// TODO
		public bool GetScoreOrder() { return default; }
		
		// TODO
		public uint GetLowestRank() { return default; }
		
		// TODO
		public byte GetMaxSeasonsToGoBack() { return default; }
		
		// TODO
		public byte GetResetMode() { return default; }
		
		// TODO
		public byte GetResetHour() { return default; }
		
		// TODO
		public byte GetResetDay() { return default; }
		
		// TODO
		public ushort GetResetMonth() { return default; }
		
		// TODO
		public void Trace() { }
		
		// TODO
		public override string ToString() { return default; }
	}
}