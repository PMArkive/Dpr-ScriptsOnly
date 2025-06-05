namespace NexPlugin
{
	public class RankingChangeAttributesParam
	{
		internal ulong param;
		internal Ranking.ModificationFlag modificationFlag;
		internal byte group0;
		internal byte group1;
		
		public RankingChangeAttributesParam()
		{
			param = 0;
			modificationFlag = Ranking.ModificationFlag.MODIFICATION_FLAG_NONE;
			group0 = 0;
			group1 = 0;
		}
		
		// TODO
		public void SetModificationFlag(Ranking.ModificationFlag flag) { }
		
		// TODO
		public Ranking.ModificationFlag GetModificationFlag() { return default; }
		
		// TODO
		public void SetGroup0(byte group0_) { }
		
		// TODO
		public byte GetGroup0() { return default; }
		
		// TODO
		public void SetGroup1(byte group1_) { }
		
		// TODO
		public byte GetGroup1() { return default; }
		
		// TODO
		public void SetParam(ulong param_) { }
		
		// TODO
		public ulong GetParam() { return default; }
		
		// TODO
		public void Trace() { }
		
		// TODO
		public override string ToString() { return default; }
	}
}