using NexPlugin;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace NexAssets
{
	[Serializable]
	public class DataStoreSearchParam
	{
		[SerializeField]
		private DataStore.SearchType searchTarget = DataStore.SearchType.SEARCH_TYPE_PUBLIC;
        [SerializeField]
        private DataStore.SearchTarget ownerType;
        [SerializeField]
        private List<ushort> dataTypes = new List<ushort>();
        [SerializeField]
        private DataStore.SearchSortColumn resultOrderColumn;
        [SerializeField]
        private DataStore.SearchSortOrder resultOrder;
        [SerializeField]
        private ResultRange resultRange = new ResultRange();
        [SerializeField]
        private DataStore.ResultFlag resultOption;
        [SerializeField]
        private List<string> tags = new List<string>();
        [SerializeField]
        private uint minimalRatingFrequency;
        [SerializeField]
        private bool totalCountEnabled;
        [SerializeField]
        private bool useCache;
		
		// TODO
		public void Validate() { }
		
		// TODO
		public DataStoreSearchParam GetDataStoreSearchParam(bool isSearchLight = false) { return default; }
	}
}