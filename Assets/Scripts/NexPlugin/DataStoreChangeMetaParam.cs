using System.Collections.Generic;

namespace NexPlugin
{
	public class DataStoreChangeMetaParam
	{
		internal ulong dataId;
		internal DataStore.ModificationFlag modifiesFlag;
		internal string name;
		internal DataStorePermission accessPermission;
		internal DataStorePermission updatePermission;
		internal ushort period;
		internal ushort dataType;
		internal List<string> tags;
		internal List<byte> metaBinary;
		internal DataStorePersistenceTarget persistenceTarget;
		internal DataStore.DataStatus status;
		internal ulong updatePassword;
		internal DataStoreChangeMetaCompareParam compareParam;
		
		public DataStoreChangeMetaParam()
		{
			Reset();
		}
		
		// TODO
		public void SetDataId(ulong dataId_) { }
		
		// TODO
		public ulong GetDataId() { return default; }
		
		// TODO
		public void SetModificationFlag(DataStore.ModificationFlag modificationFlag) { }
		
		// TODO
		public DataStore.ModificationFlag GetModificationFlag() { return default; }
		
		// TODO
		public void SetName(string name_) { }
		
		// TODO
		public string GetName() { return default; }
		
		// TODO
		public void SetAccessPermission(DataStorePermission permission_) { }
		
		// TODO
		public DataStorePermission GetAccessPermission() { return default; }
		
		// TODO
		public void SetUpdatePermission(DataStorePermission updatePermission_) { }
		
		// TODO
		public DataStorePermission GetUpdatePermission() { return default; }
		
		// TODO
		public void SetPeriod(ushort period_) { }
		
		// TODO
		public ushort GetPeriod() { return default; }
		
		// TODO
		public void SetTags(List<string> tags_) { }
		
		// TODO
		public List<string> GetTags() { return default; }
		
		// TODO
		public void SetMetaBinary(List<byte> meta) { }
		
		// TODO
		public List<byte> GetMetaBinary() { return default; }
		
		// TODO
		public void SetUpdatePassword(ulong updatePassword_) { }
		
		// TODO
		public ulong GetUpdatePassword() { return default; }
		
		// TODO
		public void SetDataType(ushort dataType_) { }
		
		// TODO
		private ushort GetDataType() { return default; }
		
		// TODO
		public void SetDataStatus(DataStore.DataStatus status_) { }
		
		// TODO
		public DataStore.DataStatus GetDataStatus() { return default; }
		
		// TODO
		public void SetChangeMetaCompareParam(DataStoreChangeMetaCompareParam compareParam_) { }
		
		// TODO
		public DataStoreChangeMetaCompareParam GetChangeMetaCompareParam() { return default; }
		
		// TODO
		public void SetPersistenceTarget(DataStorePersistenceTarget persistenceTarget_) { }
		
		// TODO
		public DataStorePersistenceTarget GetPersistenceTarget() { return default; }
		
		// TODO
		public void Reset() { }
		
		// TODO
		public void Trace() { }
		
		// TODO
		public override string ToString() { return default; }
	}
}