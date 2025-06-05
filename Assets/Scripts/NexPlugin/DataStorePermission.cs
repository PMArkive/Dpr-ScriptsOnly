using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace NexPlugin
{
	public class DataStorePermission
	{
		internal DataStore.Permission permission;
		internal List<ulong> recipientIds;
		
		public DataStorePermission()
		{
			Reset();
		}
		
		public DataStorePermission(DataStore.Permission permission, [Optional] List<ulong> recipientIds)
		{
			this.permission = permission;
			this.recipientIds = recipientIds ?? new List<ulong>();
		}
		
		// TODO
		public void SetPermission(DataStore.Permission permission_) { }
		
		// TODO
		public DataStore.Permission GetPermission() { return default; }
		
		// TODO
		public void SetRecipientIds(List<ulong> recipientIds_) { }
		
		// TODO
		public List<ulong> GetRecipientIds() { return default; }
		
		// TODO
		private void Reset() { }
		
		// TODO
		public void Trace() { }
		
		// TODO
		public override string ToString() { return default; }
	}
}