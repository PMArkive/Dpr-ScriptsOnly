namespace NexPlugin
{
	public class SubscriberGetContentParam
	{
		internal uint size;
		internal uint offset;
		internal ulong minimumContentId;
		internal uint topic;
		
		public SubscriberGetContentParam()
		{
			topic = Subscriber.INVALID_RESERVED_TOPIC_NUM;
			size = Subscriber.MAX_FOLLOWING_SIZE;
			offset = 0;
			minimumContentId = 0;
		}
		
		// TODO
		public void SetTopic(uint topic_) { }
		
		// TODO
		public uint GetTopic() { return default; }
		
		// TODO
		public void SetSize(uint size_) { }
		
		// TODO
		public uint GetSize() { return default; }
		
		// TODO
		public void SetOffset(uint offset_) { }
		
		// TODO
		public uint GetOffset() { return default; }
		
		// TODO
		public void SetMinimumContentId(ulong minimumContentId_) { }
		
		// TODO
		public ulong GetMinimumContentId() { return default; }
		
		// TODO
		public void Reset() { }
		
		// TODO
		public void Trace() { }
		
		// TODO
		public override string ToString() { return default; }
	}
}