using System.Collections.Generic;

namespace NexPlugin
{
	public class DataStoreMetaInfo
	{
		internal ulong dataId;
		internal ulong ownerId;
		internal uint size;
		internal string name;
		internal ushort dataType;
		internal ushort period;
		internal DataStorePermission accessPermission;
		internal DataStorePermission updatePermission;
		internal NpDateTime createdTime;
		internal NpDateTime updatedTime;
		internal DataStore.DataStatus status;
		internal uint referDataId;
		internal DataStore.DataFlag flag;
		internal NpDateTime expireTime;
		internal List<string> tags;
		internal List<DataStoreRatingInfo> ratingInfo;
		internal List<byte> metaBinary;
		
		public DataStoreMetaInfo()
		{
			dataId = 0;
			accessPermission = new DataStorePermission();
			updatePermission = new DataStorePermission();
			tags = new List<string>();
			ratingInfo = new List<DataStoreRatingInfo>();
			metaBinary = new List<byte>();
		}
		
		// TODO
		public ulong GetDataId() { return default; }
		
		// TODO
		public ulong GetOwnerId() { return default; }
		
		// TODO
		public uint GetSize() { return default; }
		
		// TODO
		public string GetName() { return default; }
		
		// TODO
		public ushort GetDataType() { return default; }
		
		// TODO
		public DataStorePermission GetAccessPermission() { return default; }
		
		// TODO
		public DataStorePermission GetUpdatePermission() { return default; }
		
		// TODO
		public NpDateTime GetCreatedTime() { return default; }
		
		// TODO
		public NpDateTime GetUpdatedTime() { return default; }
		
		// TODO
		public ushort GetPeriod() { return default; }
		
		// TODO
		public DataStore.DataStatus GetDataStatus() { return default; }
		
		// TODO
		public uint GetReferDataId() { return default; }
		
		// TODO
		public DataStore.DataFlag GetDataFlag() { return default; }
		
		// TODO
		public NpDateTime GetExpireTime() { return default; }
		
		// TODO
		public List<string> GetTags() { return default; }
		
		// TODO
		public List<DataStoreRatingInfo> GetRating() { return default; }
		
		// TODO
		public List<byte> GetMetaBinary() { return default; }
		
		// TODO
		public bool IsValid() { return default; }
		
		// TODO
		public void Trace() { }
		
		// TODO
		public override string ToString() { return default; }
	}
}