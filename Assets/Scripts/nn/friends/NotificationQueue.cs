using nn.account;
using System;

namespace nn.friends
{
	public sealed class NotificationQueue : IDisposable
	{
		private IntPtr queue;
		
		// TODO
		public NotificationQueue() { }
		
		// TODO
		~NotificationQueue() { }
		
		// TODO
		public void Dispose() { }
		
		// TODO
		private void Dispose(bool disposing) { }
		
		// TODO
		public Result Initialize(Uid uid) { return default; }
		
		// TODO
		public Result Initialize() { return default; }
		
		// TODO
		public void Terminate() { }
		
		// TODO
		public Uid GetUid() { return default; }
		
		// TODO
		public Result Clear() { return default; }
		
		// TODO
		public Result Pop(ref NotificationInfo outInfo) { return default; }
		
		// TODO
		public bool Exists() { return default; }

		private static extern IntPtr Create();
		private static extern void Destroy(IntPtr pQueue);
		private static extern Result Initialize(IntPtr pQueue, Uid uid);
		private static extern Result Initialize(IntPtr pQueue);
		private static extern void Terminate(IntPtr pQueue);
		private static extern Uid GetUid(IntPtr pQueue);
		private static extern Result Clear(IntPtr pQueue);
		private static extern Result Pop(IntPtr pQueue, ref NotificationInfo outInfo);
		private static extern bool Exists(IntPtr pQueue);
	}
}