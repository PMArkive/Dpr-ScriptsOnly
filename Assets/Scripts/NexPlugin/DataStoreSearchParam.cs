using System.Collections.Generic;

namespace NexPlugin
{
	public class DataStoreSearchParam
	{
		internal DataStore.SearchType searchTarget;
		internal List<ulong> ownerIds;
		internal DataStore.SearchTarget ownerType;
		internal List<ulong> destinationIds;
		internal List<ushort> dataTypes;
		internal NpDateTime createdAfter;
		internal NpDateTime createdBefore;
		internal NpDateTime updatedAfter;
		internal NpDateTime updatedBefore;
		internal DataStore.SearchSortColumn resultOrderColumn;
		internal DataStore.SearchSortOrder resultOrder;
		internal ResultRange resultRange;
		internal DataStore.ResultFlag resultOption;
		internal List<string> tags;
		internal uint minimalRatingFrequency;
		internal bool totalCountEnabled;
		internal bool useCache;
		
		public DataStoreSearchParam()
		{
			Reset();
		}
		
		// TODO
		public void SetSearchType(DataStore.SearchType searchType) { }
		
		// TODO
		public DataStore.SearchType GetSearchType() { return default; }
		
		// TODO
		public void SetOwnerIds(List<ulong> ownerIds_) { }
		
		// TODO
		public List<ulong> GetOwnerIds() { return default; }
		
		// TODO
		public void SetOwnerType(DataStore.SearchTarget ownerType_) { }
		
		// TODO
		public DataStore.SearchTarget GetOwnerType() { return default; }
		
		// TODO
		public void SetDestinationIds(List<ulong> destinationIds_) { }
		
		// TODO
		public List<ulong> GetDestinationIds() { return default; }
		
		// TODO
		public void SetDataType(ushort dataType_) { }
		
		// TODO
		public void SetDataType(List<ushort> dataTypes_) { }
		
		// TODO
		public ushort GetDataType() { return default; }
		
		// TODO
		public void GetDataType(ref List<ushort> dataTypes_) { }
		
		// TODO
		public void SetCreatedAfter(NpDateTime createdAfter_) { }
		
		// TODO
		public NpDateTime GetCreatedAfter() { return default; }
		
		// TODO
		public void SetCreatedBefore(NpDateTime createdBefore_) { }
		
		// TODO
		public NpDateTime GetCreatedBefore() { return default; }
		
		// TODO
		public void SetUpdatedAfter(NpDateTime updatedAfter_) { }
		
		// TODO
		public NpDateTime GetUpdatedAfter() { return default; }
		
		// TODO
		public void SetUpdatedBefore(NpDateTime updatedBefore_) { }
		
		// TODO
		public NpDateTime GetUpdatedBefore() { return default; }
		
		// TODO
		public void SetSearchSortOrderColumn(DataStore.SearchSortColumn resultOrderColumn_) { }
		
		// TODO
		public DataStore.SearchSortColumn GetSearchSortOrderColumn() { return default; }
		
		// TODO
		public void SetSearchSortOrder(DataStore.SearchSortOrder resultOrder_) { }
		
		// TODO
		public DataStore.SearchSortOrder GetSearchSortOrder() { return default; }
		
		// TODO
		public void SetResultRange(ResultRange resultRange_) { }
		
		// TODO
		public ResultRange GetResultRange() { return default; }
		
		// TODO
		public void SetResultOption(DataStore.ResultFlag resultOption_) { }
		
		// TODO
		public DataStore.ResultFlag GetResultOption() { return default; }
		
		// TODO
		public void SetTags(List<string> tags_) { }
		
		// TODO
		public List<string> GetTags() { return default; }
		
		// TODO
		public void SetMinimalRatingFrequency(uint minimalRatingFrequency_) { }
		
		// TODO
		public uint GetMinimalRatingFrequency() { return default; }
		
		// TODO
		public void SetUseCache(bool useCache_) { }
		
		// TODO
		public bool GetUseCache() { return default; }
		
		// TODO
		public void SetTotalCountEnabled(bool totalCountEnabled_) { }
		
		// TODO
		public bool GetTotalCountEnabled() { return default; }
		
		// TODO
		private void Reset() { }
		
		// TODO
		public void Trace() { }
		
		// TODO
		public override string ToString() { return default; }
	}
}