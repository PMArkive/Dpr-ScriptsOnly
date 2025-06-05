using System.Collections.Generic;

namespace NexPlugin
{
	public class SubscriberPostContentParam
	{
		internal List<uint> topics;
		internal List<byte> binary;
		internal string message;
		
		public SubscriberPostContentParam()
		{
			Reset();
		}
		
		// TODO
		public void SetTopic(List<uint> topics_) { }
		
		// TODO
		public void SetTopic(uint topic_) { }
		
		// TODO
		public List<uint> GetTopic() { return default; }
		
		// TODO
		public uint GetTopicSingle() { return default; }
		
		// TODO
		public void SetMessage(string message_) { }
		
		// TODO
		public string GetMessage() { return default; }
		
		// TODO
		public void SetBinary(List<byte> binary_) { }
		
		// TODO
		public List<byte> GetBinary() { return default; }
		
		// TODO
		public void Reset() { }
		
		// TODO
		public void Trace() { }
		
		// TODO
		public override string ToString() { return default; }
	}
}