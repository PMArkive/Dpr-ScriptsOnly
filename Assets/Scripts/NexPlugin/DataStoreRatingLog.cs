namespace NexPlugin
{
	public class DataStoreRatingLog
	{
		internal NpDateTime lockExpirationTime;
		internal ulong pid;
		internal int ratingValue;
		internal bool isRated;
		
		public DataStoreRatingLog()
		{
			isRated = false;
		}
		
		// TODO
		public bool IsRated() { return default; }
		
		// TODO
		public ulong GetPrincipalId() { return default; }
		
		// TODO
		public int GetRatingValue() { return default; }
		
		// TODO
		public NpDateTime GetLockExpirationTime() { return default; }
		
		// TODO
		public void Trace() { }
		
		// TODO
		public override string ToString() { return default; }
	}
}