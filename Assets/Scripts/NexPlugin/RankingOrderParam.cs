namespace NexPlugin
{
	public class RankingOrderParam
	{
		internal Ranking.OrderCalculation orderCalculation;
		internal Ranking.FilterGroupIndex groupIndex;
		internal byte groupNum;
		internal Ranking.TimeScope timeScope;
		internal uint offset;
		internal byte length;
		
		public RankingOrderParam()
		{
			orderCalculation = Ranking.OrderCalculation.ORDER_CALCULATION_113;
			groupIndex = Ranking.FilterGroupIndex.FILTER_GROUP_INDEX_NONE;
            timeScope = Ranking.TimeScope.TIME_SCOPE_ALL;
            offset = 0;
            groupNum = 0;
			length = 10;
		}
		
		// TODO
		public void SetOrderCalculation(Ranking.OrderCalculation orderCalculation_) { }
		
		// TODO
		public Ranking.OrderCalculation GetOrderCalculation() { return default; }
		
		// TODO
		public void SetFilterGroupIndex(Ranking.FilterGroupIndex groupIndex_) { }
		
		// TODO
		public Ranking.FilterGroupIndex GetFilterGroupIndex() { return default; }
		
		// TODO
		public void SetFilterGroupNum(byte groupNum_) { }
		
		// TODO
		public byte GetFilterGroupNum() { return default; }
		
		// TODO
		public void SetTimeScope(Ranking.TimeScope timeScope_) { }
		
		// TODO
		public Ranking.TimeScope GetTimeScope() { return default; }
		
		// TODO
		public void SetOffset(uint offset_) { }
		
		// TODO
		public uint GetOffset() { return default; }
		
		// TODO
		public void SetLength(byte length_) { }
		
		// TODO
		public byte GetLength() { return default; }
		
		// TODO
		public void Trace() { }
		
		// TODO
		public override string ToString() { return default; }
	}
}