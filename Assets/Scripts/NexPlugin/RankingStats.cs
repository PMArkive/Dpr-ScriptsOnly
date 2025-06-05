namespace NexPlugin
{
	public struct RankingStats
	{
		internal double total;
		internal double sum;
		internal double min;
		internal double max;
		internal double avr;
		
		// TODO
		public double GetValue(Ranking.StatsFlag flag) { return default; }
		
		// TODO
		public void Trace() { }
		
		// TODO
		public override string ToString() { return default; }
	}
}