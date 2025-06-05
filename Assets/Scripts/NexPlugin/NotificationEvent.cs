namespace NexPlugin
{
	public class NotificationEvent
	{
		internal ulong param1;
		internal ulong param2;
		internal Common.NotificationEvents type;
		internal uint subType;
		internal string stringParam;
		internal ulong pid;
		
		// TODO
		public ulong GetSource() { return default; }
		
		// TODO
		public Common.NotificationEvents GetType() { return default; }
		
		// TODO
		public uint GetSubType() { return default; }
		
		// TODO
		public ulong GetParam1() { return default; }
		
		// TODO
		public ulong GetParam2() { return default; }
		
		// TODO
		public string GetStringParam() { return default; }
		
		// TODO
		public void Trace() { }
		
		// TODO
		internal string ToString() { return default; }
	}
}