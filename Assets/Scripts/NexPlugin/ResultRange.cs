namespace NexPlugin
{
	public class ResultRange
	{
		internal uint offset;
		internal uint size;
		
		public ResultRange(uint uiOffset = 0, uint uiSize = 20)
		{
			offset = uiOffset;
			size = uiSize;
		}
		
		// TODO
		public void SetOffset(uint uiOffset = 0) { }
		
		// TODO
		public uint GetOffset() { return default; }
		
		// TODO
		public void SetSize(uint uiSize = 20) { }
		
		// TODO
		public uint GetSize() { return default; }
		
		// TODO
		public static ResultRange operator ++(ResultRange r) { return default; }
		
		// TODO
		public void Trace() { }
		
		// TODO
		public override string ToString() { return default; }
	}
}