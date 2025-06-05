using System.Collections.Generic;

namespace NexPlugin
{
	public class Ranking2ChartInfo
	{
		internal uint index;
		internal uint category;
		internal uint season;
		internal uint samplingRate;
		internal bool scoreOrder;
		internal uint estimateLength;
		internal uint estimateHighestScore;
		internal uint estimateLowestScore;
		internal uint estimateMedianScore;
		internal uint highestBinsScore;
		internal uint lowestBinsScore;
		internal uint binsWidth;
		internal uint attribute1;
		internal uint attribute2;
		internal NpDateTime createTime;
		internal double estimateAverageScore;
		internal List<uint> quantities;
		internal byte binsSize;
		
		// TODO
		public NpDateTime GetCreateTime() { return default; }
		
		// TODO
		public uint GetIndex() { return default; }
		
		// TODO
		public uint GetCategory() { return default; }
		
		// TODO
		public uint GetSeason() { return default; }
		
		// TODO
		public uint GetBinsSize() { return default; }
		
		// TODO
		public bool IsValid() { return default; }
		
		// TODO
		public uint GetSamplingRate() { return default; }
		
		// TODO
		public bool GetScoreOrder() { return default; }
		
		// TODO
		public uint GetEstimateLength() { return default; }
		
		// TODO
		public uint GetEstimateHighestScore() { return default; }
		
		// TODO
		public uint GetEstimateLowestScore() { return default; }
		
		// TODO
		public uint GetEstimateMedianScore() { return default; }
		
		// TODO
		public double GetEstimateAverageScore() { return default; }
		
		// TODO
		public uint GetHighestBinsScore() { return default; }
		
		// TODO
		public uint GetLowestBinsScore() { return default; }
		
		// TODO
		public uint GetBinsWidth() { return default; }
		
		// TODO
		public uint GetAttribute1() { return default; }
		
		// TODO
		public uint GetAttribute2() { return default; }
		
		// TODO
		public List<uint> GetQuantities() { return default; }
		
		// TODO
		public void Trace() { }
		
		// TODO
		public override string ToString() { return default; }
	}
}