namespace NexPlugin
{
	public class DataStorePrepareGetParam
	{
		internal ulong dataId;
		internal ulong accessPassword;
		internal DataStorePersistenceTarget persistenceTarget;
		
		public DataStorePrepareGetParam()
		{
			dataId = 0;
			persistenceTarget = new DataStorePersistenceTarget();
			accessPassword = 0;
		}
		
		// TODO
		public void SetDataId(ulong dataId_) { }
		
		// TODO
		public ulong GetDataId() { return default; }
		
		// TODO
		public void SetPersistenceTarget(DataStorePersistenceTarget persistenceTarget_) { }
		
		// TODO
		public DataStorePersistenceTarget GetPersistenceTarget() { return default; }
		
		// TODO
		public void SetAccessPassword(ulong accessPassword_) { }
		
		// TODO
		public ulong GetAccessPassword() { return default; }
		
		// TODO
		public void Reset() { }
		
		// TODO
		public void Trace() { }
		
		// TODO
		public override string ToString() { return default; }
	}
}