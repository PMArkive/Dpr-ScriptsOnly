using NexPlugin;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace NexAssets
{
	[Serializable]
	public class DataStoreChangeMetaParam
	{
		[SerializeField]
		private DataStore.ModificationFlag modificationFlag;
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
		[SerializeField]
		private bool isUsePersistenceSlotId = true;
		[SerializeField]
		[Range(0.0f, DataStore.NUM_PERSISTENCE_SLOT - 1.0f)]
		private ushort persistenceSlotId = DataStore.INVALID_PERSISTENCE_SLOT_ID;
		[SerializeField]
		private string dataId = "0";
		private ulong dataId_;
		[SerializeField]
		private DataStoreChangeMetaCompareParam dataStoreChangeMetaCompareParam = new DataStoreChangeMetaCompareParam();
		
		// TODO
		public void Validate() { }
		
		// TODO
		public DataStoreChangeMetaParam GetDataStoreChangeMetaParam() { return default; }
	}
}