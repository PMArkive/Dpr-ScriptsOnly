using System.Collections.Generic;

namespace NexPlugin
{
	public class DataStoreSearchResult
	{
		internal List<DataStoreMetaInfo> result;
		internal uint totalCount;
		internal DataStore.SearchResultTotalCountType totalCountType;
		
		public DataStoreSearchResult()
		{
			result = new List<DataStoreMetaInfo>();
		}
		
		// TODO
		public uint GetTotalCount() { return default; }
		
		// TODO
		public List<DataStoreMetaInfo> GetResult() { return default; }
		
		// TODO
		public DataStore.SearchResultTotalCountType GetTotalCountType() { return default; }
		
		// TODO
		public void Trace() { }
		
		// TODO
		public override string ToString() { return default; }
	}
}