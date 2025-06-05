namespace NexPlugin
{
	public class DataStorePersistenceInfo
	{
		internal ulong dataId;
		internal ulong principalId;
		internal ushort persistenceSlotId;
		
		public DataStorePersistenceInfo()
		{
			dataId = 0;
		}
		
		// TODO
		public ulong GetPrincipalId() { return default; }
		
		// TODO
		public ushort GetPersistenceSlotId() { return default; }
		
		// TODO
		public ulong GetDataId() { return default; }
		
		// TODO
		public bool IsValid() { return default; }
		
		// TODO
		public void Trace() { }
		
		// TODO
		public override string ToString() { return default; }
	}
}