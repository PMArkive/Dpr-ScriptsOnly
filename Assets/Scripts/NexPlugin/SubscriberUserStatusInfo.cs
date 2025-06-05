using System.Collections.Generic;

namespace NexPlugin
{
	public class SubscriberUserStatusInfo
	{
		internal ulong pid;
		internal Dictionary<byte, List<byte>> values;
		
		// TODO
		public ulong GetPrincipalID() { return default; }
		
		// TODO
		public bool GetValue(byte key, List<byte> value) { return default; }
		
		// TODO
		public void Trace() { }
		
		// TODO
		public override string ToString() { return default; }
	}
}