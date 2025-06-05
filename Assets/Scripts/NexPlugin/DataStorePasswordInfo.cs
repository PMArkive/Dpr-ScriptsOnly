namespace NexPlugin
{
	public class DataStorePasswordInfo
	{
		internal ulong dataId;
		internal ulong accessPassword;
		internal ulong updatePassword;
		
		public DataStorePasswordInfo()
		{
			accessPassword = 0;
			updatePassword = 0;
			dataId = 0;
		}
		
		// TODO
		public ulong GetDataId() { return default; }
		
		// TODO
		public ulong GetAccessPassword() { return default; }
		
		// TODO
		public ulong GetUpdatePassword() { return default; }
		
		// TODO
		public bool IsValid() { return default; }
		
		// TODO
		public void Trace() { }
		
		// TODO
		public override string ToString() { return default; }
	}
}