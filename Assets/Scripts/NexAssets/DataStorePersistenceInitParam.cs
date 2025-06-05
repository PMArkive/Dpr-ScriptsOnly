using NexPlugin;
using System;
using UnityEngine;

namespace NexAssets
{
	[Serializable]
	public class DataStorePersistenceInitParam
	{
		[SerializeField]
		private bool isPersistence;
		[SerializeField]
		private bool deleteLastObject;
		[SerializeField]
		[Range(0.0f, DataStore.NUM_PERSISTENCE_SLOT - 1.0f)]
		private ushort persistenceSlotId = DataStore.INVALID_PERSISTENCE_SLOT_ID;
		
		// TODO
		public void Validate() { }
		
		// TODO
		public DataStorePersistenceInitParam GetDataStorePersistenceInitParam() { return default; }
	}
}