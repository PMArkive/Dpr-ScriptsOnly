namespace NexPlugin
{
	public class UniqueIdInfo
	{
		internal ulong nexUniqueId;
		internal ulong nexUniqueIdPassword;
		
		public UniqueIdInfo()
		{
			nexUniqueId = 0;
		}
		
		public UniqueIdInfo(ulong nexUniqueId_, ulong nexUniqueIdPassword_)
		{
			nexUniqueId = nexUniqueId_;
			nexUniqueIdPassword = nexUniqueIdPassword_;
		}
		
		// TODO
		public void SetUniqueId(ulong nexUniqueId_) { }
		
		// TODO
		public ulong GetUniqueId() { return default; }
		
		// TODO
		public void SetPassword(ulong nexUniqueIdPassword_) { }
		
		// TODO
		public ulong GetPassword() { return default; }
		
		// TODO
		public bool IsValid() { return default; }
		
		// TODO
		public void Trace() { }
		
		// TODO
		public override string ToString() { return default; }
	}
}