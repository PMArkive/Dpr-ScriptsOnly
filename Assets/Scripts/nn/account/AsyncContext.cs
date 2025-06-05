using System;

namespace nn.account
{
	public sealed class AsyncContext : IDisposable
	{
		internal IntPtr _context = IntPtr.Zero;
		
		// TODO
		public AsyncContext() { }
		
		// TODO
		~AsyncContext() { }
		
		// TODO
		public void Dispose() { }
		
		// TODO
		private void Dispose(bool disposing) { }
		
		// TODO
		public Result Cancel() { return default; }
		
		// TODO
		public Result HasDone(ref bool pOut) { return default; }
		
		// TODO
		public Result GetResult() { return default; }

		private static extern IntPtr Create();
		private static extern void Destroy(IntPtr context);
		private static extern Result Cancel(IntPtr context);
		private static extern Result HasDone(IntPtr context, ref bool pOut);
		private static extern Result GetResult(IntPtr context);
	}
}