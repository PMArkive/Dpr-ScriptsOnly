using NexPlugin;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace NexAssets
{
	[Serializable]
	public class DataStoreChangeMetaCompareParam
	{
		[SerializeField]
		private DataStore.ComparisonFlag comparisonFlag;
		[SerializeField]
		private DataStore.DataStatus dataStatus;
		[SerializeField]
		private string name = "";
		[SerializeField]
		private List<string> tags = new List<string>();
		[SerializeField]
		[Range(0.0f, DataStore.MAX_PERIOD)]
		private ushort period = DataStore.DEFAULT_PERIOD;
		[SerializeField]
		[Range(0.0f, DataStore.INVALID_DATA_TYPE - 1.0f)]
		private ushort dataType;
		[SerializeField]
		private DataStore.Permission accessPermission = DataStore.Permission.PERMISSION_PRIVATE;
		[SerializeField]
		private DataStore.Permission updatePermission = DataStore.Permission.PERMISSION_PRIVATE;
		
		// TODO
		public void Validate() { }
		
		// TODO
		public DataStoreChangeMetaCompareParam GetDataStoreChangeMetaCompareParam() { return default; }
	}
}