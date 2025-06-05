namespace NexPlugin
{
	public class DataStorePersistenceInitParam
	{
		internal ushort persistenceSlotId;
		internal bool deleteLastObject;
		
		public DataStorePersistenceInitParam(ushort persistenceSlotId = DataStore.INVALID_PERSISTENCE_SLOT_ID, bool deleteLastObject = true)
		{
			this.persistenceSlotId = persistenceSlotId;
			this.deleteLastObject = deleteLastObject;
		}
		
		// TODO
		public void SetPersistenceSlotId(ushort persistenceSlotId_) { }
		
		// TODO
		public ushort GetPersistenceSlotId() { return default; }
		
		// TODO
		public void SetDeleteLastObject(bool deleteLastObject_) { }
		
		// TODO
		public bool GetDeleteLastObject() { return default; }
		
		// TODO
		public void Reset() { }
		
		// TODO
		public void Trace() { }
		
		// TODO
		public override string ToString() { return default; }
	}
}