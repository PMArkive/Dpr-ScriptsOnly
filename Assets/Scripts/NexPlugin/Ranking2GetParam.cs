namespace NexPlugin
{
	public class Ranking2GetParam
	{
		internal ulong nexUniqueId;
		internal uint category;
		internal uint offset;
		internal uint length;
		internal ulong principalId;
		internal Ranking2.Ranking2GetOptionFlags optionFlags;
		internal Ranking2.Ranking2SortFlags sortFlags;
		internal Ranking2.Ranking2Mode mode;
		internal byte numSeasonsToGoBack;
		
		public Ranking2GetParam()
		{
			mode = Ranking2.Ranking2Mode.USER_RANKING;
			numSeasonsToGoBack = 0;
			category = 0;
			offset = 0;
			length = 10;
			nexUniqueId = 0;
			principalId = 0;
			optionFlags = Ranking2.Ranking2GetOptionFlags.NOTHING;
			sortFlags = Ranking2.Ranking2SortFlags.NOTHING;
		}
		
		// TODO
		public Ranking2.Ranking2Mode GetMode() { return default; }
		
		// TODO
		public void SetMode(Ranking2.Ranking2Mode mode_) { }
		
		// TODO
		public uint GetCategory() { return default; }
		
		// TODO
		public void SetCategory(uint category_) { }
		
		// TODO
		public byte GetNumSeasonsToGoBack() { return default; }
		
		// TODO
		public void SetNumSeasonsToGoBack(byte numSeasonsToGoBack_) { }
		
		// TODO
		public uint GetOffset() { return default; }
		
		// TODO
		public void SetOffset(uint offset_) { }
		
		// TODO
		public uint GetLength() { return default; }
		
		// TODO
		public void SetLength(uint length_) { }
		
		// TODO
		public ulong GetPrincipalId() { return default; }
		
		// TODO
		public void SetPrincipalId(ulong principalId_) { }
		
		// TODO
		public ulong GetNexUniqueId() { return default; }
		
		// TODO
		public void SetNexUniqueId(ulong nexUniqueId_) { }
		
		// TODO
		public Ranking2.Ranking2SortFlags GetSortFlags() { return default; }
		
		// TODO
		public void SetSortFlags(Ranking2.Ranking2SortFlags sortFlags_) { }
		
		// TODO
		public Ranking2.Ranking2GetOptionFlags GetOptionFlags() { return default; }
		
		// TODO
		public void SetOptionFlags(Ranking2.Ranking2GetOptionFlags optionFlags_) { }
		
		// TODO
		public void Reset() { }
		
		// TODO
		public void Trace() { }
		
		// TODO
		public override string ToString() { return default; }
	}
}