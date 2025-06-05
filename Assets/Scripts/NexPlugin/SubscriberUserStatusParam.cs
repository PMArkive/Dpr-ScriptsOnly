using System.Collections.Generic;

namespace NexPlugin
{
	public class SubscriberUserStatusParam
	{
		internal byte key;
		internal List<byte> value;
		
		public SubscriberUserStatusParam()
		{
			Reset();
		}
		
		// TODO
		public void SetKey(byte key_) { }
		
		// TODO
		public byte GetKey() { return default; }
		
		// TODO
		public void SetValue(List<byte> _value) { }
		
		// TODO
		public List<byte> GetValue() { return default; }
		
		// TODO
		public void Reset() { }
		
		// TODO
		public void Trace() { }
		
		// TODO
		public override string ToString() { return default; }
	}
}