using System.Collections.Generic;

namespace NexPlugin
{
	public class RankingRankData
	{
		internal ulong principalId;
		internal uint order;
		internal ulong uniqueId;
		internal uint category;
		internal uint score;
		internal ulong param;
		internal NpDateTime updateTime;
		internal List<byte> commonData;
		internal byte group0;
		internal byte group1;
		
		public RankingRankData()
		{
			principalId = 0;
			order = 0;
			param = 0;
			uniqueId = 0;
			category = 0;
			score = 0;
			commonData = new List<byte>();
			updateTime = NpDateTime.Never;
		}
		
		// TODO
		public ulong GetPrincipalId() { return default; }
		
		// TODO
		public ulong GetUniqueId() { return default; }
		
		// TODO
		public uint GetOrder() { return default; }
		
		// TODO
		public uint GetCategory() { return default; }
		
		// TODO
		public uint GetScore() { return default; }
		
		// TODO
		public byte GetGroup0() { return default; }
		
		// TODO
		public byte GetGroup1() { return default; }
		
		// TODO
		public ulong GetParam() { return default; }
		
		// TODO
		public List<byte> GetCommonData() { return default; }
		
		// TODO
		public NpDateTime GetUpdateTime() { return default; }
		
		// TODO
		public void Trace() { }
		
		// TODO
		public override string ToString() { return default; }
	}
}