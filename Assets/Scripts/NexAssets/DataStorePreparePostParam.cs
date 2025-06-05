using NexPlugin;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace NexAssets
{
	[Serializable]
	public class DataStorePreparePostParam
	{
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
		private DataStore.DataFlag dataFlag;
		[SerializeField]
		private DataStore.Permission accessPermission = DataStore.Permission.PERMISSION_PRIVATE;
		[SerializeField]
		private DataStore.Permission updatePermission = DataStore.Permission.PERMISSION_PRIVATE;
		[SerializeField]
		private DataStorePersistenceInitParam persistenceInitParam = new DataStorePersistenceInitParam();
		[SerializeField]
		private List<DataStoreRatingInitParam> dataStoreRatingInitParamList = new List<DataStoreRatingInitParam>();
		
		// TODO
		public void Validate() { }
		
		// TODO
		public DataStorePreparePostParam GetDataStorePreparePostParam() { return default; }
	}
}