using System.Collections.Generic;

namespace NexPlugin
{
	public class DataStoreChangeMetaCompareParam
	{
		internal DataStore.ComparisonFlag comparisonFlag;
		internal string name;
		internal DataStorePermission accessPermission;
		internal DataStorePermission updatePermission;
		internal ushort dataType;
		internal ushort period;
		internal List<string> tags;
		internal List<byte> metaBinary;
		internal DataStore.DataStatus status;
		
		public DataStoreChangeMetaCompareParam()
		{
			Reset();
		}
		
		public DataStoreChangeMetaCompareParam(DataStore.ComparisonFlag comparisonFlag, DataStoreMetaInfo metaInfo)
		{
			Set(comparisonFlag, metaInfo);
		}
		
		// TODO
		public void Set(DataStore.ComparisonFlag comparisonFlag_, DataStoreMetaInfo metaInfo_) { }
		
		// TODO
		public void SetComparisonFlag(DataStore.ComparisonFlag comparisonFlag_) { }
		
		// TODO
		public DataStore.ComparisonFlag GetComparisonFlag() { return default; }
		
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
		public void SetDataType(ushort dataType_) { }
		
		// TODO
		public ushort GetDataType() { return default; }
		
		// TODO
		public void SetDataStatus(DataStore.DataStatus status_) { }
		
		// TODO
		public DataStore.DataStatus GetDataStatus() { return default; }
		
		// TODO
		private void Reset() { }
		
		// TODO
		public void Trace() { }
		
		// TODO
		public override string ToString() { return default; }
	}
}