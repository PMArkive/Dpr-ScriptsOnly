namespace NexPlugin
{
	public class DataStoreGetMetaParam
	{
		internal ulong dataId;
		internal DataStorePersistenceTarget persistenceTarget;
		internal DataStore.ResultFlag resultOption;
		internal ulong accessPassword;
		
		public DataStoreGetMetaParam()
		{
			dataId = 0;
			persistenceTarget = new DataStorePersistenceTarget();
			resultOption = 0;
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
		public void SetResultOption(DataStore.ResultFlag resultOption_) { }
		
		// TODO
		public DataStore.ResultFlag GetResultOption() { return default; }
		
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