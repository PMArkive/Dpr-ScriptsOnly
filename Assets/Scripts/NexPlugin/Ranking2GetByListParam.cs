namespace NexPlugin
{
	public class Ranking2GetByListParam
	{
		internal uint category;
		internal uint offset;
		internal uint length;
		internal Ranking2.Ranking2GetOptionFlags optionFlags;
		internal Ranking2.Ranking2SortFlags sortFlags;
		internal byte numSeasonsToGoBack;
		
		public Ranking2GetByListParam()
		{
			numSeasonsToGoBack = 0;
			sortFlags = Ranking2.Ranking2SortFlags.NOTHING;
			category = 0;
			offset = 0;
			length = 10;
			optionFlags = Ranking2.Ranking2GetOptionFlags.NOTHING;
		}
		
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