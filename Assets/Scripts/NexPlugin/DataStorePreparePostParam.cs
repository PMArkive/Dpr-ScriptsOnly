using System.Collections.Generic;

namespace NexPlugin
{
	public class DataStorePreparePostParam
	{
		internal uint size;
		internal string name;
		internal ushort dataType;
		internal ushort period;
		internal DataStorePermission accessPermission;
		internal DataStorePermission updatePermission;
		internal DataStore.DataFlag flag;
		internal List<string> tags;
		internal Dictionary<sbyte, DataStoreRatingInitParam> ratingInitParams;
		internal List<byte> meta;
		internal DataStorePersistenceInitParam persistenceInitParam;
		
		public DataStorePreparePostParam()
		{
			Reset();
		}
		
		// TODO
		public void SetSize(uint size_) { }
		
		// TODO
		public uint GetSize() { return default; }
		
		// TODO
		public void SetName(string name_) { }
		
		// TODO
		public string GetName() { return default; }
		
		// TODO
		public void SetDataType(ushort dataType_) { }
		
		// TODO
		public ushort GetDataType() { return default; }
		
		// TODO
		public void SetAccessPermission(DataStorePermission permission_) { }
		
		// TODO
		public DataStorePermission GetAccessPermission() { return default; }
		
		// TODO
		public void SetUpdatePermission(DataStorePermission updatePermission_) { }
		
		// TODO
		public DataStorePermission GetUpdatePermission() { return default; }
		
		// TODO
		public void SetDataFlag(DataStore.DataFlag flag_) { }
		
		// TODO
		public DataStore.DataFlag GetDataFlag() { return default; }
		
		// TODO
		public void SetPeriod(ushort period_) { }
		
		// TODO
		public ushort GetPeriod() { return default; }
		
		// TODO
		public void SetTags(List<string> tags_) { }
		
		// TODO
		public List<string> GetTags() { return default; }
		
		// TODO
		public void SetRatingSetting(Dictionary<sbyte, DataStoreRatingInitParam> ratingInitParam) { }
		
		// TODO
		public void ClearRatingSetting() { }
		
		// TODO
		public bool AddRatingSetting(sbyte slot, DataStoreRatingInitParam ratingInitParam) { return default; }
		
		// TODO
		public Dictionary<sbyte, DataStoreRatingInitParam> GetRatingSetting() { return default; }
		
		// TODO
		public void SetMetaBinary(List<byte> meta_) { }
		
		// TODO
		public List<byte> GetMetaBinary() { return default; }
		
		// TODO
		public void SetPersistenceInitParam(DataStorePersistenceInitParam persistenceInitParam_) { }
		
		// TODO
		public DataStorePersistenceInitParam GetPersistenceInitParam() { return default; }
		
		// TODO
		public void Reset() { }
		
		// TODO
		public void Trace() { }
		
		// TODO
		public override string ToString() { return default; }
	}
}