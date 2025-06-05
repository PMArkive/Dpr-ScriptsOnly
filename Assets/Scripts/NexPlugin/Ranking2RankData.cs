namespace NexPlugin
{
	public class Ranking2RankData
	{
		internal ulong misc;
		internal ulong nexUniqueId;
		internal ulong principalId;
		internal uint rank;
		internal uint score;
		internal Ranking2CommonData commonData;
		
		public Ranking2RankData()
		{
			commonData = new Ranking2CommonData();
		}
		
		// TODO
		public uint GetRank() { return default; }
		
		// TODO
		public uint GetScore() { return default; }
		
		// TODO
		public ulong GetPrincipalId() { return default; }
		
		// TODO
		public ulong GetNexUniqueId() { return default; }
		
		// TODO
		public Ranking2CommonData GetCommonData() { return default; }
		
		// TODO
		public ulong GetMisc() { return default; }
		
		// TODO
		public void Trace() { }
		
		// TODO
		public override string ToString() { return default; }
	}
}