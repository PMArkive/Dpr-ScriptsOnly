namespace NexPlugin
{
	public class DataStorePrepareUpdateParam
	{
		internal ulong dataId;
		internal ulong updatePassword;
		internal uint size;
		
		public DataStorePrepareUpdateParam()
		{
			size = 0;
			dataId = 0;
			updatePassword = 0;
		}
		
		// TODO
		public void SetDataId(ulong dataId_) { }
		
		// TODO
		public ulong GetDataId() { return default; }
		
		// TODO
		public void SetSize(uint size_) { }
		
		// TODO
		public uint GetSize() { return default; }
		
		// TODO
		public void SetUpdatePassword(ulong updatePassword_) { }
		
		// TODO
		public ulong GetUpdatePassword() { return default; }
		
		// TODO
		public void Reset() { }
		
		// TODO
		public void Trace() { }
		
		// TODO
		public override string ToString() { return default; }
	}
}