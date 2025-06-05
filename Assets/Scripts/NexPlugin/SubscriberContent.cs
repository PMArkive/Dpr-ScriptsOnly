using System.Collections.Generic;

namespace NexPlugin
{
	public class SubscriberContent
	{
		internal ulong contentId;
		internal ulong pid;
		internal NpDateTime postTime;
		internal List<uint> topics;
		internal List<byte> binary;
		internal string message;
		
		public SubscriberContent()
		{
			topics = new List<uint>();
			binary = new List<byte>();
			message = "";
		}
		
		// TODO
		public ulong GetContentId() { return default; }
		
		// TODO
		public string GetMessage() { return default; }
		
		// TODO
		public List<byte> GetBinary() { return default; }
		
		// TODO
		public ulong GetPosterPrincipalId() { return default; }
		
		// TODO
		public List<uint> GetTopic() { return default; }
		
		// TODO
		public uint GetTopicSingle() { return default; }
		
		// TODO
		public NpDateTime GetPostDateTime() { return default; }
		
		// TODO
		public void Trace() { }
		
		// TODO
		public override string ToString() { return default; }
	}
}