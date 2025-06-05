using nn;

namespace NexPlugin
{
	public class AsyncResult
	{
		public uint asyncId;
		public AsyncResultNum asyncNum;
		public Result nnResult;
		public uint netErrCode;
		public int returnCode;
		public uint errorCode;
		
		// TODO
		public bool IsSuccess() { return default; }
		
		// TODO
		public bool IsFailure() { return default; }
		
		// TODO
		public void Trace() { }
		
		// TODO
		public override string ToString() { return default; }
	}
}